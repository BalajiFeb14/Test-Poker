using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

  
public class Poker
{
    public class Card 
    {
        public string Rank { get; set; }
        public  int Value { get; set; }
    }
    public static void Main()
    {
        while (true)
        {
            string[] arr = new string[5];
            int i;
            var hand = new Card[]
            {
                new Card { Rank = "A", Value = 14 },
                new Card { Rank = "K", Value = 13 },
                new Card { Rank = "Q", Value = 12 },
                new Card { Rank = "J", Value = 11 },
                new Card { Rank = "10", Value = 10},
                new Card { Rank = "9", Value = 9},
                new Card { Rank = "8", Value =8},
                new Card { Rank = "7", Value = 7},
                new Card { Rank = "6", Value = 6},
                new Card { Rank = "5", Value = 5},
                new Card { Rank = "4", Value = 4},
                new Card { Rank = "3", Value = 3},
                new Card { Rank = "2", Value = 2},

            };

            Console.Write("Enter 5 card elements in the array :\n");
            for (i = 0; i < 5; i++)
            {
                Console.Write("element - {0} : ", i+1);
                arr[i] = Console.ReadLine().ToString().ToUpper();
                //string input;
                //do
                //{
                //    input = Console.ReadLine().ToString().ToUpper();
                //} while (!hand.ToList().Any(x=>x.Rank== input));
            }



           var duplicates = arr.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => new { Item = y.Key, result = "true" })
                  .ToList();

            if (duplicates.Count <= 0)
            {
                var notduplicates = arr.GroupBy(x => x)
                     .Where(g => g.Count() <= 1)
                     .Select(y => new { Item = y.Key, Count = y.Distinct().Count(), result = "false" })
                     .ToList();

                duplicates.Add(new { Item = "no pair found", result = "false" });
                //Console.WriteLine(String.Join("\n", "false"));
                // Console.WriteLine(String.Join("\n", "Card Pair:{" + String.Join(",", notduplicates.Select(s => s.Item)) + "},False"));
            }
            else
            {
                var new_Dict = hand.Where(p => p.Rank != null && duplicates.Exists(a => a.Item == p.Rank)).Distinct().ToList();
                duplicates.Clear();
                if (new_Dict.Count > 0)
                {
                    var maxRate = new_Dict.OrderByDescending(x => x.Value).First();

                    duplicates.Add(new { Item = maxRate.Rank, result = "true" });
                }
                else
                {
                    duplicates.Add(new { Item = "Invalid pair.Please key in correct poker card", result = "false" });
                }


            }

            Console.WriteLine(String.Join("\n", duplicates));
            Console.ReadLine();
        }

    }
}