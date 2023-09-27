namespace MiniEFCoreApp.Entities;

public class HomeTour
{
    public int Id { get; set; }
    public long CoreListingId { get; set; }
    public HomeTourType Type { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime CreateDate { get; set; }
}

public enum HomeTourType
{
    OpenHouseTour,
    InPersonTour,
    VideoTour
}