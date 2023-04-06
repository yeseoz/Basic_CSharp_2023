using System;

namespace cs16_inheritancce
{
    class Base // 기반(부모 클래스)
    { // 자식클래스에서 상속받으려면 private는 안써야함
        protected string Name;
        private string Color; // 만약에 상속을 할꺼면 protected로 선언해야함
        public int Age;

        public Base(string Name, string Color, int Age)
        {
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;

            Console.WriteLine("{0}.Base()", Name);
        }

        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor() // 자기 클래스라서 가능
        {
            Console.WriteLine("{0}.Base() {1}", Name, Color);
        }
    }

    class Child : Base
    {
        public Child(string Name, String Color, int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }

        //public string GetColor()
        //{
        //    return Color; // 아에 접근 불가능 Private이기 때문에
        //}
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "White", 1);
            b.BaseMethod();
            b.GetColor();

            Child c = new Child("NameC", "Black", 2);
            c.BaseMethod();
            c.ChildMethod();
            c.GetColor(); // Base.GetColor Black... c에서 Color에 접근불가!            
        }
    }
}
