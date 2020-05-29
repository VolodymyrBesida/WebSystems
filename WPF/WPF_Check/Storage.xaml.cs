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
using System.Windows.Shapes;

namespace WPF_Check
{
    /// <summary>
    /// Логика взаимодействия для Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        public Storage()
        {
            InitializeComponent();
            List<StoredData.Storage.Query> data = StoredData.Storage.getStorage();

            TextBlock txt = new TextBlock();
            foreach(StoredData.Storage.Query info in data)
            {
                txt.Text = $"\n---\nID: {info.Id}\nQuestion: {info.Question}\n" +
                                 $"Answear: {info.Answear}\n---";
                storageContainer.Children.Add(txt);

                txt = new TextBlock();
            }
            

        }

        private void queriesCheck_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwnd = new MainWindow();
            mwnd.Show();

            this.Close();
        }
    }
}
