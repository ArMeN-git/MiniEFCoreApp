namespace MiniEFCoreApp.Entities;

public class UserView
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public long CoreListingId { get; set; }
    public int Count { get; set; }
    public DateTime CreateDate { get; set; }
}
