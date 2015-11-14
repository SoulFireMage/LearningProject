using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Threading;
namespace SuperHeroSchool
{
    /// <summary>
    /// Welcome to Superhero school. It's a project created solely to learn how to do stuff. Various basic concepts are tried out
    /// including the latest C#6 syntax. As I practice I'll add more features. Eventually there will be a parallel MVC 5 app.
    /// All this app should do at the moment is try to build a school of superheroes with their grades. A chart should be added soon as well.,
    /// You'll also find two syntax styles for using simple async to get the data.
    /// </summary>
    public partial class MainWindow : Window
        {

        public static RoutedCommand ViewStudent = new RoutedCommand();
        private School _school = new School();
       

        public School School { get { return _school; }  }

        public MainWindow()
        {
            InitializeComponent();
            TitleText.AppendText("Welcome To the Super Hero Academy Student Grades Application");
            getHereosTask(); //gethereosTask2 is equivalent I believe!
        }
        /// <summary>
        /// Async style one: here we hide the need for the async inside lambdas :)
        /// Notice how the second method, Task<string> is NOT async.  Instead we just make a nice async lambda lambada!
        /// </summary>
          void getHereosTask()
            {
              Task<string> sb = Task.Run(async () => await getHeroes());
              Wilma.Text = sb.Result;
            }
        
           Task<string> getHeroes()
            {
            return   Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (StudentClass c in School.SuperHeroSchool)
                    {
                    sb.Append($"Class Name: {c.Name} \nDate:{DateTime.Today.ToShortDateString()}\n");
                    foreach (Student student in c.Students)
                        {
                        sb.Append($"\n*** {student.Name}***\n");
                        foreach (var grade in student.Grades)
                            {
                            sb.Append($"{grade.Key} : {grade.Value} \n");
                            }
                        }
                    }
                return sb.ToString();
            });
            }

        /// <summary>
        /// Non lambda version, the methods have to be async
        /// </summary>
        async void getHereosTask2()
            {
            Wilma.Text = await getHeroes2();
            }


        async Task<string> getHeroes2()
            {
            return await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (StudentClass c in School.SuperHeroSchool)
                    {
                    sb.Append($"Class Name: {c.Name} \nDate:{DateTime.Today.ToShortDateString()}\n");
                    foreach (Student student in c.Students)
                        {
                        //  Task.Delay(TimeSpan.FromMilliseconds(10)).Wait(); just for testing purposes
                        sb.Append($"\n*** {student.Name}***\n");
                        foreach (var grade in student.Grades)
                            {
                            sb.Append($"{grade.Key} : {grade.Value} \n");
                            }
                        }
                    }
                return sb.ToString();
            });
            }

        //only use for testing
        private void Drawing_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
            getHereosTask();
            }

        }
 



   
    }
