using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroSchool 
    {
    public class StudentClass
        {
        string _name = "";
        public string Name { get { return _name; } set { _name = value; } }
        List<Student> _students = new List<Student>();
        public List<Student> Students { get { return _students; } set { _students = _students ?? value; } }
        public StudentClass() { } //needed for Xaml to see this!
        public StudentClass(string name, List<Student> students)
            {
            _name = name;
            _students = students;
            }
        }
    }
