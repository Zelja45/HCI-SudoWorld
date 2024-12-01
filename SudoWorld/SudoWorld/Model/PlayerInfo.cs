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
            Easy = new GameDifficultyStats("Easy");
            Medium = new GameDifficultyStats("Medium");
            Hard = new GameDifficultyStats("Hard");
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


       
    }
}
