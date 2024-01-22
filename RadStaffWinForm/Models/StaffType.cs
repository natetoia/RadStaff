using System;
using System.Collections.Generic;

namespace RadStaffWinForm.Models;

public partial class StaffType
{
    public int StaffTypeId { get; set; }

    public string StaffTypeDescription { get; set; } = null!;

    public virtual ICollection<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();
}
