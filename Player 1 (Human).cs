using System;

namespace OopRockPaperScissors
{
    public class Player1
    {
        private string name;
        private int score;

        public Player1(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public void AddPoint()
        {
            score++;
        }

        public int CurrentScore()
        {
            return score;
        }

        public Card[] SelectCards(Card[] deck)
        {
            Console.Write("Select card positions (e.g. 1 3 5): ");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');
            Card[] chosenCards = new Card[parts.Length];
            int count = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                try
                {
                    int pos = int.Parse(parts[i]);
                    if (pos >= 1 && pos <= deck.Length)
                    {
                        Card chosen = deck[pos - 1];
                        chosenCards[count++] = chosen;
                    }
                    else
                    {
                        Console.WriteLine("Invalid position: " + parts[i]);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input: " + parts[i]);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("No valid cards selected. Please try again.");
                return SelectCards(deck);
            }

            Card[] finalCards = new Card[count];
            for (int i = 0; i < count; i++)
            {
                finalCards[i] = chosenCards[i];
            }

            return finalCards;
        }
    }
}