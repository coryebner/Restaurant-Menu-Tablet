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
using System.Windows.Shapes;

namespace WpfApplication4
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
        string orderDetails = "";
        MainWindow mainWindow;

        int quantity = 1;

		public Window1(MainWindow parentWindow)
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            mainWindow = parentWindow;
		}

        private void addToBillButton_Click(object sender, RoutedEventArgs e)
        {
            //Code to add to bill goes here

            Button sentBy = (Button)sender;

            conformationWindow confirm = new conformationWindow();
            confirm.Top = this.Top + 200;
            confirm.Left = this.Left - 350;

            if (SpecialRequestBox.Text != "Want your dish made in a special way? Add your comments here.")
            {
                confirm.messageLabel.Content = titleOfItemLabel.Content + " added to bill with Special Request";
                confirm.Show();
            }
            else
            {
                confirm.messageLabel.Content = titleOfItemLabel.Content +" Added to Bill";
                confirm.Show();
            }

            orderDetails = titleOfItemLabel.Content.ToString();

            //Adding everything to menus
            for (int i = 0; i < quantity; i++)
            {
                mainWindow.order.Add("- " + titleOfItemLabel.Content + "    " + costLabel.Content);
                mainWindow.totalCost.Add(Convert.ToDecimal(costLabel.Content.ToString().Replace("$", "")));
                
            }
            
            //mainWindow.totalCost.Add(Convert.ToDecimal(costLabel.Content.ToString()));

            this.Close();
        }

        private void lessItem_Click(object sender, RoutedEventArgs e)
        {
            if (quantity > 1)
            {
                quantity -= 1;
                quantityBox.Text = quantity.ToString();
            }
        }

        private void moreItem_Click(object sender, RoutedEventArgs e)
        {
                quantity += 1;
                quantityBox.Text = quantity.ToString();
           
        }
	}
}