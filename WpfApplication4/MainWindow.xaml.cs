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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
    /// 
	public partial class MainWindow : Window
	{
        public List<string> order = new List<string>();   //the current users order
        public List<decimal> totalCost = new List<decimal>();   //the current users order
        public List<string> completed = new List<string>(); // the items that have been ordered
        public int menuNumber = 0;
        public bool LeftSelected = false;
        public bool MidSelected = false;
        public bool RightSelected = false;
        public int miniClick = -1;
        
		public MainWindow()
		{
			this.InitializeComponent();
			// Insert code required on object creation below this point.

            
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button sentBy = (Button)sender;
            String exePath = System.IO.Directory.GetCurrentDirectory();
            //New Window
            Window1 sidemen = new Window1(this);
            sidemen.Left = this.Left+720;
            sidemen.Top = this.Top + 125;
            sidemen.Show();
            sidemen.titleOfItemLabel.Content = sentBy.Content;

            if (sentBy.Content.ToString() == "Cheese Truffles with Chives")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Visible;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Hidden;
                //setting the image
                
                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image1.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo; 

                sidemen.descriptionBox.Text = "\nThey may look as cute as holiday chocolates, but these mini cheese balls are made for those of us who love a little cayenne and sharp Cheddar on our party plate";
                sidemen.costLabel.Content = "$17.50";

            }
            
            else if (sentBy.Content.ToString() =="Caesar Salad")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Hidden;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Visible;
                //setting the image

                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image2.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo; 

                sidemen.descriptionBox.Text = "\n A salad of romaine lettuce and croutons dressed with parmesan cheese, lemon juice, olive oil, egg, Worcestershire sauce, garlic, and black pepper.";
                sidemen.costLabel.Content = "$13.50";

            }

            else if (sentBy.Content.ToString() == "Clam Chowder")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Hidden;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Visible;
                //setting the image

                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image3.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo; 

                sidemen.descriptionBox.Text = "\nA delicious, traditional, cream based chowder, this recipe calls for the standard chowder is made up of the following: onion, celery, potatoes, diced carrots, clams, and cream. A little red wine vinegar is added before serving for extra flavor.";
                sidemen.costLabel.Content = "$15.50";

            }

            else if (sentBy.Content.ToString() == "Grilled Flap Steak/Pom and Feta")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Hidden;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Hidden;
                //setting the image

                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image4.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo; 

                sidemen.descriptionBox.Text = "\nOur Steak from the finest nitrate  infused animals.  ";
                sidemen.costLabel.Content = "$27.50";

            }

            else if (sentBy.Content.ToString() == "Blueberry Cobbler/Lav Whip Cream")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Visible;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Hidden;
                //setting the image

                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image5.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo;  

                sidemen.descriptionBox.Text = "\nThis blueberry cobbler is just the ticket for channeling a Downeast summer meal. The crust on top is made of flaky, tender cream biscuits that deliver a hint of salty sweetness and just a bit of crunch. The berries bubble up around the biscuits, spilling over the sides with tart, purple juices. You can either bake one large cobbler to spoon out onto plates, or make individual mini-cobblers in heatproof ramekins. Pull from the oven, spoon with freshly whipped cream, and serve warm, just as the sun begins to set.";
                sidemen.costLabel.Content = "$16.75";

            }

            else if (sentBy.Content.ToString() == "Dom Perignon")
            {
                sidemen.Peanut.Visibility = System.Windows.Visibility.Hidden;
                sidemen.Gluten.Visibility = System.Windows.Visibility.Hidden;
                //setting the image

                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(exePath + @"\image6.jpg");
                logo.EndInit();
                sidemen.foodImage.Source = logo; 

                sidemen.descriptionBox.Text = "\nPérignon was born to a clerk of the local marshal in the town of Saint-Menehould in the ancient Province of Champagne in the Kingdom of France. Now he makes champagne ";
                sidemen.costLabel.Content = "$575.00";

            }
            
        }

        private void orderInfoButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWin = new OrderWindow(this);
            decimal finalCost = 0;
            if (order.Count == 0)
            {
                orderWin.SendToKitchenButton.Visibility = System.Windows.Visibility.Hidden;
            }

            foreach (string item in completed)
            {
                menuItems usersOrderedItems = new menuItems(orderWin.usersOrderStackPanel, this, orderWin);
                usersOrderedItems.RemoveButton.Visibility = System.Windows.Visibility.Hidden;
                usersOrderedItems.itemLabel.Content = item;
                usersOrderedItems.itemLabel.Foreground = Brushes.Green;
                orderWin.usersOrderStackPanel.Children.Add(usersOrderedItems);
            }
            
            foreach (string item in order)
            {
                menuItems usersOrderedItems = new menuItems(orderWin.usersOrderStackPanel, this, orderWin);
                usersOrderedItems.itemLabel.Content = item;
                orderWin.usersOrderStackPanel.Children.Add(usersOrderedItems);
            }

            foreach (decimal itemCost in totalCost)
            {
                finalCost = finalCost + itemCost;
            }
            finalCost = finalCost + Convert.ToDecimal(73.50);
            orderWin.TotalBillLabel.Content = "Total Bill : " + finalCost.ToString();

            //orderWin.usersOrderStackPanel.Children.Add();
            orderWin.Left = this.Left + 360;
            orderWin.Top = this.Top + 90;
            orderWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            conformationWindow confirm = new conformationWindow();
            confirm.Top = this.Top + 300;
            confirm.Left = this.Left + 360;
            confirm.messageLabel.Content = "A waiter has been flagged and will assist\nyou shortly";
            confirm.Show();
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {

           // Appetizers.Children.RemoveRange(0,8); //cahnge to 0,9 to remove all
            userInfo.Visibility = System.Windows.Visibility.Hidden;
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            LeftMenuButton.FontSize = 25;
            MiddleButton.FontSize = 25;
            RightButton.FontSize = 35;
            if (menuNumber == 0)
            {
                miniClick = 2;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Visible;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }
            if (menuNumber == 1)
            {
                miniClick = 5;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Visible;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }
                      
        }

        private void MiddleButton_Click(object sender, RoutedEventArgs e)
        {
            userInfo.Visibility = System.Windows.Visibility.Hidden;
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            LeftMenuButton.FontSize = 25;
            MiddleButton.FontSize = 35;
            RightButton.FontSize = 25;
            if (menuNumber == 0)
            {
                miniClick = 1;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Visible;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }
            if (menuNumber == 1)
            {
                miniClick = 4;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Visible;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }
            
        }

        private void LeftMenuButton_Click(object sender, RoutedEventArgs e)
        {
            userInfo.Visibility = System.Windows.Visibility.Hidden;
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            LeftMenuButton.FontSize = 35;
            MiddleButton.FontSize = 25;
            RightButton.FontSize = 25;
            if (menuNumber == 0)
            {
                miniClick = 0;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Appetizers.Visibility = System.Windows.Visibility.Visible;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }
            if (menuNumber == 1)
            {
                miniClick = 3;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Visible;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
            }

            if (menuNumber == 2)
            {
                miniClick = 6;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Visible;
            }

           
        }

               //going right
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            LeftMenuButton.FontSize = 25;
            MiddleButton.FontSize = 25;
            RightButton.FontSize = 25;
            if (menuNumber == 0)
            {
                
               
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                menuNumber = menuNumber + 1;
            }
            else if (menuNumber == 1)
            {

               
                LeftMenuButton.Content = "Services";
                RightButton.Visibility = System.Windows.Visibility.Hidden;
                MiddleButton.Visibility = System.Windows.Visibility.Hidden;
                menuNumber = menuNumber + 1;
            }
            

        }

        //going left
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            RightButton.Visibility = System.Windows.Visibility.Visible;
            MiddleButton.Visibility = System.Windows.Visibility.Visible;
            LeftMenuButton.FontSize = 25;
            MiddleButton.FontSize = 25;
            RightButton.FontSize = 25;
            if (menuNumber == 2)
            {

                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                menuNumber = menuNumber - 1;
            }
            else if (menuNumber == 1)
            {

                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                menuNumber = menuNumber - 1;
            }
        }

        private void HomeScreen_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen.Visibility = System.Windows.Visibility.Hidden;
            MiniLeft.Visibility = System.Windows.Visibility.Visible;
            MiniRight.Visibility = System.Windows.Visibility.Visible;
            //userInfo.Visibility = System.Windows.Visibility.Visible;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen.Visibility = System.Windows.Visibility.Visible;
            //userInfo.Visibility = System.Windows.Visibility.Hidden;
            //MiniLeft.Visibility = System.Windows.Visibility.Hidden;
            //MiniRight.Visibility = System.Windows.Visibility.Hidden;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            conformationWindow confirm = new conformationWindow();
            confirm.Width = 650;
            confirm.Height = 470;
            confirm.messageLabel.Width = 600;
            confirm.messageLabel.Height = 300;
            confirm.Top = this.Top + 250;
            confirm.Left = this.Left + 300;
            confirm.messageLabel.FontSize = 16;
            confirm.messageLabel.Content = "To start, press tap anywhere on the screen.\nTo call your waiter press the bell on the bottom left.\nYou will be provide with a menu list to choose from.\nThen below you will be provided with dishes to choose from.\nTap on the name or picture of the dish to view more info\nand to add to your order.\nIn the top right corner of the new window will be the\nAdd to Order Button, which will add that specific item to your order.\nTap anywhere outside that window to close item description.\nAt the top of the screen will be Order Details Button.\nTap that button to view what you have added to your order.\nTap Send order to Kitchen to finalize your order\nand have your food brought out.";
            confirm.Show();
        }

        private void CabButton_Click(object sender, RoutedEventArgs e)
        {
            conformationWindow confirm = new conformationWindow();
            confirm.Width = 550;
            confirm.Height = 230;
            confirm.messageLabel.Width = 600;
            confirm.messageLabel.Height = 75;
            confirm.Top = this.Top + 350;
            confirm.Left = this.Left + 350;
            confirm.messageLabel.FontSize = 22;
            confirm.messageLabel.Content = "Please enter your name,\nand the amount of people needing a cab.";
            confirm.okayButton.Content = "Confirm Order";
            confirm.okayButton.Width = 155;

            confirm.NumberOfPeopleComboBox.SelectedIndex = 0;
            confirm.NameTextBox.Visibility = System.Windows.Visibility.Visible;
            confirm.NumberOfPeopleComboBox.Visibility = System.Windows.Visibility.Visible;

            confirm.Show();
        }

        private void MiniLeft_Click(object sender, RoutedEventArgs e)
        {
            
            if (miniClick == 1)//Appetizers
            {
                LeftMenuButton.FontSize = 35;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 25;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Visible;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }
            else if (miniClick == 2)//Salads
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 35;
                RightButton.FontSize = 25;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Visible;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }

            else if (miniClick == 3)//Soups
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 35;
                menuNumber = menuNumber - 1;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Visible;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }

            else if (miniClick == 4)//Entree
            {

                LeftMenuButton.FontSize = 35;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 25;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Visible;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }

            else if (miniClick == 5)//Desserts
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 35;
                RightButton.FontSize = 25;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Visible;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }

            else if (miniClick == 6)//Drinks
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 35;
                menuNumber = menuNumber - 1;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                RightButton.Visibility = System.Windows.Visibility.Visible;
                MiddleButton.Visibility = System.Windows.Visibility.Visible;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Visible;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick - 1;
            }   
        }

        private void MiniRight_Click(object sender, RoutedEventArgs e)
        {
            userInfo.Visibility = System.Windows.Visibility.Hidden;
            if (miniClick == -1)//Salads
            {
                LeftMenuButton.FontSize = 35;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 25;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Visible;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }

            else if (miniClick == 0)//Salads
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 35;
                RightButton.FontSize = 25;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Visible;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }
            else if (miniClick == 1)//Soups
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 35;
                RightButton.Content = "Soups";
                MiddleButton.Content = "Salads";
                LeftMenuButton.Content = "Appetizers";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Visible;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }

            else if (miniClick == 2)//Entrees
            {
                LeftMenuButton.FontSize = 35;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 25;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                menuNumber = menuNumber + 1;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Visible;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }

            else if (miniClick == 3)//Desserts
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 35;
                RightButton.FontSize = 25;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Visible;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }

            else if (miniClick == 4)//Drinks
            {
                LeftMenuButton.FontSize = 25;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 35;
                RightButton.Content = "Drinks";
                MiddleButton.Content = "Desserts";
                LeftMenuButton.Content = "Entrée";
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Visible;
                CabButton.Visibility = System.Windows.Visibility.Hidden;
                miniClick = miniClick + 1;
            }

            else if (miniClick == 5)//Services
            {
                LeftMenuButton.FontSize = 35;
                MiddleButton.FontSize = 25;
                RightButton.FontSize = 25;
                LeftMenuButton.Content = "Services";
                RightButton.Visibility = System.Windows.Visibility.Hidden;
                MiddleButton.Visibility = System.Windows.Visibility.Hidden;
                menuNumber = menuNumber + 1;
                Appetizers.Visibility = System.Windows.Visibility.Hidden;
                Salads.Visibility = System.Windows.Visibility.Hidden;
                Soups.Visibility = System.Windows.Visibility.Hidden;
                Entrees.Visibility = System.Windows.Visibility.Hidden;
                Desserts.Visibility = System.Windows.Visibility.Hidden;
                Drinks.Visibility = System.Windows.Visibility.Hidden;
                CabButton.Visibility = System.Windows.Visibility.Visible;
                miniClick = miniClick + 1;
            }
        }


       

      
	}
}