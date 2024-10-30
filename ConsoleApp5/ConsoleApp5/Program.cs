using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseSystem system = new CourseSystem();
            Course course = null;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Додати відеокурс");
                Console.WriteLine("2. Додати текстовий курс");
                Console.WriteLine("3. Вивести список курсів");
                Console.WriteLine("4. Вивести деталі курсу за номером");
                Console.WriteLine("5. Зберегти в файл");
                Console.WriteLine("6. Завантажити з файлу");
                Console.WriteLine("0. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    case "2":
                        string title, instructor;
                        int duration = 0;

                        Console.WriteLine("Введіть назву курсу:");
                        title = Console.ReadLine();

                        Console.WriteLine("Введіть ім'я викладача:");
                        instructor = Console.ReadLine();

                        bool validDuration = false;
                        while (!validDuration)
                        {
                            Console.WriteLine("Введіть тривалість курсу в годинах:");
                            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
                            {
                                validDuration = true;
                            }
                            else
                            {
                                Console.WriteLine("Некоректне значення, тривалість курсу повинна бути більше 0. Спробуйте ще раз.");
                            }
                        }

                        if (choice == "1")
                        {
                            course = new VideoCourse { Title = title, Instructor = instructor, Duration = duration };
                            Console.WriteLine("Відеокурс додано.");
                        }
                        else if (choice == "2")
                        {
                            course = new TextCourse { Title = title, Instructor = instructor, Duration = duration };
                            Console.WriteLine("Текстовий курс додано.");
                        }
                        else
                        {
                            Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        }

                        system.AddCourse(course);
                        break;

                    case "3":
                        system.DisplayAllCourses();
                        break;

                    case "4":
                        Console.WriteLine("Введіть номер курсу:");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            system.DisplayCourseDetails(index - 1);
                        }
                        else
                        {
                            Console.WriteLine("Некоректний номер.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Введіть ім'я файлу для збереження:");
                        string savePath = Console.ReadLine();
                        system.SaveToFile(savePath);
                        break;

                    case "6":
                        Console.WriteLine("Введіть ім'я файлу для завантаження:");
                        string loadPath = Console.ReadLine();
                        system.LoadFromFile(loadPath);
                        system.DisplayLoadedData();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("Бажаєте продовжити? (Так/Ні)");
                    if (Console.ReadLine().ToLower() != "так")
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }
}
