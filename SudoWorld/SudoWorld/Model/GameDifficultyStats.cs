using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class GameDifficultyStats
    {
        private readonly int HARD_TOKEN_VALUE = 200;
        private readonly int EASY_TOKEN_VALUE = 100;
        private readonly int MEDIUM_TOKEN_VALUE = 150;
        
        public string Difficulty { get; set; }
        public TimeSpan BestTime { get; set; }
        public int PlayedGames { get; set; }
        public TimeSpan AverageTime { get; set; }
        public double AverageMissedValues { get; set; }

        public GameDifficultyStats() { }
        public GameDifficultyStats(string difficulty)
        {
            Difficulty= difficulty;
            BestTime = TimeSpan.MaxValue;
        }
        public int GetTokensForWin(string difficulty)
        {
            if (difficulty.ToLower().Equals(difficulty))
                return HARD_TOKEN_VALUE;
            else if (difficulty.ToLower().Equals(difficulty))
                return EASY_TOKEN_VALUE;
            else if (difficulty.ToLower().Equals(difficulty))
                return EASY_TOKEN_VALUE;
            else
                return 0;
        }

    }
}
