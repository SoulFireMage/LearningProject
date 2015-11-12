using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningProject
{
    /// <summary>
    /// If your reading this source code, you will only find that it's
    /// a personal practice drill - a speed drill to practice doing basic c# stuff
    /// any coherency you find in here is coincidental!
    /// at time of writing this project just has answers to differen random problems I found online.
    /// Why on earth is it on github? My convenience as I work on multiple computers at home
    /// and I like having a historical note of where I floundered about learning stuff.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder(); // Not strictly necessary, could just update a string or the textbox directly
            int[] numbers = new int[] { 1, 22, 5, 4, 3, 43, 32, 2, 6, 6, 7, 5, 5, 8, 6 };
            int findme = 5;
            //how many ways to count the occurrence of a number can you find ?
            //old school method one - beware of index out of range!
            int o = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == findme) { o += 1; }
            }
            sb.Append($"Old school if: {o}");
            //old school while
            o = 0;
            int a = 0;
            while (a++ < numbers.Length - 1)
            {
                if (numbers[a] == findme) { o += 1; }
            }
            //Linq!
            int[] n = numbers.Where(x => x == findme).ToArray();
            sb.Append($"\n Old school while: {n.Count()}");
            sb.Append(string.Format("\nLINQ: {0}", o)); //swapped to format to practice old style interpolation
            sb.Append("\n\nAnd now we list student grades! \n \n");
            //Why oh why did I name it Fred?!
            students students = new students();
            foreach(student student in students.Students)
            {
                sb.Append($"\nStudent Name:{student.Name} \n");
                foreach (var grade in student.Grades)
                {
                    sb.Append($"{grade.Key} : {grade.Value} \n");
                }
            }
           
            Fred.Text = sb.ToString();
        }

    }
    //lets wrap the students up into nice groups
    public class StudentClass
    {
        string _name = "";
        public string Name { get { return _name; } set { _name = value; } }
        students _students = new students();
        public students Students { get{ return _students; } set { _students = value; } }
        public StudentClass(students students)
        {
            _students = students;
        }
    }


    public class students
    {
        List<student> _students = new List<student>();
        public List<student> Students { get { return _students; } set { _students = value; } }
        public students()
        {
            List<string> studentNames = new List<string>() { "Fred", "Wilmer", "Barney", "Megatron", "Optimus Prime", "Thor", "Superman", "batman" };
            foreach (string name in studentNames)
            {
                buildGrades(name);
            }
        }

        private void buildGrades(string name)
        {
            List<string> subjects = new List<string>() { "English", "Maths", "Science", "Art", "Psychology" };
            Random GradeChoices = new Random();
            student student = new student(name, new Dictionary<string, int>());
            foreach (string subject in subjects)
            {
                student.Grades.Add(subject, GradeChoices.Next(1, 5));
            }
            _students.Add(student);
        }
    }
    public class student
    {
        string _name = "";
        public string Name { get { return _name; } set { _name = value; } }

        Dictionary<string, int> _grades = new Dictionary<string, int>();
        public Dictionary<string, int> Grades { get { return _grades; } set { _grades = value; } }
        public student(string name, Dictionary<string, int> grades)
        {
            Grades = grades;
            Name = name;
        }
    }
    }
