using Command.Repository.Contexts;
using Command.Repository.Interfaces;
using Commander.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Command.Repository.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommandContext _context;

        public CommandRepository(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(CommandModel command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void DeleteCommand(CommandModel command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public IEnumerable<CommandModel> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public CommandModel GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateCommand(CommandModel command)
        {
            
        }
    }
}
