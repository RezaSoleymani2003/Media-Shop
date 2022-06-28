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
            return this.Price*1.1;
        }
        public static void AddMedia(Book book,bool ShowMessage,bool DeletMedia)
        {
            if (DeletMedia == false)
            {
                Global.books.Add(book);
                Global.MediaIds.Add(book.ID);
            }
            string content = Global.ReadFromFile(Global.BooksPath);
            string[]arr=content.Split(' ');
            StreamWriter streamWriter = new StreamWriter(Global.BooksPath);
            for(int i = 0; i < arr.Length; i++)
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
    public class Video:Media
    {
        public int Time { get; set; }
        public int NumOfDiscs { get; set; }
        public double Money()
        {
            return (this.Price * (1 + this.NumOfDiscs * 0.3 + Time * 0.5 / 60));
        }
        public static void AddMedia(Video video,bool ShowMessage, bool DeletMedia)
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
            if(this.NumOfPages > 50)
            {
                return this.Price * 1.05;
            }else if(this.NumOfPages > 20)
            {
                return this.Price * 1.03;
            }
            else
            {
                return this.Price * 1.02;
            }
        }
        public static void AddMedia(Magazine magazine,bool ShowMessage, bool DeletMedia)
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
        public static void AddMedia(int n,Window1 window1)
        {
            if (n == 1)
            {
                Book book = new Book(); 
                try
                {
                    book.Price = Double.Parse(window1.MediaPriceTextBox.Text);
                    if(book.Price <= 0)
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
                            Book.AddMedia(book,true,false);
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
                if (Global.MediaIds.Contains(video.ID)==false)
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
                                            Video.AddMedia(video,true,false);
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
            
            if(n == 3)
            {
                Magazine magazine = new Magazine();
                magazine.Name = window1.MediaNameTextBox.Text;
                magazine.ID=window1.MediaIDTextBox.Text;
                if (Global.MediaIds.Contains(magazine.ID)==false)
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
                                    Magazine.AddMedia(magazine,true,false);    
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
                        foreach(Book book in Global.books.ToList())
                        {
                            Book.AddMedia(book,false,true);
                        }
                    }
                }
                for (int i = 0; i < Global.videos.Count; i++)
                {
                    if (Global.videos[i].ID == ID)
                    {
                        Global.videos.RemoveAt(i); 
                        StreamWriter sw=new StreamWriter(Global.VideosPath);
                        sw.Flush ();
                        sw.Close();
                        foreach(Video video in Global.videos.ToList())
                        {
                            Video.AddMedia(video,false,true);
                        }
                    }
                }
                for (int i = 0; i < Global.magazines.Count; i++)
                {
                    if (Global.magazines[i].ID == ID)
                    {
                        Global.magazines.RemoveAt(i);
                        StreamWriter sw=new StreamWriter(Global.MagazinesPath);
                        sw.Flush(); 
                        sw.Close ();    
                        foreach(Magazine magazine in Global.magazines.ToList())
                        {
                            Magazine.AddMedia(magazine,false,true);
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
                        info.Name.Text+=Global.books[i].Name;
                        info.ID.Text+=Global.books[i].ID;
                        info.Price.Text+=Global.books[i].Price;
                        info.Special1.Text = ("Writer: "+Global.books[i].Writer);
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
            this.NameTextBlock.Text = "Welcome Back! "+Global.sellers[sellerIndex].Username+" !!!";
            if (Global.sellers[sellerIndex].HasChangedBefore == false)
            {
                this.LastTimeChanged.Text = "YOU HAVEN'T CHANGED YOUR PASSWORD YET!!!";
            }
            else
            {
                this.LastTimeChanged.Text= Global.sellers[sellerIndex].LastTime.ToString("F"); 
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
            Global.sellers[sellerIndex].Password=this.NewPasswordTextBox.Text;
            Global.sellers[sellerIndex].HasChangedBefore = true;
            Global.sellers[sellerIndex].LastTime=DateTime.Now;
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
            whichMedia=3;   
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Library.AddMedia(whichMedia,this);

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
            for(int i = 0; i < Global.students.Count; i++)
            {
                int j = i + 1;
                this.StudentData.Text += (j + " :");
                this.StudentData.Text += "\n";
                this.StudentData.Text += ("Username: "+Global.students[i].Username);
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
