using System;

namespace number_2App
{
    class Boiler
    {
        public string brand;
        private byte voltage;
        private int temperature;

        public byte Voltage
        {
            get { return voltage; }
            set
            {
                // 110V와 220V만 저장할 수 있도록 처리
                if (value == 110 || value == 220)
                {
                    voltage = value;
                }
                else
                {
                    Console.WriteLine("110V 또는 220V만 입력 하세요");
                }

            }
        }

        public int Temperature
        {
            get { return temperature; }
            set
            {
                // 물온도는 5도 이하면 5도로, 70도 이상이면 70도로 제한
                if (value <= 5)
                {
                    temperature = 5;
                }
                if (value >= 70)
                {
                    temperature = 70;
                }
                else
                {
                    temperature = value;
                }
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("Brand = {0}, Voltage = {1}, Temperature = {2}", this.brand, this.voltage, this.temperature);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler boiler = new Boiler();
            boiler.brand = "귀뚜라미";
            boiler.Voltage = 70;
            boiler.Temperature = 100;
            boiler.PrintAll();
        }
    }

}
