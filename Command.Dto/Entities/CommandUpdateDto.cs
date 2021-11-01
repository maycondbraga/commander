using System.ComponentModel.DataAnnotations;

namespace Command.Dto.Entities
{
    public class CommandUpdateDto
    {
        /// <summary>
        /// How to
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        /// <summary>
        /// Command line
        /// </summary>
        [Required]
        public string Line { get; set; }

        /// <summary>
        /// Platform where the command is executed
        /// </summary>
        [Required]
        public string Platform { get; set; }
    }
}
