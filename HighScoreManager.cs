using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace spaceinvaders01
{
    public static class HighScoreManager
    {
        private const string highScoreFileName = "C:\\Users\\u01\\OneDrive\\C#\\Games\\spaceinvaders01\\highscore.txt";

        public static int LoadHighScore()
        {
            int highScore = 0;

            string highScoreString = File.ReadAllText(highScoreFileName);
            int.TryParse(highScoreString, out highScore);

            return highScore;
        }

        public static void SaveHighScore(int highScore)
        {

            File.WriteAllText(highScoreFileName, highScore.ToString());

        }
    }
}
