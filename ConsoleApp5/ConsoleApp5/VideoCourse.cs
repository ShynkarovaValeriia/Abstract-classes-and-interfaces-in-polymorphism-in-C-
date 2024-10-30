using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Клас Відеокурс
    public class VideoCourse : Course, IWatchable
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Назва відеокурсу: {Title}, Викладач: {Instructor}, Тривалість: {Duration} годин");
        }

        public void Watch()
        {
            Console.WriteLine($"Перегляд курсу:");
        }
    }
}
