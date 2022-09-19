using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

//1 Добавьте группы для студентов
//2 Добавьте навигационное свойство к студенту, ведущее на группу студента
//3 Добавьте обратное навигационное свойство в группу, которое позволит получить всех студентов из группы
//4 Заполните группы тестовыми данными
//5 Выполните запрос через EF, возвращающий все группы с заполненными студентами
//6 * Реализуйте запрос на EF, который выведет всех студентов, посетивших любой предмет в сентябре 2022 г.

namespace InverseNavigation
{
    public class AppDbContext:DbContext
    {
        private const string ConnectionString = "Data Source = C:\\Users\\kirsa\\OneDrive\\Рабочий стол\\Академия Шаг\\ADO.net and Entity Frimework\\home work\\08.09.22\\InverseNavigation\\InverseNavigation\\bin\\Debug\\net6.0-windows\\Attendance.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
