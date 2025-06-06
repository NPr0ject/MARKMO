using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Phone
{
    public string Number { get; set; }
    public string Operator { get; set; }
    public int RegistrationYear { get; set; }

    public Phone(string number, string operatorName, int registrationYear)
    {
        Number = number;
        Operator = operatorName;
        RegistrationYear = registrationYear;
    }

    public override string ToString()
    {
        return $"Номер: {Number}, Оператор: {Operator}, Год регистрации: {RegistrationYear}";
    }
}

public class User
{
    public string Name { get; set; }
    public string City { get; set; }
    public List<Phone> Phones { get; set; } = new List<Phone>();

    public User(string name, string city)
    {
        Name = name;
        City = city;
    }

    public void AddPhone(Phone phone)
    {
        Phones.Add(phone);
    }

    public override string ToString()
    {
        string info = string.Join("\n", Phones.Select((p, i) => $"  {i + 1}. {p}"));
        return $"Пользователь: {Name}, Город: {City}\nТелефоны:\n{info}";
    }
}

public class Program
{
    private static List<User> users = new List<User>();
    private static void AddUserAndPhone()
    {
        Console.Write("Имя: ");
        string Name = Console.ReadLine();
        Console.Write("Город: ");
        string city = Console.ReadLine();
        Console.Write("Номер телефона: ");
        string number = Console.ReadLine();
        Console.Write("Оператор связи: ");
        string operatorName = Console.ReadLine();
        Console.Write("Год постановки на учёт: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный год. Операция отменена.");
            return;
        }
        var user = new User(Name, city);
        user.AddPhone(new Phone(number, operatorName, year));
        users.Add(user);

        Console.WriteLine("Пользователь и телефон успешно добавлены!");
    }

    private static void SearchByPhoneNumber()
    {
        Console.Write("Введите номер телефона для поиска: ");
        string number = Console.ReadLine();
        var found = users.Where(u => u.Phones.Any(p => p.Number.Contains(number))).ToList();
        if (found.Any())
        {
            Console.WriteLine("\nНайденные пользователи:");
            foreach (var user in found)
            {
                Console.WriteLine(user);
                Console.WriteLine(new string('-', 40));
            }
        }
        else
        {
            Console.WriteLine("Пользователи с таким номером не найдены.");
        }
    }

    private static void SearchByOperator()
    {
        Console.Write("Введите оператора связи для поиска: ");
        string operatorName = Console.ReadLine();
        var results = users.SelectMany(u => u.Phones.Where(p => p.Operator.Equals(operatorName, StringComparison.OrdinalIgnoreCase)).Select(p => new { User = u, Phone = p })).ToList();

        if (results.Any())
        {
            Console.WriteLine("\nНайденные записи:");
            foreach (var result in results)
            {
                Console.WriteLine(result.User.Name);
                Console.WriteLine(result.Phone);
                Console.WriteLine(new string('-', 40));
            }
        }
        else
        {
            Console.WriteLine("Записи с таким оператором не найдены.");
        }
    }
    private static void SearchByRegistrationYear()
    {
        Console.Write("Введите год постановки на учёт для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный год. Операция отменена.");
            return;
        }
        var results = users.SelectMany(u => u.Phones.Where(p => p.RegistrationYear == year).Select(p => new { User = u, Phone = p })).ToList();

        if (results.Any())
        {
            Console.WriteLine("\nНайденные записи:");
            foreach (var result in results)
            {
                Console.WriteLine(result.User.Name);
                Console.WriteLine(result.Phone);
                Console.WriteLine(new string('-', 40));
            }
        }
        else
        {
            Console.WriteLine("Записи с таким годом регистрации не найдены.");
        }
    }
    static void ShowOperatorStatistics()
    {
        Dictionary<string, int> operatorStats = new Dictionary<string, int>();
        foreach (var user in users)
        {
            foreach (var phone in user.Phones)
            {
                if (operatorStats.ContainsKey(phone.Operator))
                {
                    operatorStats[phone.Operator]++;
                }
                else
                {
                    operatorStats.Add(phone.Operator, 1);
                }
            }
        }
        Console.WriteLine("\nСтатистика по операторам:");
        if (operatorStats.Count > 0)
        {
            var sortedStats = operatorStats.OrderByDescending(x => x.Value);

            foreach (var stat in sortedStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value} раз(а)");
            }
        }
        else
        {
            Console.WriteLine("Нет данных об операторах.");
        }
    }
    private static void ShowAllUsers()
    {
        if (users.Any())
        {
            Console.WriteLine("\nВсе пользователи:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("Справочник пуст.");
        }
    }
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Добавить пользователя и телефон");
            Console.WriteLine("2. Поиск по номеру телефона");
            Console.WriteLine("3. Поиск по оператору связи");
            Console.WriteLine("4. Поиск по году постановки на учёт");
            Console.WriteLine("5. Показать всех пользователей");
            Console.WriteLine("6. Показать статистику операторов");
            Console.WriteLine("7. Выход");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUserAndPhone();
                    break;
                case "2":
                    SearchByPhoneNumber();
                    break;
                case "3":
                    SearchByOperator();
                    break;
                case "4":
                    SearchByRegistrationYear();
                    break;
                case "5":
                    ShowAllUsers();
                    break;
                case "6":
                    ShowOperatorStatistics();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
