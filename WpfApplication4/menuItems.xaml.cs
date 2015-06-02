using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for menuItems.xaml
    /// </summary>
    ///
    
    public partial class menuItems : UserControl
    {
        MainWindow mainWindow;
        String s = "";
        Decimal finalResult;
        OrderWindow orderWindow;
        
        public menuItems(StackPanel usersItems, MainWindow parentWindow,OrderWindow currentOrderWindow )
        {
            this.InitializeComponent();
            mainWindow = parentWindow;
            orderWindow = currentOrderWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.order.Remove(itemLabel.Content.ToString());
            var result = Regex.Replace(itemLabel.Content.ToString(), "[^0-9.]", "");
            finalResult = Convert.ToDecimal(result);

            //MessageBox.Show(finalResult.ToString());

            mainWindow.totalCost.Add(-finalResult);

            decimal finalcost = 0;
            foreach (decimal itemCost in mainWindow.totalCost)
            {
                finalcost = finalcost + itemCost;
            }

            finalcost = finalcost + Convert.ToDecimal(73.50);

            orderWindow.TotalBillLabel.Content = "Total Bill : " + finalcost;

            this.Content = null;

        }
    }
}