using System;

namespace OopRockPaperScissors
{
    public class Player2
    {
        private string playerName = "Computer";
        private Random rand = new Random();

        public string GetName()
        {
            return playerName;
        }

        public Card GenerateCard(Card[] deck)
        {
            int pos = rand.Next(deck.Length);
            return deck[pos];
        }
    }
}