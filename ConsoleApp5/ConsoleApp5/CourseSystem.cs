using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5
{
    // Клас для управління системою курсів
    public class CourseSystem
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void DisplayAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Немає курсів для відображення.");
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Title}");
            }
        }

        public void DisplayCourseDetails(int index)
        {
            if (index >= 0 && index < courses.Count)
            {
                if (courses[index] is IWatchable watchableCourse)
                {
                    watchableCourse.Watch();
                }
                else if (courses[index] is IReadable readableCourse)
                {
                    readableCourse.Read();
                }

                courses[index].DisplayInfo();
            }
            else
            {
                Console.WriteLine("Невірний номер. Перепровірте, чи існує такий курс.");
            }
        }

        // Метод для збереження до XML файлу
        public void SaveToFile(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Course>), new Type[] { typeof(VideoCourse), typeof(TextCourse) });
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, courses);
                }
                Console.WriteLine($"Дані успішно збережено у файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка при збереженні файлу: {filePath}. Помилка: {ex.Message}");
            }
        }

        // Метод для завантаження з XML файлу
        public void LoadFromFile(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Course>), new Type[] { typeof(VideoCourse), typeof(TextCourse) });
                using (StreamReader reader = new StreamReader(filePath))
                {
                    courses = (List<Course>)serializer.Deserialize(reader);
                }
                Console.WriteLine($"Дані успішно завантажено з файлу: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка при завантаженні файлу: {filePath}. Помилка: {ex.Message}");
            }
        }

        public void DisplayLoadedData()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Немає завантажених курсів.");
                return;
            }

            Console.WriteLine("Завантажені курси:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.");
                courses[i].DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}
