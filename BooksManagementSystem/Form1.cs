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

namespace BooksManagementSystem
{
    public partial class frmAuthors : Form
    {
        public frmAuthors()
        {
            InitializeComponent();
        }

        NpgsqlConnection booksConn;
        NpgsqlCommand authorsComm;
        NpgsqlDataAdapter authorsAdapter;
        DataTable authorsTable;
        CurrencyManager authorsManager;
        NpgsqlCommandBuilder builderComm;
        bool dbError = false;
        public string AppState { get; set; }
        public int CurrentPosition { get; set; }

        private void frmAuthors_Load(object sender, EventArgs e)
        {
            try
            {
                var connString = "Server=127.0.0.1;Port=5432;Database=library;User Id=postgres;Password=admin;";
                booksConn = new NpgsqlConnection(connString);
                booksConn.Open();
                authorsComm = new NpgsqlCommand("SELECT * from Authors Order By Author", booksConn);
                authorsAdapter = new NpgsqlDataAdapter();
                authorsTable = new DataTable();
                authorsAdapter.SelectCommand = authorsComm;
                authorsAdapter.Fill(authorsTable);
                txtAuthorID.DataBindings.Add("Text", authorsTable, "id");
                txtAuthorName.DataBindings.Add("Text", authorsTable, "author");
                txtAuthorBorn.DataBindings.Add("Text", authorsTable, "year_born");
                authorsManager = (CurrencyManager)BindingContext[authorsTable];
                SetAppState("View");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbError = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            authorsManager.Position--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            authorsManager.Position++;
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {   
            if (!dbError)
            {
                booksConn.Close();
                booksConn.Dispose();
                authorsComm.Dispose();
                authorsAdapter.Dispose();
                authorsTable.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                var savedRecord = txtAuthorName.Text;
                authorsManager.EndCurrentEdit();
                builderComm = new NpgsqlCommandBuilder(authorsAdapter);  

                if (AppState == "Edit")
                {
                    var authRow = authorsTable.Select("id = " + txtAuthorID.Text);

                    if (String.IsNullOrEmpty(txtAuthorBorn.Text))
                        authRow[0]["year_born"] = DBNull.Value;
                    else
                        authRow[0]["year_born"] = txtAuthorBorn.Text;

                    authorsAdapter.Update(authorsTable);
                    txtAuthorBorn.DataBindings.Add("Text", authorsTable, "year_born");
                }
                else
                {                    
                    authorsTable.DefaultView.Sort = "author";                    
                    authorsManager.Position = authorsTable.DefaultView.Find(savedRecord);
                    authorsAdapter.Update(authorsTable);
                }
                
                MessageBox.Show("Record saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetAppState("View");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult response;
            response = MessageBox.Show("Are you sure you want to delete this record", "Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (response == DialogResult.No)
            {
                return;
            }

            try
            {
                authorsManager.RemoveAt(authorsManager.Position);
                builderComm = new NpgsqlCommandBuilder(authorsAdapter);
                authorsAdapter.Update(authorsTable);
                AppState = "Delete";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deleting record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void SetAppState(string appState)
        {
            switch (appState)
            {
                case "View":                    
                    txtAuthorName.ReadOnly = true;
                    txtAuthorBorn.ReadOnly = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    btnAddNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDone.Enabled = true;
                    txtAuthorName.TabStop = false;
                    txtAuthorBorn.TabStop = false;
                    btnFirst.Enabled = true;
                    btnLast.Enabled = true;
                    btnSearch.Enabled = true;
                    txtSearch.Enabled = true;
                    break;
                default: //add and edit states
                    txtAuthorName.ReadOnly = false;
                    txtAuthorBorn.ReadOnly = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnAddNew.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDone.Enabled = false;
                    btnFirst.Enabled = false;
                    btnLast.Enabled = false;
                    btnSearch.Enabled = false;
                    txtSearch.Enabled = false;
                    txtAuthorName.Focus();
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtAuthorBorn.DataBindings.Clear();
            SetAppState("Edit");
            AppState = "Edit";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentPosition = authorsManager.Position;
                authorsManager.AddNew();
                SetAppState("Add");
                AppState = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            authorsManager.CancelCurrentEdit();

            if (AppState == "Edit")
                txtAuthorBorn.DataBindings.Add("Text", authorsTable, "year_born");

            if (AppState == "Add")
                authorsManager.Position = CurrentPosition;

            SetAppState("View");
        }

        private void txtAuthorBorn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
                lblWrongInput.Visible = false;
            }
            else
            {
                e.Handled = true;
                lblWrongInput.Visible = true;
            }
        }

        private bool ValidateInput()
        {
            string message = "";
            int inputYear, currentYear;
            bool allOK = true;

            if (txtAuthorName.Text.Trim().Equals(""))
            {
                message = "Author's name is required" + "r\n";
                txtAuthorName.Focus();
                allOK = false;
            }

            if (!txtAuthorBorn.Text.Trim().Equals(""))
            {
                inputYear = Convert.ToInt32(txtAuthorBorn.Text);
                currentYear = DateTime.Now.Year;
                if (inputYear >= currentYear)
                {
                    message += "Invalid Year";
                    txtAuthorBorn.Focus();
                    allOK = false;
                }
            }

            if (!allOK)
            {
                MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            return allOK;
        }

        private void txtAuthorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAuthorBorn.Focus();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            authorsManager.Position = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            authorsManager.Position = authorsManager.Count - 1;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("") || txtSearch.Text.Length < 3)
            {
                MessageBox.Show("Invalid Search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataRow[] foundRecords;
            authorsTable.DefaultView.Sort = "author";
            foundRecords = authorsTable.Select("Author LIKE '*" + txtSearch.Text + "*'");

            if (foundRecords.Length == 0)
            {
                MessageBox.Show("Nothing Found", "Nothing Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmSearch searchForm = new frmSearch(foundRecords, "authors");
                searchForm.ShowDialog();
                var index = searchForm.Index;
                authorsManager.Position = authorsTable.DefaultView.Find(foundRecords[index]["author"]);
            }
        }
    }
}
