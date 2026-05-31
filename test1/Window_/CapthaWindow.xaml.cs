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

namespace test1.Window_
{
    /// <summary>
    /// Логика взаимодействия для CapthaWindow.xaml
    /// </summary>
    public partial class CapthaWindow : Window
    {
        public bool OK { get; private set; }
        public CapthaWindow()
        {
            InitializeComponent();
        }

        private void Click(object s, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Image img)
            {
                var r = (RotateTransform)img.RenderTransform;
                r.Angle = (r.Angle + 90) % 360; // Крутим на 90°
                Check();                        // Проверяем, все ли встали
            }
        }

        private void Check()
        {
            // Кнопка включится ТОЛЬКО когда у всех картинок угол == 0
            Btn.IsEnabled = G.Children.OfType<Image>().All(i => ((RotateTransform)i.RenderTransform).Angle == 0);
        }

        private void Ok(object s, RoutedEventArgs e) { OK = true; Close(); }
    }
}
