using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorinis4
{
    public class ModuleStudents
    {
        public string ModuleTitle { get; set; }
        public List<Student> studentsInModule { get; set; }
        public int Credits { get; set; }

        public ModuleStudents(string title, List<Student> students, int credits)
        {
            this.ModuleTitle = title;
            this.studentsInModule = students;
            this.Credits = credits;
        }
        
        
        
    }
}