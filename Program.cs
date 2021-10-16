using System;
using System.Collections.Generic;

namespace HomeTask_7_1
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> vocabulary = new Dictionary<string, string>();

            vocabulary.Add("I", "Boy");

            vocabulary.Add("go", "run");

            vocabulary.Add("to", "to");

            vocabulary.Add("school", "cinema");

            string text = "I go to school. Girl runs to school! Do you go to cinema?";

            string[] sentences = text.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> words = new List<string>();

            string temp = null;

            bool separator = false;

            int indexOfSep = 0; //індекс де знаходиться розділовий знак, такий як: '.','?','!'

            for (int i = 0; i < sentences.Length; i++)
            {
                words.AddRange(sentences[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                indexOfSep += sentences[i].Length;

                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Contains(',') || words[j].Contains(':'))
                    {
                        temp = words[j];
                        words[j] = words[j].Trim(',', ':');
                        separator = true;
                    }
                    if (!vocabulary.ContainsKey(words[j]))
                    {
                        Console.WriteLine("Suggest your translation for this word: " + words[j]);
                        vocabulary.Add(words[j], Console.ReadLine());
                    }
                    if (separator)
                    {
                        words[j] = vocabulary[words[j]] + temp[temp.Length - 1];
                        separator = false;
                    }
                    else words[j] = vocabulary[words[j]];
                }
                sentences[i] = string.Join(' ', words) + text[indexOfSep++];
                words.Clear();
            }

            string newText = string.Join(" ", sentences);

            Console.WriteLine('\n' + newText);
        }
    }
}
