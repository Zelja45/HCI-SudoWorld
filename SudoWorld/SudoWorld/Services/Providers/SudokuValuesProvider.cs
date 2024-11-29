using SudoWorld.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SudoWorld.Services.Providers
{
    public class SudokuValuesProvider
    {
        private static readonly string SUDOKU_API_URL = "https://sudoku-api.vercel.app/api/dosuku";
        private static readonly string QUERY = "?query={newboard(limit:1){grids{value,solution,difficulty},results,message}}";
        private HttpClient _httpClient;

        public SudokuValuesProvider()
        {
            _httpClient = new HttpClient();
        }
        public async Task<SudokuBoard> getSudokuGrid()
        {
            SudokuBoard? createdBoard = null;
            _httpClient.BaseAddress = new Uri(SUDOKU_API_URL);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _httpClient.GetAsync(QUERY);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    var root = doc.RootElement.GetProperty("newboard");

                    var boards = root.GetProperty("grids");
                    var board = boards[0];

                    var value = ParseToListOfLists(board.GetProperty("value"));
                    var solution = ParseToListOfLists(board.GetProperty("solution"));
                    var difficulty = board.GetProperty("difficulty").GetString();


                    List<SudokuGrid> grids = ConvertToSudokuBoard(value, solution);
                    createdBoard = new SudokuBoard(grids, difficulty);
                }
            }
            _httpClient.Dispose();
            return createdBoard;

        }
        private static List<SudokuGrid> ConvertToSudokuBoard(List<List<int>> values, List<List<int>> solution)
        {
            List<SudokuGrid> grids = new List<SudokuGrid>();
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    List<int> valuesGrid = new List<int>();
                    List<int> solutionGrid = new List<int>();


                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            valuesGrid[x + y * 3] = values[i + x][j + y];
                            solutionGrid[x + y * 3] = solution[i + x][j + y];
                        }
                    }

                    grids.Add(new SudokuGrid(valuesGrid, solutionGrid));
                }
            }
            return grids;
        }
        private static List<List<int>> ParseToListOfLists(JsonElement element)
        {
            return element.EnumerateArray()
                          .Select(row => row.EnumerateArray()
                                           .Select(cell => cell.GetInt32())
                                           .ToList())
                          .ToList();
        }

    }

}
