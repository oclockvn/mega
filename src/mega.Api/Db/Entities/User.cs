using mega.Api.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace mega.Api.Db.Entities;

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
