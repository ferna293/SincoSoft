using Colegio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Colegio.Data.Mapper
{
    internal class MatterMapper : EntityTypeConfiguration<MatterInfo>
    {
        public MatterMapper(string schema)
        {
            ToTable("materias", schema);

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Description)
                .HasMaxLength(100);

            Property(x => x.Id).HasColumnName("id");
            Property(x => x.Name).HasColumnName("name_mat");
            Property(x => x.Description).HasColumnName("description");
        }
    }
}