namespace hangman2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Hangman! \n");

                const string PLAY_CHOICE = "Y";


                string gameWord = "";
                string key = "";
                string letter = "";
                string result = "";
                int lettersleft = 0;
                int tries = 5;

                List<string> letterList = new List<string>();
                List<string> wordList = new List<string>()
                {
                    "apple",
                    "table",
                    "rock",
                    "computer",
                    "project",
                    "beach",
                    "keyboard",
                    "astronaut"
                };

                Random rng = new Random();
                gameWord = wordList[new Random().Next(0, wordList.Count - 1)];

                while (tries != 0)
                {
                    lettersleft = 0;
                    foreach (var character in gameWord)
                    {
                        letter = character.ToString();


                        if (letterList.Contains(letter))
                        {
                            Console.Write(letter);

                        }
                        else
                        {
                            Console.Write("_");
                            lettersleft++;
                        }
                    }
                    Console.WriteLine(string.Empty);
                    Console.WriteLine(String.Join(" , ", letterList));

                    if (lettersleft == 0)
                    {
                        break;
                    }

                    Console.WriteLine("\nplease enter a letter\n");
                    key = Console.ReadKey().KeyChar.ToString().ToLower();
                    Console.WriteLine(string.Empty);

                    if (letterList.Contains(key))
                    {
                        Console.WriteLine($"\nthe letter {key} is already given!\n");


                        continue;
                    }

                    letterList.Add(key);

                    if (!gameWord.Contains(key))
                    {
                        tries--;

                        if (tries > 0)
                        {

                            Console.WriteLine($"\nsorry this letter {key} is not in the word try again, {tries} tries left");
                            continue;
                        }
                    }

                }

                if (tries > 0)
                {
                    Console.WriteLine($"\nWell done! You found the secret word!! ({gameWord})\n");
                }
                else
                {
                    Console.WriteLine($"\nSorry you don't have more tries.. the secret word is ({gameWord}) Maybe next time\n");
                }

                Console.WriteLine($"\nDo you want to play again? Please presse ({PLAY_CHOICE}) for 'yes' to continue , or anything else to leave the game!\n");
                result = Console.ReadKey().Key.ToString();

                Console.Clear();

                if (result == PLAY_CHOICE)
                {
                    Console.WriteLine("\nOK! Let's play!!\n");
                    Console.WriteLine("******************\n");
                }
                else
                {
                    Console.WriteLine("\nOK! Goodbuy!");
                    break;
                }

            }
        }
    }
}