namespace MiniEFCoreApp.Entities;

public class Client
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ClientType Type { get; set; }
    public string Notes { get; set; }
    public bool IsActive { get; set; }
    public string InvitationData { get; set; }
    public ICollection<AgentClient> ClientAgents { get; set; }
    public DateTime CreateDate { get; set; }
    public ICollection<HomeTour> HomeTours { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletionDate { get; set; }
}

public enum ClientType
{
    Buyer,
    Renter
}
