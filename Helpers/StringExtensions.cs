using System;

namespace PigLatin
{
    public static class StringExtensions
    {
        public static void WriteLine(this string str)
        {
            Console.WriteLine(str);
        }

        public static bool IsVowel(this char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }
    }
}