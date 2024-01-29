using System.Drawing.Printing;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.Views;

public partial class MainForm : Form
{
    private const int ActiveStatusId = 1;
    private const int InactiveStatusId = 2;
    private const int PendingStatusId = 3;
    private const int linesPerPage = 20;
    private readonly List<int> _selectedStatusIds = [];
    private int currentPage = 1;
    private List<string> reportLines;


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
        var staffMembers = DataService.DataService.GetStaffMembersWithDetails()!
            .Where(s => _selectedStatusIds.Contains(s.StaffStatus.StaffStatusId))
            .OrderBy(s => s.StaffId);

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
        StaffNewForm.Tag = this;
        StaffNewForm.Location = Location;
        StaffNewForm.Show(this);
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
        deleteStaffButton.Enabled = allStaffListView.SelectedItems.Count > 0;
    }

    private void AllStaffListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (allStaffListView.SelectedItems.Count > 0 && allStaffListView.HitTest(e.X, e.Y).Item != null) OpenEditForm();
    }

    private void OpenEditForm()
    {
        if (allStaffListView.SelectedItems.Count == 0) return;
        var selectedStaffId = int.Parse(allStaffListView.SelectedItems[0].SubItems[0].Text);
        StaffEditForm = new EditForm(selectedStaffId);
        StaffEditForm.StaffMainFormReference = this;
        StaffEditForm.Tag = this;
        StaffEditForm.Location = Location;
        StaffEditForm.Show(this);
    }


    private void AllStaffListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (allStaffListView.SelectedItems.Count > 1) e.Item!.Selected = false;
    }

    private void DeleteStaffButton_Click(object sender, EventArgs e)
    {
        if (allStaffListView.SelectedItems.Count == 0) return;
        var staffMemberToDelete =
            DataService.DataService.GetStaffMemberById(
                int.Parse(allStaffListView.SelectedItems[0].SubItems[0].Text));
        if (!DeleteStaffValidation(staffMemberToDelete!.StaffId))
        {
            MessageBox.Show("Reassign associated employees to a new manager first.");
            return;
        }

        var confirmDeleteDialog = MessageBox.Show(
            $@"Are you sure you want to delete {staffMemberToDelete.StaffFirstName} {staffMemberToDelete.StaffLastName}?",
            "Delete Employee", MessageBoxButtons.YesNo);
        if (confirmDeleteDialog == DialogResult.Yes)
        {
            DataService.DataService.DeleteStaffMemberById(staffMemberToDelete.StaffId);
            BindDataToListView();
            MessageBox.Show(
                $@"{staffMemberToDelete.StaffFirstName} {staffMemberToDelete.StaffLastName} deleted successfully");
        }
    }

    private static bool DeleteStaffValidation(int staffId)
    {
        return !DataService.DataService.HasStaffMembersWithManagerId(staffId);
    }

    private void ExportCsvButton_Click(object sender, EventArgs e)
    {
        var staffMembers = DataService.DataService.GetStaffMembersWithDetails()!
            .OrderBy(s => s.StaffFirstName)
            .GroupBy(s => s.StaffType.StaffTypeDescription)
            .ToList();

        using (var streamWriter = new StreamWriter("staff_export.csv"))
        {
            streamWriter.WriteLine("StaffType,StaffId,Employee Status,Title," +
                                   "First Name,Middle Initial,Last Name," +
                                   "Employee Type,Manager,Home Ph,Mobile Ph," +
                                   "Office Ext.,IRD Number");
            foreach (var group in staffMembers)
            {
                foreach (var staffMember in group)
                    streamWriter.WriteLine(
                        $"{staffMember.StaffId},{group.Key},{staffMember.StaffStatus.StaffStatusDescription}," +
                        $"{staffMember.StaffTitle},{staffMember.StaffFirstName},{staffMember.StaffMiddleInitial}," +
                        $"{staffMember.StaffLastName},{staffMember.StaffType.StaffTypeDescription}," +
                        $"{(staffMember.StaffManager is { } manager ? $"{manager.StaffFirstName} {manager.StaffLastName}" : "")}," +
                        $"{staffMember.StaffHomePhone},{staffMember.StaffCellPhone},{staffMember.StaffOfficeExtension}," +
                        $"{staffMember.StaffIrdnumber}");
                streamWriter.WriteLine();
            }
        }

        MessageBox.Show("Staff data exported successfully to staff_export.csv");
    }

    private void ExportReportButton_Click(object sender, EventArgs e)
    {
        reportLines = new List<string>();

        var staffMembers = DataService.DataService.GetStaffMembersWithDetails()!
            .OrderBy(s => s.StaffFirstName)
            .GroupBy(s => s.StaffType.StaffTypeDescription)
            .ToList();

        foreach (var group in staffMembers)
        {
            reportLines.Add($"{group.Key}s");
            foreach (var staffMember in group)
                reportLines.Add(

                    $"Staff ID: {staffMember.StaffId}\n" +
                    $"Name: {staffMember.StaffTitle} {staffMember.StaffFirstName} {staffMember.StaffMiddleInitial} {staffMember.StaffLastName}\n" +
                    $"Staff Type: {staffMember.StaffType.StaffTypeDescription}\t" + $"{(staffMember.StaffManager is { } manager ? $"Manager: {manager.StaffFirstName} {manager.StaffLastName}" : "")}\n" +
                    $"Home Ph: {staffMember.StaffHomePhone}\t Mobile: {staffMember.StaffCellPhone}\t Office Ext: {staffMember.StaffOfficeExtension}\n" +
                    $"IRD Number: {staffMember.StaffIrdnumber}");

        }

        var printDocument = new PrintDocument();
        printDocument.PrintPage += PrintPageHandler;

        var printDialog = new PrintDialog();

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            var printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }
    }

    private void PrintPageHandler(object sender, PrintPageEventArgs e)
    {
        var linesPrinted = 0;
        var startIndex = (currentPage - 1) * (linesPerPage + 1);

        while (linesPrinted < linesPerPage && startIndex < reportLines.Count)
        {
            e.Graphics.DrawString(reportLines[startIndex], new Font("Arial", 12), Brushes.Black, 100,
                100 + linesPrinted * 110);
            startIndex++;
            linesPrinted++;
        }

        currentPage++;

        e.HasMorePages = startIndex < reportLines.Count;
    }
}