namespace Problem_04.Jedi_Dreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var functionsWithMethods = new Dictionary<string, List<string>>();
            var countLines = int.Parse(Console.ReadLine());
            /*var methodRegex = new Regex(@"static\s+.*?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)\s*\(");*/
            Regex methodRegex = new Regex(@"static\s+.*?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)\s*\(");
            /*var callRegex = new Regex(@"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(");*/
            Regex callRegex = new Regex(@"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(");
            var functionName = string.Empty;
            for (var i = 0; i < countLines; i++)
            {
                var line = Console.ReadLine();
                if (methodRegex.IsMatch(line))
                {
                    var methodMatch = methodRegex.Match(line);
                    functionName = methodMatch.Groups[1].Value;
                    if (!functionsWithMethods.ContainsKey(functionName))
                    {
                        functionsWithMethods.Add(functionName, new List<string>());
                    }
                }
                else if(callRegex.IsMatch(line) && functionName != string.Empty)
                {
                    var methodCallsCollection = callRegex.Matches(line);
                    foreach (Match callMatch in methodCallsCollection)
                    {
                        functionsWithMethods[functionName].Add(callMatch.Groups[1].Value);
                    }
                }
            }
            
        
            var funcs = functionsWithMethods.OrderByDescending(function => function.Value.Count).ThenBy(function=>function.Key);
            foreach (var func in funcs)
            {
                var count = func.Value.Count;
                if (count == 0)
                {
                    Console.WriteLine($"{func.Key} -> None");
                    return;
                }

                Console.WriteLine($"{func.Key} -> {count} -> {string.Join(", ", func.Value.OrderBy(x => x))}");
            }
        }
    }
}
