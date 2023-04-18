using System;

namespace number_5App
{
    internal class Program
    {

        interface IAnimal
        {   
            void Eat();
            void Sleep();
            void Sound();
        }
        s
        class Dog : IAnimal
        {
            private string name;
            private int age;
            public string Name
            {
                get 
                {
                    return name; 
                }
                set 
                {
                    name = value; 
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }

            public void Eat()
            {
                Console.WriteLine($"{name}이(가) 밥을 먹습니다.", name);
            }

            public void Sleep()
            {
                Console.WriteLine($"{name}이(가) 잠을 잡니다.", name);
            }

            public void Sound()
            {
                Console.WriteLine("멍멍!!"); 
            }
        }

        class Cat : IAnimal
        {
            private string name;
            private int age;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }

            public void Eat()
            {
                Console.WriteLine($"{name}이(가) 밥을 먹습니다.", name);
            }

            public void Sleep()
            {
                Console.WriteLine($"{name}이(가) 잠을 잡니다.", name);
            }

            public void Sound()
            {
                Console.WriteLine("냐옹~");
            }
        }

        class Horse : IAnimal
        {
            private string name;
            private int age;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }

            public void Eat()
            {
                Console.WriteLine($"{name}이(가) 밥을 먹습니다.", name);
            }

            public void Sleep()
            {
                Console.WriteLine($"{name}이(가) 잠을 잡니다.", name);
            }

            public void Sound()
            {
                Console.WriteLine("히이잉~!");
            }
        }


        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Horse horse = new Horse();

            dog.Name = "바둑이";
            dog.Age = 12;
            dog.Eat();
            dog.Sleep();
            dog.Sound();

            Console.WriteLine();

            cat.Name = "키티";
            cat.Age = 2;
            cat.Eat();
            cat.Sleep();
            cat.Sound();

            Console.WriteLine();

            horse.Name = "날쌘돌이";
            horse.Age = 5;
            horse.Eat();
            horse.Sleep();  
            horse.Sound();
        }
    }
}
