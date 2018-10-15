using System;
class TypeCastExample1
{
    public static void Main()
    {
        short a = 10;
        int b = a;
        int c = 50000; //이진수로 “0000 0000 0000 0000 1100 0011 0101 0000”
                       //short형으로 변환하면 부호비트가 0에서 1로, 음수가 된다.
        try
        {
            short d = checked((short)c); 
            Console.WriteLine("Short : {0}", d);
        }
        catch (Exception e)
        {
            Console.WriteLine("예외: {0}",e.StackTrace);
            Console.WriteLine("예외: " + e.StackTrace);
        }        
    }
}
