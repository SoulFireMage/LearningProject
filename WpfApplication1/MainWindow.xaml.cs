using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows; 
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace SuperHeroSchool
{
    /// <summary>
    /// Welcome to Superhero school. It's a project created solely to learn how to do stuff. Various basic concepts are tried out
    /// including the latest C#6 syntax. As I practice I'll add more features. Eventually there will be a parallel MVC 5 app.
    /// All this app should do at the moment is try to build a school of superheroes with their grades. A chart should be added soon as well.,
    /// </summary>
    public partial class MainWindow : Window
        {

        public static RoutedCommand ViewStudent = new RoutedCommand();
        private School _school = new School();
        public School School { get { return _school; }  }

        public MainWindow()
        {
            InitializeComponent();
           
            StringBuilder sb = new StringBuilder(); // Not strictly necessary, could just update a string or the textbox directly
                                                    //for now.
            sb.Append("This is the class list for this year\n");
          foreach (StudentClass c in School.SuperHeroSchool)
                {
                sb.Append($"Class Name: {c.Name} \nDate:{System.DateTime.Today.ToShortDateString()}\n");
                foreach (Student student in c.Students)
                    {
                    sb.Append($"\n*** {student.Name}***\n");
                    foreach(var grade in student.Grades)
                        {
                        sb.Append($"{grade.Key} : {grade.Value} \n");
                        }
                    }
                }
            TitleText.AppendText("Welcome To the Super Hero Academy Student Grades Application");

            Wilma.Text = sb.ToString();
        }
        /// <summary>
        /// Here I'm reading in a file of superheroes, turn them into good little students and randomly assign them to classes.
        /// At time of writing the function is doing too much but it's an exercise - refactoring will be another exerise.
        /// </summary>
       
       

    //       'Private Sub OnItemSelected(sender As Object, e As RoutedEventArgs) Handles CarePlanTreeView.SelectedItemChanged
    //'    If IsNothing(CarePlanTreeView.SelectedItem) = False Then
    //'        Dim context = CarePlanTreeView.SelectedItem
    //'        Select Case context.[GetType]
    //'            Case GetType(CarePlan)
    //'                GetCarePlanContext(context)
    //'            Case GetType(Field)
    //'                GetFieldRcpdContext(context)
    //'            Case GetType(Rcpd)
    //'                GetRcpdContext(context)
    //'            Case Else
    //'                MessageBox.Show(CarePlanTreeView.SelectedItem.ToString())
    //'        End Select
    //'    End If
    //'End Sub
       
        }
 



   
    }
