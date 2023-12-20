
public class Email
{
    public DateTime Date { get; set; }
    public string Recipient { get; set; }

    public Email(DateTime date, string recipient)
    {
        Date = date;
        Recipient = recipient;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Создание экземпляра коллекции и заполнение элементами
        List<Email> emails = new List<Email>()
        {
            new Email(new DateTime(2022, 1, 1), "recipient1@example.com"),
            new Email(new DateTime(2022, 1, 1), "recipient2@example.com"),
            new Email(new DateTime(2022, 1, 2), "recipient1@example.com"),
            new Email(new DateTime(2022, 1, 3), "recipient3@example.com"),
            new Email(new DateTime(2022, 1, 3), "recipient4@example.com")
        };

        // Запрос LINQ группирует письма по дате отправления и количества писем в каждой группе
        var groupedEmails = emails.GroupBy(e => e.Date)
                                  .Select(g => new { Date = g.Key, Count = g.Count() });

        // Вывод результатов в консоль
        foreach (var group in groupedEmails)
        {
            Console.WriteLine($"Дата: {group.Date.ToShortDateString()}, Количество писем: {group.Count}");
        }
    }
}

