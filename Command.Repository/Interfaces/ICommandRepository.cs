using Commander.Model.Entities;
using System.Collections.Generic;

namespace Command.Repository.Interfaces
{
    public interface ICommandRepository
    {
        /// <summary>
        /// Save the changes
        /// </summary>
        /// <returns> If true, saved changes, false otherwise </returns>
        bool SaveChanges();

        /// <summary>
        /// Get all commands
        /// </summary>
        /// <returns></returns>
        IEnumerable<CommandModel> GetAllCommands();

        /// <summary>
        /// Get Command by id
        /// </summary>
        /// <param name="id"> Command identifier </param>
        /// <returns></returns>
        CommandModel GetCommandById(int id);

        /// <summary>
        /// Create a new Command
        /// </summary>
        /// <param name="cmd">Command</param>
        void CreateCommand(CommandModel command);

        /// <summary>
        /// Command Update
        /// </summary>
        /// <param name="command">Command</param>
        void UpdateCommand(CommandModel command);

        /// <summary>
        /// Command Delete
        /// </summary>
        /// <param name="command">Command</param>
        void DeleteCommand(CommandModel command);
    }
}
