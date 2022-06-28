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
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public interface ICustomer
    {
        CustomerType CustomerType { get ;  }
    }
    public class Student : User,ICustomer
    {
        public CustomerType CustomerType { get { return CustomerType.student; } }
        public string ID { get; set; }  
        public bool Check()
        {
            return Regex.IsMatch(this.ID, @"^9[0-9]{7}$");


        }
    }
    public class Teacher : User, ICustomer
    {
        public CustomerType CustomerType { get { return CustomerType.teacher; } }
        public string School {get;set;}

    }
    public class Customer : User, ICustomer 
    {
        public CustomerType CustomerType { get { return CustomerType.normal; } }
        public string Ssn { get; set; } 
        
        public bool Check()
        {
            return Ssn.Check();
        }
    }

    public partial class Window2 : Window
    {
        public double bill;
        public double discount;
        public double luckDiscount;
        public int numOfBuys;
        public int numOfBuysToDiscount;
        public List<string> selectedBooks;
        public List<string> selectedVideos;
        public List<string> selectedMagazines;
        public Window2()
        {
            InitializeComponent();
            
        }
        public Window2(int numOfBuysToDiscount, double discount,string Username)
        {
            InitializeComponent();
            this.Welcome.Text += (Username+ " !!!!");

            this.discount = discount;   
            this.numOfBuys = 0;
            this.numOfBuysToDiscount = numOfBuysToDiscount;
            this.luckDiscount = 0;  
            this.MediaNames.Text = " ";
            this.selectedBooks=new List<string>();
            this.selectedVideos=new List<string>(); 
            this.selectedMagazines=new List<string>();
            for(int i = 0; i < Global.books.Count; i++)
            {
                this.MediaNames.Text += Global.books[i].Name;
                this.MediaNames.Text += "\n";
            }
            for (int i = 0; i < Global.videos.Count; i++)
            {
                this.MediaNames.Text += Global.videos[i].Name;
                this.MediaNames.Text += "\n";
            }
            for (int i = 0; i < Global.magazines.Count; i++)
            {
                this.MediaNames.Text += Global.magazines[i].Name;
                this.MediaNames.Text += "\n";
            }
        }
   
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SelectButtonConfirm_Click(object sender, RoutedEventArgs e)
        {

            string mediaName = this.MediaName.Text;
            bool validMediaName = false;
            if(this.numOfBuys < 21)
            {
                for (int i = 0; i < Global.books.Count; i++)
                {
                    if (Global.books[i].Name == mediaName)
                    {
                        validMediaName = true;
                        this.numOfBuys++;
                        double price = Global.books[i].Money();
                        this.bill += price;
                        this.selectedBooks.Add(mediaName+" "+price);
                        this.SelectedMediaList.Text += ("Media Name: "+mediaName + " Price: " + price + "\n");
                    }
                }
                for (int i = 0; i < Global.videos.Count; i++)
                {
                    if (Global.videos[i].Name == mediaName)
                    {
                        validMediaName = true;
                        this.numOfBuys++;
                        double price= Global.videos[i].Money();  
                        this.bill += price;
                        this.selectedVideos.Add(mediaName + " " + price);
                        this.SelectedMediaList.Text += ("Media Name: " + mediaName + " Price: " + price + "\n");
                    }
                }
                for (int i = 0; i < Global.magazines.Count; i++)
                {
                    if (Global.magazines[i].Name == mediaName)
                    {
                        validMediaName = true;
                        this.numOfBuys++;
                        double price=Global.magazines[i].Money();
                        this.bill+=price;
                        this.selectedMagazines.Add(mediaName + " " + price);
                        this.SelectedMediaList.Text += ("Media Name: " + mediaName + " Price: " + price + "\n");
                    }
                }
                if (validMediaName == false)
                {
                    Global.Message("Error!", "Invalid Media Name!!!");
                }
                else
                {
                    Global.Message("Confirmation", "Media Added!");
                }

            }
            else
            {
                Global.Message("Error!", "You Can Buy 20 Medias At Most!!!");
            }
        }



        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Global.Message("Confirmation", "THANKS FOR BUYING!!!");
            this.SelectedMediaList.Text = " ";
            this.selectedBooks.Clear();
            this.selectedMagazines.Clear();
            this.selectedVideos.Clear();    
            this.numOfBuys = 0;
            this.bill = 0;  
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double finalBill = 0;
            if (this.numOfBuys >= this.numOfBuysToDiscount)
            {
                finalBill = this.bill * ((100 - this.discount - this.luckDiscount) / 100);
            }
            else
            {
                finalBill = this.bill * ((100 - this.luckDiscount) / 100);
            }

            this.Bill.Text = (finalBill).ToString();
        }

        private void ChanseButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.luckDiscount != 0)
            {
                Global.Message("Error", "You Can Test Your Chanse Only Once!!!");
            }
            else
            {
                int[] arr = new int[] { 0, 2, 3, 5, 7, 10, 15, 25, 30 };
                Random rand = new Random();
                int index=rand.Next(0,arr.Length-1);
                this.luckDiscount = arr[index];
                Global.Message("Chanse","Your Luck Discount is :"+this.luckDiscount);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string mediaName = this.MediaNameToDelete.Text;
            bool validMediaName = false;
                for(int i = 0; i < this.selectedBooks.Count; i++)
                {
                    string[] arr = selectedBooks[i].Split(' ');
                    if (arr[0] == mediaName)
                    {
                        this.selectedBooks.RemoveAt(i);
                        for (int j = 0; j < Global.books.Count; j++)
                        {
                            if (Global.books[i].Name == mediaName)
                            {
                                validMediaName = true;
                                this.numOfBuys--;
                                double price = Global.books[j].Money();
                                this.bill -= price;

                            }
                        }
                    }
                }
                for (int i = 0; i < this.selectedVideos.Count; i++)
                {
                    string[] arr = selectedVideos[i].Split(' ');
                    if (arr[0] == mediaName)
                    {
                        this.selectedVideos.RemoveAt(i);
                        for (int j = 0; j < Global.videos.Count; j++)
                        {
                            if (Global.videos[i].Name == mediaName)
                            {
                                validMediaName = true;
                                this.numOfBuys--;
                                double price = Global.videos[j].Money();
                                this.bill -= price;
                            }
                        }
                    }
                }
                for (int i = 0; i < this.selectedMagazines.Count; i++)
                {
                    string[] arr = selectedMagazines[i].Split(' ');
                    if (arr[0] == mediaName)
                    {
                        this.selectedMagazines.RemoveAt(i);
                        for (int j = 0; j < Global.magazines.Count; j++)
                        {
                            if (Global.magazines[i].Name == mediaName)
                            {
                                validMediaName = true;
                                this.numOfBuys--;
                                double price = Global.magazines[j].Money();
                                this.bill -= price;

                            }
                        }
                    }
                }
            if (validMediaName == false)
            {
                Global.Message("Error!", "Invalid Media Name!!!");
            }
            else
            {
                Global.Message("Confirmation", "Media Deleted!");
            }
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void UpdateSelectedMedia_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedMediaList.Text = " ";
            for(int i = 0; i < this.selectedBooks.Count; i++)
            {
                string[] arr = selectedBooks[i].Split(' ');
                this.SelectedMediaList.Text += ("Media Name: " + arr[0] + " Price: " + arr[1] + "\n");
            }
            for (int i = 0; i < this.selectedVideos.Count; i++)
            {
                string[] arr = selectedVideos[i].Split(' ');
                this.SelectedMediaList.Text += ("Media Name: " + arr[0] + " Price: " + arr[1] + "\n");
            }
            for (int i = 0; i < this.selectedMagazines.Count; i++)
            {
                string[] arr = selectedMagazines[i].Split(' ');
                this.SelectedMediaList.Text += ("Media Name: " + arr[0] + " Price: " + arr[1] + "\n");
            }
        }
    }
}
