using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO:
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };

            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO:
            // Write an algoritm that gets the unique characters of the word below 
            // and counts the number of occurences for each character found

            var counts = word
                .GroupBy(c => c)
                .ToDictionary(group => group.Key, group => group.Count());

            foreach (var c in counts)
            {
                Console.WriteLine($"{c.Key} - {c.Value}");
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO: 
            // Write logic to determine whether a is an anagram of b

            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return false;
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            a = String.Concat(a.OrderBy(c => c));
            b = String.Concat(b.OrderBy(c => c));

            if (String.Compare(a, b) == -1)
            {
                return false;
            }

            return true;
        }
    }
}
