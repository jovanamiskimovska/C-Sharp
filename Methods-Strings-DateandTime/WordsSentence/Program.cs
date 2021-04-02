using System;

namespace WordsSentence
{
    class Program
    {
        public static void FindWordsInASentence(string sentence)
        {
            string[] splittedSentence = sentence.Split(new char[] {',', ' ', '!', '?', '.', ';'});

            foreach (string word in splittedSentence)
            {
                Console.WriteLine(word);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence in order to find all its words");
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                Console.WriteLine("All the words in the sentence are:");
                FindWordsInASentence(input);
            }
            Console.ReadLine();
        }
    }
}
