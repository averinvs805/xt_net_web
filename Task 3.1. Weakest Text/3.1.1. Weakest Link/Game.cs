using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._Weakest_Text
{
    public class Game
    {
        static string GetStringFromList(List<int> data)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var elem in data)
            {
                stringBuilder.Append($"{elem},");
            }

            return stringBuilder
                .ToString()
                .Trim(',');
        }

        public static void RunGame(int n, int step)
        {
            List<int> users = new List<int>();

            for (int e = 0; e < n; e++)
            {
                users.Add(e + 1);
            }

            int i = -1, round = 1, count = n;
            while (count != step - 1)
            {
                var i_next = i + step;

                //Когда итератор выходит за границу массива, делим его с остатком на длину массива
                i = i_next < count
                    ? i_next
                    : i_next % count;

                Console.WriteLine($"Раунд {round}. Выбыл игрок под номером {users[i]}. Осталось игроков: {users.Count - 1}");

                users.RemoveAt(i);
                count -= 1;

                round += 1;
                i -= 1;
            }

            Console.WriteLine("Игра окончена. Номера победителей: " + Environment.NewLine + GetStringFromList(users));
        }
    }
}
