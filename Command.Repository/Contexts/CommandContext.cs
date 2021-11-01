using Command.Repository.Mappings;
using Commander.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Command.Repository.Contexts
{
    /// <summary>
    /// Context for Database
    /// </summary>
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CommandMapping());
        }

        public DbSet<CommandModel> Commands { get; set; }
    }
}
