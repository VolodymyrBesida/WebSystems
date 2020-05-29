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

namespace WPF_Check
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void querySubmit_Click(object sender, RoutedEventArgs e)
        {
            string query = queryField.Text;
            int answear = MyLibrary.Convertator.convertString_Reversed(query);
            StoredData.Storage.toStore(query, answear);

            queryField.Text = "";
            MessageBox.Show($"Your result is: {answear}");
        }

        private void queriesCheck_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = new Storage();
            storage.Show();

            this.Close();
        }
    }
}
