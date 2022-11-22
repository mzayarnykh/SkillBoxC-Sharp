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
using System.IO;

namespace _11_homework_wpf
{
    public partial class MainWindow : Window
    {
        private Page1 p2;

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            var ms = new Methods();
            p2 = new Page1();
            Methods.CreateFile("account.txt");
            bool passed = ms.UserAuth(username.Text, password.Text);

            if (passed)
            {
                loginForm.Visibility = Visibility.Collapsed;
                information.Visibility = Visibility.Collapsed;
                MainFrame.Content = p2;
            }
            else
            {
                errorblock.Text = "не правлиное имя пользователя или пароль";
            }

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
