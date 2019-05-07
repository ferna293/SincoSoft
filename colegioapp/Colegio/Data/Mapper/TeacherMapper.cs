using Colegio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Colegio.Data.Mapper
{
    internal class TeacherMapper : EntityTypeConfiguration<TeacherInfo>
    {
        public TeacherMapper(string schema)
        {
            ToTable("teacher", schema);

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Id)
                .IsRequired();

            Property(x => x.IdMatter)
                .IsRequired();

            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.TypeDocument)
                .HasMaxLength(10);

            Property(x => x.NumberDocument);

            Property(x => x.Email)
                .HasMaxLength(100);

            Property(x => x.Telephone);

            Property(x => x.Id).HasColumnName("id");
            Property(x => x.Name).HasColumnName("name_teach");
            Property(x => x.LastName).HasColumnName("last_name_teach");
            Property(x => x.IdMatter).HasColumnName("id_mat");
            Property(x => x.TypeDocument).HasColumnName("type_document");
            Property(x => x.NumberDocument).HasColumnName("number_document");
            Property(x => x.Email).HasColumnName("email");
            Property(x => x.Telephone).HasColumnName("telephone");
            Ignore(x => x.MatterName);
        }
    }
}