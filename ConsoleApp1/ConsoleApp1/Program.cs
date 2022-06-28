/*using System;
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
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum UserType { user, admin }
    public enum CustomerType { normal, student, teacher }
    public abstract class Global
    {
        public static CustomerType CustomerType { get; set; }
        public static string NormalCustomersPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Normal Customers Info.txt";
        public static string TeachersPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Teachers Info.txt";
        public static string StudentsPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Students Info.txt";
        public static string BooksPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Books Info.txt";
        public static string VideosPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Vidoes Info.txt";
        public static string MagazinesPath = @"F:\Elmos\AP\Seri 06\WpfApp1\Magazines Info.txt";
        //public static FileStream file = new FileStream(Global.StudentsPath);
        public static void Message(string str, Window window1, Window window2)
        {
            if (str == "exit")
            {

                if (MessageBox.Show("Do you want to close this window?",
                                           "Confirmation",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                    window1.Close();
                }

            }
            if (str == "back")
            {
                window1.Close();

                window2.Show();
            }
        }
        public static void Message(string title, string text)
        {
            if (title == "Password" || title == "Add Media" || title == "Deleted Confirmed" || title == "Confirmation" || title == "Chanse")
            {
                MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void FileToList(string path, List<string> list)
        {

        }
        public static string ReadFromFile(string path)
        {
            string content = "";
            StreamReader reader = new StreamReader(path);
            while (reader.EndOfStream == false)
            {
                content += reader.ReadLine();
                content += " ";
            }
            //might cause troouble :
            reader.Close();
            return content;
        }
        public static void WriteToFile(string content, string path)
        {
            StreamWriter writer = new StreamWriter(path);
            string[] arr = content.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
            writer.Close();
        }
        public string ListToContent(List<string> list)
        {
            string content = "";
            foreach (string item in list)
            {
                content += (item + " ");
            }
            return content;
        }
        public static List<Customer> customers = new List<Customer>();
        public static List<Student> students = new List<Student>();
        public static List<Teacher> teachers = new List<Teacher>();
        public static List<Seller> sellers = new List<Seller>();
        public static List<Book> books = new List<Book>();
        public static List<Video> videos = new List<Video>();
        public static List<Magazine> magazines = new List<Magazine>();

        //uniques:
        public static List<string> sellersNames = new List<string>();
        public static List<string> studentsIDs = new List<string>();
        public static List<string> customersSsns = new List<string>();
        public static List<string> MediaIds = new List<string>();

    }
    public static class EMethods
    {
        public static bool Check(this string str)
        {
            if (str.Length != 10)
            {
                return false;
            }
            else
            {
                int ssn = 0;
                bool ans = false;
                try
                {
                    ssn = int.Parse(str);
                }
                catch
                {
                    Global.Message("INVALID SSN!!!", "Ssn Can Only Be Digits!!");
                }
                int a = ssn % 10;
                double b = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    double n = Char.GetNumericValue(str[i]);
                    b += (n * (10 - i));
                }
                double c = b * 0.11;
                if (c == 0 && a == 0)
                {
                    ans = true;
                }
                if (c == 1 && a == 1)
                {
                    ans = true;
                }
                if (c > 1 && Math.Abs(c - 11) == a)
                {
                    ans = true;
                }
                if (ssn % 1111111111 == 0)
                {
                    return false;
                }
                else
                {
                    return ans;


                }
            }
        }
    }
    public class User
    {
        public UserType Type { get { return UserType.user; } }
        public string Username { get; set; }


    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //todo: file to list :
            *//* string content=Global.ReadFromFile(Global.NormalCustomersPath);
             string []arr = content.Split(' ');
             for(int i=0; i < arr.Length/2; i++)
             {
                 Customer customer=new Customer();   
                 customer.Username = arr[i]; 
                 customer.Ssn = arr[i+1];
                 Global.customers.Add(customer); 
                 Global.customersSsns.Add(arr[i+1]);      
             }*/
            /* string content = Global.ReadFromFile(Global.StudentsPath);
             string[] arr = content.Split(' ');
             int i = 0;
             while (true)
             {

                     string username=arr[i+1]; 
                     string studentID=arr[i+2];
                     Student student = new Student();    
                     student.Username = username;
                     student.ID = studentID; 
                     Global.students.Add(student);   
                     i += 3;
                 if(i>=arr.Length)
                 {
                     break;  
                 }
             }*//*
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            Global.Message("exit", this, window);
        }

        private void SellerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Seller_Log_In window1 = new Seller_Log_In();
            window1.Show();
            this.Close();
        }
        private void StudentCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CustomerLogin customerLogin = new CustomerLogin();
            customerLogin.EnterWhatTextBlock.Text += "Student ID:";
            customerLogin.Show();
            CustomerLogin.WhichCustomer = 1;
            this.Close();
        }

        private void TeacherCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CustomerLogin customerLogin = new CustomerLogin();
            customerLogin.EnterWhatTextBlock.Text += "School Name:";
            customerLogin.Show();
            CustomerLogin.WhichCustomer = 2;
            this.Close();
        }

        private void CustomerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CustomerLogin customerLogin = new CustomerLogin();
            customerLogin.EnterWhatTextBlock.Text += "Your SSN:";
            customerLogin.Show();
            CustomerLogin.WhichCustomer = 3;
            this.Close();
        }

    }
}
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
            else if ("MyShop1234$" == PasswordBox.Text)
            {
                Seller seller = new Seller();
                seller.Username = UsernameBox.Text;

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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public class Seller : User
    {
        public new UserType Type { get { return UserType.admin; } }
        public string Password { get; set; }
        public DateTime LastTime { get; set; }
        public bool HasChangedBefore { get; set; }
        public bool Checker()
        {
            return (Regex.IsMatch(this.Username, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));
        }
        public Seller()
        {
            this.Password = "MyShop1234$";
            this.HasChangedBefore = false;
        }

    }
    public class Media
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ID { get; set; }
    }
    public class Book : Media
    {
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public double Money()
        {
            return this.Price * 1.1;
        }
        public static void AddMedia(Book book, bool ShowMessage, bool DeletMedia)
        {
            if (DeletMedia == false)
            {
                Global.books.Add(book);
                Global.MediaIds.Add(book.ID);
            }
            string content = Global.ReadFromFile(Global.BooksPath);
            string[] arr = content.Split(' ');
            StreamWriter streamWriter = new StreamWriter(Global.BooksPath);
            for (int i = 0; i < arr.Length; i++)
            {
                streamWriter.WriteLine(arr[i]);
            }
            streamWriter.WriteLine(book.Name);
            streamWriter.WriteLine(book.ID);
            streamWriter.WriteLine(book.Price);
            streamWriter.WriteLine(book.Writer);
            streamWriter.WriteLine(book.Publisher);
            streamWriter.Close();
            if (ShowMessage)
            {
                Global.Message("Add Media", "New Media Is Added!!!");
            }
        }

    }
    public class Video : Media
    {
        public int Time { get; set; }
        public int NumOfDiscs { get; set; }
        public double Money()
        {
            return (this.Price * (1 + this.NumOfDiscs * 0.3 + Time * 0.5 / 60));
        }
        public static void AddMedia(Video video, bool ShowMessage, bool DeletMedia)
        {
            if (DeletMedia == false)
            {
                Global.videos.Add(video);
                Global.MediaIds.Add(video.ID);
            }
            string content = Global.ReadFromFile(Global.VideosPath);
            string[] arr = content.Split(' ');
            StreamWriter streamWriter = new StreamWriter(Global.VideosPath);
            for (int i = 0; i < arr.Length; i++)
            {
                streamWriter.WriteLine(arr[i]);
            }
            streamWriter.WriteLine(video.Name);
            streamWriter.WriteLine(video.ID);
            streamWriter.WriteLine(video.Price);
            streamWriter.WriteLine(video.Time);
            streamWriter.WriteLine(video.NumOfDiscs);
            streamWriter.Close();
            if (ShowMessage)
            {
                Global.Message("Add Media", "New Media Is Added!!!");
            }
        }
    }
    public class Magazine : Media
    {
        public string Publisher { get; set; }
        public int NumOfPages { get; set; }
        public double Money()
        {
            if (this.NumOfPages > 50)
            {
                return this.Price * 1.05;
            }
            else if (this.NumOfPages > 20)
            {
                return this.Price * 1.03;
            }
            else
            {
                return this.Price * 1.02;
            }
        }
        public static void AddMedia(Magazine magazine, bool ShowMessage, bool DeletMedia)
        {
            if (DeletMedia == false)
            {
                Global.magazines.Add(magazine);
                Global.MediaIds.Add(magazine.ID);
            }
            string content = Global.ReadFromFile(Global.MagazinesPath);
            string[] arr = content.Split(' ');
            StreamWriter streamWriter = new StreamWriter(Global.MagazinesPath);
            for (int i = 0; i < arr.Length; i++)
            {
                streamWriter.WriteLine(arr[i]);
            }
            streamWriter.WriteLine(magazine.Name);
            streamWriter.WriteLine(magazine.ID);
            streamWriter.WriteLine(magazine.Price);
            streamWriter.WriteLine(magazine.Publisher);
            streamWriter.WriteLine(magazine.NumOfPages);
            streamWriter.Close();
            if (ShowMessage)
            {
                Global.Message("Add Media", "New Media Is Added!!!");
            }
        }
    }
    public class Library
    {
        public static void AddMedia(int n, Window1 window1)
        {
            if (n == 1)
            {
                Book book = new Book();
                try
                {
                    book.Price = Double.Parse(window1.MediaPriceTextBox.Text);
                    if (book.Price <= 0)
                    {
                        Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                    }
                    else
                    {
                        book.Name = window1.MediaNameTextBox.Text;
                        book.ID = window1.MediaIDTextBox.Text;
                        if (Global.MediaIds.Contains(book.ID))
                        {
                            Global.Message("INVALID INPUT!!", "Media IDs Should Be Unique !!");

                        }
                        else
                        {
                            book.Publisher = window1.MediaSpecialProperty1TextBox.Text;
                            book.Writer = window1.MediaSpecialProperty2TextBox.Text;
                            Book.AddMedia(book, true, false);
                        }
                    }
                }
                catch
                {
                    Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                }
            }

            if (n == 2)
            {
                Video video = new Video();
                video.Name = window1.MediaNameTextBox.Text;
                video.ID = window1.MediaIDTextBox.Text;
                if (Global.MediaIds.Contains(video.ID) == false)
                {
                    try
                    {
                        video.Price = Double.Parse(window1.MediaPriceTextBox.Text);
                        if (video.Price <= 0)
                        {
                            Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                        }
                        else
                        {
                            try
                            {
                                video.Time = int.Parse(window1.MediaSpecialProperty1TextBox.Text);
                                if (video.Time <= 0)
                                {
                                    Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                                }
                                else
                                {
                                    try
                                    {
                                        video.NumOfDiscs = int.Parse(window1.MediaSpecialProperty2TextBox.Text);
                                        if (video.NumOfDiscs <= 0)
                                        {
                                            Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                                        }
                                        else
                                        {
                                            Video.AddMedia(video, true, false);
                                        }
                                    }
                                    catch
                                    {
                                        Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                                    }
                                }
                            }
                            catch
                            {
                                Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                            }
                        }
                    }
                    catch
                    {
                        Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                    }
                }
                else
                {
                    Global.Message("INVALID INPUT!!", "Media IDs Should Be Unique !!");
                }
            }

            if (n == 3)
            {
                Magazine magazine = new Magazine();
                magazine.Name = window1.MediaNameTextBox.Text;
                magazine.ID = window1.MediaIDTextBox.Text;
                if (Global.MediaIds.Contains(magazine.ID) == false)
                {
                    magazine.Publisher = window1.MediaSpecialProperty2TextBox.Text;
                    try
                    {
                        magazine.NumOfPages = int.Parse(window1.MediaSpecialProperty1TextBox.Text);
                        if (magazine.NumOfPages <= 0)
                        {
                            Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                        }
                        else
                        {
                            try
                            {
                                magazine.Price = Double.Parse(window1.MediaPriceTextBox.Text);
                                if (magazine.Price <= 0)
                                {
                                    Global.Message("INVALID INPUT!!", "Positive Numbers Are Alowed Only!!");
                                }
                                else
                                {
                                    Magazine.AddMedia(magazine, true, false);
                                }
                            }
                            catch
                            {
                                Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                            }
                        }
                    }
                    catch
                    {
                        Global.Message("INVALID INPUT!!", "Numbers Are Alowed Only!!");
                    }
                }
                else
                {
                    Global.Message("INVALID INPUT!!", "Media IDs Should Be Unique !!");
                }
            }
        }
        public static void DeleteMedia(string ID)
        {
            if (Global.MediaIds.Contains(ID) == false)
            {
                Global.Message("Error", "Entered ID Doesn't Exist!!");
            }
            else
            {
                for (int i = 0; i < Global.books.Count; i++)
                {
                    if (Global.books[i].ID == ID)
                    {
                        Global.books.RemoveAt(i);
                        StreamWriter sw = new StreamWriter(Global.BooksPath);
                        sw.Flush();
                        sw.Close();
                        foreach (Book book in Global.books.ToList())
                        {
                            Book.AddMedia(book, false, true);
                        }
                    }
                }
                for (int i = 0; i < Global.videos.Count; i++)
                {
                    if (Global.videos[i].ID == ID)
                    {
                        Global.videos.RemoveAt(i);
                        StreamWriter sw = new StreamWriter(Global.VideosPath);
                        sw.Flush();
                        sw.Close();
                        foreach (Video video in Global.videos.ToList())
                        {
                            Video.AddMedia(video, false, true);
                        }
                    }
                }
                for (int i = 0; i < Global.magazines.Count; i++)
                {
                    if (Global.magazines[i].ID == ID)
                    {
                        Global.magazines.RemoveAt(i);
                        StreamWriter sw = new StreamWriter(Global.MagazinesPath);
                        sw.Flush();
                        sw.Close();
                        foreach (Magazine magazine in Global.magazines.ToList())
                        {
                            Magazine.AddMedia(magazine, false, true);
                        }
                    }
                }
                Global.MediaIds.Remove(ID);
                Global.Message("Deleted Confirmed", "Media Is Deleted!");
            }
        }
        public static void Search(string ID)
        {
            if (Global.MediaIds.Contains(ID) == false)
            {
                Global.Message("Error", "Entered ID Doesn't Exist!!");
            }
            else
            {
                for (int i = 0; i < Global.books.Count; i++)
                {
                    if (Global.books[i].ID == ID)
                    {
                        MediaInfo info = new MediaInfo();
                        info.Type.Text += "Book";
                        info.Name.Text += Global.books[i].Name;
                        info.ID.Text += Global.books[i].ID;
                        info.Price.Text += Global.books[i].Price;
                        info.Special1.Text = ("Writer: " + Global.books[i].Writer);
                        info.Special2.Text = ("Publisher: " + Global.books[i].Publisher);
                        info.Show();
                    }
                    break;
                }
                for (int i = 0; i < Global.videos.Count; i++)
                {
                    if (Global.videos[i].ID == ID)
                    {
                        MediaInfo info = new MediaInfo();
                        info.Type.Text += "Video";
                        info.Name.Text += Global.videos[i].Name;
                        info.ID.Text += Global.videos[i].ID;
                        info.Price.Text += Global.videos[i].Price;
                        info.Special1.Text = ("Time: " + Global.videos[i].Time);
                        info.Special2.Text = ("Number Of Discs: " + Global.videos[i].NumOfDiscs);
                        info.Show();
                    }
                    break;
                }
                for (int i = 0; i < Global.magazines.Count; i++)
                {
                    if (Global.magazines[i].ID == ID)
                    {
                        MediaInfo info = new MediaInfo();
                        info.Type.Text += "Magazines";
                        info.Name.Text += Global.magazines[i].Name;
                        info.ID.Text += Global.magazines[i].ID;
                        info.Price.Text += Global.magazines[i].Price;
                        info.Special1.Text = ("Publisher: " + Global.magazines[i].Publisher);
                        info.Special2.Text = ("Number Of Pages: " + Global.magazines[i].NumOfPages);
                        info.Show();
                    }
                    break;
                }

            }
        }
    }
    public partial class Window1 : Window
    {
        public static int whichMedia;
        public int sellerIndex;
        public Window1()
        {


        }
        public Window1(int sellerIndex)
        {
            InitializeComponent();
            this.sellerIndex = sellerIndex;
            this.NameTextBlock.Text = "Welcome Back! " + Global.sellers[sellerIndex].Username + " !!!";
            if (Global.sellers[sellerIndex].HasChangedBefore == false)
            {
                this.LastTimeChanged.Text = "YOU HAVEN'T CHANGED YOUR PASSWORD YET!!!";
            }
            else
            {
                this.LastTimeChanged.Text = Global.sellers[sellerIndex].LastTime.ToString("F");
            }


        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void ChangePassword(int sellerIndex)
        {
            Global.sellers[sellerIndex].Password = this.NewPasswordTextBox.Text;
            Global.sellers[sellerIndex].HasChangedBefore = true;
            Global.sellers[sellerIndex].LastTime = DateTime.Now;
            Global.Message("Password", "New Password Is Saved!!");
        }
        private void ConfirmNewPassword(object sender, RoutedEventArgs e)
        {
            ChangePassword(sellerIndex);
        }

        private void BookRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.MediaSpecialProperty1.Text = "Enter Writer's Name :";
            this.MediaSpecialProperty2.Text = "Enter Publisher's Name :";
            whichMedia = 1;

        }
        private void VideoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.MediaSpecialProperty1.Text = "Enter Video's Time :";
            this.MediaSpecialProperty2.Text = "Enter Number Of Discs:";
            whichMedia = 2;
        }

        private void MagaineRaadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.MediaSpecialProperty1.Text = "Enter Magazine's Number Of Pages:";
            this.MediaSpecialProperty2.Text = "Enter Publisher's Name :";
            whichMedia = 3;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Library.AddMedia(whichMedia, this);

        }

        private void ConfirmDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Library.DeleteMedia(this.MediaID.Text);
        }

        private void ConfirmSearchButton_Click(object sender, RoutedEventArgs e)
        {
            Library.Search(this.MediaID2.Text);
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < Global.students.Count; i++)
            {
                int j = i + 1;
                this.StudentData.Text += (j + " :");
                this.StudentData.Text += "\n";
                this.StudentData.Text += ("Username: " + Global.students[i].Username);
                this.StudentData.Text += "\n";
                this.StudentData.Text += ("ID: " + Global.students[i].ID);
                this.StudentData.Text += "\n";
                this.StudentData.Text += "\n";
            }
            for (int i = 0; i < Global.teachers.Count; i++)
            {
                int j = i + 1;
                this.TeacherData.Text += (j + " :");
                this.TeacherData.Text += "\n";
                this.TeacherData.Text += ("Username: " + Global.teachers[i].Username);
                this.TeacherData.Text += "\n";
                this.TeacherData.Text += ("School: " + Global.teachers[i].School);
                this.TeacherData.Text += "\n";
                this.TeacherData.Text += "\n";
            }
            for (int i = 0; i < Global.customers.Count; i++)
            {
                int j = i + 1;
                this.CustomerData.Text += (j + " :");
                this.CustomerData.Text += "\n";
                this.CustomerData.Text += ("Username: " + Global.customers[i].Username);
                this.CustomerData.Text += "\n";
                this.CustomerData.Text += ("SSN: " + Global.customers[i].Ssn);
                this.CustomerData.Text += "\n";
                this.CustomerData.Text += "\n";
            }
        }
    }
}
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Media_Info.xaml
    /// </summary>
    public partial class MediaInfo : Window
    {
        public MediaInfo()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
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
        CustomerType CustomerType { get; }
    }
    public class Student : User, ICustomer
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
        public string School { get; set; }

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
        public Window2(int numOfBuysToDiscount, double discount, string Username)
        {
            InitializeComponent();
            this.Welcome.Text += (Username + " !!!!");

            this.discount = discount;
            this.numOfBuys = 0;
            this.numOfBuysToDiscount = numOfBuysToDiscount;
            this.luckDiscount = 0;
            this.MediaNames.Text = " ";
            this.selectedBooks = new List<string>();
            this.selectedVideos = new List<string>();
            this.selectedMagazines = new List<string>();
            for (int i = 0; i < Global.books.Count; i++)
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
            if (this.numOfBuys < 21)
            {
                for (int i = 0; i < Global.books.Count; i++)
                {
                    if (Global.books[i].Name == mediaName)
                    {
                        validMediaName = true;
                        this.numOfBuys++;
                        double price = Global.books[i].Money();
                        this.bill += price;
                        this.selectedBooks.Add(mediaName + " " + price);
                        this.SelectedMediaList.Text += ("Media Name: " + mediaName + " Price: " + price + "\n");
                    }
                }
                for (int i = 0; i < Global.videos.Count; i++)
                {
                    if (Global.videos[i].Name == mediaName)
                    {
                        validMediaName = true;
                        this.numOfBuys++;
                        double price = Global.videos[i].Money();
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
                        double price = Global.magazines[i].Money();
                        this.bill += price;
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
                int index = rand.Next(0, arr.Length - 1);
                this.luckDiscount = arr[index];
                Global.Message("Chanse", "Your Luck Discount is :" + this.luckDiscount);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string mediaName = this.MediaNameToDelete.Text;
            bool validMediaName = false;
            for (int i = 0; i < this.selectedBooks.Count; i++)
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
            for (int i = 0; i < this.selectedBooks.Count; i++)
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
    /// Interaction logic for Customer_Login.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        public static int WhichCustomer;
        public CustomerLogin()
        {
            InitializeComponent();

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerLogin.WhichCustomer == 1)
            {
                if (Global.studentsIDs.Contains(this.CustomerKeyBox.Text))
                {
                    for (int i = 0; i < Global.students.Count; i++)
                    {
                        if (Global.studentsIDs[i] == this.CustomerKeyBox.Text)
                        {
                            Window2 window2 = new Window2(0, 20, Global.students[i].Username);
                            window2.Show();
                            this.Close();
                        }
                        else
                        {
                            Global.Message("IVALID STUDENT ID", "Please Enter The Correct Student ID !!!");
                        }
                    }
                }
                else
                {
                    Student student = new Student();
                    student.Username = this.CustomerUsernameBox.Text;
                    student.ID = this.CustomerKeyBox.Text;
                    if (student.Check() == true)
                    {
                        Global.students.Add(student);
                        Global.studentsIDs.Add(student.ID);
                        string content = Global.ReadFromFile(Global.StudentsPath);
                        string[] arr = content.Split(' ');
                        StreamWriter writer = new StreamWriter(Global.StudentsPath);
                        foreach (string s in arr)
                        {
                            writer.WriteLine(s);
                        }
                        writer.WriteLine(student.Username);
                        writer.WriteLine(student.ID);
                        writer.Close();
                        Window2 window2 = new Window2(0, 20, student.Username);
                        window2.Show();
                        this.Close();
                    }
                    else
                    {
                        Global.Message("IVALID STUDENT ID", "Student ID Should Be In This Format: 9xxxxxxxx !!!");
                    }
                }
            }

            if (CustomerLogin.WhichCustomer == 2)
            {
                Teacher teacher = new Teacher();
                teacher.Username = this.CustomerUsernameBox.Text;
                teacher.School = this.CustomerKeyBox.Text;
                Global.teachers.Add(teacher);
                string content = Global.ReadFromFile(Global.TeachersPath);
                string[] arr = content.Split(' ');
                StreamWriter writer = new StreamWriter(Global.TeachersPath);
                foreach (string s in arr)
                {
                    writer.WriteLine(s);
                }
                writer.WriteLine(teacher.Username);
                writer.WriteLine(teacher.School);
                writer.Close();
                Window2 window2 = new Window2(3, 15, teacher.Username);
                window2.Show();
                this.Close();
            }

            if (CustomerLogin.WhichCustomer == 3)
            {
                Customer customer = new Customer();
                customer.Username = this.CustomerUsernameBox.Text;
                customer.Ssn = this.CustomerKeyBox.Text;
                if (Global.customersSsns.Contains(customer.Ssn))
                {
                    for (int i = 0; i < Global.customers.Count; i++)
                    {
                        if (Global.customers[i].Ssn == customer.Ssn)
                        {
                            Window2 window2 = new Window2(5, 5, customer.Username);
                            window2.Show();
                            this.Close();
                        }
                        else
                        {
                            Global.Message("INVALID SSN", "Please Enter The Correct SSN !!!");
                        }
                    }
                }
                else
                {
                    if (customer.Ssn.Check() == true)
                    {
                        Global.customers.Add(customer);
                        Global.customersSsns.Add(customer.Ssn);
                        string content = Global.ReadFromFile(Global.NormalCustomersPath);
                        string[] arr = content.Split(' ');
                        StreamWriter writer = new StreamWriter(Global.NormalCustomersPath);
                        foreach (string s in arr)
                        {
                            writer.WriteLine(s);
                        }
                        writer.WriteLine(customer.Username);
                        writer.WriteLine(customer.Ssn);
                        writer.Close();
                        Window2 window2 = new Window2(5, 5, customer.Username);
                        window2.Show();
                        this.Close();
                    }
                    else
                    {
                        Global.Message("IVALID STUDENT ID", "Student ID Should Be In This Format: 9xxxxxxxx !!!");
                    }
                }
            }

        }
    }
}

*/