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
    /// Interaction logic for Homeloan.xaml
    /// </summary>
    public partial class Homeloan : Window
    {
        //declaring variables
        public static double rentalAmount { get; set; }
        public static double HomePurchasePrice { get; set; }
        public static double deposit { get; set; }
        public static int interest { get; set; }
        public static int months { get; set; }
        public static double monthlyRepayment { get; set; }

        //booleans that check  when values are corretly entered
        public static Boolean rent = false;
        public static Boolean buy = false;
        public static Boolean submit = false;
        public static Boolean check = true;
        public Homeloan()
        {
            InitializeComponent();
        }

        private void rentradbtn_Checked(object sender, RoutedEventArgs e)
        {
            //displaying inputs for if user selected rent
            if (submit == false)
            {
                rent = true;
                buy = false;
                rentlbl.Visibility = Visibility.Visible;
                rentalAmounttxt.Visibility = Visibility.Visible;
                submitbtn.Margin = new Thickness(0, 234, 0, 0);
                submitbtn.HorizontalAlignment = HorizontalAlignment.Center;
                submitbtn.Visibility = Visibility.Visible;
                rentalRec.Visibility = Visibility.Visible;
                buyRec.Visibility = Visibility.Hidden;

                purchasePricelbl.Visibility = Visibility.Hidden;
                purchasePricetxt.Visibility = Visibility.Hidden;
                depositlbl.Visibility = Visibility.Hidden;
                deposittxt.Visibility = Visibility.Hidden;
                interestlbl.Visibility = Visibility.Hidden;
                interesttxt.Visibility = Visibility.Hidden;
                monthslbl.Visibility = Visibility.Hidden;
                monthslide.Visibility = Visibility.Hidden;
                Currentlbl.Visibility = Visibility.Hidden;
                Currenttxt.Visibility = Visibility.Hidden;
                UpdateLayout();
            }
        }

        private void buyradbtn_Checked(object sender, RoutedEventArgs e)
        {
            //displaying inputs if user selected buy
            if (submit == false)
            {
                buy = true;
                rent = false;
                rentlbl.Visibility = Visibility.Hidden;
                rentalAmounttxt.Visibility = Visibility.Hidden;
                submitbtn.Margin = new Thickness(188, 216, 0, 0);
                submitbtn.HorizontalAlignment = HorizontalAlignment.Left;
                submitbtn.Visibility = Visibility.Visible;
                rentalRec.Visibility = Visibility.Hidden;
                buyRec.Visibility = Visibility.Visible;

                purchasePricelbl.Visibility = Visibility.Visible;
                purchasePricetxt.Visibility = Visibility.Visible;
                depositlbl.Visibility = Visibility.Visible;
                deposittxt.Visibility = Visibility.Visible;
                interestlbl.Visibility = Visibility.Visible;
                interesttxt.Visibility = Visibility.Visible;
                monthslbl.Visibility = Visibility.Visible;
                monthslide.Visibility = Visibility.Visible;
                Currentlbl.Visibility = Visibility.Visible;
                Currenttxt.Visibility = Visibility.Visible;
                UpdateLayout();
            }
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            //allowing user to only submit once
            if (submit == false)
            {
                //for renters
                if (rent)
                {
                    //using a try and catch statement for if user entered an invalid response (error handling)
                    try
                    {
                        rentalAmount = double.Parse(rentalAmounttxt.Text);
                        check = true;
                    }
                    catch
                    {
                        MessageBox.Show("Enter a valid numerical value");
                        check = false;
                    }
                    while (check == true)
                    {
                        MainWindow.expenses.Add(rentalAmount);
                        MainWindow.expensesNames.Add("Monthly Rental Amount");

                        RentalMonthlyAmountlbl.Visibility = System.Windows.Visibility.Visible;
                        RentalMonthlyAmountlbl.Content = "R " + rentCalc();

                        displayRentRec.Visibility = Visibility.Visible;
                        amountlbl.Visibility = Visibility.Visible;
                        VehicleBtn.Visibility = Visibility.Visible;
                        reportbtn.Visibility = Visibility.Visible;
                        
                        submit = true;
                        break;
                    }
                }
                //for buyers
                else if (buy)
                {
                    //using a try and catch statement for if user entered an invalid response (error handling)
                    try
                    {
                        HomePurchasePrice = int.Parse(purchasePricetxt.Text);
                        deposit = int.Parse(deposittxt.Text);
                        interest = int.Parse(interesttxt.Text);
                        months = int.Parse(Currenttxt.Text);
                        check = true;
                    }
                    catch
                    {
                        MessageBox.Show("Enter a valid numerical value");
                        check = false;
                    }
                    while (check == true)
                    {
                        MainWindow.expenses.Add(MonthlyRepayment());
                        MainWindow.expensesNames.Add("Monthly Repayment Amount");

                        monthlyRepaylbl.Visibility = Visibility.Visible;
                        monthlyRepaymentlbl.Visibility = System.Windows.Visibility.Visible;                
                        monthlyRepaymentlbl.Content = "R " + MonthlyRepayment();

                        avaliableRepaylbl.Visibility = Visibility.Visible;
                        availableRepaymentlbl.Visibility = System.Windows.Visibility.Visible;
                        availableRepaymentlbl.Content = "R " + buyCalc();

                        displayBuyRec.Visibility = Visibility.Visible;
                        VehicleBtn.Visibility = Visibility.Visible;
                        reportbtn.Visibility = Visibility.Visible;
                        UpdateLayout();
                        submit = true;

                        //if user repayment is more then a third of user income
                        if (MonthlyRepayment() > (MainWindow.monthlyIncome / 3))
                        {
                            MessageBox.Show("\nThe approval of the loan is unlikely.");
                        }

                        break;
                    }
                }
                else
                {
                    MessageBox.Show("You have already submitted");
                }
            }

        }
        //method to calculate monthly repayments for rent
        public static double rentCalc()
            {
             //using Math.Round to round up amount available to 2 decimal places
             double avaliable = Math.Round((MainWindow.total - rentalAmount), 2, MidpointRounding.AwayFromZero);
             return avaliable;
        }
        //method to calculate monthly repayements for buy
        public static double buyCalc()
        {
            //using Math.Round to round up amount available to 2 decimal places
            double avaliable = Math.Round((MainWindow.total - MonthlyRepayment()), 2, MidpointRounding.AwayFromZero);
            return avaliable;
        }

        //method that returns monthlyRepayments
        public static double MonthlyRepayment()
        {
            //calculating total repayment
            double x = HomePurchasePrice - deposit;
            double repayment = x * (1 + (interest * 0.01) * (months / 12));
            //calculating monthly repayment           
            monthlyRepayment = Math.Round((repayment / months), 2, MidpointRounding.AwayFromZero);
            return monthlyRepayment;
        }

        //if users wants to open report class
        private void reportbtn_Click(object sender, RoutedEventArgs e)
            {
            //opening report class
            Report r = new Report();
            r.Show();
            //displaying all expenses
            Report.expensesDescOrder();
            r.displaylbl.Content =Report.display;
            //closing homeloan
            Close();
        }

        private void VehicleBtn_Click(object sender, RoutedEventArgs e)
        {
            //if user wants to loan a vehicle
            Vehicle v = new Vehicle();
            v.Show();
            //closing homeloan
            Close();
        }
    }
}
//References:
//Troelsen, A.and Japikse, P., n.d. Pro C# 9 with .NET 5.


