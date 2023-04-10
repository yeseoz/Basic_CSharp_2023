using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        private int temp; // 기본 멤버변수

        public int Temp // property(속성) => property는 대문자로 시작!
        {
            get { return temp; }
            set // set 하면 무조건 value를 사용!
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10; // 제일 낮은 온도로 변경 설정
                }
                else
                {
                    temp = value;
                }
            }
        }

        // 위의 get; set;과 비교
        public void SetTemp(int temp)
        {
            if (temp<=10 || temp >=70)
            {
                //Console.WriteLine("수온설정값이 너무 낮거나 높습니다. 10도에서 70도 사이로 지정해주세요");
                //return;
                this.temp = 10;
            }
            this.temp = temp;
        }

        public int GetTemp()
        {
            return this.temp;
        }
    }

    class Car
    {
        int year;
        string fuelType;
        int door;
        string tireType;
        string company;
        int price;
        string carIdNumber;
        string carPlateNumber;

        public string Name { get; set; } // 필터링이 필요 없으면 멤버변수 없이 프로퍼티로 대체 
        // set 없으면 입력 불가 get은 없으면 안됨
        public string Color { get; set; }

        public int Year { get => year; //  == get {return year;} 람다식
            set
            {
                if(value <= 1990 || value>=2023)
                {
                    value = 2023;
                }
                year = value;
            }
        }
        public string FuelType { get => fuelType;
            set
            {
                if(value !="휘발유"||value !="경유")
                    {
                        value = "휘발유";
                    }
             fuelType = value;
            }
        }
        public int Door
        {
            get { return door; }
            set
            {
                if (value != 2 || value != 4)
                {
                    value = 4;
                }
            }
        }
        public string TireType { get; set; }
        public string Company { get; set; } = "현대자동차";
        public int Price { get => price; set => price = value; }
        public string CarIdNumber { get; set; }
        public string CarPlateNumber { get; set; }
    }

    interface IProduct
    {
        string ProductName { get; set; }
        void Produce();
    }

    class MyProduct : IProduct
    {
        public string ProductName;

        public string PrductName
        {
            get { return ProductName; }
            set { ProductName = value; }
        }
        string IProduct.ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Produce()
        {
            Console.Write("{0}을(를) 생산합니다. ", PrductName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler();
            //kitturami.temp = 60; // 기본이 private

            //// ....
            //kitturami.temp = 300000; // 보일러 물 수온이 30만도?
            //// public을 쓰면 모르는 사람이 바꿀 수도 있고... 응애
            //kitturami.temp = -120;
            //// 이렇게 마음대로 사용하면 안되니까 get set을 만드는 거임

            kitturami.SetTemp(50); // 같은 것 같지만 다름 값을 지정할 수 잇거든
            Console.WriteLine(kitturami.GetTemp()); // 구식 방법

            Boiler navien = new Boiler();
            navien.Temp = 5000; // Temp가 왼쪽에 있을때 오른쪽에 있는 값이 Value가 됨
            Console.WriteLine(navien.Temp);

            Car ionic = new Car();
            ionic.Name = "아이오닉"; //ionic에 set이 없으면 입력 불가!
            Console.WriteLine(ionic.Name);

            // 생성할 때 프로퍼티로 초기화
            Car genesis = new Car()
            {
                Name = "제네시스",
                FuelType = "휘발유",
                Color = "흰색",
                Door = 4,
                TireType = "광폭타이어",
                Year = 0
            };

            Console.WriteLine("자동차 제조회사는 {0}", genesis.Company);
            Console.WriteLine("자동차 제조년도는 {0}년", genesis.Year);

        }
    }
}
