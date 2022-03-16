using System.Text.Json;

namespace Api;

public class AuditLogger : IAuditLogger
{
    private readonly PharmacyContext _context;

    public AuditLogger(PharmacyContext context)
    {
        _context = context;
    }

    public void Log(AuditLogAction action, string user)
    {
        AuditLog log = new() { Action = action, User = user, Timestamp = DateTime.Now };
        _context.AuditLogs.Add(log);
        _context.SaveChanges();
    }

    public void Log<T>(AuditLogAction action, string user, T obj) where T : EntityWithId
    {
        AuditLog log = new()
        {
            Action = action,
            User = user,
            Timestamp = DateTime.Now, 
            ItemId = obj.Id, 
            ItemAction = obj.GetType().FullName!, 
            ItemJson = JsonSerializer.Serialize(obj)
        };
        _context.AuditLogs.Add(log);
        _context.SaveChanges();
    }

    public async Task LogAsync(AuditLogAction action, string user)
    {
        AuditLog log = new() { Action = action, User = user, Timestamp = DateTime.Now };
        await _context.AuditLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }

    public async Task LogAsync<T>(AuditLogAction action, string user, T obj) where T : EntityWithId
    {
        AuditLog log = new()
        {
            Action = action,
            User = user,
            Timestamp = DateTime.Now,
            ItemId = obj.Id,
            ItemAction = obj.GetType().FullName!,
            ItemJson = JsonSerializer.Serialize(obj)
        };
        await _context.AuditLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}

public interface IAuditLogger
{
    void Log(AuditLogAction action, string user);
    void Log<T>(AuditLogAction action, string user, T obj) where T : EntityWithId;
    Task LogAsync(AuditLogAction action, string user);
    Task LogAsync<T>(AuditLogAction action, string user, T obj) where T : EntityWithId;
}
