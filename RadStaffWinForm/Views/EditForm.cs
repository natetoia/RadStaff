using RadStaffWinForm.Models;
using static System.Text.RegularExpressions.Regex;

namespace RadStaffWinForm.Views;

public partial class EditForm : Form
{
    private const string NameValidationPattern = @"^[a-zA-Z-]{0,50}$";
    private const string MiddleInitialValidationPattern = @"^[a-zA-Z](?:\s?[a-zA-Z])?$";
    private const string IrdNumberValidationPattern = @"^\d{0,9}$";
    private const string PhoneNumberValidationPattern = @"^\d{0,16}$";
    private const string OfficeNumberValidationPattern = @"^\d{0,5}$";
    private readonly ToolTip _toolTip = new();
    private readonly int _selectedStaffId;

    public EditForm()
    {
        InitializeComponent();
        BindStaffTypesComboBox();
        BindStaffStatusComboBox();
    }

    public MainForm? StaffMainFormReference { get; set; }

    public EditForm(int selectedStaffId) : this()
    {
        _selectedStaffId = selectedStaffId;
        var staffMember = GetStaffMemberDetails();
        if (staffMember != null)
        {
            editTitleComboBox.SelectedItem = staffMember.StaffTitle;
            editTypeComboBox.SelectedValue = staffMember.StaffType.StaffTypeId;
            if (editManagerComboBox.Enabled)
            {
                editManagerComboBox.SelectedValue = staffMember.StaffManager?.StaffId ?? -1;
            }
            editFirstNameTextBox.Text = staffMember.StaffFirstName;
            editMiddleInitialTextBox.Text = staffMember.StaffMiddleInitial;
            editLastNameTextBox.Text = staffMember.StaffLastName;
            editIRDTextBox.Text = staffMember.StaffIrdnumber;
            editMobileTextBox.Text = staffMember.StaffCellPhone;
            editHomeTextBox.Text = staffMember.StaffHomePhone;
            editOfficeTextBox.Text = staffMember.StaffOfficeExtension;
            editStatusComboBox.SelectedValue = staffMember.StaffStatus.StaffStatusId;
        }
    }

    private StaffMember? GetStaffMemberDetails()
    {
        return DataService.DataService.GetStaffMemberById(_selectedStaffId);
    }


    private void BindStaffTypesComboBox()
    {
        var staffTypes = DataService.DataService.GetStaffTypes();
        editTypeComboBox.DataSource = staffTypes;
        editTypeComboBox.DisplayMember = "StaffTypeDescription";
        editTypeComboBox.ValueMember = "StaffTypeId";
        editTypeComboBox.SelectedIndex = -1;
    }

    private void BindStaffStatusComboBox()
    {
        var staffStatuses = DataService.DataService.GetStaffStatuses();
        editStatusComboBox.DataSource = staffStatuses;
        editStatusComboBox.DisplayMember = "StaffStatusDescription";
        editStatusComboBox.ValueMember = "StaffStatusId";
        editStatusComboBox.SelectedIndex = -1;
    }

    private void BindManagerComboBox()
    {
        var managerStaffMembers = DataService.DataService.GetManagerStaffMembersIdAndName();

        editManagerComboBox.DataSource = managerStaffMembers;
        editManagerComboBox.DisplayMember = "StaffMemberName";
        editManagerComboBox.ValueMember = "StaffMemberId";
        editManagerComboBox.SelectedIndex = -1;
    }

    private void EditTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        editManagerComboBox.Enabled = false;
        editManagerComboBox.SelectedIndex = -1;
        var selectedStaffType = editTypeComboBox.SelectedValue;
        if (selectedStaffType == null || !selectedStaffType.Equals(1)) return;

        editManagerComboBox.Enabled = true;
        BindManagerComboBox();
    }

    private void EditSaveButton_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        var confirmNew = MessageBox.Show("Confirm Updated Employee?", "Confirm Updated Employee",
            MessageBoxButtons.YesNo);
        if (confirmNew == DialogResult.No) return;
        StaffMember updatedStaffMember = new StaffMember
        {
            StaffTitle = editTitleComboBox.Text,
            StaffFirstName = editFirstNameTextBox.Text,
            StaffMiddleInitial = editMiddleInitialTextBox.Text,
            StaffLastName = editLastNameTextBox.Text,
            StaffIrdnumber = editIRDTextBox.Text,
            StaffCellPhone = editMobileTextBox.Text,
            StaffHomePhone = editHomeTextBox.Text,
            StaffOfficeExtension = editOfficeTextBox.Text,
            StaffTypeId = (int)editTypeComboBox.SelectedValue!,
            StaffManagerId = (int?)editManagerComboBox.SelectedValue,
            StaffStatusId = (int)editStatusComboBox.SelectedValue!
        };
        DataService.DataService.UpdateStaffMemberById(_selectedStaffId, updatedStaffMember);
        StaffMainFormReference?.BindDataToListView();
        MessageBox.Show("Employee Updated Succesfully");
        Close();
    }

    private void EditFirstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var firstNameTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = firstNameTextBox.Text + e.KeyChar;


        if (!IsMatch(input, NameValidationPattern)) e.Handled = true;
    }

    private void EditLastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var lastNameTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = lastNameTextBox.Text + e.KeyChar;


        if (!IsMatch(input, NameValidationPattern)) e.Handled = true;
    }

    private void EditMiddleInitialTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var middleInitialTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = middleInitialTextBox.Text + e.KeyChar;


        if (!IsMatch(input, MiddleInitialValidationPattern)) e.Handled = true;
    }

    private void EditIRDTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var irdNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = irdNumberTextBox.Text + e.KeyChar;


        if (!IsMatch(input, IrdNumberValidationPattern)) e.Handled = true;
    }

    private void EditMobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var mobileNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = mobileNumberTextBox.Text + e.KeyChar;


        if (!IsMatch(input, PhoneNumberValidationPattern)) e.Handled = true;
    }

    private void EditHomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var homeNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = homeNumberTextBox.Text + e.KeyChar;


        if (!IsMatch(input, PhoneNumberValidationPattern)) e.Handled = true;
    }

    private void EditOfficeTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var officeNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = officeNumberTextBox.Text + e.KeyChar;


        if (!IsMatch(input, OfficeNumberValidationPattern)) e.Handled = true;
    }

    private bool ValidateInput()
    {
        if (editTitleComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Title is not selected", editTitleComboBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editFirstNameTextBox.Text) ||
            !IsMatch(editFirstNameTextBox.Text, NameValidationPattern))
        {
            _toolTip.Show("First Name is invalid", editFirstNameTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editMiddleInitialTextBox.Text) ||
            !IsMatch(editMiddleInitialTextBox.Text, MiddleInitialValidationPattern))
        {
            _toolTip.Show("Middle Initial is invalid", editMiddleInitialTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editLastNameTextBox.Text) ||
            !IsMatch(editLastNameTextBox.Text, NameValidationPattern))
        {
            _toolTip.Show("Last Name is invalid", editLastNameTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editIRDTextBox.Text) ||
            !IsMatch(editIRDTextBox.Text, IrdNumberValidationPattern))
        {
            _toolTip.Show("IRD Number is invalid", editIRDTextBox, 0, -20, 5000);
            return false;
        }

        if (editIRDTextBox.Text.Length < 8)
        {
            _toolTip.Show("IRD Number must be 8 or 9 digits", editIRDTextBox, 0, -20, 5000);
            return false;
        }

        if (editTypeComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Type is is invalid", editTypeComboBox, 0, -20, 5000);
            return false;
        }

        if ((int?)editTypeComboBox.SelectedValue == 1 &&
            DataService.DataService.HasStaffMembersWithManagerId(_selectedStaffId))
        {
            _toolTip.Show("Reassign associated employees to a new manager first.",
                editTypeComboBox, 0, -20, 5000);
            return false;
        }

        if (editManagerComboBox.Enabled && editManagerComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Manager must be selected. If no Manager exists, please create a Manager record.",
                editManagerComboBox, 0, -20, 5000);
            return false;
        }

        if (editManagerComboBox.Enabled && (int)editManagerComboBox.SelectedValue! == _selectedStaffId)
        {
            _toolTip.Show("Employee cannot be their own Manager", editManagerComboBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editMobileTextBox.Text) ||
            !IsMatch(editMobileTextBox.Text, PhoneNumberValidationPattern))
        {
            _toolTip.Show("Mobile Number is invalid", editMobileTextBox, 0, -20, 5000);
            return false;
        }

        if (!string.IsNullOrWhiteSpace(editHomeTextBox.Text) &&
            !IsMatch(editHomeTextBox.Text, PhoneNumberValidationPattern))
        {
            _toolTip.Show("Home Number is invalid", editHomeTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(editOfficeTextBox.Text) ||
            !IsMatch(editOfficeTextBox.Text, OfficeNumberValidationPattern))
        {
            _toolTip.Show("Office Extension is invalid", editOfficeTextBox, 0, -20, 5000);
            return false;
        }

        return true;
    }

    private void CancelEditButton_Click(object sender, EventArgs e)
    {
        var confirmClose = MessageBox.Show("Are you sure you want to cancel?", "Cancel Edit Employee",
            MessageBoxButtons.YesNo);
        if (confirmClose == DialogResult.Yes)
            Close();
    }
}