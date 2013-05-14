namespace TeamTellurium.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        private const string SCOREBOARD_PATH = "../../scoreboard.txt";

        public string ShowScoreboard()
        {
            StringBuilder scoreboardResult = new StringBuilder();
            var scoreboardSorted = this.SortReadedScoreboardFile();
            int playerPosition = 0;

            foreach (var result in scoreboardSorted)
            {
                scoreboardResult.AppendFormat("{0}: {1} -> {2}", ++playerPosition, result.Key, result.Value).AppendLine();
            }

            if (scoreboardResult.ToString() == string.Empty) //if (isEmpty) Console.WriteLine("Scoreboard is empty.");
            {
                scoreboardResult.AppendFormat("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
                //Console.WriteLine("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
            }

            return scoreboardResult.ToString();
        }

        public void AddPlayerInScoreboard(string playerName, int playerScore) //public void add(string name, int score)
        {
            SortedDictionary<string, int> playerNameAndScore = new SortedDictionary<string, int>();
            playerNameAndScore.Add(playerName, playerScore);

            foreach (KeyValuePair<string, int> topScorers in playerNameAndScore)
            {
                File.AppendAllText(SCOREBOARD_PATH, string.Format("{0} {1} {2}", topScorers.Key, topScorers.Value, Environment.NewLine));
            }
        }

        private List<KeyValuePair<string, int>> ReadScoreboardFile()
        {
            FileInfo currentScoreboard = this.OpenScoreboardFile(); //FileInfo file = OpenFile();
            var scoreboard = new List<KeyValuePair<string, int>>();

            using (StreamReader scoreboardList = currentScoreboard.OpenText())
            {
                string currentLine = null; //string line = null;
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
            FileInfo scoreBoardFile = new FileInfo(SCOREBOARD_PATH);
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

            string fileName = SCOREBOARD_PATH.Substring(SCOREBOARD_PATH.LastIndexOf("/") + 1);
            string filePath = directory + @"\" + fileName;

            using (File.Create(filePath))
            {
            }
        }
    }
}