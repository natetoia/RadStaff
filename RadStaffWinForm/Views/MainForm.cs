namespace RadStaffWinForm.Views
{
    public partial class MainForm : Form
    {
        private readonly List<int> _selectedStatusIds = [];
        private const int ActiveStatusId = 1;
        private const int InactiveStatusId = 2;
        private const int PendingStatusId = 3;

        public NewForm? StaffNewForm { get; private set; }

        private readonly DataService.DataService _staffDataService;

        public MainForm()
        {
            InitializeComponent();
            _staffDataService = new DataService.DataService();
            showActiveCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            showInactiveCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            showPendingCheckBox.CheckedChanged += Checkbox_CheckedChanged;
            BindDataToListView();
        }

        private void Checkbox_CheckedChanged(object? sender, EventArgs e)
        {
            BindDataToListView();
        }

        private void UpdateSelectedStatusIds()
        {
            _selectedStatusIds.Clear();

            if (showActiveCheckBox.Checked)
                _selectedStatusIds.Add(ActiveStatusId);

            if (showInactiveCheckBox.Checked)
                _selectedStatusIds.Add(InactiveStatusId);

            if (showPendingCheckBox.Checked)
                _selectedStatusIds.Add(PendingStatusId);
        }

        private void CreateListView()
        {
            allStaffListView.View = View.Details;
            var columns = new[]
            {
                "Employee Status", "Staff ID", "Title", "First Name", "Middle Initial", 
                "Last Name", "Home Ph", "Mobile Ph", "Office Ext.", 
                "IRD Number", "Employee Type", "Manager"
            };

            foreach (var column in columns)
            {
                allStaffListView.Columns.Add(column);
            }

            SetColumnWidth();
        }

        private void BindDataToListView()
        {
            allStaffListView.Clear();
            CreateListView();

            UpdateSelectedStatusIds();
            var staffMembers = _staffDataService.GetStaffMembersWithDetails(_selectedStatusIds);

            if (staffMembers == null)
                return;

            allStaffListView.Items.AddRange(staffMembers.Select(staffMember => new ListViewItem(new[]
            {
                staffMember.StaffStatus.StaffStatusDescription,
                staffMember.StaffId.ToString(),
                staffMember.StaffTitle,
                staffMember.StaffFirstName,
                staffMember.StaffMiddleInitial,
                staffMember.StaffLastName,
                staffMember.StaffHomePhone,
                staffMember.StaffCellPhone,
                staffMember.StaffOfficeExtension,
                staffMember.StaffIrdnumber,
                staffMember.StaffType.StaffTypeDescription,
                staffMember.StaffManager?.StaffFirstName
            }!)).ToArray());
        }

        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            StaffNewForm = new NewForm();
            StaffNewForm.Show();
        }

        private void SetColumnWidth()
        {
            var columnCount = allStaffListView.Columns.Count;
            var columnWidth = allStaffListView.Width / columnCount;

            foreach (ColumnHeader column in allStaffListView.Columns)
            {
                column.Width = columnWidth;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetColumnWidth();
        }
    }
}
