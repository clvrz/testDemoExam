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
using test1.Data_;

namespace test1.Window_
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
            dgTab.ItemsSource = new TestCarDbEntities().Cars.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(((Button)sender).Uid, out var id)) return;

            switch (id)
            {
                case 1: dgTab.ItemsSource = new TestCarDbEntities().Cars.ToList(); break;
                case 2: new AddWindow().Show(); break;
                //case 3: new Edit().Show(); break;
                //case 4: new Delete().Show(); break;
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new TestCarDbEntities())
            {
                string text = tbSearch.Text.Trim();
                var data = string.IsNullOrEmpty(text)
                    ? db.Cars.ToList()
                    : db.Cars.Where(u => u.Model.Contains(text)).ToList();

                dgTab.ItemsSource = data;
            }
        }
    }
}
