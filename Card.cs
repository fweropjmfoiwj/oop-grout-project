using System;


namespace OopRockPaperScissors
{
public class Card
{
    private string type;
    private string display;
    private int position;

    public Card(string type, string display, int position)
    {
        this.type = type;
        this.display = display;
        this.position = position;
    }

    public string Type()
        {
            return type;
        }
    public string Display()
        {
            return display;
        }
    public int Position()
        {
            return position;
        }

    public int CompareCard(Card other)
    {
        string thisType = this.type.ToLower();
        string otherType = other.type.ToLower();

        if (this.type == other.type) return 0;

        if ((this.type == "rock" && other.type == "scissors") ||
            (this.type == "scissors" && other.type == "paper") ||
            (this.type == "paper" && other.type == "rock"))
        {
            return 1;
        }

        return -1;
    }
}
}