using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorinis4
{
    public class Student
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public string StudentSurname { get; set; }
        public string StudentName { get; set; }
        public string Group { get; set; }

        public Student(string title, string module, string surname, string name, string group)
        {
            this.Title = title;
            this.Module = module;
            this.StudentSurname = surname;
            this.StudentName = name;
            this.Group = group;
        }
    }
}