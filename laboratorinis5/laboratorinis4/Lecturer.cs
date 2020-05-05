using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorinis4
{
    public class Lecturer
    {
        public string LecturerSurname { get; set; }
        public string LecturerName { get; set; }
        public List<ModuleStudents> lecturerModules { get; set; }
        public double WorkSize
        {
            get
            {

                var sum = (from module in lecturerModules
                           select module.Credits * module.studentsInModule.Count).Sum();
                return sum;
                
                //int sum = 0;
                //foreach(var module in lecturerModules)
                //{
                //    sum = sum + (module.Credits * module.studentsInModule.Count);
                //}
                //return sum;
            }
        }

        public void Sorting()
        {
            List<Student> list = new List<Student>();
            foreach (var item in lecturerModules)
            {
                var sort = item.studentsInModule
                    .OrderBy(nn => nn.Group)
                    .ThenBy(nn => nn.StudentSurname).ToList();

                list = sort;
                item.studentsInModule = list;
            }
        }

        public Lecturer(string surname, string name, List<ModuleStudents> modules)
        {
            this.LecturerSurname = surname;
            this.LecturerName = name;
            this.lecturerModules = modules;
        }

    }
}