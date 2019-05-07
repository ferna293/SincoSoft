using Colegio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Colegio.Data.Mapper
{
    internal class TermMapper : EntityTypeConfiguration<TermInfo>
    {
        public TermMapper(string schema)
        {
            ToTable("term", schema);

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Description)
                .HasMaxLength(500);

            Property(x => x.Id).HasColumnName("id");
            Property(x => x.Name).HasColumnName("name_term");
            Property(x => x.Description).HasColumnName("description");
        }
    }
}