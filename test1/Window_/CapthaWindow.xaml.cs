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
        bool CapthaPass = false;
        public CapthaWindow()
        {
            InitializeComponent();
        }

        private void CaptchGrid_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Image img && img.RenderTransform is RotateTransform rot)
            {
                rot.Angle = (rot.Angle + 90) % 360;
                CapthaPass = CaptchGrid.Children.OfType<Image>()
                    .All(i => ((RotateTransform)i.RenderTransform).Angle == 0);
            }

        }
    }
}
