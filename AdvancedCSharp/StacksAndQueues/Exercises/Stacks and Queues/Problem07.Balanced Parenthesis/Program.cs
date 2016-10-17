namespace Problem07.Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            var parenthesisBrackets = new Stack<int>();
            bool areBalanced = true;
            foreach (char ch in parenthesis)
            {
                switch (ch)
                {
                    case ')':
                        {
                            if (parenthesisBrackets.Count == 0 || parenthesisBrackets.Pop() != '(')
                            {
                                areBalanced = false;
                            }
                        }

                        break;
                    case ']':
                        {
                            if (parenthesisBrackets.Count == 0 || parenthesisBrackets.Pop() != '[')
                            {
                                areBalanced = false;
                            }
                        }

                        break;
                    case '}':
                        {
                            if (parenthesisBrackets.Count == 0 || parenthesisBrackets.Pop() != '{')
                            {
                                areBalanced = false;
                            }
                        }

                        break;
                    case '(':
                    case '[':
                    case '{':
                        {
                            parenthesisBrackets.Push(ch);
                        }

                        break;
                }

                if (!areBalanced)
                {
                    break;
                }
            }

            Console.WriteLine(areBalanced ? "YES" : "NO");
        }
    }
}
