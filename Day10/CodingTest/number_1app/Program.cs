using System;

namespace number_1app
{
    class Boiler
    {
        public string Brand;
        public int Voltage;
        public int Temperature;

        //public Boiler(string Brand, int Voltage, int Temperature)
        //{
        //    this.Brand = Brand;
        //    this.Voltage = Voltage;
        //    this.Temperature = Temperature;
        //}

        public void PrintAll()
        {
            Console.WriteLine("Brand = {0}, Voltage = {1}, Temperature = {2}", Brand, Voltage, Temperature);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler {Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();
        }
    }
}
