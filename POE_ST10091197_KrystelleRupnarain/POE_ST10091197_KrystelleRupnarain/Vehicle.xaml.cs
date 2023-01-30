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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POE_ST10091197_KrystelleRupnarain
{
    /// <summary>
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Window
    {
        //declaring variables
        public static String Model { get; set; }
        public static String Make { get; set; }
        public static double CarPurchasePrice { get; set; }
        public static double TotalDeposit { get; set; }
        public static int carInterest { get; set; }
        public static double insurance { get; set; }
        public static double monthlyCost { get; set; }
        //delegate for notification
        public delegate void notifyPtr();
        //boolean to make sure values are correct before moving on to other code
        public static Boolean check = false;
        public Vehicle()
        {
            InitializeComponent();
        }

        private void sumbitbtn_Click(object sender, RoutedEventArgs e)
        {
            //using a try and catch statement for if user entered an invalid response (error handling)
            try
            {
                Model = (modeltxt.Text);
                Make = (maketxt.Text);
                CarPurchasePrice = double.Parse(purchasePricetxt.Text);
                TotalDeposit = double.Parse(Deposittxt.Text);
                carInterest = int.Parse(Interesttxt.Text);
                insurance = double.Parse(insurancetxt.Text);
                check = true;
            }
            catch
            {
                check = false;
                MessageBox.Show("Please enter a numerical value");
            }
            //while loop that will only run if values are true
            while(check == true){
                monthlyCostlbl.Visibility = Visibility.Visible;
                carMonthlylbl.Visibility = System.Windows.Visibility.Visible;
                displayRec.Visibility = Visibility.Visible;
                carMonthlylbl.Content = "R " + totalMonthlyCost();
                nextbtn.Visibility = Visibility.Visible;
                sumbitbtn.Visibility = Visibility.Hidden;
                //invoking delegate
                notifyPtr obj = new notifyPtr(notify);
                obj.Invoke();
                break;
            }
        }

        //method that calculates total monthly cost of vehicle
        public static double totalMonthlyCost()
        {
            //calculating the total loan repayment
            double loanRepayment = CarPurchasePrice * (1 + (carInterest * 0.01) * (5));
            //calculating the loan repayment per month
            loanRepayment = loanRepayment / 60;
            monthlyCost = Math.Round((loanRepayment + insurance), 2, MidpointRounding.AwayFromZero);
            MainWindow.expenses.Add(monthlyCost);
            MainWindow.expensesNames.Add("Monthly cost of car (incl. insurance premium)");
            return monthlyCost;
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            //opening report class
            Report r = new Report();
            r.Show();
            //displaying expenses in descending order
            Report.expensesDescOrder();
            r.displaylbl.Content = Report.display;
            Close();
        }

        //method notifying user if their expenses is more then 75% of the income
        public static void notify()
        {
            if (calcTotalExpenses() > ((MainWindow.monthlyIncome * 75) / 100))
            {
                MessageBox.Show("Total expenses are more than 75% of your income (including loan repayments)");
            }

        }

        //method calculating total expenses
        public static double calcTotalExpenses()
        {
            double TotalExpenses = MainWindow.expenses.Sum();
            return TotalExpenses;
        }

    }
}
//References:
//Troelsen, A.and Japikse, P., n.d. Pro C# 9 with .NET 5.

