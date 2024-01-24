namespace RadStaffWinForm.Views;

public partial class MainForm : Form
{
    private const int ActiveStatusId = 1;
    private const int InactiveStatusId = 2;
    private const int PendingStatusId = 3;
    private readonly List<int> _selectedStatusIds = [];


    public MainForm()
    {
        InitializeComponent();
        BindDataToListView();
    }

    public AddForm? StaffNewForm { get; private set; }
    public EditForm? StaffEditForm { get; private set; }

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
            "Staff ID", "Employee Status", "Title", "First Name", "Middle Initial",
            "Last Name", "Employee Type", "Manager", "Home Ph", "Mobile Ph", "Office Ext.",
            "IRD Number"
        };

        foreach (var column in columns) allStaffListView.Columns.Add(column);

        SetColumnWidth();
    }

    internal void BindDataToListView()
    {
        allStaffListView.Clear();
        CreateListView();

        UpdateSelectedStatusIds();
        var staffMembers = DataService.DataService.GetStaffMembersWithDetails(_selectedStatusIds);

        if (staffMembers == null)
            return;

        allStaffListView.Items.AddRange(staffMembers.Select(staffMember => new ListViewItem(new[]
        {
            staffMember.StaffId.ToString(),
            staffMember.StaffStatus.StaffStatusDescription,
            staffMember.StaffTitle,
            staffMember.StaffFirstName,
            staffMember.StaffMiddleInitial,
            staffMember.StaffLastName,
            staffMember.StaffType.StaffTypeDescription,
            staffMember.StaffManager is { } manager ? $"{manager.StaffFirstName} {manager.StaffLastName}" : "",
            staffMember.StaffHomePhone,
            staffMember.StaffCellPhone,
            staffMember.StaffOfficeExtension,
            staffMember.StaffIrdnumber
        }!)).ToArray());
    }

    private void AddStaffButton_Click(object sender, EventArgs e)
    {
        StaffNewForm = new AddForm();
        StaffNewForm.StaffMainFormReference = this;
        StaffNewForm.Show();
    }

    private void SetColumnWidth()
    {
        var columnCount = allStaffListView.Columns.Count;
        var columnWidth = allStaffListView.Width / columnCount;

        foreach (ColumnHeader column in allStaffListView.Columns) column.Width = columnWidth;
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        SetColumnWidth();
    }

    private void EditStaffButton_Click(object sender, EventArgs e)
    {
        OpenEditForm();
    }

    private void AllStaffListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        editStaffButton.Enabled = allStaffListView.SelectedItems.Count > 0;
    }

    private void AllStaffListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (allStaffListView.SelectedItems.Count > 0 && allStaffListView.HitTest(e.X, e.Y).Item != null) OpenEditForm();
    }

    private void OpenEditForm()
    {
        StaffEditForm = new EditForm();
        StaffEditForm.StaffMainFormReference = this;
        StaffEditForm.Show();
    }

    private void AllStaffListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (allStaffListView.SelectedItems.Count > 1) e.Item!.Selected = false;
    }
}