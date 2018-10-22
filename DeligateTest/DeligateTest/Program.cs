using System;

namespace DeligateTest
{
    class Delegate1
    {       
        static void Main(string[] args)
        {
            Delegate1 s = new Delegate1();
            Action<int,int> myMethod = s.Sum;
            myMethod(10, 30);
        }

        void Sum(int i, int j)
        {
            Console.WriteLine(i+j);
        }
    }
}
