using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace SudoWorld.Model
{
    public class PlayerInfo
    {
        public int TokensBalance { get; set; }
        public GameDifficultyStats Easy { get; set; }
        public GameDifficultyStats Medium { get; set; }
        public GameDifficultyStats Hard { get; set; }

        public PlayerInfo(int TokenBalance)
        {
            TokensBalance = TokenBalance;
            Easy = new GameDifficultyStats("Easy",GameDifficultyStats.EASY_TOKEN_VALUE);
            Medium = new GameDifficultyStats("Medium",GameDifficultyStats.MEDIUM_TOKEN_VALUE);
            Hard = new GameDifficultyStats("Hard",GameDifficultyStats.HARD_TOKEN_VALUE);
        }
        public PlayerInfo() { }

        public GameDifficultyStats GetGameDifficultyByName(String name)
        {
            if (Easy.Difficulty.ToLower().Equals(name.ToLower()))
                return Easy;
            else if (Hard.Difficulty.ToLower().Equals(name.ToLower()))
                return Hard;
            else if (Medium.Difficulty.ToLower().Equals(name.ToLower()))
                return Medium;
            else
                return null;
        }
        [JsonIgnore]
        public int GetTotalNumOfWins
        {
            get
            {
                int sum = 0;
                foreach (var property in this.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(GameDifficultyStats))
                    {
                        var gameStats = property.GetValue(this) as GameDifficultyStats;
                        if (gameStats != null)
                        {
                            sum += gameStats.PlayedGames;
                        }
                    }
                }
                return sum;
            }
        }


       
    }
}
