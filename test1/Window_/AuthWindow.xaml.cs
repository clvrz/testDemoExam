using System;
using System.Collections.Generic;
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
using test1.Material_.Models;

namespace test1.Window_
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AuthService.Auth(logintb.Text, passtb.Password))
            {
                if (new TestCarDbEntities().Users.FirstOrDefault(u => u.Login == logintb.Text).RoleID == 1)
                {
                    new Window_.AdminPanelWindow().Show();
                    this.Close();
                }
                else
                {
                    new Window_.UsersWindow().Show();
                    this.Close();
                }
            }
            else
            {
                errortb.Text = "Неверный логин или пароль";
            }
        }
    }
}
