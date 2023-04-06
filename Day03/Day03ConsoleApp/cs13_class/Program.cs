using System;

namespace cs13_class
{
    // 파이썬 보다 클래스가 복잡함..
    class Cat // private 이라도 같은 cs13_class 안에 있기 때문에 접근 가능
    {
        #region < 생성자 >
        // 생성자 없으면 컴파일러가 알아서 만들어줌
        // 초기화 할게 있으면 만들어 줘야함
        // 있으나 없으나 차이 없음

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Cat()
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }
        /// <summary>
        /// 사용자 지정생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color =  "흰색", sbyte age = 1) // 생성할때 이름만 넣어도 색상이랑 나이를 기본으로 넣어줌
        {
            Name = name;
            Color = color;
            Age = age;
        }

        #endregion

        #region < 멤버 변수 - 속성 >
        public string Name; // 고양이 이름
        public string Color; // 색상
        public sbyte Age; //나이 0~255
        #endregion

        #region < 멤버메서드 - 기능 > 
        public void Meow() // Class 안에 있어서 접근 불가능
        {
            Console.WriteLine("{0} : 야옹-", Name);
        }

        public void Run()
        {
            Console.WriteLine("{0} 달린다.", Name);
        }
        #endregion
    }
    internal class Program // internal cs13_class에서 어디에서든지 사용가능하다.
    {
        static void Main(string[] args)
        {
            Cat helloKitty = new Cat(); // helloKitty라는 이름의 객체를 생성
            // 클래스는 같은 네임스페이스 안에 있기 때문에 접근 가능
            // 하지만 클래스 안에 있는 것들은 접근 불가
            // 따라서 Public을 써줘야 접근 가능
            helloKitty.Name = "헬로키티";
            helloKitty.Color = "흰색";
            helloKitty.Age = 50;
            helloKitty.Meow();
            helloKitty.Run();

            // 객체를 생성하면서 속성 초기화
            Cat nero = new Cat()
            {
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27,
            };
            nero.Meow();
            nero.Run();
 
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다.", helloKitty.Name, helloKitty.Color, helloKitty.Age);
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다.", nero.Name, nero.Color, nero.Age);

            Cat yaongi = new Cat(); // 기본생성자
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다.", yaongi.Name, yaongi.Color, yaongi.Age);

            Cat norangi = new Cat("노랑이", "노랑색"); // 사용자 지정생성자
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다.", norangi.Name, norangi.Color, norangi.Age);
        }
    }
}
