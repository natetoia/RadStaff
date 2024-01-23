﻿using RadStaffWinForm.Models;
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

    public EditForm()
    {
        InitializeComponent();
        BindStaffTypesComboBox();
    }

    public MainForm? StaffMainFormReference { get; set; }

    private void BindStaffTypesComboBox()
    {
        var staffTypes = DataService.DataService.GetStaffTypes();
        editTypeComboBox.DataSource = staffTypes;
        editTypeComboBox.DisplayMember = "StaffTypeDescription";
        editTypeComboBox.ValueMember = "StaffTypeId";
        editTypeComboBox.SelectedIndex = -1;
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

        if (editManagerComboBox.Enabled && editManagerComboBox.SelectedIndex == -1)
        {
            _toolTip.Show("Manager must be selected. If no Manager exists, please create a Manager record.",
                editManagerComboBox, 0, -20, 5000);
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


}