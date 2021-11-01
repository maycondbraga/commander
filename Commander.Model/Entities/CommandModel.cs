namespace Commander.Model.Entities
{
    /// <summary>
    /// Class model for TB_COMMAND
    /// </summary>
    public class CommandModel
    {
        /// <summary>
        /// Command identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// How to
        /// </summary>
        public string HowTo { get; set; }

        /// <summary>
        /// Command line
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Platform where the command is executed
        /// </summary>
        public string Platform { get; set; }
    }
}
