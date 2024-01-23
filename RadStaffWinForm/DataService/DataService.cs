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

        public List<object> GetManagerStaffMembersIdAndName()
        {
            using (var context = new RadDbContext())
            {
                var result = context.StaffMembers!
                    .Where(s => s.StaffTypeId == 2)
                    .Select(s => new
                    {
                        StaffMemberId = s.StaffId,
                        StaffMemberName = s.StaffFirstName
                    })
                    .ToList();

                return result.Cast<object>().ToList();
            }
        }

        public List<StaffType> GetStaffTypes()
        {
            using (var context = new RadDbContext())
            {
                return context.StaffTypes!.ToList();
            }
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            using (var context = new RadDbContext())
            {
                context.StaffMembers!.Add(staffMember);
                context.SaveChanges();
            }
        }

    }
}