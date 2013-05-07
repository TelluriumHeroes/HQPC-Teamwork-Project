using System;
using System.IO;
using System.Linq;

namespace TeamTellurium.Labyrinth
{
    public class ScoreBoard
    {
        private const string SCOREBOARD_PATH = "../../scoreboard.txt";

        public FileInfo CreateScoreboard()
        {
            FileInfo scoreBoardFile = new FileInfo(SCOREBOARD_PATH); //FileInfo file = new FileInfo(SCOREBOARD_PATH);
            using (FileStream stream = scoreBoardFile.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {

            }

            return scoreBoardFile;
        }

        public void ShowScoreboard()
        {
            FileInfo currentScoreboard = OpenScoreboardFile(); //FileInfo file = OpenFile();
            using (StreamReader scoreboardList = currentScoreboard.OpenText())
            {
                string currentLine = null; //string line = null;
                bool isEmpty = true;
                int playerPosition = 0; //int i = 0;

                while ((currentLine = scoreboardList.ReadLine()) != null)
                {
                    isEmpty = false;
                    string[] nameAndScore = currentLine.Split();
                    Console.WriteLine("{0}: {1}->{2}", ++playerPosition, nameAndScore[0], nameAndScore[1]);
                }

                if (isEmpty == true) //if (isEmpty) Console.WriteLine("Scoreboard is empty.");
                {
                    Console.WriteLine("Scoreboard is empty. Congratulations, you will be the first who will play that game!");
                }
            }
        }

        private FileInfo OpenScoreboardFile()
        {
            FileInfo scoreBoardFile = new FileInfo(SCOREBOARD_PATH);
            return scoreBoardFile;
        }

        public void add(string name, int score)
        {
            CreateScoreboard();

            FileInfo file = new FileInfo(SCOREBOARD_PATH);
            StreamReader fileReader = file.OpenText();
            String line = null;
            int index = 0;
            int[] scores = new int[5];
            string[] names = new string[5];

            while ((line = fileReader.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split();
                scores[index] = Int32.Parse(nameAndScore[1]);
                names[index++] = nameAndScore[0];
            }

            if (index < 5)
            {
                scores[index] = score;
                names[index] = name;
            }
            else
                if (score < scores[index - 1])
                {
                    scores[index - 1] = score;
                    names[index - 1] = name;
                }

            if (index == 5) index = 4;
            for (int i = 0; i <= index - 1; i++)
                for (int j = i + 1; j <= index; j++)
                    if (scores[i] > scores[j])
                    {
                        int swapValue = scores[i];
                        scores[i] = scores[j];
                        scores[j] = swapValue;
                        string swapValueString = names[i];
                        names[i] = names[j];
                        names[j] = swapValueString;
                    }
            fileReader.Close();
            StreamWriter fileWriter = file.CreateText();
            for (int i = 0; i <= index; i++)
                fileWriter.WriteLine("{0} {1}", names[i], scores[i], i + 1);
            fileWriter.Close();
        }
    }
}
