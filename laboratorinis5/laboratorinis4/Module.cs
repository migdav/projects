using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorinis4
{
    public class Module
    {
        public string ModuleTitle { get; set; }
        public string LecturerSurname { get; set; }
        public string LecturerName { get; set; }
        public int Credits { get; set; }

        public Module(string title, string surname, string name, int credits)
        {
            this.ModuleTitle = title;
            this.LecturerSurname = surname;
            this.LecturerName = name;
            this.Credits = credits;
        }
    }
}