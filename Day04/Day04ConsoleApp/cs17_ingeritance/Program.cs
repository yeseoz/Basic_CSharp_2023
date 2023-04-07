using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_ingeritance
{
    #region < 부모클래스 >
    // 상속해줄 부모 클래스
    class Parent
    {
        protected string Name; // 상속할때는 private를 쓰면 안됨

        public Parent(string Name) // 생성자
        {
            this.Name = Name;
            Console.WriteLine("{0} from Parent 생성자", Name);
        }

        public void ParentMethod() // 얘도 private하면 사용 x
        {
            Console.WriteLine("{0} from Parent 메서드", Name);
        }
    }
    #endregion

    #region < 자식클래스 >
    // 상속받을 자식 클래스
    class Child : Parent
    {
        public Child(string Name):base(Name) // 부모클래스의 생성자를 먼저 실행한되 자신 생성자를 실행
        {
            Console.WriteLine("{0} from Child 생성자", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0} from Child 메서드", Name);
        }
    }
    #endregion

    #region < 클래스간 형변환 >
    // 클래스간 형변환 DB처리 , DI
    class Mammal // 포유류
    {
        public void Nurse() // 기르다
        {
            Console.WriteLine("포유류 기르다");
        }
    }

    class Dogs : Mammal // 포유류를 물려받은 자식 클래스
    {
       public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Cats : Mammal // 포유류를 물려받은 자식클래스
    {
        public void Meow()
        {
            Console.WriteLine("냐옹 -");
        }
    }

    class Elephant: Mammal
    {
        public void Ppoo()
        {
            Console.WriteLine("뿌우~");
        }
    }

    class ZooKeeper
    {
        // 형변환 정말 많이 쓰임...!!!
        public void Wash(Mammal mammal)
        {
            if (mammal is Elephant)
            {
                var animal = mammal as Elephant;
                Console.WriteLine("코끼리를 씻깁니당");
                animal.Ppoo();
            }
            else if (mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("강아지를 씻깁니다아");
                animal.Bark();
            }
            else if (mammal is Cats) 
            {
                var animal = mammal as Cats;
                Console.WriteLine("고양이을 씻깁니다..ㅠ"); ;
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
                animal.Meow();
            }
        }
        
    }
    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 기본 상속 개념 >
            Parent p = new Parent("p");
            p.ParentMethod();

            Console.WriteLine("자식클래스 생성");
            Child c = new Child("c"); // 부모클래스의 생성자가 먼저 실행됨 :base (Name) 때문에
            c.ParentMethod(); // 자식클래스는 부모클래스의 속성, 기능을 모두 쓸 수 있다.(단 private가 아닌경우)
            c.ChildMethod();
            #endregion

            #region < 클래스간 형식변환 >
            // Mammal mammal = new Mammal(); // 기본
            Mammal mammal = new Dogs();
            // 자식은 부모가 가진 클래스를 다 가지고 있기 때문에 승계 가능
            // 자식 클래스 = 부모 클래스 + a
            // Dogs dogs = new Mammal(); // 부모는 자식이 가지고 있는 것 다 가지고 있지 않기 때문에 변환 불가능
            // mammal.Bark(); // 바로 안됨
            // 부모클래스 승계가 없으면 하위클래스 갯수만큼 만들어야함;;; 승계가 있어서 하나만 만들어도 됨

            if (mammal is Dogs) // 여기서 선별을 먼저하고
            {
                // Dogs midDog = (Dogs)mammal; // 구식
                Dogs midDog = mammal as Dogs; // 이게 더 많이 쓰는 방식 // 여기서 형변환?
                midDog.Bark();
            }

            Dogs dog2 = new Dogs();
            Cats cat2 = new Cats();
            Elephant elephant2 = new Elephant();

            ZooKeeper keeper = new ZooKeeper();
            keeper.Wash(dog2);
            keeper.Wash(cat2);
            keeper.Wash(elephant2);

            #endregion

        }
    }
}
