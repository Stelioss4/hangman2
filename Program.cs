using System.Linq;
namespace hangman2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char PLAY_CHOICE = 'y';
            const int TRIES = 5;

            Console.WriteLine("Welcome to Hangman! \n");
            Random random = new Random();
            List<string> wordList = new List<string>()
                            {
                                "apple",
                                "orange",
                                "mango",
                                "pineapple",
                                "strawberry",
                                "kiwi",
                                "table",
                                "rock",
                                "computer",
                                "smartphone",
                                "headphones",
                                "speaker",
                                "microphone",
                                "camera",
                                "mountain",
                                "river",
                                "forest",
                                "desert",
                                "ocean",
                                "lake",
                                "project",
                                "beach",
                                "keyboard",
                                "astronaut"
                            };

            while (true)
            {
                string gameWord = wordList[random.Next(0, wordList.Count)];

                List<string> letterList = new List<string>();

                Console.WriteLine("\nplease write letters to find the secret word\n\n");

                int lives = TRIES;
                while (lives != 0)
                {
                    int lettersleft = 0;
                    foreach (char character in gameWord)
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

                    Console.WriteLine($"\n{String.Join(" , ", letterList)}\n");

                    if (lettersleft == 0)
                    {
                        break;
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
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
                char replay = char.ToLower(Console.ReadKey().KeyChar);

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