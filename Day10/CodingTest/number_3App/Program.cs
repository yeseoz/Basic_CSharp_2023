using System;

namespace number_3App
{
    class Car
    {
        protected string name;
        protected string maker;
        protected string color;
        protected int yearModel;
        protected int maxSpeed;
        protected string uniquNumber;

        public string Name
        {
            get 
            {
                return  name; 
            }
            set 
            {
                name = value;
            }
        }
        public string Maker
        {
            get
            {
                return maker;
            }
            set
            {
                maker = value;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public int YearModel
        {
            get
            {
                return yearModel;
            }
            set
            {
                if(value<=1990 || value>=2023)
                {
                    yearModel = 2023;
                }
                else
                {
                    yearModel = value;
                }
            }
        }

        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value<=0||value>=200)
                {
                    maxSpeed = 200;
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }

        public string UniquNumber
        {
            get
            {
                return uniquNumber;
            }
            set
            {
                uniquNumber = value;
            }
        }

        public void Start()
        {
            Console.WriteLine("{0}의 시동을 겁니다", name);
        }

        public void Accelerate()
        {
            Console.WriteLine("최대시속 {0}km/h로 가속합니다.", maxSpeed);
        }

        public void TurnRight()
        {
            Console.WriteLine("{0}이 우회전 합니다.", name);
        }

        public void Brake()
        {
            Console.WriteLine("{0}의 브레이크를 밟습니다.", name);
        }
    }
    class ElectricCar:Car
    {
        public virtual void Recharge()
        {
            Console.WriteLine("배터리를 충전합니다.");
        }
    }
    
    class HybridCar : ElectricCar
    {
        public override void Recharge()
        {
            Console.WriteLine("달리면서 베터리를 충전합니다.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ioniq = new HybridCar();
            ioniq.Name = "아이오닉";
            ioniq.Maker = "현대자동차";
            ioniq.Color = "white";
            ioniq.YearModel = 2018;
            ioniq.MaxSpeed = 220;
            ioniq.UniquNumber = "54라 3346";

            ioniq.Start();
            ioniq.Accelerate();
            ioniq.Recharge();
            ioniq.TurnRight();
            ioniq.Brake();
        }
    }
}
