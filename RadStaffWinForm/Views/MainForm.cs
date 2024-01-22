using RadStaffWinForm.Models;

namespace RadStaffWinForm.Views
{
    public partial class MainForm : Form
    {
        private readonly RadDbContext _dbContext = new();
        private readonly List<int> _selectedStatusIds = [1];

        public MainForm()
        {
            InitializeComponent();
            showActiveCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            showInactiveCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            showPendingCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            BindDataToListView();
        }

        private void Checkbox_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateSelectedStatusIds();
            BindDataToListView();
        }

        private void UpdateSelectedStatusIds()
        {
            _selectedStatusIds.Clear();

            if (showActiveCheckBox.Checked)
                _selectedStatusIds.Add(1);

            if (showInactiveCheckBox.Checked)
                _selectedStatusIds.Add(2);

            if (showPendingCheckBox.Checked)
                _selectedStatusIds.Add(3);
        }

        private void CreateListView()
        {
            allStaffListView.View = View.Details;
            allStaffListView.Columns.Add("Staff ID",  50);
            allStaffListView.Columns.Add("Title", 50);
            allStaffListView.Columns.Add("First Name", 100);
            allStaffListView.Columns.Add("Middle Initial", 100);
            allStaffListView.Columns.Add("Last Name", 100);
            allStaffListView.Columns.Add("Home Ph", 100);
            allStaffListView.Columns.Add("Mobile Ph", 100);
            allStaffListView.Columns.Add("Office Ext.", 75);

            //in the real world I would totally not include an employees IRD number in a list view like this, but for the project I will 

            allStaffListView.Columns.Add("IRD Number", 100);
            allStaffListView.Columns.Add("Employee Status", 100);
            allStaffListView.Columns.Add("Employee Type", 100);
            allStaffListView.Columns.Add("Manager", 100);
        }

        private void BindDataToListView()
        {
            allStaffListView.Clear();
            CreateListView();
            var staffDataService = new DataService.DataService(_dbContext);

           
                var staffMembers = staffDataService.GetStaffMembersWithDetails(_selectedStatusIds);

                if (staffMembers == null)
                    return;
                
                allStaffListView.Items.AddRange(staffMembers.Select(staffMember => new ListViewItem(new[]
                {
                    staffMember.StaffId.ToString(),
                    staffMember.StaffTitle,
                    staffMember.StaffFirstName,
                    staffMember.StaffMiddleInitial,
                    staffMember.StaffLastName,
                    staffMember.StaffHomePhone,
                    staffMember.StaffCellPhone,
                    staffMember.StaffOfficeExtension,
                    staffMember.StaffIrdnumber,
                    staffMember.StaffStatus.StaffStatusDescription,
                    staffMember.StaffType.StaffTypeDescription,
                    staffMember.StaffManager?.StaffFirstName
                }!)).ToArray());
        }
    }
}