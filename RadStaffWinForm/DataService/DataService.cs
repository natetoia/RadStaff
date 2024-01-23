using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.DataService
{
    public class DataService(DbContext dbContext)
    {
        public List<StaffMember>? GetStaffMembersWithDetails(List<int> statusIds)
        {
            return dbContext.Set<StaffMember>()
                .Include(s => s.StaffStatus)
                .Include(s => s.StaffType)
                .Include(s => s.StaffManager)?
                .Where(s => statusIds.Contains(s.StaffStatusId))
                .ToList();
            
        }
    }
}