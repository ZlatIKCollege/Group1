using Microsoft.EntityFrameworkCore;
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


namespace Xiaomi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private group_1_is_31Context _dbContext = new group_1_is_31Context();
        private string _userTable;
        private string _roleTable;
        private string _clientsTable;
        private string _suppliersTable;
        private string _productTable;
        private string _saleTable;
        public MainWindow()
        {
            InitializeComponent();
            _userTable = "Пользователи";
            _roleTable = "Роли";
            _clientsTable = "Клиенты";
            _suppliersTable = "Поставщики";
            _productTable = "Созданный товар";
            _saleTable = "Продажи";
            RefreshTable(_userTable);
            RefreshTable(_roleTable);
            RefreshTable(_clientsTable);
            RefreshTable(_suppliersTable);
            RefreshTable(_productTable);
            RefreshTable(_saleTable);
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
                case "role":
                    e.Column.Header = "Должность";
                    break;
            }
        }
    }
}
