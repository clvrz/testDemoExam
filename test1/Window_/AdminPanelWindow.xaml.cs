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
            LoadData();
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
        private void LoadData()
        {
            using (var db = new TestCarDbEntities())
            {
                dgTab.ItemsSource = db.Cars.ToList(); // 👈 Заменить Cars на нужную таблицу
            }
        }

        // ➕ Добавить
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var item = new Cars(); // 👈 Заменить Cars на нужный класс
            var dlg = new CRUDWindow(item, true); // true = новый
            if (dlg.ShowDialog() == true) LoadData();
        }

        // ✏️ Изменить
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTab.SelectedItem is Cars item)
            {
                var dlg = new CRUDWindow(item, false); // false = редактирование
                if (dlg.ShowDialog() == true) LoadData();
            }
            else MessageBox.Show("Выберите строку");
        }

        // 🗑️ Удалить
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgTab.SelectedItem is Cars item)
            {
                if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var db = new TestCarDbEntities())
                    {
                        db.Cars.Attach(item);
                        db.Cars.Remove(item);
                        db.SaveChanges();
                    }
                    LoadData();
                }
            }
            else MessageBox.Show("Выберите строку");
        }
    }
}
