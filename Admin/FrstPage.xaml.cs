using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin
{
    /// <summary>
    /// Interaction logic for FrstPage.xaml
    /// </summary>
    public partial class FrstPage : Page
    {
        // object from database
        AdmindbEntities2 db = new AdmindbEntities2();


        public FrstPage()
        {
            // in constructor object from table 
            Employee employee = new Employee();
            InitializeComponent();
            MyDataGrid.ItemsSource = db.Employees.ToList();
        }

        private void InsertBut_Click(object sender, RoutedEventArgs e)
        {
            Employee rec = new Employee();
            rec.Emplyee_Name = Nametxt.Text;
            rec.EmployeeState = Statetxt.Text;
            db.Employees.Add(rec);
            db.SaveChanges();
            MyDataGrid.ItemsSource = db.Employees.ToList();

        }

        private void Updatebut_Click(object sender, RoutedEventArgs e)
        {
            Employee rec = new Employee();
            int IdfromText = int.Parse((string)IdTxt.Text);
            rec = db.Employees.First(x => x.ID == IdfromText);
            rec.ID = int.Parse(IdTxt.Text);
            rec.Emplyee_Name = Nametxt.Text;
            rec.EmployeeState = Statetxt.Text;
            db.Employees.AddOrUpdate(rec);
            db.SaveChanges();     
            MyDataGrid.ItemsSource = db.Employees.ToList();

        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            int idfromtxt = int.Parse(IdTxt.Text);
            Employee rec = db.Employees.Remove(db.Employees.First(x => x.ID == idfromtxt));
            db.SaveChanges();
            MyDataGrid.ItemsSource = db.Employees.ToList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Employee rec = new Employee();
            string Namesearch = Nametxt.Text;
            var r = db.Employees.Where( x=> x.Emplyee_Name == Namesearch).ToList();
            db.SaveChanges();
            MyDataGrid.ItemsSource = r;       
        }

        private void Nametxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
