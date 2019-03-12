using System;

namespace RandNum
{
    class Program
    {
        static Random rand = new Random();
        static void Rules()
        {
            //Вывод правил игры
            Console.WriteLine("Правила игры: \nУгадай число, за определенное число попыток. \n\nНастроим условия игры: ");
        }
        static int AskUser(string message)
        {
            //метод выводит сообщение и запрашивает число, проверяя его на валидность
            Console.WriteLine(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Не является числом!");
            }
        }
        static int GenerationRandValue(int interval)
        {
            int rndValue = 1 + rand.Next(interval); //генерируем случайно число и записываем его в переменную
            return rndValue; //возвращаем рандомное значение
        }
        static string Game(int attemp, int rndValue, int interval)
        {
            int numAttemp = 0; //хранение количества попыток
            while (attemp > 0)
            {
                numAttemp++; //счетчик попыток (с какой угадал)
                attemp--; //счетчик попыток (сколько осталось)

                int entNum = AskUser($"Попытка {numAttemp}. Введите число: ");  //запись в переменную числа, которое ввел пользователь

                if (entNum == 0 || entNum > interval || entNum < 0)
                {
                    return $"Будь внимательнее! От 1 до {interval}.";
                }
                if (entNum == rndValue)
                {
                    return $"Молодец! Ты угадал с {numAttemp} попытки.";
                }
            }
            return "Не угадал, это число " + rndValue + ".";
        }
        static void Main(string[] args)
        {
            Console.Title = "Угадай число"; //заголовок окна консоли
            Rules(); //вывод правил

            int interval = AskUser("Выберите промежуток чисел от 1 до "); //переменная для хранения числа промежутка            
            int attemp = AskUser("Введите количество попыток: "); //переменная для хранения числа количества попыток
            int rndValue = GenerationRandValue(interval); //переменная для хранения рандомного числа

            Console.WriteLine(Game(attemp, rndValue, interval));
            Console.ReadKey();
        }
    }
}