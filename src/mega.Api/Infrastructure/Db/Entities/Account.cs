using mega.Api.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace mega.Api.Infrastructure.Db.Entities;

public class Account : IEntity
{
    public int Id { get; set; }

    [MaxLength(250)]
    public string Name { get; set; } = null!;
    public bool Active { get; set; }
    public AuthProvider AuthProvider { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
