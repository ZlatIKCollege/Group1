using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Xiaomi.Entities;


namespace Xiaomi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private group_1_is_31Context _dbContext = new group_1_is_31Context();
        private string _currentTable;

        public MainWindow()
        {
            new Auth().ShowDialog();

            InitializeComponent();
            CheckUser();

            _currentTable = "Пользователи";
            RefreshTable(_currentTable);
        }

        private void RefreshTable(string tableName)
        {
            switch (tableName)
            {
                case "Пользователи": 
                    _dbContext.Users.Load();
                    user.ItemsSource = _dbContext.Users.Local.ToObservableCollection();
                break;

                case "Роли":
                    _dbContext.Roles.Load();
                    role.ItemsSource = _dbContext.Roles.Local.ToObservableCollection();
                break;

                case "Клиенты":
                    _dbContext.Clients.Load();
                    clients.ItemsSource = _dbContext.Clients.Local.ToObservableCollection();
                break;

                case "Поставщики":
                    _dbContext.Suppliers.Load();
                    suppliiers.ItemsSource = _dbContext.Suppliers.Local.ToObservableCollection();
                break;

                case "Созданный товар":
                    _dbContext.Products.Load();
                    product.ItemsSource = _dbContext.Products.Local.ToObservableCollection();
                break;

                case "Продажи":
                    _dbContext.Sales.Load();
                    sale.ItemsSource = _dbContext.Sales.Local.ToObservableCollection();
                break;

            }
        }
        private void user_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch (headerName)
            {
                case "RoleId":
                    e.Column.Visibility= Visibility.Collapsed;
                break;

                case "Role":
                    e.Column.Visibility = Visibility.Collapsed;

                    _dbContext.Roles.Load();
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("RoleId");
                    DataGridComboBoxColumn col = new DataGridComboBoxColumn
                    {
                        Header = "Должность",
                        DisplayMemberPath = "NameRole",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Roles.ToArray(),
                        SelectedValueBinding = binding
                    };
                    ((DataGrid)sender).Columns.Add(col);
                    break;

                case "Surname":
                    e.Column.Header = "Фамилия";
                break;

                case "Name":
                    e.Column.Header = "Имя";
                break;

                case "Patronymic":
                    e.Column.Header = "Отчество";
                break;

                case "Login":
                    e.Column.Header = "Логин";
                break;

                case "Password":
                    e.Column.Header = "Пароль";
                break;

                case "Passport":
                    e.Column.Header = "Паспортные данные";
                break;

                case "Contact":
                    e.Column.Header = "Контактные данные";
                break;

                case "Birthday":
                    e.Column.Header = "День рождения";
                break;

                case "Address":
                    e.Column.Header = "Адрес";
                break;
            }
        }

        private void role_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch (headerName)
            {
                case "NameRole":
                    e.Column.Header = "Наименование должности";
                break;
            }
        }

        private void clients_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch(headerName)
            {
                case "NameComp":
                    e.Column.Header = "Компания";
                break;

                case "Contact":
                    e.Column.Header = "Контакты";
                break;

                case "Adress":
                    e.Column.Header = "Адрес";
                break;
            }
        }

        private void suppliiers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch(headerName)
            {
                case "Name":
                    e.Column.Header = "Наименования поставщика";
                break;

                case "Contact":
                    e.Column.Header = "Контакты";
                break;

                case "Adress":
                    e.Column.Header = "Адрес";
                break;
            }
        }

        private void product_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch (headerName)
            {
                case "Date":
                    e.Column.Header = "Дата";
                break;

                case "Surname":
                    e.Column.Header = "Фамилия";
                break;

                case "Name":
                    e.Column.Header = "Имя";
                break;

                case "Product1":
                    e.Column.Header = "Товар";
                break;

                case "KolVo":
                    e.Column.Header = "Количество";
                break;

                case "Summa":
                    e.Column.Header = "Сумма";
                break;
            }
        }

        private void sale_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();

            switch(headerName)
            {
                case "Date":
                    e.Column.Header = "Дата";
                    break;

                case "Client":
                    e.Column.Header = "Компания";
                    break;

                case "Product":
                    e.Column.Header = "Наименование товара";
                    break;

                case "KolVo":
                    e.Column.Header = "Количество";
                    break;

                case "Summa":
                    e.Column.Header = "Сумма";
                    break;
            }
        }

        private void Save_button(object sender, RoutedEventArgs e)
        {
            _dbContext.SaveChanges();
        }

        private void Delete_button(object sender, RoutedEventArgs e)
        {
            switch (_currentTable) {
                case "Пользователи":
                    _dbContext.Users.Local.Remove(user.SelectedItem as User);
                    break;
                case "Роли":
                    _dbContext.Roles.Local.Remove(role.SelectedItem as Role);
                    break;
                case "Клиенты":
                    _dbContext.Clients.Local.Remove(clients.SelectedItem as Client);
                    break;
                case "Поставщики":
                    _dbContext.Suppliers.Local.Remove(suppliiers.SelectedItem as Supplier);
                    break;
                case "Созданный товар":
                    _dbContext.Products.Local.Remove(product.SelectedItem as Product);
                    break;
                case "Продажи":
                    _dbContext.Sales.Local.Remove(sale.SelectedItem as Sale);
                    break;
            }
        }

        private void Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            _currentTable = ((TabItem)sender).Header.ToString();
            RefreshTable(_currentTable);
        }



        private void CheckUser()
        {
            switch (Auth.CurrentUser.RoleId)
            {
                case 1://Бухгалтер
                    roleTab.Visibility = Visibility.Collapsed;
                    break;
                case 2://Менеджер
                    userTab.Visibility = Visibility.Collapsed;
                    roleTab.Visibility = Visibility.Collapsed;
                    break;
                case 3://Управляющий
                    break;
                case 4://дистрибьютор
                    userTab.Visibility = Visibility.Collapsed;
                    roleTab.Visibility = Visibility.Collapsed;
                    break;
                case 5://Производитель
                    userTab.Visibility = Visibility.Collapsed;
                    roleTab.Visibility = Visibility.Collapsed;
                    saleTab.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private string GetUserFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV файлы | *.csv";
            ofd.Title = "Выберите файл для экспорта";

            if (ofd.ShowDialog() == true)
            {
                return ofd.FileName;
            }

            return null;
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string filepath = GetUserFile();

            if (filepath == null)
                return;
            StreamWriter file = new StreamWriter(filepath, false);

            switch (_currentTable)
            {
                case "Пользователи":
                    ObservableCollection<User> table = _dbContext.Users.Local.ToObservableCollection();


                    file.WriteLine($"ID;Логин;Пароль;РольИД");

                    foreach (User elem in table)
                    {
                        file.WriteLine($"{elem.Id};{elem.Login};{elem.Password};{elem.RoleId}");
                    }

                    break;
            }
            file.Close();
            MessageBox.Show("Экспорт успешно завершен", "Успешно");
        }
    }
    
}
