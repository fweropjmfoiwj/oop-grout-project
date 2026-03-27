using System;

namespace OopRockPaperScissors
{
    public class ScoreTracker
    {
        private int winningScore;

        public ScoreTracker(int winningScore)
        {
            this.winningScore = winningScore;
        }

        public bool Win(int currentScore)
        {
            return currentScore >= winningScore;
        }

        public int WinningScore()
        {
            return winningScore;
        }
    }
}