using System;
using System.Collections.Generic;
using YahtzeeLight.Infrastructure;

namespace YahtzeeLight.Models
{
    public class Game
    {
        public static void genereerWorpen()
        {
            List<int> worp = new List<int>();
            List<List<int>> worpen = new List<List<int>>();

            foreach (Speler speler in Database.Spelers)
            {
                worpen = new List<List<int>>();
                for (int i = 0; i < 10; i++)
                {
                    worp = new List<int>();
                    for (int j = 0; j < 5; j++)
                    {
                        int dobbel = DiceRandom.random.Next(1, 7);
                        worp.Add(dobbel);
                    }
                    worpen.Add(worp);
                }
                speler.Worpen = worpen;
            }
        }
    }
}
