namespace RadStaffWinForm.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainFormTitle = new Label();
            allStaffListView = new ListView();
            showActiveCheckBox = new CheckBox();
            showPendingCheckBox = new CheckBox();
            showInactiveCheckBox = new CheckBox();
            addStaffButton = new Button();
            SuspendLayout();
            // 
            // mainFormTitle
            // 
            mainFormTitle.AutoSize = true;
            mainFormTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainFormTitle.Location = new Point(11, 8);
            mainFormTitle.Name = "mainFormTitle";
            mainFormTitle.Size = new Size(303, 40);
            mainFormTitle.TabIndex = 0;
            mainFormTitle.Text = "RadStaff Contact List";
            // 
            // allStaffListView
            // 
            allStaffListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            allStaffListView.BorderStyle = BorderStyle.FixedSingle;
            allStaffListView.FullRowSelect = true;
            allStaffListView.GridLines = true;
            allStaffListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            allStaffListView.Location = new Point(11, 62);
            allStaffListView.Name = "allStaffListView";
            allStaffListView.Size = new Size(1117, 531);
            allStaffListView.TabIndex = 1;
            allStaffListView.UseCompatibleStateImageBehavior = false;
            
            // 
            // showActiveCheckBox
            // 
            showActiveCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            showActiveCheckBox.AutoSize = true;
            showActiveCheckBox.Checked = true;
            showActiveCheckBox.CheckState = CheckState.Checked;
            showActiveCheckBox.Location = new Point(784, 27);
            showActiveCheckBox.Name = "showActiveCheckBox";
            showActiveCheckBox.Size = new Size(91, 19);
            showActiveCheckBox.TabIndex = 2;
            showActiveCheckBox.Text = "Show Active";
            showActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // showPendingCheckBox
            // 
            showPendingCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            showPendingCheckBox.AutoSize = true;
            showPendingCheckBox.Location = new Point(901, 27);
            showPendingCheckBox.Name = "showPendingCheckBox";
            showPendingCheckBox.Size = new Size(102, 19);
            showPendingCheckBox.TabIndex = 3;
            showPendingCheckBox.Text = "Show Pending";
            showPendingCheckBox.UseVisualStyleBackColor = true;
            // 
            // showInactiveCheckBox
            // 
            showInactiveCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            showInactiveCheckBox.AutoSize = true;
            showInactiveCheckBox.Location = new Point(1029, 27);
            showInactiveCheckBox.Name = "showInactiveCheckBox";
            showInactiveCheckBox.Size = new Size(99, 19);
            showInactiveCheckBox.TabIndex = 4;
            showInactiveCheckBox.Text = "Show Inactive";
            showInactiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // addStaffButton
            // 
            addStaffButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addStaffButton.Location = new Point(12, 607);
            addStaffButton.Name = "addStaffButton";
            addStaffButton.Size = new Size(133, 33);
            addStaffButton.TabIndex = 5;
            addStaffButton.Text = "Add New";
            addStaffButton.UseVisualStyleBackColor = true;
            addStaffButton.Click += AddStaffButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1140, 653);
            Controls.Add(addStaffButton);
            Controls.Add(showInactiveCheckBox);
            Controls.Add(showPendingCheckBox);
            Controls.Add(showActiveCheckBox);
            Controls.Add(allStaffListView);
            Controls.Add(mainFormTitle);
            Name = "MainForm";
            Text = "RadStaff Contact List";
            Resize += MainForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mainFormTitle;
        private ListView allStaffListView;
        private CheckBox showActiveCheckBox;
        private CheckBox showPendingCheckBox;
        private CheckBox showInactiveCheckBox;
        private Button addStaffButton;
    }
}
