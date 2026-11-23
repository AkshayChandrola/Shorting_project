using System;

namespace Task_2.Services
{
    public static class InputService
    {
        public static int ReadInt(string prompt, Func<int, bool> validator, string errorMessage)
        {
            Console.WriteLine(prompt);
            int value;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out value) && validator(value))
                    return value;
                Console.WriteLine(errorMessage);
            }
        }
    }
}
