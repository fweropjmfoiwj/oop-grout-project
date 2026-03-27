using System;
using System.Threading; // Smooth timer

namespace OopRockPaperScissors
{
    class Program
    {
        static void Main()
        {
            bool keepPlaying = true;

            while (keepPlaying)
            {
                //Introduction
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("=======================================");
                Console.WriteLine("   WELCOME TO SYNTX RPS MEMORY DUEL");
                Console.WriteLine("=======================================");
                Console.WriteLine();

                //Menu
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");
                string menuChoice = Console.ReadLine();
                if (menuChoice == "2") return;

                //Choose Difficulty
                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine("       Choose Difficulty:");
                Console.WriteLine("=================================");
                Console.WriteLine();
                Console.WriteLine("1. Beginner (3 levels, 7 cards, win at 4 points in 14 seconds.)");
                Console.WriteLine("2. Intermediate (3 levels, 10 cards, win at 5 points in 12 seconds.)");
                Console.WriteLine("3. Hard (3 levels, 13 cards, win at 6 points in 10 seconds.)");
                Console.WriteLine();
                Console.Write("Enter choice: ");
                string levelChoice = Console.ReadLine();

                int cardCount, winScore, timeLimit;
                string difficultyName;
                switch (levelChoice)
                {
                    case "1":
                        cardCount = 7; winScore = 4; timeLimit = 14;
                        difficultyName = "Beginner";
                        break;
                    case "2":
                        cardCount = 10; winScore = 5; timeLimit = 12;
                        difficultyName = "Intermediate";
                        break;
                    case "3":
                        cardCount = 13; winScore = 6; timeLimit = 10;
                        difficultyName = "Hard";
                        break;
                    default:
                        Console.WriteLine("Invalid choice, defaulting to Beginner.");
                        cardCount = 7; winScore = 4; timeLimit = 14;
                        difficultyName = "Beginner";
                        break;
                }

                GameCoordinator gameCoordinator = new GameCoordinator();
                ScoreTracker scoreTracker = new ScoreTracker(winScore);

                Console.WriteLine();
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Player1 player1 = new Player1(name);
                Player2 player2 = new Player2();

                Console.WriteLine();
                gameCoordinator.StartGame();

                //Play 3 levels
                for (int levelNum = 1; levelNum <= 3; levelNum++)
                {
                    Level level = new Level(levelNum, cardCount, timeLimit);
                    Console.WriteLine("Starting Level " + level.LevelNumber() + " (" + difficultyName + ")");

                    Card[] deck = level.BuildDeck();

                    // Countdown with deck visible
                    Console.WriteLine("=================================");
                    Console.WriteLine("   MEMORIZE YOUR CARDS - LEVEL " + level.LevelNumber());
                    Console.WriteLine("=================================");
                    Console.WriteLine();
                    Console.WriteLine("You have " + level.TimeLimit() + " seconds.");
                    Console.WriteLine();

                    for (int i = 0; i < deck.Length; i++)
                    {
                        Card c = deck[i];
                        Console.WriteLine("   [Position " + c.Position() + "] " + c.Display());
                    }

                    Console.WriteLine();
                    Console.Write("   Time left: ");

                    int timerCursorLeft = Console.CursorLeft;
                    int timerCursorTop = Console.CursorTop;

                    Timer timer = new Timer(level.TimeLimit());
                    timer.StartTimer();

                    int lastSecond = level.TimeLimit();

                    while (timer.GetTimeLeft() > 0)
                    {
                        int remaining = timer.GetTimeLeft();
                        if (remaining < lastSecond)
                        {
                            Console.SetCursorPosition(timerCursorLeft, timerCursorTop);
                            Console.Write(remaining + " seconds  ");
                            lastSecond = remaining;
                        }
                        Thread.Sleep(1000);
                    }

                    // Hide deck
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("      TIME'S UP! CARDS HIDDEN");
                    Console.WriteLine("=================================");
                    Console.WriteLine();

                    //Computer's move
                    Card computerCard = player2.GenerateCard(deck);
                    Console.WriteLine("Computer chose: " + computerCard.Display());
                    Console.WriteLine();

                    //Player's move
                    Card[] humanCards = player1.SelectCards(deck);

                    for (int i = 0; i < humanCards.Length; i++)
                    {
                        Card humanCard = humanCards[i];
                        int result = humanCard.CompareCard(computerCard);

                        if (result == 1)
                        {
                            Console.WriteLine("   You win with " + humanCard.Display() + "!");
                            player1.AddPoint();
                            gameCoordinator.AddMatch();
                        }
                        else if (result == -1)
                        {
                            Console.WriteLine("   Computer wins against " + humanCard.Display() + "!");
                        }
                        else
                        {
                            Console.WriteLine("   It's a tie with " + humanCard.Display() + "!");
                        }
                    }

                    // Show score at end of round
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("   Current Score: " + player1.CurrentScore());
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();

                    // Pause so score is visible before clearing
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();

                    level.EndLevel();

                    if (scoreTracker.Win(player1.CurrentScore()))
                    {
                        Console.WriteLine("Congratulations! You reached the win score!");
                        gameCoordinator.SetOutcome(name + " Wins");
                        break;
                    }

                    if (levelNum < 3)
                    {
                        Console.Clear();
                        gameCoordinator.NextLevel(3);
                    }
                }

                if (gameCoordinator.GetOutcome() == "Undecided")
                {
                    gameCoordinator.SetOutcome("Computer Wins");
                }

                gameCoordinator.EndGame(player1.CurrentScore());

                Console.WriteLine();
                Console.WriteLine("Do you want to go back to the menu?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No (Exit)");
                Console.Write("Enter choice: ");
                string replayChoice = Console.ReadLine();
                if (replayChoice == "2")
                {
                    keepPlaying = false;
                }
            }
        }
    }
}