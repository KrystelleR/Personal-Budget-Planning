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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public static String display;
        public Report()
        {
            expensesDescOrder();
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            //closing report 
            Close();
        }

        //method putting expeneses in descending order
        public static void expensesDescOrder()
        {
            //bubble sort algorithm to put expense generic collection in descending order
            double tempVar;
            String tempName;
            for (int i = 0; i < MainWindow.expenses.Count - 1; i++)
            {
                for (int j = 0; j < MainWindow.expenses.Count - i - 1; j++)
                {
                    if (MainWindow.expenses[j] < MainWindow.expenses[j + 1])
                    {
                        tempVar = MainWindow.expenses[j + 1];
                        MainWindow.expenses[j + 1] = MainWindow.expenses[j];
                        MainWindow.expenses[j] = tempVar;

                        tempName = MainWindow.expensesNames[j + 1];
                        MainWindow.expensesNames[j + 1] = MainWindow.expensesNames[j];
                        MainWindow.expensesNames[j] = tempName;
                    }
                }
            }

            //displaying the generic collection
            Console.WriteLine("\n*** Expenses in descending order ***");
            display="";
            for (int i = 0; i < MainWindow.expenses.Count; i++)
            {
                display= display +MainWindow.expensesNames[i] + ": R "+ MainWindow.expenses[i] + "\n\n";
            }     
        }

        private void SaveUpbtn_Click(object sender, RoutedEventArgs e)
        {
            //opening up saveup class
            SaveUp s = new SaveUp();
            s.Show();
            //closing report
            Close();
        }
    }
}
//References:
//Troelsen, A.and Japikse, P., n.d. Pro C# 9 with .NET 5.
