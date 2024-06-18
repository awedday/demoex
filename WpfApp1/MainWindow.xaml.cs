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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Session1_XXEntities db = new Session1_XXEntities();
        public MainWindow()
        {
            InitializeComponent();
            Data_Reload();
        }

        public void Data_Reload()
        {
            var userList = db.Users.ToList();
            DataUsers.SelectedValuePath = "ID";
            DataUsers.ItemsSource = userList;
            DataUsers.SelectionMode = DataGridSelectionMode.Single;


            var OfficeList = db.Offices.ToList();
            Parametr.ItemsSource = OfficeList;
            Parametr.SelectedIndex = 0;
            Parametr.SelectedValuePath = "ID";
            Parametr.DisplayMemberPath = "Title";

            All.Text = userList.Count.ToString();

            double AverageCout = 0;
            foreach(var user in userList)
            {
                AverageCout += user.ID;
            }
            if(AverageCout != 0)
            {
                AverageCout /= userList.Count;
            }
            Average.Text = AverageCout.ToString();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var userList = db.Users.Where(a =>a.FirstName.Contains(Search.Text)).ToList();
            DataUsers.SelectedValuePath = "ID";
            DataUsers.ItemsSource = userList;
            DataUsers.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Parametr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Parametr.ActualHeight != 0 )
            {
                int OfficeId = (int)Parametr.SelectedValue;
                var userList = db.Users.Where(a => a.Offices.ID == OfficeId).ToList();
                DataUsers.SelectedValuePath = "ID";
                DataUsers.ItemsSource = userList;
                DataUsers.SelectionMode = DataGridSelectionMode.Single;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Users selectedItem = (Users)  DataUsers.SelectedItem;
            db.Users.Remove(selectedItem);
            db.SaveChanges();
            DataUsers.Items.Refresh();
            Data_Reload();
            
        }

        private void DataUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data_Reload();
            if (DataUsers.SelectedValuePath != null)
            {

            }
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            Roles apl = new Roles();
            {
                apl.Title = RoleName.Text;
               
            };
            db.Roles.Add(apl);
            db.SaveChanges();
            MessageBox.Show("Данные добавлены");
            Data_Reload();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Data_Reload();
            var apl = DataUsers.SelectedItem as Roles;
            if (DataUsers.SelectedValuePath != null)
            {
                apl.Title = RoleName.Text;

            }
        }
    }
}
