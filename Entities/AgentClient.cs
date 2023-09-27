namespace MiniEFCoreApp.Entities;

public class AgentClient
{
    public int Id { get; set; }
    public int AgentUserId { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public DateTime CreateDate { get; set; }
}

