using Colegio.Interfaces;

namespace Colegio.Business
{
    public class Factory
    {
        private IAlumno alumno;

        public IAlumno Alumno
        {
            get
            {
                if (alumno == null)
                {
                    alumno = new Alumno();
                }
                return alumno;
            }
        }

        private IMatter matter;

        public IMatter Matter
        {
            get
            {
                if (matter == null)
                {
                    matter = new Matter();
                }
                return matter;
            }
        }

        private INote note;

        public INote Note
        {
            get
            {
                if (note == null)
                {
                    note = new Note();
                }
                return note;
            }
        }

        private ITeacher teacher;

        public ITeacher Teacher
        {
            get
            {
                if (teacher == null)
                {
                    teacher = new Teacher();
                }
                return teacher;
            }
        }

        private ITerm term;

        public ITerm Term
        {
            get
            {
                if (term == null)
                {
                    term = new Term();
                }
                return term;
            }
        }
    }
}