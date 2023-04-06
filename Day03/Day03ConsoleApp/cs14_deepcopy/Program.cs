using System;
using System.Collections.Specialized;

namespace cs14_deepcopy
{
    class SomeClass // get, set 정말 중요행
    {
        #region
        public int SomeField1;
        public int SomeField2;

        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = SomeField1; // Call by Value
            newCopy.SomeField2 = SomeField2;

            return newCopy;
        }
    }

    // this 사용법
    class Employee
    {
        private string Name;
        public void SetName(string Name)
        {
            this.Name = Name; // 클래스 멤버변수(속성)과 메서드의 매개변수이름이 대소문자까지 완전히 똑같을때 구분하기 위해서 쓰임
        }
    }

    class ThisClass
    {
        int a, b, c;

        public ThisClass()
        {
            this.a = 1;
        }

        public ThisClass(int b) : this()
        {
            this.b = b;
        }

        public ThisClass(int b, int c) : this(b)
        {
            this.c = c;
        }

        public void Setabc(int a, int b, int c)
        {
            Console.WriteLine("a = {0}, b = {1}, c = {2}",a, b, c);
        }

        #endregion

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사 시작"); // source와 target이 (주소복사) 값이 쉐어(!) <!-- 문제가 됨 --!> ###조심###

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;
            target.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}", source.SomeField1, source.SomeField2);
            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",target.SomeField1, target.SomeField2);
            // source.SomeField1 = 100 , source.SomeField2 = 300
            // target.SomeField1 = 100 , target.SomeField2 = 300
            // call by reference

            Console.WriteLine("깊은 복사 시작");
            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy(); // 깊은 복사
            t.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}", s.SomeField1, s.SomeField2);
            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}", t.SomeField1, t.SomeField2);
            // source.SomeField1 = 100 , source.SomeField2 = 200
            // target.SomeField1 = 100 , target.SomeField2 = 300
            // call by value

            ThisClass tc = new ThisClass();
            tc.Setabc(1,3,5);
        }
}
}
