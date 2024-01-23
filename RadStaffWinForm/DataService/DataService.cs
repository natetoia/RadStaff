using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.DataService
{
    public class DataService
    {
        public List<StaffMember>? GetStaffMembersWithDetails(List<int> statusIds)
        {
            using (var context = new RadDbContext())
            {
                return context.Set<StaffMember>()
                    .Include(s => s.StaffStatus)
                    .Include(s => s.StaffType)
                    .Include(s => s.StaffManager)?
                    .Where(s => statusIds.Contains(s.StaffStatusId))
                    .ToList();
            }
        }
    }
}