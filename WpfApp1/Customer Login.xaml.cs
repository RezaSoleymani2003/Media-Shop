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
            if(CustomerLogin.WhichCustomer == 1)
            {
                if (Global.studentsIDs.Contains(this.CustomerKeyBox.Text))
                {
                    for(int i=0; i < Global.students.Count; i++)
                    {
                        if(Global.studentsIDs[i] == this.CustomerKeyBox.Text)
                        {
                            Window2 window2 = new Window2(0,20, Global.students[i].Username);    
                            window2.Show();
                            this.Close();
                        }
                        else
                        {
                            Global.Message("IVALID STUDENT ID","Please Enter The Correct Student ID !!!");
                        }
                    }
                }
                else
                {
                    Student student = new Student();
                    student.Username=this.CustomerUsernameBox.Text;
                    student.ID=this.CustomerKeyBox.Text;
                    if (student.Check()==true)
                    {
                        Global.students.Add(student);
                        Global.studentsIDs.Add(student.ID);
                        string content=Global.ReadFromFile(Global.StudentsPath);
                        string[]arr=content.Split(' ');
                        StreamWriter writer=new StreamWriter(Global.StudentsPath);  
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
                teacher.Username=this.CustomerUsernameBox.Text;
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

            if(CustomerLogin.WhichCustomer == 3)
            {
                Customer customer=new Customer();
                customer.Username=this.CustomerUsernameBox.Text;
                customer.Ssn = this.CustomerKeyBox.Text;
                if (Global.customersSsns.Contains(customer.Ssn))
                {
                    for(int i=0;i<Global.customers.Count; i++)
                    {
                        if (Global.customers[i].Ssn == customer.Ssn)
                        {
                            Window2 window2 = new Window2(5,5, customer.Username);
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
                    if (customer.Ssn.Check()==true)
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
                        Window2 window2 = new Window2(5, 5,customer.Username);
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
