using System;

namespace basicAttribute
{

    class MyClass
    {
        [Obsolete("OldMethod�� ��� �Ǿ����ϴ�. NewMethod()�� �̿��ϼ���.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm old");
        }
        public void NewMethod()
        {
            Console.WriteLine("I'm new");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            obj.OldMethod();
            obj.NewMethod();
        }
    }
}
