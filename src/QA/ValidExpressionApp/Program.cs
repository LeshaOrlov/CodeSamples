using System;
using System.Collections.Generic;

namespace ValidExpressionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "([)(])";
            Console.WriteLine(IsValid(str));
        }

        static public bool IsValid(string str)
        {
            var map = new Dictionary<char, char>() { 
                { ')' ,'('}, 
                { ']', '[' } , 
                { '}', '{' } 
            };

            var stack = new Stack<char>();

            foreach (var s in str)
            {
                if (!map.ContainsKey(s))
                {
                    stack.Push(s);
                    continue;
                }
                else
                {
                    if (stack.Count != 0 && map[s] == stack.Peek())
                    { 
                        stack.Pop();
                        continue; 
                    }
                    else return false;

                }
            }

            return stack.Count == 0;
        }
    }
}
