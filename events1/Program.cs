namespace events1;

class Program
{
    static void Main(string[] args)
    {
        Robot bot = new Robot();
        bot.onBack += WriteToFile;
        Console.WriteLine($"Ваша текущая скорость: {bot.speed}\nДля увеличения скорости нажмите \"+\" или \"-\"\n");
        while (true)
        {
            if (bot.speed == 0)
            {
                Console.WriteLine($"Робот не движется");
            }
            else
            {
                Console.WriteLine($"Робот движется {bot.Move()}");
            }
            Console.WriteLine($"Текущая скорость: {bot.speed}");
            Console.WriteLine($"Текущие координаты(x, y): {bot.x}, {bot.y}");
            Console.WriteLine();
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Add)
            {
                bot.speed++;
            }
            else if (key.Key == ConsoleKey.Subtract)
            {
                if (bot.speed > 0)
                    bot.speed--;
                else bot.speed = 0;
            }
            else continue;
        }
        
    }

    private static void WriteToFile(Robot robot)
    {
        using (StreamWriter sw = new StreamWriter(new FileStream("Log.txt", FileMode.Append, FileAccess.Write)))
        {
            //Console.WriteLine(1);
            sw.WriteLine($"{DateTime.Now}. Робот движется вниз со скоростью {robot.speed}");
            sw.WriteLine($"Координаты: {robot.x}, {robot.y}\n");
        }
    }
}

