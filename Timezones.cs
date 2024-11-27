using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Compare two DateTime objects
        DateTime date1 = new DateTime(2023, 11, 20);
        DateTime date2 = new DateTime(2024, 3, 15);
        CompareDates(date1, date2);

        // Task 2: Print current time in New York and Tokyo
        PrintCurrentTimeInZones();

        // Task 3: Days until midsummer
        int daysUntilMidsummer = DaysUntilMidsummer();
        Console.WriteLine($"Days until midsummer day: {daysUntilMidsummer}");

        // Task 4: Print leap years around a given year
        int year = 2000; // Example year
        PrintLeapYearInfo(year);
    }

    // Task 1: Compare two DateTime objects
    static void CompareDates(DateTime dt1, DateTime dt2)
    {
        if (dt1 > dt2)
        {
            Console.WriteLine($"{dt1} is later than {dt2}");
        }
        else if (dt1 < dt2)
        {
            Console.WriteLine($"{dt2} is later than {dt1}");
        }
        else
        {
            Console.WriteLine($"{dt1} and {dt2} are the same.");
        }
    }

    // Task 2: Print current time in New York and Tokyo
    static void PrintCurrentTimeInZones()
    {
        DateTime utcNow = DateTime.UtcNow;

        DateTime tokyoTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "Tokyo Standard Time");
        DateTime newYorkTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "Eastern Standard Time");
        Console.OutputEncoding = Encoding.Unicode; // To display japanese characters
        Console.WriteLine("Current time in Tokyo: " + tokyoTime.ToString("f", new CultureInfo("ja-JP")));
        Console.WriteLine("Current time in New York: " + newYorkTime.ToString("f", new CultureInfo("en-US")));
    }

    // Task 3: Days until midsummer
    static int DaysUntilMidsummer()
    {
        DateTime midsummer = new DateTime(DateTime.Now.Year, 6, 24); // June 24
        if (DateTime.Now > midsummer)
        {
            // If midsummer has already passed this year, use next year's midsummer
            midsummer = new DateTime(DateTime.Now.Year + 1, 6, 24);
        }

        return (midsummer - DateTime.Now).Days;
    }

    // Task 4: Print leap years around a given year
    static void PrintLeapYearInfo(int year)
    {
        for (int offset = -10; offset <= 10; offset++)
        {
            int currentYear = year + offset;
            bool isLeap = DateTime.IsLeapYear(currentYear);

            string leapText = isLeap ? "a leap year" : "not a leap year";
            Console.WriteLine($"{Math.Abs(offset)} year(s) {(offset < 0 ? "ago" : "ahead")} was {currentYear}, which is {leapText}.");
        }

        int totalDays = 0;
        for (int y = year - 10; y <= year + 10; y++)
        {
            totalDays += DateTime.IsLeapYear(y) ? 366 : 365;
        }

        Console.WriteLine($"Total days in this range: {totalDays}");
    }
}
