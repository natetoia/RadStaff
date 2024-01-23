using System.Text.RegularExpressions;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.Views;

public partial class AddForm : Form
{
    private const string NameValidationPattern = @"^[a-zA-Z-]{0,50}$";
    private const string MiddleInitialValidationPattern = @"^[a-zA-Z](?:\s?[a-zA-Z])?$";
    private const string IrdNumberValidationPattern = @"^\d{0,9}$";
    private const string PhoneNumberValidationPattern = @"^\d{0,16}$";
    private const string OfficeNumberValidationPattern = @"^\d{0,5}$";
    private readonly DataService.DataService _staffDataService;
    private readonly ToolTip _toolTip = new();

    public AddForm()
    {
        InitializeComponent();
        _staffDataService = new DataService.DataService();
        BindStaffTypesComboBox();
    }

    public MainForm? StaffMainFormReference { get; set; }

    private void BindStaffTypesComboBox()
    {
        var staffTypes = DataService.DataService.GetStaffTypes();
        addTypeComboBox.DataSource = staffTypes;
        addTypeComboBox.DisplayMember = "StaffTypeDescription";
        addTypeComboBox.ValueMember = "StaffTypeId";
        addTypeComboBox.SelectedIndex = -1;
    }

    private void BindManagerComboBox()
    {
        var managerStaffMembers = DataService.DataService.GetManagerStaffMembersIdAndName();

        addManagerComboBox.DataSource = managerStaffMembers;
        addManagerComboBox.DisplayMember = "StaffMemberName";
        addManagerComboBox.ValueMember = "StaffMemberId";
        addManagerComboBox.SelectedIndex = -1;
    }

    private void AddTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        addManagerComboBox.Enabled = false;
        addManagerComboBox.SelectedIndex = -1;
        var selectedStaffType = addTypeComboBox.SelectedValue;
        if (selectedStaffType == null || !selectedStaffType.Equals(1)) return;

        addManagerComboBox.Enabled = true;
        BindManagerComboBox();
    }

    private void addNewButton_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        var confirmNew = MessageBox.Show("Confirm New Employee?", "Confirm New Employee",
            MessageBoxButtons.YesNo);
        if (confirmNew == DialogResult.No) return;
            
        var newStaffMember = new StaffMember
        {
            StaffTitle = addTitleComboBox.Text,
            StaffFirstName = addFirstNameTextBox.Text,
            StaffMiddleInitial = addMiddleInitialTextBox.Text,
            StaffLastName = addLastNameTextBox.Text,
            StaffIrdnumber = addIRDTextBox.Text,
            StaffCellPhone = addMobileTextBox.Text,
            StaffHomePhone = addHomeTextBox.Text,
            StaffOfficeExtension = addOfficeTextBox.Text,
            StaffTypeId = (int)addTypeComboBox.SelectedValue!,
            StaffManagerId = (int?)addManagerComboBox.SelectedValue,
            StaffStatusId = 3
        };

        DataService.DataService.AddStaffMember(newStaffMember);
        StaffMainFormReference?.BindDataToListView();
        Close();
        MessageBox.Show("Pending staff member created successfully");
    }

    private void AddFirstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var firstNameTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = firstNameTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, NameValidationPattern)) e.Handled = true;
    }

    private void AddLastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var lastNameTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = lastNameTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, NameValidationPattern)) e.Handled = true;
    }

    private void AddMiddleInitialTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var middleInitialTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = middleInitialTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, MiddleInitialValidationPattern)) e.Handled = true;
    }

    private void AddIRDTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var irdNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = irdNumberTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, IrdNumberValidationPattern)) e.Handled = true;
    }

    private void AddMobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var mobileNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = mobileNumberTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, PhoneNumberValidationPattern)) e.Handled = true;
    }

    private void AddHomeTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var homeNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = homeNumberTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, PhoneNumberValidationPattern)) e.Handled = true;
    }

    private void AddOfficeTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var officeNumberTextBox = (TextBox)sender;
        if (char.IsControl(e.KeyChar)) return;

        var input = officeNumberTextBox.Text + e.KeyChar;


        if (!Regex.IsMatch(input, OfficeNumberValidationPattern)) e.Handled = true;
    }

    private bool ValidateInput()
    {
        if (addTitleComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Title is not selected", addTitleComboBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addFirstNameTextBox.Text) ||
            !Regex.IsMatch(addFirstNameTextBox.Text, NameValidationPattern))
        {
            _toolTip.Show("First Name is invalid", addFirstNameTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addMiddleInitialTextBox.Text) ||
            !Regex.IsMatch(addMiddleInitialTextBox.Text, MiddleInitialValidationPattern))
        {
            _toolTip.Show("Middle Initial is invalid", addMiddleInitialTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addLastNameTextBox.Text) ||
            !Regex.IsMatch(addLastNameTextBox.Text, NameValidationPattern))
        {
            _toolTip.Show("Last Name is invalid", addLastNameTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addIRDTextBox.Text) ||
            !Regex.IsMatch(addIRDTextBox.Text, IrdNumberValidationPattern))
        {
            _toolTip.Show("IRD Number is invalid", addIRDTextBox, 0, -20, 5000);
            return false;
        }

        if (addIRDTextBox.Text.Length < 8)
        {
            _toolTip.Show("IRD Number must be 8 or 9 digits", addIRDTextBox, 0, -20, 5000);
            return false;
        }

        if (addTypeComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Type is is invalid", addTypeComboBox, 0, -20, 5000);
            return false;
        }

        if (addManagerComboBox.Enabled && addManagerComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Manager must be selected. If no Manager exists, please create a Manager record.",
                addManagerComboBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addMobileTextBox.Text) ||
            !Regex.IsMatch(addMobileTextBox.Text, PhoneNumberValidationPattern))
        {
            _toolTip.Show("Mobile Number is invalid", addMobileTextBox, 0, -20, 5000);
            return false;
        }

        if (!string.IsNullOrWhiteSpace(addHomeTextBox.Text) &&
            !Regex.IsMatch(addHomeTextBox.Text, PhoneNumberValidationPattern))
        {
            _toolTip.Show("Home Number is invalid", addHomeTextBox, 0, -20, 5000);
            return false;
        }

        if (string.IsNullOrWhiteSpace(addOfficeTextBox.Text) ||
            !Regex.IsMatch(addOfficeTextBox.Text, OfficeNumberValidationPattern))
        {
            _toolTip.Show("Office Extension is invalid", addOfficeTextBox, 0, -20, 5000);
            return false;
        }

        return true;
    }

    private void cancelNewButton_Click(object sender, EventArgs e)
    {
        var confirmClose = MessageBox.Show("Are you sure you want to cancel?", "Cancel New Employee",
            MessageBoxButtons.YesNo);
        if (confirmClose == DialogResult.Yes)
            Close();
    }
}