namespace DigitalPoint.Domain.Entities;

public class WorkPoints {
    public int Id { get; private set; }
    public DateTime Day { get; private set; }
    public int DepartureTimeHour { get; private set; }
    public int DepartureTimeMinute { get; private set; }
    public int EntryTimeHour { get; private set; }
    public int EntryTimeMinute { get; private set; }
    public bool Attendance { get; private set; }
    public ApplicationUser ApplicationUser { get; private set; }
    private WorkPoints() { }
    public WorkPoints(
        DateTime day,
        int departureTimeHour,
        int departureTimeMinute,
        int entryTimeHour,
        int entryTimeMinute,
        bool attendance,
        ApplicationUser user
     ){

        Day = day;

        DepartureTimeHour = departureTimeHour;

        DepartureTimeMinute = departureTimeMinute;

        EntryTimeHour = entryTimeHour;

        EntryTimeMinute = entryTimeMinute;

        Attendance = attendance;

        ApplicationUser = user;

    }

}
