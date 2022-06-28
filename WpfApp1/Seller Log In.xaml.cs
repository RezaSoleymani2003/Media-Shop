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
using System.Windows.Shapes;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Seller_Log_In.xaml
    /// </summary>
    public partial class Seller_Log_In : Window
    {
        public Seller_Log_In()
        {
            InitializeComponent();
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Global.sellersNames.Contains(UsernameBox.Text))
            {
                int sellerIndex = 0;
                for (int i = 0; i < Global.sellers.Count; i++)
                {
                    if (UsernameBox.Text == Global.sellers[i].Username)
                    {
                        sellerIndex = i;
                    }
                }
                if (Global.sellers[sellerIndex].Password == PasswordBox.Text)
                {
                    Window1 window1 = new Window1(sellerIndex);
                    window1.sellerIndex = sellerIndex;  
                    window1.Show(); 
                    this.Close();   
                }
                else
                {
                    Global.Message("INVALID PASSWORD!!", "Please Enter the Correct Password!!");
                }
            }
            else if("MyShop1234$" == PasswordBox.Text)
            {
                Seller seller=new Seller();
                seller.Username=UsernameBox.Text;
                
                if (seller.Checker() == true)
                {
                    Global.sellers.Add(seller);
                    Global.sellersNames.Add(UsernameBox.Text);
                    int sellerIndex = 0;
                    for (int i = 0; i < Global.sellers.Count; i++)
                    {
                        if (UsernameBox.Text == Global.sellers[i].Username)
                        {
                            sellerIndex = i;
                        }
                    }
                    Window1 window1 = new Window1(sellerIndex);
                    window1.Show();
                    this.Close();
                }
                else
                {
                    Global.Message("INVALID USERNAME!!", "Username Should Be In An Email Format: A@B.C");
                }
            }
            else
            {
                    Global.Message("INVALID PASSWORD!!", "Please Enter the Correct Password!!");
            }
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();   
            mainWindow.Show();
            this.Close();   
        }
    }
}
