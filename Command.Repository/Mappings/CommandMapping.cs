using Commander.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Command.Repository.Mappings
{
    /// <summary>
    /// Command Mapping
    /// </summary>
    public class CommandMapping : IEntityTypeConfiguration<CommandModel>
    {
        /// <summary>
        /// Configure for Command entity
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CommandModel> builder)
        {
            builder.ToTable("TB_COMMAND");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID_COMMAND").ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(t => t.HowTo).HasColumnName("DS_HOW_TO");
            builder.Property(t => t.Line).HasColumnName("DS_LINE");
            builder.Property(t => t.Platform).HasColumnName("DS_PLATFORM");
        }
    }
}
