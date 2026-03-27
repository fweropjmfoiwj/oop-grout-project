using System;

namespace OopRockPaperScissors
{
    public class Level
    {
        private int levelNumber;
        private int cardCount;
        private int timeLimit;

        public Level(int levelNumber, int cardCount, int timeLimit)
        {
            this.levelNumber = levelNumber;
            this.cardCount = cardCount;
            this.timeLimit = timeLimit;
        }

        public int LevelNumber()
        {
            return levelNumber;
        }

        public int CardCount()
        {
            return cardCount;
        }

        public int TimeLimit()
        {
            return timeLimit;
        }
        public void StartLevel()
        {
          
        }

        public void EndLevel()
        {
            Console.WriteLine("Ending Level " + levelNumber);
        }

        public Card[] BuildDeck()
        {
            Card[] deck = new Card[cardCount];
            string[] types = { "rock", "paper", "scissors" };
            string[] displays = { "🪨  rock", "📄 paper", "✂️  scissors" };
            Random rand = new Random();

            for (int i = 0; i < types.Length && i < deck.Length; i++)
            {
                deck[i] = new Card(types[i], displays[i], i + 1);
            }

            for (int i = types.Length; i < deck.Length; i++)
            {
                int choice = rand.Next(types.Length);
                deck[i] = new Card(types[choice], displays[choice], i + 1);
            }

            return deck;
        }
    }
}