using System;

namespace RockPaperScissors
{
    class Program
    {
        private const int Rock = 0; //beats scissors (Scissors + 1) % 3 = 0;
        private const int Paper = 1; //beats rock (Rock + 1) % 3 = 1;
        private const int Scissors = 2; //beats paper (Paper + 1) %  3 = 2;

        static void Main(string[] args)
        {
            bool playing;
            do
            {
                Random randomNumbers = new Random();

                string playerChoice;
                int playerValue;

                int cpuValue = randomNumbers.Next(3);
                string cpuChoice;

                if (cpuValue == 0)
                {
                    cpuChoice = "Rock";
                }
                else if (cpuValue == 1)
                {
                    cpuChoice = "Paper";
                }
                else
                {
                    cpuChoice = "Scissors";
                }

                Console.Clear();
                while (true)
                {
                    Console.Write("Please enter Rock (R), Paper (P) or Scissors (S): ");
                    playerChoice = Console.ReadLine().ToLower();
                    if (playerChoice.Equals("rock") || (playerChoice.Equals("r")))
                    {
                        playerChoice = "Rock";
                        playerValue = Rock;
                        break;
                    }
                    else if (playerChoice.Equals("paper") || (playerChoice.Equals("p")))
                    {
                        playerChoice = "Paper";
                        playerValue = Paper;
                        break;
                    }
                    else if (playerChoice.Equals("scissors") || (playerChoice.Equals("s")))
                    {
                        playerChoice = "Scissors";
                        playerValue = Scissors;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{playerChoice} is not a valid choice");
                    }
                }

                Console.WriteLine($"Computer chose {cpuChoice}, Player chose {playerChoice}");
                if (playerValue == cpuValue)
                {
                    Console.WriteLine("Its a draw!");
                }
                // else if ((playerValue - 1 == computerValue) || (playerValue == Rock && computerValue == Scissors))
                else if (playerValue == (cpuValue + 1) % 3)
                {
                    Console.WriteLine("Player Wins!");
                }
                else
                {
                    Console.WriteLine("Computer Won!");
                }
                playing = GetYesOrNo("PlayAgain? Y or N: ");

            } while (playing);
        }

        /**
        * Returns a boolean response to a yes/no question.
        *
        * @param string
        *            The question to be asked.
        * @return True if the answer was yes, False if no.
        */
        public static bool GetYesOrNo(string question)
        {
            char answer;
            while (true)
            {
                Console.Write($"{question}");
                answer = Console.ReadKey().KeyChar;
                answer = char.ToLower(answer);
                if (answer.Equals('y'))
                {
                    return true;
                }
                else if (answer.Equals('n'))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine();
                    GetYesOrNo($"{question}");
                }
            }
        }
    }
}