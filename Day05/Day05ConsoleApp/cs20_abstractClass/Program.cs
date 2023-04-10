using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abstractClass
{
    abstract class AbstractParent // 클래스의 특징과 인터페이스의 특징을 가지고 있는 추상 클래스
    {
        protected void MethodA() // 클래스랑 동일
        {
            Console.WriteLine("AbstractParent.MethodA()");
        }

        public void MethodB() // 클래스랑 동일
        {
            Console.WriteLine("AbstractParent.MethodB()");
        }

        public abstract void MethodC(); // 인터페이스랑 동일  추상메서드
    }

    class Child : AbstractParent // 인터페이스는 AbstractParent에 밑줄 가면서 메소드 구현하라고 함 근데 추상클래스는 좀 다름
    {
        public override void MethodC() // 추상메서드 재정의 (사실은 구현임)
        {
            Console.WriteLine("Child.MethodC() - 추상클래스 구현"); // 기능은 동일?
            MethodA(); // 여기서는 사용가능
        }
    }

    abstract class Mammal // 포유류 최상위 클래스
    {
        public abstract void Sound(); 
        // 클래스에서 쓸때는 하위클래스에 Sound를 다 넣어야 했는데 
        // 추상클래스는 하나 만들어서 다른 클래스에서 다르게 사용가능
    }

    class Dogs : Mammal
    {
        public void Nurse()
        {
            Console.WriteLine("포유한다.");
        }
        public override void Sound()
        {
            Console.WriteLine("멍멍!!");
        }
    }

    class Cats : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("냐옹-");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractParent parent = new Child(); // 부모 = 자식 => 자식 클래스를 부모 클래스로 할당
            // 추상클래스는 이렇게 많이 쓰임
            // 할때마다 다른일을 할 수 있음
            parent.MethodC();
            parent.MethodB();
            // parent.MethodA(); // protected는 자기자신과 자식클래스 내에서만 사용가능 클래스 밖에서는 사용 불가!
        }
    }
}
