using mega.Api.Application.Enums;
using mega.Api.Infrastructure.Db;
using System.ComponentModel.DataAnnotations;

namespace mega.Api.Infrastructure.Db.Entities;

public class User : IEntity
{
    public int Id { get; set; }

    [Required, MaxLength(250)]
    public string FullName { get; set; } = null!;

    [Required, MaxLength(250)]
    public string Username { get; set; } = null!;

    [Required, MaxLength(250)]
    public string Email { get; set; } = null!;

    public UserStatus Status { get; set; }

    public ICollection<Account> Accounts { get; set; } = [];
}
