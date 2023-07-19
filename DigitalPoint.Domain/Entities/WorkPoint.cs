using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Domain.Entities;

public class WorkPoint {

    [Key]
    public int Id { get; set; }
    public DateTime Day { get; private set; }
    public string DepartureTime { get; private set; }
    public string EntryTime { get; private set; }
    public bool Attendance { get; private set; }
    public IdentityUser ApplicationUser { get; private set; }
    private WorkPoint() { }
    public WorkPoint(DateTime day, string departureTime,string entryTime,bool attendance, IdentityUser user){

        Day = day;

        DepartureTime = departureTime;

        EntryTime = entryTime;

        Attendance = attendance;

        ApplicationUser = user;

    }
    public static WorkPoint Create(DateTime day, string departureTime, string entryTime, bool attendance, IdentityUser user)
    {
        return new WorkPoint(day, departureTime, entryTime, attendance, user);
    }



}
