using Colegio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Colegio.Data.Mapper
{
    internal class AlumnoMapper : EntityTypeConfiguration<AlumnoInfo>
    {
        public AlumnoMapper(string schema)
        {
            ToTable("alumno", schema);

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.LastName)
                .HasMaxLength(20);

            Property(x => x.Email)
                .HasMaxLength(100);

            Property(x => x.TypeDocument)
                .HasMaxLength(20);

            Property(x => x.NumberDocument);

            Property(x => x.Id).HasColumnName("id");
            Property(x => x.Name).HasColumnName("name_alumno");
            Property(x => x.LastName).HasColumnName("last_name_alumno");
            Property(x => x.Email).HasColumnName("email");
            Property(x => x.TypeDocument).HasColumnName("type_document");
            Property(x => x.NumberDocument).HasColumnName("number_document");
        }
    }
}