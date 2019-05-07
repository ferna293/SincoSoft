namespace Colegio.Entities
{
    public class TeacherInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int IdMatter { get; set; }

        public string MatterName { get; set; }

        public string TypeDocument { get; set; }

        public int? NumberDocument { get; set; }

        public string Email { get; set; }

        public int? Telephone { get; set; }
    }
}