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

namespace LabSheet4_Execerise_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities db = new Entities();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from o in db.SalesOrderHeaders
                        orderby o.Customer.CompanyName

                        select o.Customer.CompanyName;


            lbxCustomers.ItemsSource = query.ToList().Distinct();


        }

        private void lbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int OrderID = Convert.ToInt32(lbxCustomers.SelectedValue);

                if (OrderID > 0)
            {
                var query = from od in db.SalesOrderDetails
                            where od.SalesOrderID == OrderID
                            select new
                            {
                                ProductName = od.Product.Name,
                                od.UnitPrice,
                                od.UnitPriceDiscount,
                                od.OrderQty,
                                od.LineTotal


                            };

                dgOrdersDetails.ItemsSource = query.ToList();

            }

                


        }

        private void lbxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string customer = lbxCustomers.SelectedItem as string;

            if (customer != null)
            {
                var query = from o in db.SalesOrderHeaders
                            where o.Customer.CompanyName.Equals(customer)
                            select o;

                lbxOrders.ItemsSource = query.ToList();

            }


        }




    }
}
