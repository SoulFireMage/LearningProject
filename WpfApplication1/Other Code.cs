 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroSchool
    {/// <summary>
    /// Code I'm keeping in the project for my reference. And yes, I would run this lot in LinqPad. Slated for some other thing I guess.
    /// </summary>
    class Other_Code
        { 
        public Other_Code()
            { 
        StringBuilder sb = new StringBuilder();
        int[] numbers = new int[] { 1, 22, 5, 4, 3, 43, 32, 2, 6, 6, 7, 5, 5, 8, 6 };
        int findme = 5;
        //how many ways to count the occurrence of a number can you find ?
        //old school method one - beware of index out of range!
        int o = 0;
            for (int i = 0; i<numbers.Length; i++)
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
            sb.Append("\n\nAnd now we list Student grades! \n \n");
            //Why oh why did I name it Fred?!
            }

        //for future reference!
        private void nullableExample()
            {
            int? a = null;  //nullable type
            int b;
            if (a.HasValue) { b = a.Value; } else { b = 0; } //pre c# form of check
            int c = a ?? 0; //c6 alternative! nullable operator
            }

        //List<Tuple<string, string>> comparekids = new List<Tuple<string, string>>();
        //comparekids = test.Zip(OriginalList, (first, second) => new Tuple<string, string>(first.Name, second.Name)).ToList(); //this wasn't necessary but I wanted to practice the syntax!
        //StringBuilder sb = new StringBuilder();

        //comparekids.ForEach(x => sb.Append($"{x.Item1} : {x.Item2} \n"));
        //    Fred.Text = sb.ToString();
        }

//This left holes.
//for (int i = 0; i < intakeStudents.Count; i++)
//    {
//    int r = ind.Next(0, intakeStudents.Count);
//    students[r] = students[r] ?? intakeStudents.Where(x => intakeStudents.IndexOf(x) == i).FirstOrDefault();
//    }

//if (students.Where(x => x != null && x.Name == inputStudents[s].Name).FirstOrDefault() != null) failed attempt to do a good job of guaranteeing no matches!
//    { inputStudents = inputStudents.RemoveIndices(s); }; //For now I don't need any other equality comparer; normally I would!
public static class DreadedUtils
    {
    /// <summary>
    /// Remove an element from an array, old school style!
    /// </summary>
    /// <param name="incomingArray"></param>
    /// <param name="Removeindex"></param>
    /// <returns></returns>
    public static Student[] RemoveIndices(this Student[] incomingArray, int Removeindex)
        {
        Student[] _temp = new Student[incomingArray.Length - 1];
        int i = 0;
        int j = 0;
        while (i < incomingArray.Length)
            {
            if (i != Removeindex)
                {
                _temp[j] = incomingArray[i]; //you need a second index because your going to be sending back a shorter array and their length is immutable 
                j++;
                }
            i++;
            }
        return _temp;
        }

    public static Student[] AddIndices(this Student[] incomingArray, Student newItem)
        {

        Student[] _temp = new Student[incomingArray.Length];
        _temp[incomingArray.Length] = newItem;

        return _temp;
        }
    }

    }
