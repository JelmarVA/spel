using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YahtzeeLight.Infrastructure
{
    public class Combinatie
    {

        public static bool IsChance(List<int> combinatie) {
            return !IsYahtzee(combinatie) && !IsGroteStraat(combinatie) && !IsKleineStraat(combinatie) && !IsDrieGelijke(combinatie) && !IsVierGelijke(combinatie) && !IsFullHouse(combinatie);
        }

        public static bool IsYahtzee(List<int> combinatie)
        {
            List<int> local = new List<int>(combinatie);

            if (local.TrueForAll(i => i.Equals(local.FirstOrDefault())))
            {
                return true;
            }

            return false;
        }

        public static bool IsGroteStraat(List<int> combinatie)
        {

            List<int> local = new List<int>(combinatie);

            local.Sort();

            int[] groteStraat1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] groteStraat2 = new int[5] { 2, 3, 4, 5, 6 };
            bool isGS1 = local.Intersect(groteStraat1).Count() == 5;
            bool isGS2 = local.Intersect(groteStraat2).Count() == 5;

            if (isGS1 || isGS2)
            {
                return true;
            }

            return false;
        }

        public static bool IsKleineStraat(List<int> combinatie)
        {

            List<int> local = new List<int>(combinatie);

            local.Sort();

            local = local.Distinct().ToList();

            int[] kleineStraat1 = new int[4] { 1, 2, 3, 4 };
            int[] kleineStraat2 = new int[4] { 2, 3, 4, 5 };
            int[] kleineStraat3 = new int[4] { 3, 4, 5, 6 };

            bool isKS1 = local.Intersect(kleineStraat1).Count() == 4;
            bool isKS2 = local.Intersect(kleineStraat2).Count() == 4;
            bool isKS3 = local.Intersect(kleineStraat3).Count() == 4;

            if (isKS1 || isKS2 || isKS2)
            {
                if (IsGroteStraat(local) || IsYahtzee(local)) {
                    return false;
                }
                return true;
            }

            return false;
        }


        public static bool IsVierGelijke(List<int> combinatie)
        {

            List<int> local = new List<int>(combinatie);

            local.Sort();

            if (local[0] == local[1] && local[1] == local[2] && local[2] == local[3] && local[0] == local[3] || local[1] == local[2] && local[2] == local[3] && local[3] == local[4] && local[1] == local[4])
            {
                if(IsYahtzee(local)) {
                    return false;
                }
                return true;
            }

            return false;
        }

        public static bool IsDrieGelijke(List<int> combinatie)
        {

            List<int> local = new List<int>(combinatie);

            local.Sort();

            if (local[0] == local[1] && local[1] == local[2] || local[1] == local[2] && local[2] == local[3] || local[2] == local[3] && local[3] == local[4])
            {
                if (IsFullHouse(combinatie) || IsVierGelijke(combinatie)) {
                    return false;
                }
                return true;
            }

            return false;
        }

        public static bool IsFullHouse(List<int> combinatie)
        {

            List<int> local = new List<int>(combinatie);

            local.Sort();

            if (local[0] == local[1] && local[2] == local[3] && local[3] == local[4] || local[0] == local[1] && local[1] == local[2] && local[3] == local[4])
            {
                return true;
            }

            return false;
        }

        public static int getScoreFor(List<int> combinatie) {
            
            if(IsYahtzee(combinatie)) {
                return 50;
            } else if(IsFullHouse(combinatie)) {
                return 25;
            } else if (IsGroteStraat(combinatie)) {
                return 40;
            } else if (IsKleineStraat(combinatie)){
                return 30;
            }

            return berekenAantalOgen(combinatie);
        }

        private static int berekenAantalOgen(List<int> combinatie) {
            int score = 0;
            foreach (var oog in combinatie)
            {
                score += oog;
            }
            return score;
        }
    }
}
