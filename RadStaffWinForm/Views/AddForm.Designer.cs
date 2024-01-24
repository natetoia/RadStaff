namespace RadStaffWinForm.Views
{
    partial class AddForm
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
            addTitleComboBox = new ComboBox();
            addTitleLabel = new Label();
            addFirstNameLabel = new Label();
            addFirstNameTextBox = new TextBox();
            addMiddleInitialTextBox = new TextBox();
            addMiddleInitialLabel = new Label();
            addLastNameLabel = new Label();
            addLastNameTextBox = new TextBox();
            addHomeLabel = new Label();
            addIRDTextBox = new TextBox();
            addMobileLabel = new Label();
            addMobileTextBox = new TextBox();
            addOfficeLabel = new Label();
            addHomeTextBox = new TextBox();
            addIRDLabel = new Label();
            addOfficeTextBox = new TextBox();
            addTypeLabel = new Label();
            addTypeComboBox = new ComboBox();
            addManagerLabel = new Label();
            addManagerComboBox = new ComboBox();
            addNewButton = new Button();
            cancelNewButton = new Button();
            SuspendLayout();
            // 
            // addTitleComboBox
            // 
            addTitleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addTitleComboBox.FormattingEnabled = true;
            addTitleComboBox.Items.AddRange(new object[] { "Mr", "Mrs", "Miss", "Sir" });
            addTitleComboBox.Location = new Point(12, 27);
            addTitleComboBox.Name = "addTitleComboBox";
            addTitleComboBox.Size = new Size(163, 23);
            addTitleComboBox.TabIndex = 0;
            // 
            // addTitleLabel
            // 
            addTitleLabel.AutoSize = true;
            addTitleLabel.Location = new Point(12, 9);
            addTitleLabel.Name = "addTitleLabel";
            addTitleLabel.Size = new Size(32, 15);
            addTitleLabel.TabIndex = 1;
            addTitleLabel.Text = "Title:";
            // 
            // addFirstNameLabel
            // 
            addFirstNameLabel.AutoSize = true;
            addFirstNameLabel.Location = new Point(12, 66);
            addFirstNameLabel.Name = "addFirstNameLabel";
            addFirstNameLabel.Size = new Size(67, 15);
            addFirstNameLabel.TabIndex = 3;
            addFirstNameLabel.Text = "First Name:";
            // 
            // addFirstNameTextBox
            // 
            addFirstNameTextBox.Location = new Point(12, 84);
            addFirstNameTextBox.Name = "addFirstNameTextBox";
            addFirstNameTextBox.Size = new Size(163, 23);
            addFirstNameTextBox.TabIndex = 4;
            addFirstNameTextBox.KeyPress += AddFirstNameTextBox_KeyPress;
            // 
            // addMiddleInitialTextBox
            // 
            addMiddleInitialTextBox.Location = new Point(12, 141);
            addMiddleInitialTextBox.Name = "addMiddleInitialTextBox";
            addMiddleInitialTextBox.Size = new Size(163, 23);
            addMiddleInitialTextBox.TabIndex = 5;
            addMiddleInitialTextBox.KeyPress += AddMiddleInitialTextBox_KeyPress;
            // 
            // addMiddleInitialLabel
            // 
            addMiddleInitialLabel.AutoSize = true;
            addMiddleInitialLabel.Location = new Point(12, 123);
            addMiddleInitialLabel.Name = "addMiddleInitialLabel";
            addMiddleInitialLabel.Size = new Size(79, 15);
            addMiddleInitialLabel.TabIndex = 6;
            addMiddleInitialLabel.Text = "Middle Initial:";
            // 
            // addLastNameLabel
            // 
            addLastNameLabel.AutoSize = true;
            addLastNameLabel.Location = new Point(12, 180);
            addLastNameLabel.Name = "addLastNameLabel";
            addLastNameLabel.Size = new Size(66, 15);
            addLastNameLabel.TabIndex = 7;
            addLastNameLabel.Text = "Last Name:";
            // 
            // addLastNameTextBox
            // 
            addLastNameTextBox.Location = new Point(12, 198);
            addLastNameTextBox.Name = "addLastNameTextBox";
            addLastNameTextBox.Size = new Size(163, 23);
            addLastNameTextBox.TabIndex = 8;
            addLastNameTextBox.KeyPress += AddLastNameTextBox_KeyPress;
            // 
            // addHomeLabel
            // 
            addHomeLabel.AutoSize = true;
            addHomeLabel.Location = new Point(198, 180);
            addHomeLabel.Name = "addHomeLabel";
            addHomeLabel.Size = new Size(60, 15);
            addHomeLabel.TabIndex = 9;
            addHomeLabel.Text = "Home Ph:";
            // 
            // addIRDTextBox
            // 
            addIRDTextBox.Location = new Point(12, 255);
            addIRDTextBox.Name = "addIRDTextBox";
            addIRDTextBox.Size = new Size(163, 23);
            addIRDTextBox.TabIndex = 10;
            addIRDTextBox.KeyPress += AddIRDTextBox_KeyPress;
            // 
            // addMobileLabel
            // 
            addMobileLabel.AutoSize = true;
            addMobileLabel.Location = new Point(198, 123);
            addMobileLabel.Name = "addMobileLabel";
            addMobileLabel.Size = new Size(64, 15);
            addMobileLabel.TabIndex = 11;
            addMobileLabel.Text = "Mobile Ph:";
            // 
            // addMobileTextBox
            // 
            addMobileTextBox.Location = new Point(198, 141);
            addMobileTextBox.Name = "addMobileTextBox";
            addMobileTextBox.Size = new Size(163, 23);
            addMobileTextBox.TabIndex = 12;
            addMobileTextBox.KeyPress += AddMobileTextBox_KeyPress;
            // 
            // addOfficeLabel
            // 
            addOfficeLabel.AutoSize = true;
            addOfficeLabel.Location = new Point(198, 237);
            addOfficeLabel.Name = "addOfficeLabel";
            addOfficeLabel.Size = new Size(61, 15);
            addOfficeLabel.TabIndex = 13;
            addOfficeLabel.Text = "Office Ext:";
            // 
            // addHomeTextBox
            // 
            addHomeTextBox.Location = new Point(198, 198);
            addHomeTextBox.Name = "addHomeTextBox";
            addHomeTextBox.Size = new Size(163, 23);
            addHomeTextBox.TabIndex = 14;
            addHomeTextBox.KeyPress += AddHomeTextBox_KeyPress;
            // 
            // addIRDLabel
            // 
            addIRDLabel.AutoSize = true;
            addIRDLabel.Location = new Point(12, 237);
            addIRDLabel.Name = "addIRDLabel";
            addIRDLabel.Size = new Size(47, 15);
            addIRDLabel.TabIndex = 15;
            addIRDLabel.Text = "IRD No:";
            // 
            // addOfficeTextBox
            // 
            addOfficeTextBox.Location = new Point(198, 255);
            addOfficeTextBox.Name = "addOfficeTextBox";
            addOfficeTextBox.Size = new Size(163, 23);
            addOfficeTextBox.TabIndex = 16;
            addOfficeTextBox.KeyPress += AddOfficeTextBox_KeyPress;
            // 
            // addTypeLabel
            // 
            addTypeLabel.AutoSize = true;
            addTypeLabel.Location = new Point(198, 9);
            addTypeLabel.Name = "addTypeLabel";
            addTypeLabel.Size = new Size(89, 15);
            addTypeLabel.TabIndex = 17;
            addTypeLabel.Text = "Employee Type:";
            // 
            // addTypeComboBox
            // 
            addTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addTypeComboBox.FormattingEnabled = true;
            addTypeComboBox.Location = new Point(198, 27);
            addTypeComboBox.Name = "addTypeComboBox";
            addTypeComboBox.Size = new Size(163, 23);
            addTypeComboBox.TabIndex = 18;
            addTypeComboBox.SelectedIndexChanged += AddTypeComboBox_SelectedIndexChanged;
            // 
            // addManagerLabel
            // 
            addManagerLabel.AutoSize = true;
            addManagerLabel.Location = new Point(198, 66);
            addManagerLabel.Name = "addManagerLabel";
            addManagerLabel.Size = new Size(57, 15);
            addManagerLabel.TabIndex = 19;
            addManagerLabel.Text = "Manager:";
            // 
            // addManagerComboBox
            // 
            addManagerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addManagerComboBox.FormattingEnabled = true;
            addManagerComboBox.Location = new Point(198, 84);
            addManagerComboBox.Name = "addManagerComboBox";
            addManagerComboBox.Size = new Size(163, 23);
            addManagerComboBox.TabIndex = 20;
            // 
            // addNewButton
            // 
            addNewButton.Location = new Point(198, 305);
            addNewButton.Name = "addNewButton";
            addNewButton.Size = new Size(75, 25);
            addNewButton.TabIndex = 21;
            addNewButton.Text = "Add";
            addNewButton.UseVisualStyleBackColor = true;
            addNewButton.Click += addNewButton_Click;
            // 
            // cancelNewButton
            // 
            cancelNewButton.Location = new Point(286, 305);
            cancelNewButton.Name = "cancelNewButton";
            cancelNewButton.Size = new Size(75, 25);
            cancelNewButton.TabIndex = 22;
            cancelNewButton.Text = "Cancel";
            cancelNewButton.UseVisualStyleBackColor = true;
            cancelNewButton.Click += cancelNewButton_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 342);
            Controls.Add(cancelNewButton);
            Controls.Add(addNewButton);
            Controls.Add(addManagerComboBox);
            Controls.Add(addManagerLabel);
            Controls.Add(addTypeComboBox);
            Controls.Add(addTypeLabel);
            Controls.Add(addOfficeTextBox);
            Controls.Add(addIRDLabel);
            Controls.Add(addHomeTextBox);
            Controls.Add(addOfficeLabel);
            Controls.Add(addMobileTextBox);
            Controls.Add(addMobileLabel);
            Controls.Add(addIRDTextBox);
            Controls.Add(addHomeLabel);
            Controls.Add(addLastNameTextBox);
            Controls.Add(addLastNameLabel);
            Controls.Add(addMiddleInitialLabel);
            Controls.Add(addMiddleInitialTextBox);
            Controls.Add(addFirstNameTextBox);
            Controls.Add(addFirstNameLabel);
            Controls.Add(addTitleLabel);
            Controls.Add(addTitleComboBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AddForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Add New Employee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox addTitleComboBox;
        private Label addTitleLabel;
        private Label addFirstNameLabel;
        private TextBox addFirstNameTextBox;
        private TextBox addMiddleInitialTextBox;
        private Label addMiddleInitialLabel;
        private Label addLastNameLabel;
        private TextBox addLastNameTextBox;
        private Label addHomeLabel;
        private TextBox addIRDTextBox;
        private Label addMobileLabel;
        private TextBox addMobileTextBox;
        private Label addOfficeLabel;
        private TextBox addHomeTextBox;
        private Label addIRDLabel;
        private TextBox addOfficeTextBox;
        private Label addTypeLabel;
        private ComboBox addTypeComboBox;
        private Label addManagerLabel;
        private ComboBox addManagerComboBox;
        private Button addNewButton;
        private Button cancelNewButton;
    }
}