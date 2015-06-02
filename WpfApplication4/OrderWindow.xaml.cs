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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        MainWindow mainWindow;

        public OrderWindow(MainWindow parentWindow)
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.

            mainWindow = parentWindow;
        }

        private void SendToKitchenButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            conformationWindow confirm = new conformationWindow();
            confirm.Top = this.Top + 220;
            confirm.Left = this.Left;
            mainWindow.completed.AddRange(mainWindow.order);
            mainWindow.order.Clear();
            confirm.messageLabel.Content = "Order has been sent to Kitchen.";
            confirm.Show();
        }
    }
}