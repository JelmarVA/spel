using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YahtzeeLight.Models
{
    public class Database
    {
        private static List<Speler> spelers = new List<Speler>();

        public static IEnumerable<Speler> Spelers
        {
            get
            {
                return spelers;
            }
        }

        public static int getID()
        {
            return spelers.Count() + 1;
        }

        public static void ClearSpelers() {
            spelers = new List<Speler>();
        }

        public static void VoegSpelerToe(Speler speler)
        {
            spelers.Add(speler);
        }

        public static int TotaalAantalSpelers()
        {
            return spelers.Count();
        }

        public static List<Speler> getSpelersOrderedByScore()
        {
            List<Speler> sortedSpelers = spelers;
            sortedSpelers.Sort((Speler s1, Speler s2) => s1.TotaleScore.CompareTo(s2.TotaleScore));
            sortedSpelers.Reverse();
            return sortedSpelers;
        }

    }
}
