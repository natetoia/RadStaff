using Microsoft.EntityFrameworkCore;
using RadStaffWinForm.Models;

namespace RadStaffWinForm.DataService;

public class DataService
{
    public static List<StaffMember>? GetStaffMembersWithDetails()
    {
        using (var context = new RadDbContext())
        {
            return context.Set<StaffMember>()
                .Include(s => s.StaffStatus)
                .Include(s => s.StaffType)
                .Include(s => s.StaffManager)?
                .ToList();
        }
    }

    public static StaffMember? GetStaffMemberById(int staffId)
    {
        using (var context = new RadDbContext())
        {
            return context.Set<StaffMember>()
                .Include(s => s.StaffStatus)
                .Include(s => s.StaffType)
                .Include(s => s.StaffManager)
                .FirstOrDefault(s => s.StaffId == staffId);
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

    public static List<StaffStatus> GetStaffStatuses()
    {
        using (var context = new RadDbContext())
        {
            return context.StaffStatuses!.ToList();
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

    public static void UpdateStaffMemberById(int staffId, StaffMember updatedStaffMember)
    {
        using (var context = new RadDbContext())
        {
            var existingStaffMember = context.StaffMembers!
                .FirstOrDefault(s => s.StaffId == staffId);
            if (existingStaffMember == null) return;
            existingStaffMember.StaffTitle = updatedStaffMember.StaffTitle;
            existingStaffMember.StaffFirstName = updatedStaffMember.StaffFirstName;
            existingStaffMember.StaffMiddleInitial = updatedStaffMember.StaffMiddleInitial;
            existingStaffMember.StaffLastName = updatedStaffMember.StaffLastName;
            existingStaffMember.StaffIrdnumber = updatedStaffMember.StaffIrdnumber;
            existingStaffMember.StaffCellPhone = updatedStaffMember.StaffCellPhone;
            existingStaffMember.StaffHomePhone = updatedStaffMember.StaffHomePhone;
            existingStaffMember.StaffOfficeExtension = updatedStaffMember.StaffOfficeExtension;
            existingStaffMember.StaffTypeId = updatedStaffMember.StaffTypeId;
            existingStaffMember.StaffManagerId = updatedStaffMember.StaffManagerId;
            existingStaffMember.StaffStatusId = updatedStaffMember.StaffStatusId;
            context.SaveChanges();
        }
    }

    public static bool HasStaffMembersWithManagerId(int managerId)
    {
        using (var context = new RadDbContext())
        {
            return context.StaffMembers!.Any(s => s.StaffManagerId == managerId);
        }
    }

    public static void DeleteStaffMemberById(int staffId)
    {
        using (var context = new RadDbContext())
        {
            var staffMemberToDelete = context.StaffMembers!
                .FirstOrDefault(s => s.StaffId == staffId);

            if (staffMemberToDelete == null) return;
            context.StaffMembers!.Remove(staffMemberToDelete);
            context.SaveChanges();
        }
    }
}