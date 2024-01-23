using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.DataService
{
    public class DataService
    {
        public static List<StaffMember>? GetStaffMembersWithDetails(List<int> statusIds)
        {
            using (var context = new RadDbContext())
            {
                return context.Set<StaffMember>()
                    .Include(s => s.StaffStatus)
                    .Include(s => s.StaffType)
                    .Include(s => s.StaffManager)?
                    .Where(s => statusIds.Contains(s.StaffStatusId))
                    .OrderBy(s => s.StaffId)
                    .ToList();
            }
        }

        public static List<object> GetManagerStaffMembersIdAndName()
        {
            using (var context = new RadDbContext())
            {
                var result = context.StaffMembers!
                    .Where(s => s.StaffTypeId == 2)
                    .OrderBy(s => s.StaffFirstName)
                    .Select(s => new
                    {
                        StaffMemberId = s.StaffId,
                        StaffMemberName = $"{s.StaffFirstName} {s.StaffLastName}"
                    })
                    .ToList();

                return result.Cast<object>().ToList();
            }
        }

        public static List<StaffType> GetStaffTypes()
        {
            using (var context = new RadDbContext())
            {
                return context.StaffTypes!.ToList();
            }
        }

        public static void AddStaffMember(StaffMember staffMember)
        {
            using (var context = new RadDbContext())
            {
                context.StaffMembers!.Add(staffMember);
                context.SaveChanges();
            }
        }

    }
}