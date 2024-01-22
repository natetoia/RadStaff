using System;
using System.Collections.Generic;

namespace RadStaffWinForm.Models;

public partial class StaffStatus
{
    public int StaffStatusId { get; set; }

    public string StaffStatusDescription { get; set; } = null!;

    public virtual ICollection<StaffMember> StaffMembers { get; set; } = new List<StaffMember>();
}
