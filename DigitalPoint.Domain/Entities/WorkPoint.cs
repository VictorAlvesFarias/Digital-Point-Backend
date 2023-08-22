using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Domain.Entities;

public class WorkPoint 
{
    public int Id { get; set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime EntryTime { get; private set; }
    public ApplicationUser ApplicationUser { get; private set; } 
    public string ApplicationUserId { get; private set; }
    private WorkPoint() { }
    public WorkPoint(DateTime departureTime, DateTime entryTime, ApplicationUser applicationUser)
    {

        DepartureTime = departureTime;

        EntryTime = entryTime;

        ApplicationUser = applicationUser;

    }
    public static WorkPoint Create(DateTime departureTime, DateTime entryTime, ApplicationUser applicationUser)
    {
        return new WorkPoint(entryTime, departureTime, applicationUser);

    }
    public void  Update(DateTime departureTime, DateTime entryTime)
    {
        { 
          DepartureTime = departureTime;
          EntryTime = entryTime;
        };
    }

}
