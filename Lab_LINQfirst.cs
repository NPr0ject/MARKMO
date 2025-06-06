using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiP_LINQ
{
    class PhoneRecord
    {
        public string Number;
        public int Year;
        public string Operator;
        public string Name;

        public override string ToString()
        {
            return $"Номер: {Number}, Год подключения: {Year}, Оператор: {Operator}, ФИО: {Name}";
        }
    }
    class Program
    {
        static List<PhoneRecord> phoneRecords = new List<PhoneRecord>();
        static void GroupByConnectionYear()
        {
            var grouped = phoneRecords.GroupBy(r => r.Year).OrderBy(g => g.Key);
            foreach (var group in grouped)
            {
                Console.WriteLine($"\nГод подключения: {group.Key}");
                foreach (var record in group)
                {
                    Console.WriteLine(record);
                }
            }
        }
        static void GroupByOperator()
        {
            var grouped = phoneRecords.GroupBy(r => r.Operator).OrderBy(g => g.Key);
            foreach (var group in grouped)
            {
                Console.WriteLine($"\nОператор: {group.Key}");
                foreach (var record in group)
                {
                    Console.WriteLine(record);
                }
            }
        }
        static void SearchByPhoneNumber()
        {
            Console.Write("Введите номер телефона для поиска: ");
            string searchNumber = Console.ReadLine();
            var result = phoneRecords.Where(r => r.Number.Contains(searchNumber)).ToList();
            if (result.Any())
            {
                Console.WriteLine("\nНайденные записи:");
                foreach (var record in result)
                {
                    Console.WriteLine(record);
                }
            }
            else
            {
                Console.WriteLine("Записи с таким номером не найдены.");
            }
        }
        static void SearchByFullName()
        {
            Console.Write("Введите ФИО или часть для поиска: ");
            string searchName = Console.ReadLine();
            var result = phoneRecords.Where(r => r.Name.ToLower().Contains(searchName.ToLower())).ToList();
            if (result.Any())
            {
                Console.WriteLine("\nНайденные записи:");
                foreach (var record in result)
                {
                    Console.WriteLine(record);
                }
            }
            else
            {
                Console.WriteLine("Записи с таким ФИО не найдены.");
            }
        }
        static void Main(string[] args)
        {
            phoneRecords.AddRange(new[]
            {
            new PhoneRecord { Number = "79123456789", Year = 2020, Operator = "МТС", Name = "Иванов Марк" },
            new PhoneRecord { Number = "79234567890", Year = 2021, Operator = "Билайн", Name = "Жуков Павел" },
            new PhoneRecord { Number = "79345678901", Year = 2020, Operator = "Мегафон", Name = "Леонтьев Андрей" },
            new PhoneRecord { Number = "79456789012", Year = 2022, Operator = "МТС", Name = "Сан Саныч" }
        });
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Группировка по дате подключения");
                Console.WriteLine("2. Группировка по оператору связи");
                Console.WriteLine("3. Поиск по номеру телефона");
                Console.WriteLine("4. Поиск по ФИО");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        GroupByConnectionYear();
                        break;
                    case 2:
                        GroupByOperator();
                        break;
                    case 3:
                        SearchByPhoneNumber();
                        break;
                    case 4:
                        SearchByFullName();
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
