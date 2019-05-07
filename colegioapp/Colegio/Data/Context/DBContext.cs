using Colegio.Data.Mapper;
using Colegio.Entities;
using System.Data.Entity;

namespace Colegio.Data.Context
{
    internal class DBContext : DbContext
    {
        private string schema { get; set; }

        public DBContext() : base("DefaultConnection")
        {
            schema = "dbo";
        }

        public DbSet<AlumnoInfo> Alumnos { get; set; }
        public DbSet<MatterInfo> Matters { get; set; }
        public DbSet<NoteInfo> Notes { get; set; }
        public DbSet<TeacherInfo> Teachers { get; set; }
        public DbSet<TermInfo> Terms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlumnoMapper(schema));
            modelBuilder.Configurations.Add(new MatterMapper(schema));
            modelBuilder.Configurations.Add(new NoteMapper(schema));
            modelBuilder.Configurations.Add(new TeacherMapper(schema));
            modelBuilder.Configurations.Add(new TermMapper(schema));
        }
    }
}