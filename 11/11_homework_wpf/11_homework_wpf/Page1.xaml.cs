using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;

namespace _11_homework_wpf
{
    public partial class Page1 : Page
    {
        public string path = "employees.xml";

        public string Whois(int whois)
        {
            string who = null;

            if (whois == 1)
            {
                who = "Менеджер";
            }
            if (whois == 2)
            {
                who = "Консультант";
            }

            return who;
        }

        public Page1()
        {
            InitializeComponent();  
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string auth = File.ReadAllText(@"account.txt");
            int role = int.Parse(auth);

            if (role == 1)
            {
                bankLabel.Text = "C# БАНК, Менеджер";
                passportW.Visibility = Visibility.Collapsed;
            }

            if (role == 2)
            {
                bankLabel.Text = "C# БАНК, Консультант";
                firstnamet.IsEnabled = false;
                lastnamett.IsEnabled = false;
                fathernamet.IsEnabled = false;
                passportt.Visibility = Visibility.Collapsed;
                passportW.IsEnabled = false;
                passportC.Width = 0;
                mobileC.Width = 220;
                deleteBTN.IsEnabled = false;
                createBTN.IsEnabled = false;
            }
            List<Person> list = Methods.DeserializePersonList(path);
            listView.ItemsSource = list;
            okbtn.Visibility = Visibility.Collapsed;
            hellouser.Visibility = Visibility.Collapsed;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var selectedItem = (Person)listView.SelectedItems[0];
                lastnamett.Text = selectedItem.LastName;
                firstnamet.Text = selectedItem.FirstName;
                fathernamet.Text = selectedItem.FatherName;
                mobilet.Text = selectedItem.Mobile;
                passportt.Text = selectedItem.Passport;
                passportW.Password = selectedItem.Passport;
                hellouser.Text = $"{listView.SelectedIndex}";
                comment.Text = selectedItem.Comment;
            }
        }

        private void createBTNc(object sender, RoutedEventArgs e)
        {
            string whois = Whois(int.Parse(File.ReadAllText(@"account.txt")));
            string created = $"Создано: {DateTime.Now} Кем: {whois}\n";
            Methods.AddElement(created, lastnamett.Text, firstnamet.Text, fathernamet.Text, mobilet.Text, passportt.Text);
            listView.ClearValue(ItemsControl.ItemsSourceProperty);
            List<Person> list = Methods.DeserializePersonList(path);
            listView.ItemsSource = list;
        }

        private void editBTNc(object sender, RoutedEventArgs e)
        {
            string whois = Whois(int.Parse(File.ReadAllText(@"account.txt")));
            string created = $"Дата: {DateTime.Now} Кем: {whois} Изменино:";
            Methods.EditElement(created, hellouser.Text, lastnamett.Text, firstnamet.Text, fathernamet.Text, mobilet.Text, passportt.Text);
            List<Person> list = Methods.DeserializePersonList(path);
            listView.ClearValue(ItemsControl.ItemsSourceProperty);
            listView.ItemsSource = list;
        }

        private void deleteBTNc(object sender, RoutedEventArgs e)
        {
            Methods.DeleteElement(hellouser.Text);
            List<Person> list = Methods.DeserializePersonList(path);
            listView.ClearValue(ItemsControl.ItemsSourceProperty);
            listView.ItemsSource = list;
        }
    }
}
