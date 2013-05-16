namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        private readonly string scoreboardLocation = "../../scoreboard.txt";

        public string GetScoreboardFileLocation()
        {
            return scoreboardLocation;
        }

        public string ShowScoreboard()
        {
            StringBuilder scoreboardResult = new StringBuilder();
            var scoreboardSorted = this.SortReadedScoreboardFile();
            int playerPosition = 0;

            foreach (var result in scoreboardSorted)
            {
                scoreboardResult.AppendFormat("{0}: {1} -> {2}", ++playerPosition, result.Key, result.Value).AppendLine();
            }

            if (scoreboardResult.ToString() == string.Empty)
            {
                scoreboardResult.AppendFormat("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
            }

            string scoreboard = scoreboardResult.ToString();
            return scoreboard;
        }

        public void AddPlayerInScoreboard(string playerName, int playerScore)
        {
            File.AppendAllText(scoreboardLocation, string.Format("{0} {1} {2}", playerName, playerScore, Environment.NewLine));
        }

        private List<KeyValuePair<string, int>> ReadScoreboardFile()
        {
            FileInfo currentScoreboard = this.OpenScoreboardFile();
            var scoreboard = new List<KeyValuePair<string, int>>();

            using (StreamReader scoreboardList = currentScoreboard.OpenText())
            {
                string currentLine = null;
                int nameIndex = 0;
                int scoreIndex = 1;

                while ((currentLine = scoreboardList.ReadLine()) != null)
                {
                    string[] nameAndScore = currentLine.Split();
                    scoreboard.Add(new KeyValuePair<string, int>(nameAndScore[nameIndex], int.Parse(nameAndScore[scoreIndex])));
                }
            }

            return scoreboard;
        }

        private List<KeyValuePair<string, int>> SortReadedScoreboardFile()
        {
            var scoreboardList = this.ReadScoreboardFile();
            var sortedScoreboardList = from items in scoreboardList
                                       orderby items.Value, items.Key ascending
                                       select items;

            return sortedScoreboardList.ToList();
        }

        private FileInfo OpenScoreboardFile()
        {
            FileInfo scoreBoardFile = new FileInfo(scoreboardLocation);
            if (!scoreBoardFile.Exists)
            {
                this.CreateScoreTextFile();
            }

            return scoreBoardFile;
        }

        private void CreateScoreTextFile()
        {
            string directory = Directory.GetCurrentDirectory();

            for (int index = 0; index < 2; index++)
            {
                directory = directory.Substring(0, directory.LastIndexOf(@"\"));
            }

            string fileName = scoreboardLocation.Substring(scoreboardLocation.LastIndexOf("/") + 1);
            string filePath = directory + @"\" + fileName;

            using (File.Create(filePath))
            {
            }
        }
    }
}