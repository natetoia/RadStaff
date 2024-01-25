using System;
using System.Collections.Generic;

namespace RadStaffWinForm.Models;

public partial class StaffMember
{
    public int StaffId { get; set; }

    public string? StaffTitle { get; set; } = null!;

    public string StaffFirstName { get; set; } = null!;

    public string StaffLastName { get; set; } = null!;

    public string StaffMiddleInitial { get; set; } = null!;

    public string? StaffHomePhone { get; set; }

    public string StaffCellPhone { get; set; } = null!;

    public string StaffOfficeExtension { get; set; } = null!;

    public string StaffIrdnumber { get; set; } = null!;

    public int StaffStatusId { get; set; }

    public int StaffTypeId { get; set; }

    public int? StaffManagerId { get; set; }

    public virtual ICollection<StaffMember> InverseStaffManager { get; set; } = new List<StaffMember>();

    public virtual StaffMember? StaffManager { get; set; }

    public virtual StaffStatus StaffStatus { get; set; } = null!;

    public virtual StaffType StaffType { get; set; } = null!;
}
