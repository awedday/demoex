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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }
        public Session1_XXEntities db = new Session1_XXEntities();
        private void AuthBt_Click(object sender, RoutedEventArgs e)
        {
            
                var userList = db.Users.Where(a => (a.Email.Contains(Email.Text)) && a.Password.Contains(Password.Text)).ToList();
                if (userList.Count != 0)
                {
                    try
                    {
                        foreach (var user in userList)
                        {
                            if (user.RoleID == 1)
                            {
                                MainWindow main = new MainWindow();
                                main.Show();
                                this.Close();
                            }
                            else if (user.RoleID == 2)
                            {
                                MessageBox.Show("вы пользователь");

                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль");

                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            
        }      
    }
}
