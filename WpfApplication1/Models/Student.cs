using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroSchool
    {
    public class Student
        {
        string _name = "";
        public string Name { get { return _name; } set { _name = value; } }

        Dictionary<string, int> _grades = new Dictionary<string, int>();
        public Dictionary<string, int> Grades { get { return _grades; } set { _grades = _grades ?? value; } }

        public Student()
            {
 
            }
        public Student(string name)
            {
            Name = name;
            buildGrades();
            }

        private void buildGrades( )
            {
            List<string> subjects = new List<string>() { "English", "Maths", "Science", "Art", "Psychology" }; //We could have subjects here as well but I want to get this done today!
            Random GradeChoices = new Random();

            foreach (string subject in subjects)
                {
                _grades.Add(subject, GradeChoices.Next(1, 5));
                }
             
            }
        //public Student(string name, Dictionary<string, int> grades)
        //    {
        //    Grades = grades;
        //    Name = name;
        //    }
        }
    }
