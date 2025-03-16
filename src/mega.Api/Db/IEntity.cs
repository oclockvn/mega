using mega.Api.Db.Entities;

namespace mega.Api.Db;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}

public interface IEntity : IEntity<int>
{
}

public interface ICreatedBy
{
    public DateTime CreatedUtc { get; set; }
    public int CreatedId { get; set; }
    public User CreatedUser { get; set; }
}

public interface IUpdatedBy
{
    public DateTime? UpdatedUtc { get; set; }
    public int? UpdatedId { get; set; }
    public User? UpdatedUser { get; set; }
}
