namespace RadStaffWinForm.Views
{
    partial class EditForm
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
            editTitleComboBox = new ComboBox();
            editTitleLabel = new Label();
            editFirstNameLabel = new Label();
            editFirstNameTextBox = new TextBox();
            editMiddleInitialTextBox = new TextBox();
            editMiddleInitialLabel = new Label();
            editLastNameLabel = new Label();
            editLastNameTextBox = new TextBox();
            editHomeLabel = new Label();
            editIRDTextBox = new TextBox();
            editMobileLabel = new Label();
            editMobileTextBox = new TextBox();
            editOfficeLabel = new Label();
            editHomeTextBox = new TextBox();
            editIRDLabel = new Label();
            editOfficeTextBox = new TextBox();
            editTypeLabel = new Label();
            editTypeComboBox = new ComboBox();
            editManagerLabel = new Label();
            editManagerComboBox = new ComboBox();
            editSaveButton = new Button();
            cancelEditButton = new Button();
            editStatusComboBox = new ComboBox();
            editStatusLabel = new Label();
            SuspendLayout();
            // 
            // editTitleComboBox
            // 
            editTitleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            editTitleComboBox.FormattingEnabled = true;
            editTitleComboBox.Items.AddRange(new object[] { "Mr", "Mrs", "Miss", "Sir" });
            editTitleComboBox.Location = new Point(12, 27);
            editTitleComboBox.Name = "editTitleComboBox";
            editTitleComboBox.Size = new Size(163, 23);
            editTitleComboBox.TabIndex = 0;
            // 
            // editTitleLabel
            // 
            editTitleLabel.AutoSize = true;
            editTitleLabel.Location = new Point(12, 9);
            editTitleLabel.Name = "editTitleLabel";
            editTitleLabel.Size = new Size(32, 15);
            editTitleLabel.TabIndex = 1;
            editTitleLabel.Text = "Title:";
            // 
            // editFirstNameLabel
            // 
            editFirstNameLabel.AutoSize = true;
            editFirstNameLabel.Location = new Point(12, 64);
            editFirstNameLabel.Name = "editFirstNameLabel";
            editFirstNameLabel.Size = new Size(67, 15);
            editFirstNameLabel.TabIndex = 3;
            editFirstNameLabel.Text = "First Name:";
            // 
            // editFirstNameTextBox
            // 
            editFirstNameTextBox.Location = new Point(12, 82);
            editFirstNameTextBox.Name = "editFirstNameTextBox";
            editFirstNameTextBox.Size = new Size(163, 23);
            editFirstNameTextBox.TabIndex = 4;
            editFirstNameTextBox.KeyPress += EditFirstNameTextBox_KeyPress;
            // 
            // editMiddleInitialTextBox
            // 
            editMiddleInitialTextBox.Location = new Point(12, 137);
            editMiddleInitialTextBox.Name = "editMiddleInitialTextBox";
            editMiddleInitialTextBox.Size = new Size(163, 23);
            editMiddleInitialTextBox.TabIndex = 5;
            editMiddleInitialTextBox.KeyPress += EditMiddleInitialTextBox_KeyPress;
            // 
            // editMiddleInitialLabel
            // 
            editMiddleInitialLabel.AutoSize = true;
            editMiddleInitialLabel.Location = new Point(12, 119);
            editMiddleInitialLabel.Name = "editMiddleInitialLabel";
            editMiddleInitialLabel.Size = new Size(79, 15);
            editMiddleInitialLabel.TabIndex = 6;
            editMiddleInitialLabel.Text = "Middle Initial:";
            // 
            // editLastNameLabel
            // 
            editLastNameLabel.AutoSize = true;
            editLastNameLabel.Location = new Point(12, 174);
            editLastNameLabel.Name = "editLastNameLabel";
            editLastNameLabel.Size = new Size(66, 15);
            editLastNameLabel.TabIndex = 7;
            editLastNameLabel.Text = "Last Name:";
            // 
            // editLastNameTextBox
            // 
            editLastNameTextBox.Location = new Point(12, 192);
            editLastNameTextBox.Name = "editLastNameTextBox";
            editLastNameTextBox.Size = new Size(163, 23);
            editLastNameTextBox.TabIndex = 8;
            editLastNameTextBox.KeyPress += EditLastNameTextBox_KeyPress;
            // 
            // editHomeLabel
            // 
            editHomeLabel.AutoSize = true;
            editHomeLabel.Location = new Point(198, 174);
            editHomeLabel.Name = "editHomeLabel";
            editHomeLabel.Size = new Size(60, 15);
            editHomeLabel.TabIndex = 9;
            editHomeLabel.Text = "Home Ph:";
            // 
            // editIRDTextBox
            // 
            editIRDTextBox.Location = new Point(12, 247);
            editIRDTextBox.Name = "editIRDTextBox";
            editIRDTextBox.Size = new Size(163, 23);
            editIRDTextBox.TabIndex = 10;
            editIRDTextBox.KeyPress += EditIRDTextBox_KeyPress;
            // 
            // editMobileLabel
            // 
            editMobileLabel.AutoSize = true;
            editMobileLabel.Location = new Point(198, 119);
            editMobileLabel.Name = "editMobileLabel";
            editMobileLabel.Size = new Size(64, 15);
            editMobileLabel.TabIndex = 11;
            editMobileLabel.Text = "Mobile Ph:";
            // 
            // editMobileTextBox
            // 
            editMobileTextBox.Location = new Point(198, 137);
            editMobileTextBox.Name = "editMobileTextBox";
            editMobileTextBox.Size = new Size(163, 23);
            editMobileTextBox.TabIndex = 12;
            editMobileTextBox.KeyPress += EditMobileTextBox_KeyPress;
            // 
            // editOfficeLabel
            // 
            editOfficeLabel.AutoSize = true;
            editOfficeLabel.Location = new Point(198, 229);
            editOfficeLabel.Name = "editOfficeLabel";
            editOfficeLabel.Size = new Size(61, 15);
            editOfficeLabel.TabIndex = 13;
            editOfficeLabel.Text = "Office Ext:";
            // 
            // editHomeTextBox
            // 
            editHomeTextBox.Location = new Point(198, 192);
            editHomeTextBox.Name = "editHomeTextBox";
            editHomeTextBox.Size = new Size(163, 23);
            editHomeTextBox.TabIndex = 14;
            editHomeTextBox.KeyPress += EditHomeTextBox_KeyPress;
            // 
            // editIRDLabel
            // 
            editIRDLabel.AutoSize = true;
            editIRDLabel.Location = new Point(12, 229);
            editIRDLabel.Name = "editIRDLabel";
            editIRDLabel.Size = new Size(47, 15);
            editIRDLabel.TabIndex = 15;
            editIRDLabel.Text = "IRD No:";
            // 
            // editOfficeTextBox
            // 
            editOfficeTextBox.Location = new Point(198, 247);
            editOfficeTextBox.Name = "editOfficeTextBox";
            editOfficeTextBox.Size = new Size(163, 23);
            editOfficeTextBox.TabIndex = 16;
            editOfficeTextBox.KeyPress += EditOfficeTextBox_KeyPress;
            // 
            // editTypeLabel
            // 
            editTypeLabel.AutoSize = true;
            editTypeLabel.Location = new Point(198, 9);
            editTypeLabel.Name = "editTypeLabel";
            editTypeLabel.Size = new Size(89, 15);
            editTypeLabel.TabIndex = 17;
            editTypeLabel.Text = "Employee Type:";
            // 
            // editTypeComboBox
            // 
            editTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            editTypeComboBox.FormattingEnabled = true;
            editTypeComboBox.Location = new Point(198, 27);
            editTypeComboBox.Name = "editTypeComboBox";
            editTypeComboBox.Size = new Size(163, 23);
            editTypeComboBox.TabIndex = 18;
            editTypeComboBox.SelectedIndexChanged += EditTypeComboBox_SelectedIndexChanged;
            // 
            // editManagerLabel
            // 
            editManagerLabel.AutoSize = true;
            editManagerLabel.Location = new Point(198, 64);
            editManagerLabel.Name = "editManagerLabel";
            editManagerLabel.Size = new Size(57, 15);
            editManagerLabel.TabIndex = 19;
            editManagerLabel.Text = "Manager:";
            // 
            // editManagerComboBox
            // 
            editManagerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            editManagerComboBox.FormattingEnabled = true;
            editManagerComboBox.Location = new Point(198, 82);
            editManagerComboBox.Name = "editManagerComboBox";
            editManagerComboBox.Size = new Size(163, 23);
            editManagerComboBox.TabIndex = 20;
            // 
            // editSaveButton
            // 
            editSaveButton.Location = new Point(198, 302);
            editSaveButton.Name = "editSaveButton";
            editSaveButton.Size = new Size(75, 25);
            editSaveButton.TabIndex = 21;
            editSaveButton.Text = "Save";
            editSaveButton.UseVisualStyleBackColor = true;
            editSaveButton.Click += EditSaveButton_Click;
            // 
            // cancelEditButton
            // 
            cancelEditButton.Location = new Point(286, 302);
            cancelEditButton.Name = "cancelEditButton";
            cancelEditButton.Size = new Size(75, 25);
            cancelEditButton.TabIndex = 22;
            cancelEditButton.Text = "Cancel";
            cancelEditButton.UseVisualStyleBackColor = true;
            cancelEditButton.Click += CancelEditButton_Click;
            // 
            // editStatusComboBox
            // 
            editStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            editStatusComboBox.FormattingEnabled = true;
            editStatusComboBox.Location = new Point(12, 302);
            editStatusComboBox.Name = "editStatusComboBox";
            editStatusComboBox.Size = new Size(163, 23);
            editStatusComboBox.TabIndex = 23;
            // 
            // editStatusLabel
            // 
            editStatusLabel.AutoSize = true;
            editStatusLabel.Location = new Point(12, 284);
            editStatusLabel.Name = "editStatusLabel";
            editStatusLabel.Size = new Size(42, 15);
            editStatusLabel.TabIndex = 24;
            editStatusLabel.Text = "Status:";
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 342);
            Controls.Add(editStatusLabel);
            Controls.Add(editStatusComboBox);
            Controls.Add(cancelEditButton);
            Controls.Add(editSaveButton);
            Controls.Add(editManagerComboBox);
            Controls.Add(editManagerLabel);
            Controls.Add(editTypeComboBox);
            Controls.Add(editTypeLabel);
            Controls.Add(editOfficeTextBox);
            Controls.Add(editIRDLabel);
            Controls.Add(editHomeTextBox);
            Controls.Add(editOfficeLabel);
            Controls.Add(editMobileTextBox);
            Controls.Add(editMobileLabel);
            Controls.Add(editIRDTextBox);
            Controls.Add(editHomeLabel);
            Controls.Add(editLastNameTextBox);
            Controls.Add(editLastNameLabel);
            Controls.Add(editMiddleInitialLabel);
            Controls.Add(editMiddleInitialTextBox);
            Controls.Add(editFirstNameTextBox);
            Controls.Add(editFirstNameLabel);
            Controls.Add(editTitleLabel);
            Controls.Add(editTitleComboBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "EditForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Edit Employee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox editTitleComboBox;
        private Label editTitleLabel;
        private Label editFirstNameLabel;
        private TextBox editFirstNameTextBox;
        private TextBox editMiddleInitialTextBox;
        private Label editMiddleInitialLabel;
        private Label editLastNameLabel;
        private TextBox editLastNameTextBox;
        private Label editHomeLabel;
        private TextBox editIRDTextBox;
        private Label editMobileLabel;
        private TextBox editMobileTextBox;
        private Label editOfficeLabel;
        private TextBox editHomeTextBox;
        private Label editIRDLabel;
        private TextBox editOfficeTextBox;
        private Label editTypeLabel;
        private ComboBox editTypeComboBox;
        private Label editManagerLabel;
        private ComboBox editManagerComboBox;
        private Button editSaveButton;
        private Button cancelEditButton;
        private ComboBox editStatusComboBox;
        private Label editStatusLabel;
    }
}