using System;
using System.Collections.Generic;
using System.Linq;

namespace Valid_Braces_6kyu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidBraces("(){}[]"));
            Console.WriteLine(ValidBraces("([{}])"));
            Console.WriteLine(ValidBraces("(}"));
            Console.WriteLine(ValidBraces("[(])"));
            Console.WriteLine(ValidBraces("[({})](]"));
        }

        public static bool ValidBraces(string braces)
        {
            bool result = true;

            char[] leftBracesArr = new char[] { '(', '[', '{' };
            char[] rightBracesArr = new char[] { ')', ']', '}' };

            Stack<char> leftBracesStack = new Stack<char>();
            Queue<char> rightBracesQueue = new Queue<char>();

            if (rightBracesArr.Contains(braces[0]))
                return false;

            if (leftBracesArr.Contains(braces[braces.Length - 1]))
                return false;

            if (braces.Length % 2 != 0)
                return false;

            for (int i = 0; i < braces.Length; i++)
            {
                if (leftBracesArr.Contains(braces[i]))
                {
                    leftBracesStack.Push(braces[i]);
                }
                else if(rightBracesArr.Contains(braces[i]))
                {
                    rightBracesQueue.Enqueue(braces[i]);

                    for (int j = 0; j < rightBracesQueue.Count; j++)
                    {
                        if (!IsTheBracesPairCorrect(leftBracesStack.Pop(), rightBracesQueue.Dequeue()))
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static bool IsTheBracesPairCorrect(char a, char b)
        {
            if (a == '(')
            {
                if (b == ')')
                    return true;
            }
            else if (a == '[')
            {
                if (b == ']')
                    return true;
            }
            else if (a == '{')
            {
                if (b == '}')
                    return true;
            }
            else if (a == ')')
            {
                if (b == '(')
                    return true;
            }
            else if (a == ']')
            {
                if (b == '[')
                    return true;
            }
            else if (a == '}')
            {
                if (b == '{')
                    return true;
            }

            return false;
        }
    }
}
