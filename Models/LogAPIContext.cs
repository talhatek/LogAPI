using Microsoft.EntityFrameworkCore;
namespace LogAPI.Models
{
    public class LogAPIContext: DbContext
    {
        public LogAPIContext(DbContextOptions<LogAPIContext> options) :base (options){}

        public DbSet<Log> Logs {get;set;}
        
    }
}