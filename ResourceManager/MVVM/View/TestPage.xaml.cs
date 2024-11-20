using ResourceManager.Core;
using ResourceManager.Data;
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

namespace ResourceManager.MVVM.View
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : UserControl

    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Names names = new Names
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
            };

            NamesData.AddNamesToDb(names);

        }
    }
}