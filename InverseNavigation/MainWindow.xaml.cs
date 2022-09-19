using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InverseNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new AppDbContext())
            {
                DataOutput();
                //addData();
               
            }
        }


        public async void DataOutput()
        {
            using (var db = new AppDbContext())
            {
                StringBuilder sb=new StringBuilder();
                var groups = await db.Groups.Include(it => it.Students).ToListAsync();
                foreach (var group in groups)
                {
                    sb.Append(group.NameGroup + ":\n");
                    foreach (var student in group.Students)
                    {
                        sb.Append(student.Name + "\n");
                    }
                }
                Attendance.Text = sb.ToString();


            }
        




            //dataGridAttendance.Items.Clear();
            //dataGridAttendance.ItemsSource= groups;
            //dataGridAttendance.Items.Refresh();
        

        }

        public async void addData()
        {
            using (var db = new AppDbContext())
            {
                Group group123 = new Group() { Id = Guid.NewGuid(), NameGroup = "123" };
                Group group111 = new Group() { Id = Guid.NewGuid(), NameGroup = "111" };
                await db.AddAsync(group123);
                await db.AddAsync(group111);

                Student student1 = new Student() { Id = Guid.NewGuid(), Name = "Tom", Group = group111 };
                Student student2 = new Student() { Id = Guid.NewGuid(), Name = "John", Group = group111 };
                Student student3 = new Student() { Id = Guid.NewGuid(), Name = "Julia", Group = group123 };
                Student student4 = new Student() { Id = Guid.NewGuid(), Name = "Peter", Group = group123 };
                Student student5 = new Student() { Id = Guid.NewGuid(), Name = "Sara", Group = group123 };
                await db.Students.AddAsync(student1);
                await db.Students.AddAsync(student2);
                await db.Students.AddAsync(student3);
                await db.Students.AddAsync(student4);
                await db.Students.AddAsync(student5);

                Subject math = new Subject() { Id = Guid.NewGuid(), Title = "Math" };
                Subject physics = new Subject() { Id = Guid.NewGuid(), Title = "Physics" };
                await db.Subjects.AddRangeAsync(math, physics);

                Visit visits1 = new Visit()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2022, 09, 02),
                    Student = student1,
                    Subject = math
                };
                Visit visits2 = new Visit()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2022, 09, 02),
                    Student = student2,
                    Subject = math
                };

                Visit visits3 = new Visit()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2022, 09, 02),
                    Student = student3,
                    Subject = physics
                };

                Visit visits4 = new Visit()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2022, 09, 02),
                    Student = student4,
                    Subject = physics
                };

                Visit visits5 = new Visit()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2022, 08, 02),
                    Student = student5,
                    Subject = math
                };
                await db.Visits.AddRangeAsync(visits1, visits2, visits3, visits4, visits5);
                await db.SaveChangesAsync();
            }
        }
    }

}
