class A{
    protected A()  {   }
    ~A()  //finalize() 메소드
    {
        System.Console.WriteLine("A 소멸~");
    }
}
class B : A{
    public B()  {

    }
    static void Main()
    {
        B a = new B();
        System.GC.Collect();
    }
}