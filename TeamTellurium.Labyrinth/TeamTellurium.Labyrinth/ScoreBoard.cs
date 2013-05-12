using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TeamTellurium.Labyrinth
{
    public class ScoreBoard
    {
        private const string SCOREBOARD_PATH = "../../scoreboard.txt";

        public string ShowScoreboard()
        {
            StringBuilder scoreboardResult = new StringBuilder();
            var sortedScoreboard = ReadScoreboardFile();
            int playerPosition = 0;
            foreach (var result in sortedScoreboard)
            {
                scoreboardResult.AppendFormat("{0}: {1} -> {2}", ++playerPosition, result.Key, result.Value).AppendLine();
            }

            if (scoreboardResult.ToString() == String.Empty) //if (isEmpty) Console.WriteLine("Scoreboard is empty.");
            {
                scoreboardResult.AppendFormat("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
                //Console.WriteLine("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
            }

            return scoreboardResult.ToString();
        }

        private List<KeyValuePair<string, int>> ReadScoreboardFile()
        {
            FileInfo currentScoreboard = OpenScoreboardFile(); //FileInfo file = OpenFile();
            var results = new List<KeyValuePair<string, int>>();

            using (StreamReader scoreboardList = currentScoreboard.OpenText())
            {
                string currentLine = null; //string line = null;
                int nameIndex = 0;
                int scoreIndex = 1;
                while ((currentLine = scoreboardList.ReadLine()) != null)
                {
                    string[] nameAndScore = currentLine.Split();
                    results.Add(new KeyValuePair<string, int>(nameAndScore[nameIndex],Int32.Parse(nameAndScore[scoreIndex])));
                }
            }
            results.Sort(Compare1);
            return results;           
        }

        private FileInfo OpenScoreboardFile()
        {
            FileInfo scoreBoardFile = new FileInfo(SCOREBOARD_PATH);
            if (!scoreBoardFile.Exists)
            {
                CreateScoreTextFile();
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

            using (File.Create(filePath)) { }
        }

        public SortedDictionary<string, int> AddPlayerInScoreboard(string playerName, int playerScore) //public void add(string name, int score)
        {
            SortedDictionary<string, int> nameAndScore = new SortedDictionary<string, int>();
            if (!string.IsNullOrEmpty(playerName))
            {
                nameAndScore.Add(playerName, playerScore);
            }
            
            foreach (KeyValuePair<string, int> topScorers in nameAndScore)
            {
                File.AppendAllText(SCOREBOARD_PATH, string.Format("{0} {1} {2}", topScorers.Key, topScorers.Value, Environment.NewLine));
            }

            return nameAndScore;
        }

        static int Compare1(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }
    }
}