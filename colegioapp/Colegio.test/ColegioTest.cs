using Colegio.Business;
using Colegio.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Colegio.test
{
    [TestClass]
    public class ColegioTest
    {
        private Factory facade;

        public Factory Facade
        {
            get
            {
                if (facade == null)
                {
                    facade = new Factory();
                }
                return facade;
            }
        }

        public static AlumnoInfo AlumnoData
        {
            get
            {
                return new AlumnoInfo()
                {
                    Id = 0,
                    Name = "Fernando",
                    LastName = "Camargo",
                    Email = "fenilol293@gmail.com"
                };
            }
        }

        public static MatterInfo MatterData
        {
            get
            {
                return new MatterInfo()
                {
                    Id = 0,
                    Name = "Matematicas",
                    Description = "Numeros por todos lados",
                };
            }
        }

        public static TeacherInfo TeacherData
        {
            get
            {
                return new TeacherInfo()
                {
                    Id = 0,
                    Name = "Ciudadela",
                    LastName = "Educativa",
                };
            }
        }

        public static TermInfo TermData
        {
            get
            {
                return new TermInfo()
                {
                    Id = 0,
                    Name = "Primer periodo",
                    Description = "6 meses",
                };
            }
        }

        [TestMethod]
        public void TestAlumno()
        {
            AlumnoInfo alumno = Facade.Alumno.Create(AlumnoData);
            Assert.IsNotNull(alumno);
            alumno.Name = "Luis";

            AlumnoInfo alumnoUpdate = Facade.Alumno.Update(alumno);
            Assert.IsNotNull(alumnoUpdate);

            AlumnoInfo alumnoGet = Facade.Alumno.Get(alumno.Id);
            Assert.IsNotNull(alumnoGet);

            List<AlumnoInfo> alumnoList = Facade.Alumno.GetList();
            Assert.IsNotNull(alumnoList);

            Facade.Alumno.Delete(alumno.Id);
        }

        [TestMethod]
        public void Testmatter()
        {
            MatterInfo matter = Facade.Matter.Create(MatterData);
            Assert.IsNotNull(matter);
            matter.Description = "Algo cambio";

            MatterInfo matterUpdate = Facade.Matter.Update(matter);
            Assert.IsNotNull(matterUpdate);

            MatterInfo matterGet = Facade.Matter.Get(matter.Id);
            Assert.IsNotNull(matterGet);

            List<MatterInfo> matterList = Facade.Matter.GetList();
            Assert.IsNotNull(matterList);

            Facade.Matter.Delete(matter.Id);
        }

        [TestMethod]
        public void TestTeacher()
        {
            MatterInfo matter = Facade.Matter.Create(MatterData);
            Assert.IsNotNull(matter);

            TeacherInfo teacherInfo = TeacherData;
            teacherInfo.IdMatter = matter.Id;

            TeacherInfo teacher = Facade.Teacher.Create(teacherInfo);
            Assert.IsNotNull(teacher);
            teacher.LastName = "Apellido cambiado";

            TeacherInfo teacherUpdate = Facade.Teacher.Update(teacher);
            Assert.IsNotNull(teacherUpdate);

            TeacherInfo teacherGet = Facade.Teacher.Get(teacher.Id);
            Assert.IsNotNull(teacherGet);

            List<TeacherInfo> teacherList = Facade.Teacher.GetList();
            Assert.IsNotNull(teacherList);

            //Facade.Teacher.Delete(teacher.Id);
        }

        [TestMethod]
        public void TestTerm()
        {
            TermInfo term = Facade.Term.Create(TermData);
            Assert.IsNotNull(term);
            term.Name = "Terecer periodo";

            TermInfo termUpdate = Facade.Term.Update(term);
            Assert.IsNotNull(termUpdate);

            TermInfo termGet = Facade.Term.Get(termUpdate.Id);
            Assert.IsNotNull(termGet);

            List<TermInfo> termList = Facade.Term.GetList();
            Assert.IsNotNull(termList);

            Facade.Term.Delete(termUpdate.Id);
        }

        [TestMethod]
        public void TestNotes()
        {
            TermInfo termNote = Facade.Term.Create(TermData);
            Assert.IsNotNull(termNote);

            MatterInfo matterNote = Facade.Matter.Create(MatterData);
            Assert.IsNotNull(matterNote);

            AlumnoInfo almunoNote = Facade.Alumno.Create(AlumnoData);
            Assert.IsNotNull(almunoNote);

            NoteInfo note = new NoteInfo();
            note.IdTerm = termNote.Id;
            note.IdMatter = matterNote.Id;
            note.IdAlumno = almunoNote.Id;

            NoteInfo noteComplete = Facade.Note.Create(note);
            Assert.IsNotNull(noteComplete);
            noteComplete.Notes = 3.5;

            NoteInfo noteUpdate = Facade.Note.Update(noteComplete);
            Assert.IsNotNull(noteUpdate);

            NoteInfo noteGet = Facade.Note.Get(noteUpdate.Id);
            Assert.IsNotNull(noteGet);

            List<NoteInfo> noteList = Facade.Note.GetList();
            Assert.IsNotNull(noteList);

            //Facade.Note.Delete(noteUpdate.Id);
        }
    }
}