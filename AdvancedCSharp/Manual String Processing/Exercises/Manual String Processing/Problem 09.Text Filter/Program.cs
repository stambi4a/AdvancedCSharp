namespace Problem_09.Text_Filter
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();
            var strBuilder = new StringBuilder();
            var textLength = text.Length;
            foreach (var word in bannedWords)
            {
                var wordLength = word.Length;
                var replace = new string('*', wordLength);
                var index = 0;
                while (true)
                {
                    var lastIndex = index;
                    index = text.IndexOf(word, index, StringComparison.Ordinal);
                    if (index == -1)
                    {
                        index = lastIndex;
                        break;
                    }

                    strBuilder.Append(text.Substring(lastIndex, index - lastIndex));
                    strBuilder.Append(replace);
                    index += wordLength;
                }

                strBuilder.Append(text.Substring(index, textLength - index));
                text = strBuilder.ToString();
                strBuilder.Clear();
            }   
            
            Console.WriteLine(text);       
        }
    }
}
