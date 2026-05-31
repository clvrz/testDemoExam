using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    /// Логика взаимодействия для CRUDWindow.xaml
    /// </summary>
    public partial class CRUDWindow : Window
    {
        private Cars _item;
        private bool _isNew;
        public CRUDWindow(Cars item, bool isNew)
        {
            InitializeComponent();
            _item = item;
            _isNew = isNew;

            // Заполняем поля данными
            if (!_isNew)
            {
                tbBrand.Text = _item.Brand;
                tbModel.Text = _item.Model;
                tbYear.Text = _item.Year.ToString();
                tbPlate.Text = _item.LicensePlate;
                tbPrice.Text = _item.Price?.ToString();
            }
        }
        private void Save(object s, RoutedEventArgs e)
        {
            // Простая валидация
            if (string.IsNullOrWhiteSpace(tbBrand.Text)) { MessageBox.Show("Введите марку"); return; }

            // Записываем данные обратно в объект
            _item.Brand = tbBrand.Text;
            _item.Model = tbModel.Text;
            _item.Year = int.TryParse(tbYear.Text, out var y) ? y : 2020;
            _item.LicensePlate = tbPlate.Text;
            _item.Price = decimal.TryParse(tbPrice.Text, out var p) ? p : 0;

            using (var db = new TestCarDbEntities())
            {
                if (_isNew) db.Cars.Add(_item);
                else db.Entry(_item).State = EntityState.Modified;
                db.SaveChanges();
            }
            DialogResult = true;
            Close();
        }

        private void Cancel(object s, RoutedEventArgs e) { DialogResult = false; Close(); }
    }
}
