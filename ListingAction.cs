namespace MiniEFCoreApp;

public class ListingAction
{
    public int UserId { get; set; }
    public long CoreListingId { get; set; }
    public ClientListingAction Action { get; set; }
    public DateTime CreateDate { get; set; }
    public string Text { get; set; }
    public string AdditionalInfo { get; set; }
}

public enum ClientListingAction
{
    AddedToCollection,
    AddedNote,
    Viewed,
    Liked,
    NotInterested,
    AddedHomeTour,
    Compared,
    AddedOpenHouseToCalendar,
    Shared,
    AddedToInspiration
}