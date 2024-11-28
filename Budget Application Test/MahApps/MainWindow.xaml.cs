using MahApps.Business_Logic;
using MahApps.Metro.Controls;
using MahApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MahApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public string RemainingBalance { get; set; }

        public ObservableCollection<BudgetClass> budgetList;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            double Balance = 1600;
            RemainingBalance = $"${Balance}";

            budgetList = new ObservableCollection<BudgetClass>();

            MahApps.Core.DbCommands.InitializeDb();
        }

        private void NewBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            if ((BudgetStackPanel.Visibility) == Visibility.Collapsed)
                    {
                     BudgetStackPanel.Visibility = Visibility.Visible;
                    }
        }

        private void CreateBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            string ErrorMessage = BudgetValidation.ValidateBudget(TotalBudgetTextBox.Text, StartDatePicker.SelectedDate, EndDatePicker.SelectedDate);

                if (ErrorMessage != "")
            {
                ShowError(ErrorMessage);
                return;
            }

            BudgetClass budget = new BudgetClass
            {
                StartDate = (DateTime)StartDatePicker.SelectedDate,
                EndDate = (DateTime)EndDatePicker.SelectedDate,
                BudgetAmount = double.Parse(TotalBudgetTextBox.Text)
            };



            string StartDateStr = budget.StartDate.ToString();
            string EndDateStr = budget.EndDate.ToString();
            StartDateStr = "\"" + StartDateStr + "\"";
            EndDateStr = "\"" + EndDateStr + "\"";

            budgetList.Add(budget);
            MahApps.Core.DbCommands.DataInDb(StartDateStr, EndDateStr, budget.BudgetAmount);

            BudgetListView.ItemsSource = budgetList;

            ShowSuccess();
        }

        private void ShowError(string Error)
        {
            UpdateFlyout.Background = Brushes.Red;
            FlyOutTextBlock.Text = Error;
            UpdateFlyout.AutoCloseInterval = 3000;
            UpdateFlyout.CloseButtonVisibility = Visibility.Hidden;

            UpdateFlyout.IsOpen = true;
        }

        private void ShowSuccess()
        {
            UpdateFlyout.Background = Brushes.Green;
            FlyOutTextBlock.Text = "Added Budget Successfully";

            UpdateFlyout.CloseButtonVisibility = Visibility.Hidden;

            BudgetStackPanel.Visibility = Visibility.Collapsed;

            UpdateFlyout.IsOpen = true;
        }
    }
}
