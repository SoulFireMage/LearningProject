using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperHeroSchool
    {
    public class School
        {
        private List<StudentClass> _superHeroSchool;
        public List<StudentClass> SuperHeroSchool
            {
            get { return _superHeroSchool; }
            set { _superHeroSchool = value; }
            }
      public School()
            {
            _superHeroSchool = _superHeroSchool ?? BuildSchool();
            }

    private List<StudentClass> BuildSchool()
        {
            //When I come back need to iterate through Student list and randomly assign each to one of the classes. Must check what the numbers are for the class first
            //or I could randomise the list into another list or even better an array perhaps? then just cycle through the classes instead.
            //there is more than one way to skin this cat eh?
            
            Dictionary<int, StudentClass> ClassAssign = new Dictionary<int, StudentClass>();

        List<string> Classnames = new List<string>() { "AngelWing", "Archetype", "MetaChron", "HeirArch" };
        Classnames.ForEach(name => ClassAssign.Add(Classnames.IndexOf(name), new StudentClass(name, new List<Student>())));

        string path = @"superheroes.txt";  //needs to be in the .exe folder
        Dictionary<int, Student> heroes = new Dictionary<int, Student>();
        int i = 0;
        using (FileStream fs = new FileStream(path, FileMode.Open))
            {
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
                {
                heroes.Add(i, new Student(sr.ReadLine()));
                i++;
                }
            }
        Random AssignmentNumber = new Random(42);
        var OriginalList = shuffleStudents(heroes.Select(x => x.Value).ToList()).ToArray();
        int classkey = 0;
        int counter = OriginalList.Count();
        //distribute the heroes evenly
        for (int schoolIdx = 0; schoolIdx < counter; schoolIdx++)
            {
            counter = OriginalList.Count();

            classkey = classkey == 4 ? 0 : classkey;

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
        private List<Student> shuffleStudents(List<Student> intake)
            {
            Random ind = new Random();
            var inputStudents = intake.ToArray();
            Student[] students = new Student[intake.Count];
            int s = 0;
            while (students.Any(x => x == null) && inputStudents.Length > 0)
                {
                int r = ind.Next(0, inputStudents.Length);

                if (students[r] == null)
                    {
                    students[r] = inputStudents[s]; //do this here so I can get s = 0 in the array
                    }
                else
                    {
                    List<int> nulls = new List<int>();
                    for (int _i = 0; _i < inputStudents.Count(); _i++) if (students[_i] == null) nulls.Add(_i); //get a list of null indices
                    if (nulls.Count() > 0) students[nulls.First()] = inputStudents[s]; //fill up the holes
                    }
                s++;
                s = s < inputStudents.Length ? s : 0; //increment the input index but don't go outside the bounds of the array!
                }

            return students.ToList();
            }
        }
    }
