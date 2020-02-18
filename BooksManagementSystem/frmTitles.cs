using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
//TO DO - Saving record for ISBNtitleAuthor - the Example 6-9 saves title in form closing and Title_Author in Save btn click event
//do both in the click event
//also, take care of the search button - the author is not placed in combo box if searching for title - just call GetAuthor method
//also, we don't need AuthorManager object - we are not browsing between authors on this form
namespace BooksManagementSystem
{
    public partial class frmTitles : Form
    {
        public frmTitles()
        {
            InitializeComponent();
        }

        NpgsqlConnection booksConn;
        NpgsqlCommand titlesComm;
        NpgsqlDataAdapter titlesAdapter;
        DataTable titlesTable;
        CurrencyManager titlesManager;
        public string AppState { get; set; }
        NpgsqlCommandBuilder builderComm;
        public int CurrentPosition { get; set; }
        NpgsqlCommand authorsComm;
        NpgsqlDataAdapter authorsAdapter;
        DataTable [] authorsTable = new DataTable[4];
        ComboBox[] authorCombo = new ComboBox[4];
        NpgsqlCommand ISBNAuthorsComm;
        NpgsqlDataAdapter ISBNAuthorsAdapter;
        DataTable ISBNAuthorsTable;
        NpgsqlCommand publisherComm;
        NpgsqlDataAdapter publisherAdaptor;
        DataTable publisherTable;

        private void frmTitles_Load(object sender, EventArgs e)
        {
            try
            {
                var connString = "Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=admin;";
                booksConn = new NpgsqlConnection(connString);
                booksConn.Open();
                titlesComm = new NpgsqlCommand("SELECT * FROM titles ORDER BY title", booksConn);
                titlesAdapter = new NpgsqlDataAdapter();
                titlesAdapter.SelectCommand = titlesComm;
                titlesTable = new DataTable();
                titlesAdapter.Fill(titlesTable);
                txtTitle.DataBindings.Add("Text", titlesTable, "title");
                txtYearPublished.DataBindings.Add("Text", titlesTable, "year_published");
                txtISBN.DataBindings.Add("Text", titlesTable, "isbn");
                txtDescription.DataBindings.Add("Text", titlesTable, "description");
                txtNotes.DataBindings.Add("Text", titlesTable, "notes");
                txtSubject.DataBindings.Add("Text", titlesTable, "subject");
                txtComments.DataBindings.Add("Text", titlesTable, "comments");
                titlesManager = (CurrencyManager)BindingContext[titlesTable];

                authorCombo[0] = cboAuthor1;
                authorCombo[1] = cboAuthor2;
                authorCombo[2] = cboAuthor3;
                authorCombo[3] = cboAuthor4;
                authorsComm = new NpgsqlCommand("SELECT * FROM authors ORDER BY author", booksConn);
                authorsAdapter = new NpgsqlDataAdapter();
                authorsAdapter.SelectCommand = authorsComm;

                for (int i =0; i < 4; i++)
                {
                    authorsTable[i] = new DataTable();
                    authorsAdapter.Fill(authorsTable[i]);
                    authorCombo[i].DisplayMember = "author";
                    authorCombo[i].ValueMember = "au_id";
                    authorCombo[i].DataSource = authorsTable[i];
                    authorCombo[i].SelectedIndex = -1;
                }

                publisherComm = new NpgsqlCommand("Select * from publishers Order By name", booksConn);
                publisherAdaptor = new NpgsqlDataAdapter();
                publisherTable = new DataTable();
                publisherAdaptor.SelectCommand = publisherComm;
                publisherAdaptor.Fill(publisherTable);

                cboPublisher.DataSource = publisherTable;
                cboPublisher.DisplayMember = "name";
                cboPublisher.ValueMember = "pubid";
                cboPublisher.DataBindings.Add("SelectedValue", titlesTable, "pubid");

                SetAppState("View");
                GetAuthors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            booksConn.Close();
            booksConn.Dispose();
            titlesComm.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            titlesManager.Position = 0;
            GetAuthors();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            titlesManager.Position = titlesManager.Count - 1;
            GetAuthors();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            titlesManager.Position--;
            GetAuthors();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            titlesManager.Position++;
            GetAuthors();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("") || txtSearch.Text.Length < 3)
            {
                MessageBox.Show("Invalid Search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow[] foundRecords;
            titlesTable.DefaultView.Sort = "title";
            foundRecords = titlesTable.Select("Title LIKE '*" + txtSearch.Text + "*'");

            if (foundRecords.Length == 0)
            {
                MessageBox.Show("No record found", "No record found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmSearch searchForm = new frmSearch(foundRecords, "titles");
                searchForm.ShowDialog();
                var index = searchForm.Index;
                titlesManager.Position = titlesTable.DefaultView.Find(foundRecords[index]["title"]);
                GetAuthors();
            }
        }

        private void SetAppState(string appState)
        {
            switch (appState)
            {
                case "View":
                    txtTitle.ReadOnly = true;
                    txtYearPublished.ReadOnly = true;
                    txtISBN.ReadOnly = true;
                    txtDescription.ReadOnly = true;
                    txtNotes.ReadOnly = true;
                    txtSubject.ReadOnly = true;
                    txtComments.ReadOnly = true;
                    btnFirst.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    btnAddNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDone.Enabled = true;
                    btnFind.Enabled = true;
                    btnAuthors.Enabled = true;
                    btnPublishers.Enabled = true;
                    cboAuthor1.Enabled = false;
                    cboAuthor2.Enabled = false;
                    cboAuthor3.Enabled = false;
                    cboAuthor4.Enabled = false;
                    btnXAuthor1.Enabled = false;
                    btnXAuthor2.Enabled = false;
                    btnXAuthor3.Enabled = false;
                    btnXAuthor4.Enabled = false;
                    cboPublisher.Enabled = false;
                    break;
                default:
                    txtTitle.ReadOnly = false;
                    txtYearPublished.ReadOnly = false;
                    if (appState == "Add")
                    {
                        txtISBN.ReadOnly = false;
                    } else
                    {
                        txtISBN.ReadOnly = true;
                    }
                    
                    txtDescription.ReadOnly = false;
                    txtNotes.ReadOnly = false;
                    txtSubject.ReadOnly = false;
                    txtComments.ReadOnly = false;
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnAddNew.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDone.Enabled = false;
                    btnFind.Enabled = false;
                    btnAuthors.Enabled = false;
                    btnPublishers.Enabled = false;
                    cboAuthor1.Enabled = true;
                    cboAuthor2.Enabled = true;
                    cboAuthor3.Enabled = true;
                    cboAuthor4.Enabled = true;
                    btnXAuthor1.Enabled = true;
                    btnXAuthor2.Enabled = true;
                    btnXAuthor3.Enabled = true;
                    btnXAuthor4.Enabled = true;
                    cboPublisher.Enabled = true;
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtYearPublished.DataBindings.Clear();
            SetAppState("Edit");
            AppState = "Edit";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            cboAuthor1.SelectedIndex = -1;
            cboAuthor2.SelectedIndex = -1;
            cboAuthor3.SelectedIndex = -1;
            cboAuthor4.SelectedIndex = -1;
            CurrentPosition = titlesManager.Position;
            SetAppState("Add");
            titlesManager.AddNew();
            AppState = "Add";
        }

        private bool ValidateIntput()
        {
            string message = "";
            bool isOK = true;

            if (txtTitle.Text.Equals(""))
            {
                message = "You must enter a title.\r\n";
                isOK = false;
            }

            int inputYear, currentYear;
            if (!txtYearPublished.Text.Trim().Equals(""))
            {
                inputYear = Convert.ToInt32(txtYearPublished.Text);
                currentYear = DateTime.Now.Year;
                if (inputYear > currentYear)
                {
                    message += "Year published cannot be greater than current year \r\n";
                    isOK = false;
                }
            }

            if (!(txtISBN.Text.Length == 13))
            {
                message += "Incomplete ISBN\r\n";
                isOK = false;
            }

            //TO DO validate publisher

            if (!isOK)
            {
                MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isOK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateIntput())
            {
                return;
            }

            try
            {
                var savedRecord = txtISBN.Text;
                titlesManager.EndCurrentEdit();
                builderComm = new NpgsqlCommandBuilder(titlesAdapter);  
                
                if (AppState == "Edit")
                {
                    var titleRow = titlesTable.Select("isbn = '" + savedRecord + "'");

                    if (String.IsNullOrEmpty(txtYearPublished.Text))
                        titleRow[0]["year_published"] = DBNull.Value;
                    else
                        titleRow[0]["year_published"] = txtYearPublished.Text;

                    titlesAdapter.Update(titlesTable);
                    txtYearPublished.DataBindings.Add("Text", titlesTable, "year_published");
                }
                else
                {                    
                    titlesAdapter.Update(titlesTable);
                    DataRow[] foundRecords;
                    titlesTable.DefaultView.Sort = "title";
                    foundRecords = titlesTable.Select("isbn = '" + savedRecord + "'");
                    titlesManager.Position = titlesTable.DefaultView.Find(foundRecords[0]["title"]);
                }

                builderComm = new NpgsqlCommandBuilder(ISBNAuthorsAdapter);
                if (ISBNAuthorsTable.Rows.Count != 0)
                {
                    for (int i = 0; i < ISBNAuthorsTable.Rows.Count; i++)
                    {
                        ISBNAuthorsTable.Rows[i].Delete();
                    }

                    ISBNAuthorsAdapter.Update(ISBNAuthorsTable);
                }

                for(int i = 0; i < 4; i++)
                {
                    if (authorCombo[i].SelectedIndex != -1)
                    {
                        ISBNAuthorsTable.Rows.Add();
                        ISBNAuthorsTable.Rows[ISBNAuthorsTable.Rows.Count - 1]["isbn"] = txtISBN.Text;
                        ISBNAuthorsTable.Rows[ISBNAuthorsTable.Rows.Count - 1]["au_id"] = authorCombo[i].SelectedValue;
                    }
                }

                ISBNAuthorsAdapter.Update(ISBNAuthorsTable);

                MessageBox.Show("Record Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetAppState("View");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult response;
            response = MessageBox.Show("Are you sure you want to delete this record?", "Delete record",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (response == DialogResult.No)
                return;

            try
            {
                titlesManager.RemoveAt(titlesManager.Position);
                builderComm = new NpgsqlCommandBuilder(titlesAdapter);
                titlesAdapter.Update(titlesTable);
                AppState = "Delete";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Deleting record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            titlesManager.CancelCurrentEdit();

            if (AppState == "Edit")
                txtYearPublished.DataBindings.Add("Text", titlesTable, "year_published");

            if (AppState == "Add")
                titlesManager.Position = CurrentPosition;

            SetAppState("View");
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >='0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void GetAuthors()
        {
            for (int i = 0; i < 4; i++)
            {
                authorCombo[i].SelectedIndex = -1;
            }

            ISBNAuthorsComm = new NpgsqlCommand("Select * FROM title_author WHERE isbn = '" + txtISBN.Text + "'", booksConn);
            ISBNAuthorsAdapter = new NpgsqlDataAdapter();
            ISBNAuthorsAdapter.SelectCommand = ISBNAuthorsComm;
            ISBNAuthorsTable = new DataTable();
            ISBNAuthorsAdapter.Fill(ISBNAuthorsTable);

            if (ISBNAuthorsTable.Rows.Count == 0)
                return;

            for (int i = 0; i < ISBNAuthorsTable.Rows.Count; i++)
            {
                authorCombo[i].SelectedValue = ISBNAuthorsTable.Rows[i]["au_id"].ToString();
            }
        }

        private void btnXAuthor_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button) sender;
            switch (btnClicked.Name)
            {
                case "btnXAuthor1":
                    cboAuthor1.SelectedIndex = -1;
                    break;
                case "btnXAuthor2":
                    cboAuthor2.SelectedIndex = -1;
                    break;
                case "btnXAuthor3":
                    cboAuthor3.SelectedIndex = -1;
                    break;
                case "btnXAuthor4":
                    cboAuthor4.SelectedIndex = -1;
                    break;
            }
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            frmAuthors authorForm = new frmAuthors();
            authorForm.ShowDialog();
            authorForm.Dispose();
            booksConn.Close();

            var connString = "Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=admin;";
            booksConn = new NpgsqlConnection(connString);
            booksConn.Open();
            authorsAdapter.SelectCommand = authorsComm;

            for (int i = 0; i < 4; i++)
            {
                authorsTable[i] = new DataTable();
                authorsAdapter.Fill(authorsTable[i]);
                authorCombo[i].DataSource = authorsTable[i];
            }

            GetAuthors();
        }

        private void btnPublishers_Click(object sender, EventArgs e)
        {
            frmPublishers pubForm = new frmPublishers();
            pubForm.ShowDialog();
            pubForm.Dispose();
            var connString = "Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=admin;";
            booksConn = new NpgsqlConnection(connString);
            booksConn.Open();
            cboPublisher.DataBindings.Clear();
            publisherAdaptor.SelectCommand = publisherComm;
            publisherTable = new DataTable();
            publisherAdaptor.Fill(publisherTable);
            cboPublisher.DataSource = publisherTable;
            cboPublisher.DisplayMember = "name";
            cboPublisher.ValueMember = "pubid";
            cboPublisher.DataBindings.Add("SelectedValue", titlesTable, "pubid");
        }
    }
}
