namespace Colegio.Entities
{
    public class NoteInfo
    {
        public int Id { get; set; }

        public int IdTerm { get; set; }

        public int IdAlumno { get; set; }

        public int IdMatter { get; set; }

        public double? Notes { get; set; }

        public string NameMatter { get; set; }

        public double Total { get; set; }

        public string NameTerm { get; set; }
    }
}