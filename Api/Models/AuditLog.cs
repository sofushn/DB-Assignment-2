using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class AuditLog: EntityWithId
{
    public int Id { get; set; }
    [Column("AuditAction")]
    public AuditLogAction Action { get; set; }
    [Column("UserName")]
    public string User { get; set; }
    public string ItemType { get; set; }
    public int ItemId { get; set; }
    public string ItemJson { get; set; }
    [Column("AuditTimestamp")]
    public DateTime Timestamp { get; set; }
}

public enum AuditLogAction { AccessAll, Access, Create, Update, Delete }
