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
using System.Text.RegularExpressions;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum UserType { user, admin }
    public enum CustomerType { normal, student, teacher}
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
        public static void Message(string str,Window window1,Window window2)
        {
            if (str == "exit")
            {

               if( MessageBox.Show("Do you want to close this window?",
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
        public static void Message(string title,string text)
        {
            if (title == "Password" || title == "Add Media"|| title == "Deleted Confirmed" || title=="Confirmation" || title=="Chanse")
            {
                MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void FileToList(string path,List<string>list)
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
        public static void WriteToFile(string content,string path)
        {
            StreamWriter writer = new StreamWriter(path);
            string[] arr = content.Split(' ');
            for(int i = 0; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
            writer.Close(); 
        }
        public string ListToContent(List<string>list)
        {
            string content = "";
            foreach(string item in list)
            {
                content+=(item+" ");
            }
            return content;
        }
        public static List<Customer> customers = new List<Customer>();
        public static List<Student> students = new List<Student>();
        public static List<Teacher> teachers = new List<Teacher>();
        public static List<Seller> sellers = new List<Seller>();
        public static List<Book>books=new List<Book>(); 
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
            if(str.Length !=10)
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
                int a = ssn%10;
                double b = 0;
                for(int i = 0; i < str.Length; i++)
                {
                    double n = Char.GetNumericValue(str[i]);
                    b += (n * (10 - i));
                }
                double c = b*0.11;
                if (c == 0 && a == 0)
                {
                    ans = true;
                }
                if (c == 1 && a == 1)
                {
                    ans = true;
                }
                if(c>1&&Math.Abs(c-11) == a)
                {
                    ans=true;   
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
            /* string content=Global.ReadFromFile(Global.NormalCustomersPath);
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
            }*/
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();   
            Global.Message("exit",this,window);
        }

        private void SellerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Seller_Log_In window1 = new Seller_Log_In();    
            window1.Show();
            this.Close();
        }
        private void StudentCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CustomerLogin customerLogin=new CustomerLogin();
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
