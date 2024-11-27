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
            BudgetClass budget = new BudgetClass
            {
                StartDate = (DateTime)StartDatePicker.SelectedDate,
                EndDate = (DateTime)EndDatePicker.SelectedDate,
                BudgetAmount = double.Parse(TotalBudgetTextBox.Text)
            };

            budgetList.Add(budget);

            BudgetListView.ItemsSource = budgetList;

            UpdateFlyout.CloseButtonVisibility=Visibility.Hidden;

            BudgetStackPanel.Visibility=Visibility.Collapsed;

            UpdateFlyout.IsOpen=true;
        }

    }
}
