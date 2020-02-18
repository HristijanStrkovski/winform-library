namespace BooksManagementSystem
{
    partial class frmTitles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtYearPublished = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnPublishers = new System.Windows.Forms.Button();
            this.cboAuthor1 = new System.Windows.Forms.ComboBox();
            this.cboAuthor2 = new System.Windows.Forms.ComboBox();
            this.cboAuthor3 = new System.Windows.Forms.ComboBox();
            this.cboAuthor4 = new System.Windows.Forms.ComboBox();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnXAuthor4 = new System.Windows.Forms.Button();
            this.btnXAuthor2 = new System.Windows.Forms.Button();
            this.btnXAuthor1 = new System.Windows.Forms.Button();
            this.btnXAuthor3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(124, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(476, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtYearPublished
            // 
            this.txtYearPublished.Location = new System.Drawing.Point(124, 59);
            this.txtYearPublished.Name = "txtYearPublished";
            this.txtYearPublished.Size = new System.Drawing.Size(141, 20);
            this.txtYearPublished.TabIndex = 1;
            this.txtYearPublished.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 213);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(476, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(124, 251);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(476, 20);
            this.txtNotes.TabIndex = 3;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(124, 299);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(476, 20);
            this.txtSubject.TabIndex = 4;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(124, 341);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(476, 20);
            this.txtComments.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 435);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 6;
            // 
            // txtISBN
            // 
            this.txtISBN.BackColor = System.Drawing.Color.Red;
            this.txtISBN.Location = new System.Drawing.Point(414, 58);
            this.txtISBN.Mask = "A-AAAAAAA-A-A";
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(186, 20);
            this.txtISBN.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search Titles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Year Published";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Notes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Subject";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Comments";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(24, 467);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(243, 377);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 17;
            this.btnFirst.Text = "|<First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(334, 377);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 18;
            this.btnPrevious.Text = "<Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(430, 377);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(525, 377);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 20;
            this.btnLast.Text = "Last>|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(334, 409);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(430, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(525, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(334, 440);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 24;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(430, 440);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(525, 440);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 26;
            this.btnDone.Text = "D&one";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.Location = new System.Drawing.Point(124, 467);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(75, 23);
            this.btnAuthors.TabIndex = 27;
            this.btnAuthors.Text = "A&uthors";
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnPublishers
            // 
            this.btnPublishers.Location = new System.Drawing.Point(216, 467);
            this.btnPublishers.Name = "btnPublishers";
            this.btnPublishers.Size = new System.Drawing.Size(75, 23);
            this.btnPublishers.TabIndex = 28;
            this.btnPublishers.Text = "&Publishers";
            this.btnPublishers.UseVisualStyleBackColor = true;
            this.btnPublishers.Click += new System.EventHandler(this.btnPublishers_Click);
            // 
            // cboAuthor1
            // 
            this.cboAuthor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuthor1.FormattingEnabled = true;
            this.cboAuthor1.Location = new System.Drawing.Point(124, 95);
            this.cboAuthor1.Name = "cboAuthor1";
            this.cboAuthor1.Size = new System.Drawing.Size(141, 21);
            this.cboAuthor1.TabIndex = 29;
            // 
            // cboAuthor2
            // 
            this.cboAuthor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuthor2.FormattingEnabled = true;
            this.cboAuthor2.Location = new System.Drawing.Point(414, 95);
            this.cboAuthor2.Name = "cboAuthor2";
            this.cboAuthor2.Size = new System.Drawing.Size(150, 21);
            this.cboAuthor2.TabIndex = 30;
            // 
            // cboAuthor3
            // 
            this.cboAuthor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuthor3.FormattingEnabled = true;
            this.cboAuthor3.Location = new System.Drawing.Point(124, 134);
            this.cboAuthor3.Name = "cboAuthor3";
            this.cboAuthor3.Size = new System.Drawing.Size(141, 21);
            this.cboAuthor3.TabIndex = 31;
            // 
            // cboAuthor4
            // 
            this.cboAuthor4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuthor4.FormattingEnabled = true;
            this.cboAuthor4.Location = new System.Drawing.Point(414, 134);
            this.cboAuthor4.Name = "cboAuthor4";
            this.cboAuthor4.Size = new System.Drawing.Size(150, 21);
            this.cboAuthor4.TabIndex = 32;
            // 
            // cboPublisher
            // 
            this.cboPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.Location = new System.Drawing.Point(124, 173);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(476, 21);
            this.cboPublisher.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Author 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(358, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Author 4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Author 1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Author 3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(62, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Publisher";
            // 
            // btnXAuthor4
            // 
            this.btnXAuthor4.Location = new System.Drawing.Point(570, 132);
            this.btnXAuthor4.Name = "btnXAuthor4";
            this.btnXAuthor4.Size = new System.Drawing.Size(30, 23);
            this.btnXAuthor4.TabIndex = 39;
            this.btnXAuthor4.Text = "X";
            this.btnXAuthor4.UseVisualStyleBackColor = true;
            this.btnXAuthor4.Click += new System.EventHandler(this.btnXAuthor_Click);
            // 
            // btnXAuthor2
            // 
            this.btnXAuthor2.Location = new System.Drawing.Point(570, 93);
            this.btnXAuthor2.Name = "btnXAuthor2";
            this.btnXAuthor2.Size = new System.Drawing.Size(30, 23);
            this.btnXAuthor2.TabIndex = 40;
            this.btnXAuthor2.Text = "X";
            this.btnXAuthor2.UseVisualStyleBackColor = true;
            this.btnXAuthor2.Click += new System.EventHandler(this.btnXAuthor_Click);
            // 
            // btnXAuthor1
            // 
            this.btnXAuthor1.Location = new System.Drawing.Point(271, 95);
            this.btnXAuthor1.Name = "btnXAuthor1";
            this.btnXAuthor1.Size = new System.Drawing.Size(30, 23);
            this.btnXAuthor1.TabIndex = 41;
            this.btnXAuthor1.Text = "X";
            this.btnXAuthor1.UseVisualStyleBackColor = true;
            this.btnXAuthor1.Click += new System.EventHandler(this.btnXAuthor_Click);
            // 
            // btnXAuthor3
            // 
            this.btnXAuthor3.Location = new System.Drawing.Point(271, 132);
            this.btnXAuthor3.Name = "btnXAuthor3";
            this.btnXAuthor3.Size = new System.Drawing.Size(30, 23);
            this.btnXAuthor3.TabIndex = 42;
            this.btnXAuthor3.Text = "X";
            this.btnXAuthor3.UseVisualStyleBackColor = true;
            this.btnXAuthor3.Click += new System.EventHandler(this.btnXAuthor_Click);
            // 
            // frmTitles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 534);
            this.Controls.Add(this.btnXAuthor3);
            this.Controls.Add(this.btnXAuthor1);
            this.Controls.Add(this.btnXAuthor2);
            this.Controls.Add(this.btnXAuthor4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboPublisher);
            this.Controls.Add(this.cboAuthor4);
            this.Controls.Add(this.cboAuthor3);
            this.Controls.Add(this.cboAuthor2);
            this.Controls.Add(this.cboAuthor1);
            this.Controls.Add(this.btnPublishers);
            this.Controls.Add(this.btnAuthors);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtYearPublished);
            this.Controls.Add(this.txtTitle);
            this.Name = "frmTitles";
            this.Text = "Titles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClosing);
            this.Load += new System.EventHandler(this.frmTitles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtYearPublished;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.MaskedTextBox txtISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnPublishers;
        private System.Windows.Forms.ComboBox cboAuthor1;
        private System.Windows.Forms.ComboBox cboAuthor2;
        private System.Windows.Forms.ComboBox cboAuthor3;
        private System.Windows.Forms.ComboBox cboAuthor4;
        private System.Windows.Forms.ComboBox cboPublisher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnXAuthor4;
        private System.Windows.Forms.Button btnXAuthor2;
        private System.Windows.Forms.Button btnXAuthor1;
        private System.Windows.Forms.Button btnXAuthor3;
    }
}