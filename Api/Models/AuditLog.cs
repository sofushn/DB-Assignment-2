namespace Api.Models;

public class AuditLog: EntityWithId
{
    public int Id { get; set; }
    public AuditLogAction Action { get; set; }
    public string User { get; set; }
    public string ItemAction { get; set; }
    public int ItemId { get; set; }
    public string ItemJson { get; set; }
    public DateTime Timestamp { get; set; }
}

public enum AuditLogAction { AccessAll, Access, Create, Update, Delete }
