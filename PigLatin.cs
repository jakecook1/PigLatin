using System;
using System.IO;

namespace PigLatin
{
    public class PigLatin
    {
        private string _fileName;
        public PigLatin()
        {
            _fileName = @"./Data/PigLatin.data";
        }

        public void Start()
        {
            if (File.Exists(_fileName))
            {
                Convert(_fileName);
            }
            else
            {
                "No such file to read.".WriteLine();
            }

            "Program End".WriteLine();
        }

        public void Convert(string fileName)
        {
            var text = File.ReadAllText(fileName);
            var words = text.Split(" ");

            var newText = GetPigLatin(words);

            newText.WriteLine();
        }

        public string GetPigLatin(string[] words)
        {
            var newText = string.Empty;

            foreach (var word in words)
            {
                var charactors = word.ToCharArray();
                int vowelPosition = GetVowelPostion(charactors);

                newText += string.Format(!string.IsNullOrEmpty(newText)
                                ? " {0}" : "{0}", ApplyRule(word, vowelPosition));
            }

            return newText;
        }

        public int GetVowelPostion(char[] charactors)
        {
            for (var i = 0; i < charactors.Length; i++)
            {
                if (charactors[i].IsVowel())
                {
                    return i;
                }
            }

            return 0;
        }

        public string ApplyRule(string word, int vowelPosition)
        {
            switch (vowelPosition)
            {
                case 0:
                    // ---------------Pig latin rule #1---------------------
                    // For words that begin with vowel sounds, one just adds "way" or "yay"
                    // to the end (or just "ay").
                    // EG: eat = eatway or eatay, explain = explainway, I = Iway
                    return CreateWord(word, vowelPosition);
                case 1:
                    // ---------------Pig latin rule #2---------------------
                    // For words that begin with consonant sounds, all letters before the initial vowel
                    // are placed at the end of the word sequence. Then, "ay" is added.
                    // EG: pig = igpay, duck = uckday, too = ootay
                    return CreateWord(word, vowelPosition);
                case 2:
                    // ---------------Pig latin rule #3---------------------
                    // When words begin with consonant clusters (multiple consonants that form one sound), 
                    // the whole sound is added to the end when speaking or writing
                    // EG: smile = ilesmay, stupid = upidstay, trash = ashtray
                    return CreateWord(word, vowelPosition);
                default:
                    return word;
            }
        }

        public string CreateWord(string word, int position)
        {
            if (position == 0)
            {
                return string.Format("{0}way", word);
            }

            return word.Substring(position)
                    + string.Format("{0}ay", word.Substring(0, position)).ToLower();
        }
    }
}