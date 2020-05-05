using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorinis4
{
    public class Faculty
    {
        public string Title { get; set; }
        public List<Student> FacultyStudents{get; set;}

        public Faculty(string title, List<Student> students)
        {
            this.Title = title;
            this.FacultyStudents = students;
        }

    }
}