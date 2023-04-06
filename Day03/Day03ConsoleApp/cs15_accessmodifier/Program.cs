using System;

namespace cs15_accessmodifier
{
    internal class WaterHeater
    {
        protected int temp; //온도

        public void SetTemp(int temp)
        {
            if (temp < -5 || temp > 40)
            {
                Console.WriteLine("범위 이탈");
                return;
            }
            this.temp = temp;
        }

        public int GetTemp() // public으로 메개변수를 지정하면 굳이 get, set을 쓸필요가 없음
        {
            return this.temp;
        }

        internal void TurnOnHeater()
        {
            Console.WriteLine("보일러를 켭니다 : {0}", temp);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            WaterHeater boiler = new WaterHeater();
            boiler.SetTemp(30);
            Console.WriteLine(boiler.GetTemp());
            boiler.TurnOnHeater();
            //boiler.temp = 30; // 보호 수준 때문에 엑세스 불가 => private이기 때문
        }

    }
}

