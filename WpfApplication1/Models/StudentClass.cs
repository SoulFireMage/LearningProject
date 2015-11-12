using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroSchool.Models
    {
    public class StudentClass
        {
        string _name = "";
        public string Name { get { return _name; } set { _name = value; } }
        List<student> _students = new List<student>();
        public List<student> Students { get { return _students; } set { _students = _students ?? value; } }
      
        public StudentClass(string name, List<student> students)
            {
            _name = name;
            _students = students;
            }
        }
    }
