using System;

namespace OopRockPaperScissors
{
    public class GameCoordinator
    {
        private int currentLevel;
        private int matchCount;
        private string gameOutcome;

        public GameCoordinator()
        {
            currentLevel = 1;
            matchCount = 0;
            gameOutcome = "Undecided";
        }

        public void StartGame()
        {
            Console.WriteLine("Game started!");
        }

        public void NextLevel(int maxLevel)
        {
            if (currentLevel < maxLevel)
            {
                currentLevel++;
                Console.WriteLine("Advancing to Level " + currentLevel);
            }
        }

        public void EndGame(int finalScore)
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("Game Over");
            Console.WriteLine("Outcome: " + gameOutcome);
            Console.WriteLine("Final Score: " + finalScore);
            Console.WriteLine("================================");
            Console.WriteLine("=== Thanks for playing Syntx RPS Memory Duel! ===");
        }

        public void AddMatch()
        {
            matchCount++;
        }

        public void SetOutcome(string outcome)
        {
            gameOutcome = outcome;
        }

        public int GetMatchCount()
        {
            return matchCount;
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }

        public string GetOutcome()
        {
            return gameOutcome;
        }
    }
}