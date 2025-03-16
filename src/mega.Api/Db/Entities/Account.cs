namespace mega.Api.Db.Entities;

public class Account : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool Active { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
