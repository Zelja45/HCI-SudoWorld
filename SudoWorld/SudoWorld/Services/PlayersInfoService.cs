using Newtonsoft.Json;
using SudoWorld.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SudoWorld.Services
{
    public class PlayersInfoService
    {
        public static readonly int SUDOKU_HINT_COST = 50;
        private static readonly string PLAYER_INFO_PATH="./playerInfo.json";
        public PlayerInfo PlayerInfo { get; set; }

        public PlayersInfoService()
        {
            if (!File.Exists(PLAYER_INFO_PATH))
            {
                using (var file = File.Create(PLAYER_INFO_PATH))
                {
                    
                }

                PlayerInfo = new PlayerInfo(500);
                WritePlayerInfo();
            }
            else
                ReadPlayerInfo();
        }
        private void ReadPlayerInfo()
        {
            string json = File.ReadAllText(PLAYER_INFO_PATH);
            PlayerInfo = JsonConvert.DeserializeObject<PlayerInfo>(json);
        }
        private void WritePlayerInfo() 
        {
            string json = JsonConvert.SerializeObject(PlayerInfo, Formatting.Indented);
            File.WriteAllText(PLAYER_INFO_PATH, json);
        }
        public void AddFinishedGameInfo(String difficulty,TimeSpan playTime,int missedValues)
        {
            GameDifficultyStats stats = PlayerInfo.GetGameDifficultyByName(difficulty);
            if (stats.BestTime > playTime)
                stats.BestTime = playTime;
            stats.AverageMissedValues = (stats.AverageMissedValues*stats.PlayedGames+missedValues)/(stats.PlayedGames+1);
            stats.AverageTime = new TimeSpan((stats.AverageTime.Ticks * stats.PlayedGames + playTime.Ticks) / (stats.PlayedGames + 1));
            stats.PlayedGames++;
            PlayerInfo.TokensBalance += stats.TokensForWin;
            WritePlayerInfo();
        }
        public int UseHint()
        {
            PlayerInfo.TokensBalance -= SUDOKU_HINT_COST;
            WritePlayerInfo();
            return PlayerInfo.TokensBalance;
    }
    }
}
