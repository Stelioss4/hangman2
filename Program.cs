using System.Linq;
namespace hangman2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                const string PLAY_CHOICE = "Y";
                const int TRIES = 5;

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

                string gameWord = wordList[new Random().Next(wordList.Count)];
                Console.WriteLine("Welcome to Hangman! \n");
                Console.WriteLine("\nplease enter a letter\n\n");

                int lives = TRIES;
                while (lives != 0)
                {
                    int lettersleft = 0;
                    foreach (var character in gameWord)
                    {
                        string letter = character.ToString().ToLower();
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

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Console.WriteLine(string.Empty);
                    char key = keyInfo.KeyChar;

                    if (!char.IsLetter(key))
                    {
                        Console.WriteLine("\nPlease enter only alphabetical characters!");
                        continue;
                    }

                    key = char.ToLower(key);

                    if (letterList.Contains(key.ToString()))
                    {
                        Console.WriteLine($"\nthe letter ({key}) is already given!\n");
                        continue;
                    }

                    letterList.Add(key.ToString());

                    if (!gameWord.Contains(key))
                    {
                        lives--;
                        if (lives > 0)
                        {
                            Console.WriteLine($"\nSorry the letter ({key}) is not in the word try again, {lives} tries left");
                        }
                    }
                }

                if (lives > 0)
                {
                    Console.WriteLine($"\nWell done! You found the secret word!! ({gameWord})\n");
                }
                else
                {
                    Console.WriteLine($"\nSorry you don't have more tries.. the secret word is ({gameWord}) Maybe next time\n");
                }

                Console.WriteLine($"\nDo you want to play again? Please presse ({PLAY_CHOICE}) for 'yes' to continue , or anything else to leave the game!\n");
                string replay = Console.ReadKey().Key.ToString();

                Console.Clear();

                if (replay == PLAY_CHOICE)
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