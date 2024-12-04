using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class GameDifficultyStats
    {
        public static readonly int HARD_TOKEN_VALUE = 200;
        public static readonly int EASY_TOKEN_VALUE = 100;
        public static readonly int MEDIUM_TOKEN_VALUE = 150;
        private string _bestTimeString;
        public int TokensForWin { get; set; }
        public string Difficulty { get; set; }
        public TimeSpan BestTime { get; set; }
        [JsonIgnore]
        public string BestTimeString { get => BestTime == TimeSpan.MaxValue ? "--:--:--" : BestTime.ToString(); }
        public int PlayedGames { get; set; }
        public TimeSpan AverageTime { get; set; }
        public double AverageMissedValues { get; set; }

        public GameDifficultyStats() { }
        public GameDifficultyStats(string difficulty,int tokensForWin)
        {
            Difficulty= difficulty;
            BestTime = TimeSpan.MaxValue;
            TokensForWin = tokensForWin;
        }
        

    }
}
