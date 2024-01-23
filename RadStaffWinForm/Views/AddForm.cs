﻿namespace RadStaffWinForm.Views
{
    public partial class AddForm : Form
    {
        private readonly DataService.DataService _staffDataService;

        public AddForm()
        {
            InitializeComponent();
            _staffDataService = new DataService.DataService();
            BindStaffTypesComboBox();
        }

        private void BindStaffTypesComboBox()
        {
            var staffTypes = _staffDataService.GetStaffTypes();
            addTypeComboBox.DataSource = staffTypes;
            addTypeComboBox.DisplayMember = "StaffTypeDescription";
            addTypeComboBox.ValueMember = "StaffTypeId";
            addTypeComboBox.SelectedIndex = -1;
        }

        private void BindManagerComboBox()
        {
            var managerStaffMembers = _staffDataService.GetManagerStaffMembersIdAndName();

            addManagerComboBox.DataSource = managerStaffMembers;
            addManagerComboBox.DisplayMember = "StaffMemberName"; 
            addManagerComboBox.ValueMember = "StaffMemberId";
            addManagerComboBox.SelectedIndex = -1;
        }

        private void AddTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addManagerComboBox.Enabled = false;
            addManagerComboBox.SelectedIndex = -1;

            if (addTypeComboBox.SelectedIndex != 0)
            {
                return;
            }

            addManagerComboBox.Enabled = true;
            BindManagerComboBox();
        }
    }
}