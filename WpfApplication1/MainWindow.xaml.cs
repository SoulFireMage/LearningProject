using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SuperHeroSchool.Models;
using System.Diagnostics;
using System.IO;

namespace SuperHeroSchool
{
    /// <summary>
    /// Welcome to Superhero school. It's a project created solely to learn how to do stuff. Various basic concepts are tried out
    /// including the latest C#6 syntax. As I practice I'll add more features. Eventually there will be a parallel MVC 5 app.
    /// All this app should do at the moment is try to build a school of superheroes with their grades. A chart should be added soon as well.,
    /// </summary>
    public partial class MainWindow : Window
        {
        private List<StudentClass> _superHeroSchool;
        public  List<StudentClass> SuperHeroSchool
            {
            get { return _superHeroSchool; }
            set { _superHeroSchool = _superHeroSchool ??   BuildSchool(); }
            }
        private List<string> Classnames = new List<string>() { "AngelWing", "Archetype", "MetaChron", "HeirArch" };
        
        public MainWindow()
        {
            InitializeComponent();
           
            StringBuilder sb = new StringBuilder(); // Not strictly necessary, could just update a string or the textbox directly
            _superHeroSchool = BuildSchool(); //for now.
            TitleText.AppendText("Welcome To the Super Hero Academy Student Grades Application");

        }
        /// <summary>
        /// Here I'm reading in a file of superheroes, turn them into good little students and randomly assign them to classes.
        /// At time of writing the function is doing too much but it's an exercise - refactoring will be another exerise.
        /// </summary>
        private List<StudentClass> BuildSchool()
            {
            //When I come back need to iterate through student list and randomly assign each to one of the classes. Must check what the numbers are for the class first
            //or I could randomise the list into another list or even better an array perhaps? then just cycle through the classes instead.
            //there is more than one way to skin this cat eh?
            Dictionary<int, StudentClass> ClassAssign = new Dictionary<int, StudentClass>();
            Classnames.ForEach(name => ClassAssign.Add(Classnames.IndexOf(name), new StudentClass(name,  new List<student>())) ); 
            string path = @"superheroes.txt";
            Dictionary<int,student> heroes = new Dictionary<int, student>(); 
            int i = 0;
            using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                StreamReader sr = new StreamReader(fs);
                while (! sr.EndOfStream)
                    {
                    heroes.Add(i,new student(sr.ReadLine()));
                    i++;
                    }
                }
            Random AssignmentNumber = new Random(42);
            var OriginalList = shuffleStudents(heroes.Select(x => x.Value).ToList()).ToArray();
            int classkey = 0;
            int counter = OriginalList.Count();
            //distribute the heroes evenly
            for (int schoolIdx = 0; schoolIdx < counter; schoolIdx++ )
                {
                    counter = OriginalList.Count();
              
                    classkey = classkey == 4 ?   0 : classkey;

                    ClassAssign[classkey].Students.Add(OriginalList[schoolIdx]);
                    classkey++;
                }
            return ClassAssign.Select(x => x.Value).ToList();
            // I may not even need  a dictionary here but until I've done the class assignment i'll just project it to the list.
            //must do this at the end _superHeroSchool.Add(_class ); 
            }

        /// <summary>
        /// A classic sort of a problem really. Given a list, can you randomly shuffle it into an array but be sure that  the array is full?
        /// My first approach, commented out, does not guarantee this at all! 
        /// </summary>
        /// <param name="intake"></param>
        /// <returns></returns>
        private List<student> shuffleStudents(List<student> intake)
            {
            Random ind = new Random();
            var inputStudents = intake.ToArray();
            student[] students = new student[intake.Count];
            int s = 0;
            while (students.Any(x => x == null) && inputStudents.Length >0)
                {
                int r =  ind.Next(0, inputStudents.Length)  ;
                
                if (students[r] == null)
                        {
                            students[r] = inputStudents[s]; //do this here so I can get s = 0 in the array
                        }
                    else
                        {
                            List<int> nulls = new List<int>();
                            for (int _i = 0; _i < inputStudents.Count(); _i++) if (students[_i] == null)  nulls.Add(_i); //get a list of null indices
                            if (nulls.Count() > 0) students[nulls.First()] = inputStudents[s]; //fill up the holes
                        }
               s++;
               s = s < inputStudents.Length ? s : 0; //increment the input index but don't go outside the bounds of the array!
                  }
          
            return students.ToList();
            }
       
        }
 



   
    }
