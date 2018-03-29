using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using YahtzeeLight.Infrastructure;

namespace YahtzeeLight.Models
{
    public class Speler
    {
        private List<int> _besteWorp;

        public int SpelerID { get; set; }

        public string Naam { get; set; }

        public int TotaleScore { get {
                return berekenTotaleScore();
            }
        } 

        public List<List<int>> Worpen { get; set; }

        public IEnumerable<int> BesteWorp {
            get {
                return sorteerVolgensWaarde(this._besteWorp);
            }
        } 

        private int berekenTotaleScore()
        {
            int score = 0;
            _besteWorp = null;

            foreach (var worp in Worpen)
            {
                int scoreWorp = Combinatie.getScoreFor(worp);
                score += scoreWorp;
                if (_besteWorp == null || scoreWorp > Combinatie.getScoreFor(this._besteWorp))
                {
                    this._besteWorp = worp;
                }
            }

            return score;
        }

        private IEnumerable<int> sorteerVolgensWaarde(List<int> combo)
        {
            List<int> local = combo;

            local.Sort((int a, int b) => a - b);

            return local;
        }
    }
}
