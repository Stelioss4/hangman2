namespace hangman2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine(string.Empty);

                const string YES = "Y";
                const string WORD1 = "apple";
                const string WORD2 = "table";
                const string WORD3 = "rock";
                const string WORD4 = "computer";
                const string WORD5 = "project";
                const string WORD6 = "beach";
                const string WORD7 = "keyboard";
                
                string gameWord = "";
                string key = "";
                string letter = "";
                string result = "";
                int tries = 5;
                var lettersleft = 0;
                var letters = new List<string>();
                var theWord = new List<string>()
                {
                WORD1,
                WORD2,
                WORD3,
                WORD4,
                WORD5,
                WORD6,
                WORD7
                };
                gameWord = theWord[new Random().Next(0, theWord.Count - 1)];
                while (tries != 0)
                {
                    lettersleft = 0;
                    foreach (var character in gameWord)
                    {
                        letter = character.ToString();
                        if (letters.Contains(letter))
                        {
                            Console.Write(letter);
                        }
                        else
                        {
                            Console.Write("_");
                            lettersleft++;
                        }
                    }
                    if (lettersleft == 0)
                    {
                        break;
                    }
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("please enter a letter");
                    key = Console.ReadKey().Key.ToString().ToLower();
                    Console.WriteLine(string.Empty);
                    letters.Add(key);
                    if (!gameWord.Contains(key))
                    {
                        tries--;
                        if (tries > 0)
                        {
                            Console.WriteLine($"sorry this letter {key} is not in the word try again, {tries} tries left");
                            continue;
                        }
                    }
                }
                if (tries > 0)
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"Well done! You found the secret word!! ({gameWord})");
                   
                }
                if (tries == 0)
                {
                    Console.WriteLine($"Sorry you don't have more tries.. the secret word is ({gameWord}) Maybe next time");
                }
                Console.WriteLine(string.Empty);
                Console.WriteLine($"Do you want to play again? Please presse ({YES}) for 'yes' to continue , or anything else to leave the game!");
                result = Console.ReadKey().Key.ToString();
                if (result == YES)
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("OK! Let's play!!");
                    Console.WriteLine("******************");
                }
                else
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("OK! Goodbuy!");
                    break;
                }
            }
        }
    }
}