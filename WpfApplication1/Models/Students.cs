using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroSchool.Models
    {
    public class students
        {
        List<student> _students = new List<student>();
        public List<student> Students { get { return _students; } set { _students = value; } }
        public students(List<student> students)
            {
            _students = students;
            //List<string> studentNames = new List<string>() { "Fred", "Wilmer", "Barney", "Megatron", "Optimus Prime", "Thor", "Superman", "batman" };
            //foreach (student s in _students)
            //    {
            //    buildGrades(s);
            //    }
            }

        
        }
    }
