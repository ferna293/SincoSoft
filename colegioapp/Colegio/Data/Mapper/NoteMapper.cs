using Colegio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Colegio.Data.Mapper
{
    internal class NoteMapper : EntityTypeConfiguration<NoteInfo>
    {
        public NoteMapper(string schema)
        {
            ToTable("notas", schema);

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired();

            Property(x => x.IdTerm)
                .IsRequired();

            Property(x => x.IdAlumno)
                .IsRequired();

            Property(x => x.IdMatter)
                .IsRequired();

            Property(x => x.Notes);

            Property(x => x.Id).HasColumnName("id");
            Property(x => x.IdTerm).HasColumnName("id_term");
            Property(x => x.IdAlumno).HasColumnName("id_alumno");
            Property(x => x.IdMatter).HasColumnName("id_mat");
            Property(x => x.Notes).HasColumnName("notes");
            Ignore(x => x.NameMatter);
            Ignore(x => x.Total);
            Ignore(x => x.NameTerm);
        }
    }
}