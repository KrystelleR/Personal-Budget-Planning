/*
 PROG6221 POE 
 Group: 2
 Author: Krystelle Rupnarain (ST10091197)
 Lecturer: Siphesihle Sithungu
 Due: 30 June 2022
*/
using System;
using System.Collections.Generic;
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

namespace POE_ST10091197_KrystelleRupnarain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //declaring variables
        public static double monthlyIncome { get; set; }
        public static double monthlyTax { get; set; }

        //array for expenditures
        public static double groceries { get; set; }
        public static double waterandlights { get; set; }
        public static double travelcosts { get; set; }
        public static double cellphone { get; set; }
        public static double otherexpenses { get; set; }


        //generic collection of all expenses as well as expenses names
        public static List<double> expenses = new List<double>();
        public static List<String> expensesNames = new List<String>();

        public static double total;

        public static double totalExpenses;

        public static Boolean check = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            //using a try and catch statement for if user entered an invalid response (error handling)
            try
            {
                //getting input from user
                monthlyIncome = double.Parse(monthlyIncometxt.Text);
                monthlyTax = double.Parse(taxdeductedtxt.Text);
                groceries = double.Parse(groceriestxt.Text);
                waterandlights = double.Parse(waterandlightstxt.Text);
                travelcosts = double.Parse(travelcoststxt.Text);
                cellphone = double.Parse(cellphonetxt.Text);
                otherexpenses = double.Parse(otherexpensestxt.Text);
                check = true;
            }
            catch
            {
                //if user enters incorrect value
                MessageBox.Show("Enter a valid numerical value");
                check = false;
            }
           
            while (check==true)
            {
                //adding all expenses into expense arraylist
                expenses.Add(monthlyTax);
                expensesNames.Add("Monthly tax");
                expenses.Add(groceries);
                expensesNames.Add("Groceries");
                expenses.Add(waterandlights);
                expensesNames.Add("Water and Lights");
                expenses.Add(travelcosts);
                expensesNames.Add("Travel Costs");
                expenses.Add(cellphone);
                expensesNames.Add("Cellphone and telephone");
                expenses.Add(otherexpenses);
                expensesNames.Add("Other Expenses");
                //calculating total of expenses
                total = monthlyIncome - (monthlyTax + groceries + waterandlights + travelcosts + cellphone + otherexpenses);
               //calling homeloan form
                Homeloan hl = new Homeloan();
                hl.Show();
                //closing mainwindow
                Close();
                break;
            }

        }
    }
}
//References:
//Troelsen, A.and Japikse, P., n.d. Pro C# 9 with .NET 5.
