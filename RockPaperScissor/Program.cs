using System;

namespace RockPaperScissor
{

    public abstract class Player
    {

        public enum Roshambo
        {
            rock,
            paper,
            scissors
        }

        public abstract string GenerateRoshambo();
       
    }

    class Rock : Player
    {
        public override string GenerateRoshambo()
        {
            return Roshambo.rock.ToString();
            
        }
    }

    class RandomPlayer : Player
    {
        public override string GenerateRoshambo()
        {
            Random rand = new Random();
            int pick = rand.Next(0, 2);
            if ((int)Roshambo.rock == pick)
            {
                return Roshambo.rock.ToString();
            }
            else if (((int)Roshambo.paper == pick))
            {
                return Roshambo.paper.ToString();
            }
            else if (((int)Roshambo.scissors == pick))
            {
                return Roshambo.scissors.ToString();
            }
            else
            {
                return "4";
            }

        }
    }

    class HumanPlayer : Player
    {
        public override string GenerateRoshambo()
        {
            Console.WriteLine("Rock, paper, or scissors? (R/P/S): ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            if (input == "r")
            {
                return Roshambo.rock.ToString();
            }else if (input == "p")
            {
                return Roshambo.paper.ToString();
            }else if (input == "s")
            {
                return Roshambo.scissors.ToString();
            }
            else
            {
                return "4";
            }

          

        }

      
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            Console.Write("Would you like to play against TheJets or TheSharks (j/s)?:");
            string opponentPlayer = Console.ReadLine().ToLower();

            if (opponentPlayer=="j")
            {
                opponentPlayer = "TheJets";
            }
            else
            {
                opponentPlayer = "TheSharks";
            }

            string yn ="n";
            while (yn!="y")
            {
                //Console.Write("Rock, paper, or scissors? (R/P/S):");
                HumanPlayer humanPlayer = new HumanPlayer();
                string humanChoice = humanPlayer.GenerateRoshambo();

                RandomPlayer randomPlayer = new RandomPlayer();
                string randomChoice = randomPlayer.GenerateRoshambo();

                Rock rock = new Rock();
                string defaultRock = rock.GenerateRoshambo();

                if (humanChoice.ToLower() == "rock")
                {
                    Console.WriteLine(userName + ": " + humanChoice.ToLower());
                    Console.WriteLine(opponentPlayer + ": " + randomChoice.ToLower());
                    if (humanChoice == randomChoice)
                    {

                        Console.WriteLine("Draw");

                    }
                    else
                    {
                        string res = result(humanChoice, randomChoice);
                        if (res == humanChoice)
                        {
                            Console.WriteLine(userName + " wins");
                        }
                        else
                        {
                            Console.WriteLine(opponentPlayer + " Wins");
                        }

                    }
                   
                }
                else
                {
                    Console.WriteLine(userName + ": " + humanChoice.ToLower());
                    Console.WriteLine(opponentPlayer + ": " + defaultRock.ToLower());
                    string res = result(humanChoice, randomChoice);
                    if (res == humanChoice)
                    {
                        Console.WriteLine(userName + " wins");
                    }
                    else
                    {
                        Console.WriteLine(opponentPlayer + " Wins");
                    }

                }


            }


        }

        public static string result(string result1, string result2)
        {
            if (result1 == "rock" && result2 == "paper")
            {
                return result2;
            }
            else if (result1=="rock"&& result2=="scissor")
            {
                return result1;
            }
            else if (result1=="scissor"&& result2=="paper")
            {
                return result2;
            }
            else
            {
                return "";    
            }



        }
    }

    
}
