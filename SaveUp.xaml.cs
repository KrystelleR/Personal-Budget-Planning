/*
 PROG6221 POE 
 Group: 2
 Author: Krystelle Rupnarain (ST10091197)
 Lecturer: Siphesihle Sithungu
 Due: 30 June 2022
*/
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SaveUp.xaml
    /// </summary>
    public partial class SaveUp : Window
    {
        //declaring variables
        public static String goalName { get; set; }
        public static double goalAmount { get; set; }
        public static int SaveInterest { get; set; }
        public static int date { get; set; }
        public static int MonthlyGoal { get; set; }
        //boolean that allows the next code to run when value are correct
        public static Boolean check = false;
        public SaveUp()
        {
            InitializeComponent();
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            //closing saveup class
            Close();
        }

        private void Submitbtn_Click(object sender, RoutedEventArgs e)
        {
            //using a try and catch statement for if user entered an invalid response (error handling)
            try
            {
                goalName = goalNametxt.Text;
                goalAmount = double.Parse(goalAmounttxt.Text);
                SaveInterest = int.Parse(SaveInteresttxt.Text);
                DateTime EndDate = goalDateDP.SelectedDate.Value;
                DateTime StartDate = DateTime.UtcNow;
                date = (EndDate.Date - StartDate.Date).Days;
                check = true;
            }
            catch
            {
                MessageBox.Show("Enter a valid numerical value.");
                check = false;
            }
            //displaying monthly save
            if(check == true)
            {
                monthlySavingslbl.Content = ("R " + MonthlySave());
                monthlySavingslbl.Visibility = Visibility.Visible;
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                rec1.Visibility = Visibility.Visible;
                Exitbtn.Visibility = Visibility.Visible;
                UpdateLayout();
            }

        }
        //calculating monthly savings
        public static double MonthlySave()
        {
            //calculation derived from calculater found:
            //Financial Mentor. 2022. Savings Account Calculator - How Long To Reach My Goal. [online] Available at: <https://financialmentor.com/calculator/savings-account-calculator> [Accessed 30 June 2022].

            //calculating total repayment
            double monthlySavings = (goalAmount - (goalAmount /100) *SaveInterest)/(date/30);
            //calculating monthly repayment           
            monthlySavings = Math.Round(monthlySavings, 2, MidpointRounding.AwayFromZero);
            return monthlySavings;
        }
    }
}
//References:
//Troelsen, A.and Japikse, P., n.d. Pro C# 9 with .NET 5.
