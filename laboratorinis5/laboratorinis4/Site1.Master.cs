using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace laboratorinis4
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //reading
        List<Faculty> faculties;
        List<Module> modules;

        // transformed structure list
        List<Lecturer> lecturers;

        Dictionary<string, int> uniqueLecturers = new Dictionary<string, int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Table1.Visible = false;
            faculties = new List<Faculty>();
            modules = new List<Module>();
            lecturers = new List<Lecturer>();
            ReadFiles();
            FindUniqueLecturers();
            WriteDataToDropdown();
            TransformToList();
            Sort();

        }
        private void WriteDataToDropdown()
        {
            if (!IsPostBack)
            {
                var toList = (from lecturer in uniqueLecturers
                              select lecturer.Key).ToList();

                foreach (var item in toList)
                {
                    DropDownList1.Items.Add(item.ToString());
                }        
            }
        }

        private void Sort()
        {
            foreach (var item in lecturers) 
            {
                item.Sorting();
            }
        }

        private void TransformToList()
        {  
            bool written;
            foreach (var item in modules)
            {
                written = false;
                foreach (var lecturer in lecturers)
                {
                    if (lecturer.LecturerSurname.Contains(item.LecturerSurname)//where
                        && lecturer.LecturerName.Contains(item.LecturerName))
                    {
                        List<Student> stud = new List<Student>();
                        foreach (var faculty in faculties)
                        {
                            stud = (from student in faculty.FacultyStudents
                                    where student.Module == item.ModuleTitle
                                    select student).ToList();                        
                        }
                        ModuleStudents mod = new ModuleStudents(item.ModuleTitle, stud, item.Credits);
                        lecturer.lecturerModules.Add(mod);
                        written = true;
                    }
                }

                if (written == false)
                {
                    List<Student> stud = new List<Student>();
                    foreach (var faculty in faculties)
                    {
                        stud = (from student in faculty.FacultyStudents
                                where student.Module == item.ModuleTitle
                                select student).ToList();
                        
                    }
                    ModuleStudents mod = new ModuleStudents(item.ModuleTitle, stud, item.Credits);
                    List<ModuleStudents> modStud = new List<ModuleStudents>();
                    modStud.Add(mod);
                    Lecturer lect = new Lecturer(item.LecturerSurname, item.LecturerName, modStud);
                    lecturers.Add(lect);
                }
            }
        }

        private void FindUniqueLecturers()
        {
            foreach (var item in modules)
            {
                if (uniqueLecturers.ContainsKey(item.LecturerSurname + " " + item.LecturerName))
                    uniqueLecturers[item.LecturerSurname + " " + item.LecturerName]++;
                else
                {
                    uniqueLecturers.Add(item.LecturerSurname + " " + item.LecturerName, 0);
                }
            }
        }

        private void ReadFiles()
        {
            // faculties
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("fakultetai"));
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                ReadFaculty(file.ToString());
            }
            // read module
            ReadModule();
        }

        private void ReadModule()
        {
            using (StreamReader reader = new StreamReader(Server.MapPath("Moduliai.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string module = values[0];
                    string surname = values[1];
                    string name = values[2];
                    int credits = Convert.ToInt32(values[3]);
                    Module modulee = new Module(module, surname, name, credits);
                    modules.Add(modulee);
                }
            }
        }

        private void ReadFaculty(string file)
        {
            using (StreamReader reader = new StreamReader(Server.MapPath("fakultetai/" + file)))
            {
                string line = reader.ReadLine();
                string facultyTitle = line;
                List<Student> readStudents = new List<Student>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string module = values[0];
                    string surname = values[1];
                    string name = values[2];
                    string group = values[3];
                    Student student = new Student(facultyTitle, module, surname, name, group);
                    readStudents.Add(student);
                }
                Faculty readFaculty = new Faculty(facultyTitle, readStudents);
                faculties.Add(readFaculty);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Label1.Visible = true;
            Label2.Visible = true;
            Table1.Visible = true;
            string selectedLecturer = null;
            selectedLecturer = DropDownList1.SelectedValue.ToString();
            Session["name"] = selectedLecturer;
            WriteData(selectedLecturer);
            DropDownList1.Text = selectedLecturer;
        }

        private void WriteData(string selected)
        {
            Label1.Text = selected;
            foreach (var lecturer in lecturers)
            {
                if (selected == (lecturer.LecturerSurname + " " + lecturer.LecturerName))
                {
                    foreach (var module in lecturer.lecturerModules)
                    {

                        // title of module
                        TableRow row = new TableRow();
                        TableCell title = new TableCell();
                        title.Text = String.Format("<b>{0}</b>", module.ModuleTitle);
                        title.ForeColor = System.Drawing.ColorTranslator.FromHtml("#007bff");
                        row.Cells.Add(title);
                        Table1.Rows.Add(row);

                        // titles of each collumn
                        TableRow row2 = new TableRow();
                        TableCell group = new TableCell();
                        group.Text = String.Format("<b>Grupė</b>");
                        row2.Cells.Add(group);

                        TableCell surname = new TableCell();
                        surname.Text = "<b>Pavardė</b>";
                        row2.Cells.Add(surname);

                        TableCell name = new TableCell();
                        name.Text = "<b>Vardas</b>";
                        row2.Cells.Add(name);

                        TableCell modul = new TableCell();
                        modul.Text = "<b>Modulis</b>";
                        row2.Cells.Add(modul);

                        TableCell faculty = new TableCell();
                        faculty.Text = "<b>Fakultetas</b>";
                        row2.Cells.Add(faculty);
                        Table1.Rows.Add(row2);                                      

                        // list of students
                        foreach (var student in module.studentsInModule)
                        {
                            TableRow roww = new TableRow();
                            TableCell groupp = new TableCell();
                            groupp.Text = student.Group;
                            roww.Cells.Add(groupp);

                            TableCell surnamee = new TableCell();
                            surnamee.Text = student.StudentSurname;
                            roww.Cells.Add(surnamee);

                            TableCell namee = new TableCell();
                            namee.Text = student.StudentName;
                            roww.Cells.Add(namee);

                            TableCell modulee = new TableCell();
                            modulee.Text = student.Module;
                            roww.Cells.Add(modulee);

                            TableCell facultyy = new TableCell();
                            facultyy.Text = student.Title;
                            roww.Cells.Add(facultyy);
                            Table1.Rows.Add(roww);
                        }
                        // empty line
                        TableRow rowlast = new TableRow();
                        TableCell last = new TableCell();
                        last.Text = " ";
                        rowlast.Cells.Add(last);

                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Table1.Visible = false;
        }
    }
}