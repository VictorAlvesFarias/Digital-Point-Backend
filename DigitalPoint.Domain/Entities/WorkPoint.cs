using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Domain.Entities;

public class WorkPoint 
{
    public int Id { get; set; }
    public DateTime Day { get; private set; }
    public string DepartureTime { get; private set; }
    public string EntryTime { get; private set; }
    public bool Attendance { get; private set; }
    public ApplicationUser ApplicationUser { get; private set; }
    private WorkPoint() { }
    public WorkPoint(DateTime day, string departureTime, string entryTime, bool attendance, ApplicationUser applicationUser)
    {

        Day = day;

        DepartureTime = departureTime;

        EntryTime = entryTime;

        Attendance = attendance;

        ApplicationUser = applicationUser;

    }
    public static WorkPoint Create(DateTime day, string departureTime, string entryTime, bool attendance, ApplicationUser applicationUser)
    {
        return new WorkPoint(day, departureTime, entryTime, attendance, applicationUser);
    }
    public void  Update(DateTime day, string departureTime, string entryTime, bool attendance)
    {
        { 
          Day = day;
          DepartureTime = departureTime;
          EntryTime = entryTime;
          Attendance = attendance;
        };
    }


}
