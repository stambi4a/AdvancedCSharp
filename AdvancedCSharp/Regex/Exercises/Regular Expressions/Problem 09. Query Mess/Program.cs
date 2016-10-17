namespace Problem_09.Query_Mess
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private const string SpaceReducePattern = "(\\+|%20){1,}";
        private static void Main(string[] args)
        {   
            while (true)
            {

               /* var inStream = Console.OpenStandardInput(BufSize);
                Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, BufSize));*/

                var input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }

                var members = input.Split(new[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);

                var keysAndValues = new Dictionary<string, List<string>>();
                foreach (var member in members)
                {
                    var keyValuePair = member.Split(new [] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (keyValuePair.Length == 1)
                    {
                        continue;
                    }

                    var key = Regex.Replace(keyValuePair[0], SpaceReducePattern, " ").Trim();
                    /* if (keyValuePair[0].IndexOf("%20") == 0)
                     {
                         keyValuePair[0] = keyValuePair[0].Remove(0, 3);
                     }

                     var lastIndex = keyValuePair[0].LastIndexOf("%20");
                     if (lastIndex != -1 &&  lastIndex == keyValuePair[0].Length - 3)
                     {
                         keyValuePair[0] = keyValuePair[0].Remove(keyValuePair[0].Length - 3, 3);
                     }

                     var key = Regex.Replace(keyValuePair[0], SpaceReducePattern, "$1");*/
                    var value = Regex.Replace(keyValuePair[1], SpaceReducePattern, " ").Trim();
                    /*var values = keyValuePair[1].Split(new[] { "+", "%20" }, StringSplitOptions.RemoveEmptyEntries);
                    var value = string.Join(" ", values);*/
                    if(!keysAndValues.ContainsKey(key))
                    {
                        keysAndValues.Add(key, new List<string>());
                    };

                    keysAndValues[key].Add(value);
                }

                foreach (var keyValue in keysAndValues)
                {
                    Console.Write($"{keyValue.Key}=[{string.Join(", ", keyValue.Value)}]");
                }

                Console.WriteLine();
            }
        }
    }
}
