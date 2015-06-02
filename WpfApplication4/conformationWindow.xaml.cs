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
	/// Interaction logic for conformationWindow.xaml
	/// </summary>
	public partial class conformationWindow : Window
	{
		public conformationWindow()
		{
			this.InitializeComponent();
     
			
			// Insert code required on object creation below this point.
		}

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            if (messageLabel.Content.ToString() == "Please enter your name,\nand the amount of people needing a cab.")
            {
                if (String.IsNullOrEmpty(NameTextBox.Text) || NameTextBox.Text=="Your Name")
                { 
                    MessageBox.Show("Please enter your Name");
                }
                else
                    this.Close();
            }
            else
                this.Close();
        }
	}
}