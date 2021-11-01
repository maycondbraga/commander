namespace Command.Dto.Entities
{

    public class CommandReadDto
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
    }
}
