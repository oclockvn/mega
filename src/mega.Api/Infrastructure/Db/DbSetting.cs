namespace mega.Api.Infrastructure.Db;

public class DbSetting
{
    public const string SECTION_NAME = "Database";
    public string ConnectionString { get; set; } = null!;
}
