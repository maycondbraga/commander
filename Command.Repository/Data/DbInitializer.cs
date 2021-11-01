using Command.Repository.Contexts;
using Commander.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Repository.Data
{
    /// <summary>
    /// Database initialization class
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// If there is no record in the database, it will be created by the initiator
        /// </summary>
        /// <param name="context"> Command Context </param>
        public void Initialize(CommandContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Command.
            if (context.Commands.Any())
            {
                return;   // DB has been seeded
            }

            var commands = new CommandModel[]
            {
                new CommandModel{ HowTo="How to create Migrations", Line="Add-Migration <Migration Name>", Platform="Visual Studio"},
                new CommandModel{ HowTo="How to delete Migrations", Line="Remove-Migration", Platform="Visual Studio"},
                new CommandModel{ HowTo="How to run Migrations", Line="Update-Database", Platform="Visual Studio"},
                new CommandModel{ HowTo="How to generate SQLServer Script", Line="Script-Migration", Platform="Visual Studio"}
            };

            foreach (CommandModel c in commands)
            {
                context.Commands.Add(c);
            }

            context.SaveChanges();
        }
    }
}
