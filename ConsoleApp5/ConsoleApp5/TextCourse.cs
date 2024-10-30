using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Клас Текстовий курс
    public class TextCourse : Course, IReadable
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"Назва текстового курсу: {Title}, Викладач: {Instructor}, Тривалість: {Duration} годин");
        }

        public void Read()
        {
            Console.WriteLine($"Читання курсу:");
        }
    }
}
