using System;
using System.IO;

namespace StackApp
{
    internal class Program{
        public static void Main(string[] args){
            IStack<int> stack = new FixedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine(stack.Pull());
            Console.WriteLine(stack.Pull());
            Console.WriteLine(stack.Pull());
        }
    }


}
