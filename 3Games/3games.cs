using System;
using System.Diagnostics;

Menu.menu();

public static class Menu
{
    public static void menu()
    {
        int option;

        Console.WriteLine("Please select a game: \n" +
            "\n [1] = Reaction Game\n" +
            "\n [2] = Number Guesser\n" +
            "\n [3] = Casino Game\n\n" +
            "Choice: ");

        option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;
        

        switch (option)
        {
            case 1:
                Reaction.afterReact();
                Console.WriteLine(_option);
                break;
            case 2:
                NumberGuesser.NumberGuess();
                break;
            case 3:
                Casino.Intro();
                break;
            default:
                Console.Clear();
                Menu.menu();
                break;
        }
    }
}

public class Reaction
{
    static int playerTime1 = 0;
    static int playerTime2 = 0;

    public static int ReactionGame()
    {
        long result = 0;
        Console.Clear();
        Console.WriteLine("Press the promted letter");
        Stopwatch reaction = new Stopwatch();
        Random random = new Random();
        int time = random.Next(1000, 6001);
        char randomChar = (char)random.Next('a', 'z');

        Thread.Sleep(time);
        reaction.Start();

        Console.WriteLine("\n" + randomChar);
        Console.Beep(400, 300);
        char answer;
        do
        {
            answer = Console.ReadKey().KeyChar;
            if (answer == randomChar)
            {
                result = reaction.ElapsedMilliseconds;
                if (result < 150)
                {
                    Console.WriteLine("You cheated, start over");
                    Reaction.afterReact();
                }
            }
        }
        while (answer != randomChar);
        return (int)result;
    }



    public static void afterReact()
    {
        Console.Clear();
        Console.WriteLine("Player 2 press enter to start");
        Console.ReadLine();

        playerTime1 = ReactionGame();

        Console.Clear();
        Console.WriteLine("Player 2 press enter to start");
        Console.ReadLine();

        playerTime2 = ReactionGame();

        Console.Clear();
        Console.WriteLine("Player 1's reaction time: " + playerTime1 + "\n" +
            "Player 2's reaction time: " + playerTime2);

        if (playerTime1 > playerTime2)
        {
            Console.WriteLine("\nPlayer 2 wins");
        }
        else
        {
            Console.WriteLine("\nPlayer 1 wins");
        }
        Thread.Sleep(3000);
        char answer = 't';
        while (answer != 'r' || answer != 'm')
        {
            Console.Clear();
            Console.WriteLine("Write 'r' to play again \n" +
            "Or write 'm' to exit to menu");
            answer = Console.ReadKey().KeyChar;
            if (answer == 'r')
            {
                Reaction.afterReact();
            }
            else if (answer == 'm')
            {
                Console.Clear();
                Menu.menu();
            }
        }
    }
}

public class NumberGuesser
{
    public static void NumberGuess()
    {
        Console.Clear();
        Console.WriteLine("You have 10 guesses \n" +
            "Write a number between 1 and 1000: ");
        Random number = new Random();
        int num = number.Next(1, 1001);
        int times = 0;
        while (times++ != 10)
        {
            int guess = int.TryParse(Console.ReadLine(), out var _guess) ? _guess : 0;
            if (guess == num)
            {
                Console.WriteLine("You won");
                Thread.Sleep(3000);
                char answer1 = 't';
                while (answer1 != 'r' || answer1 != 'm')
                {
                    Console.Clear();
                    Console.WriteLine("Write 'r' to play again \n" +
                    "Or write 'm' to exit to menu");
                    answer1 = Console.ReadKey().KeyChar;
                    if (answer1 == 'r')
                    {
                        NumberGuesser.NumberGuess();
                    }
                    else if (answer1 == 'm')
                    {
                        Console.Clear();
                        Menu.menu();
                    }
                }
                Console.ReadLine();
                Console.Clear();
                Menu.menu();
            }
            else
            {
                if (guess > num)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            }
        }
        Console.WriteLine("You lose, number was " + num);
        Thread.Sleep(3000);
        char answer2 = 't';
        while (answer2 != 'r' || answer2 != 'm')
        {
            Console.Clear();
            Console.WriteLine("Write 'r' to play again \n" +
            "Or write 'm' to exit to menu");
            answer2 = Console.ReadKey().KeyChar;
            if (answer2 == 'r')
            {
                NumberGuesser.NumberGuess();
            }
            else if (answer2 == 'm')
            {
                Console.Clear();
                Menu.menu();
            }
        }
        Console.ReadLine();
        Console.Clear();
        Menu.menu();
    }
}

public static class Casino
{
    static Random dice = new Random();
    static string playerName = "nothing";
    static int money = 0;
    static int betAmount = 0;
    static int num = dice.Next(1, 11);
    static int payout = 0;
    static int guess = 0;
    static int turn = 0;

    public static void Intro()
    {
        Console.Clear();
        Console.Write("Please Enter Player's Name: ");
        playerName = Console.ReadLine();
        foreach (var c in playerName) // Indexes through it and checks if the numbers 0 to 9 are in there, if so then it restarts
        {
            if (!((int)c - '0' > 9)) // '0' takes ASCII charcters and checks if they are bigger than 9, if so, runs the clear
            {
                Console.Clear();
                Intro();
            }
        }
        if (string.IsNullOrEmpty(playerName))
        {
            Console.Clear();
            Intro(); //Restarts the game if there is no name input
        }

        Console.Write("Please Enter Cash Amount: ");

        money = int.TryParse(Console.ReadLine(), out var _money) ? _money : 0; //tryparse returns a bool (if it could parse or not) and if true it just returns the var, if false 0.
        while (money == 0)
        {
            Console.Clear();
            Console.WriteLine("Please Enter Player's Name: " + playerName);
            Console.Write("Please Enter Cash Amount: ");
            money = int.TryParse(Console.ReadLine(), out var _money2) ? _money2 : 0;
        }

        Console.Write("Please Enter The Bet Amount: ");
        betAmount = int.TryParse(Console.ReadLine(), out var _bet) ? _bet : 0;
        while (betAmount == 0)
        {
            Console.Clear();
            Console.WriteLine("Please Enter Player's Name: " + playerName);
            Console.WriteLine("Please Enter Cash Amount: " + money);
            Console.Write("Please Enter The Bet Amount: ");
            betAmount = int.TryParse(Console.ReadLine(), out var _bet2) ? _bet2 : 0;
        }

        while (betAmount > money)
        {
            Console.Clear();
            Console.WriteLine("Please Enter Player's Name: " + playerName);
            Console.WriteLine("Please Enter Cash Amount: " + money);
            Console.Write("Please Enter The Bet Amount: ");
            betAmount = int.TryParse(Console.ReadLine(), out var _bet3) ? _bet3 : 0;
            while (betAmount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Please Enter Player's Name: " + playerName);
                Console.WriteLine("Please Enter Cash Amount: " + money);
                Console.Write("Please Enter The Bet Amount: ");
                betAmount = int.TryParse(Console.ReadLine(), out var _bet4) ? _bet4 : 0;
            }
        }

        CasinoGame(money, betAmount);
    }

    static int CasinoGame(int money, int bet)
    {
        turn = 0;
        guess = 0;
        num = dice.Next(1, 11);
        while (turn++ != 3 && guess != num)
        {
            Console.WriteLine("Guess any betting number between 1 & 10 :");
            guess = int.TryParse(Console.ReadLine(), out var _guess) ? _guess : 0;
            if (guess < 1 || guess > 10 || string.IsNullOrEmpty(guess.ToString()))
            {
                Console.WriteLine("Number should be between 1 to 10");
                turn--;
            }
            else
            {
                if (guess == num && turn != 4)
                {
                    Console.WriteLine("You won");
                    money = money + betAmount;
                    Console.WriteLine("New balance is: " + money +
                        "\nWould you like to play again? Y/N");
                    char answer = 't';
                    answer = Console.ReadKey().KeyChar;
                    if (answer == 'y')
                    {
                        Console.Clear();
                        Console.WriteLine("Current balance is: " + money);
                        Console.Write("Please Enter The Bet Amount: ");
                        betAmount = int.TryParse(Console.ReadLine(), out var _bet5) ? _bet5 : 0;
                        while (betAmount > money || betAmount == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Current balance is: " + money);
                            Console.Write("Please Enter The Bet Amount: ");
                            betAmount = int.TryParse(Console.ReadLine(), out var _bet6) ? _bet6 : 0;

                        }
                        CasinoGame(money, bet);
                    }
                    else if (answer == 'n')
                    {
                        Console.Clear();
                        Menu.menu();
                    }
                    else
                    {
                        while (answer != 'y' || answer != 'n')
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("New balance is: " + money +
                            "\nWould you like to play again? Y/N");
                            answer = Console.ReadKey().KeyChar;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Wrong");
                }
            }
        }
        if (money <= 0)
        {
            return 0;
        }


        if (guess != num)
        {
            Console.WriteLine("You lost, want to play again? Y/N");
            money = money - betAmount;

            Console.WriteLine("New balance is: " + money);
            char answer;
            answer = Console.ReadKey().KeyChar;
            if (answer == 'y')
            {
                Console.Clear();
                if (money < 1)
                {
                    Console.WriteLine("You're out of money, please come back again later \n");
                    Menu.menu();
                }
                else
                {
                    Console.WriteLine("Current balance is: " + money);
                    turn = 0;
                    num = dice.Next(1, 11);
                    Console.Write("Please Enter The Bet Amount: ");
                    betAmount = int.TryParse(Console.ReadLine(), out var _bet4) ? _bet4 : 0;
                    while (betAmount >= money || betAmount == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Current balance is: " + money);
                        Console.Write("Please Enter The Bet Amount: ");
                        betAmount = int.TryParse(Console.ReadLine(), out var _bet6) ? _bet6 : 0;

                    }   
                }
                CasinoGame(money, bet);
            }
            else if (answer == 'n')
            {
                Console.Clear();
                Menu.menu();
            }
            else
            {
                Console.WriteLine("\nInvalid input");
                Console.WriteLine("Current balance is: " + money);
                Console.Write("Please Enter The Bet Amount: ");
                betAmount = int.TryParse(Console.ReadLine(), out var _bet6) ? _bet6 : 0;
            }
        }
        return payout;
    }
}
