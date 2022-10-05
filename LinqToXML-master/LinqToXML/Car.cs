using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarType { get; set; }
        public int CarYear { get; set; }
        public string CarCost { get; set; }
        public Car(int carId, string carBrand, string carType, int carYear, string carCost)
        {
            this.CarId = carId;
            this.CarBrand = carBrand;
            this.CarType = carType;
            this.CarYear = carYear;
            this.CarCost = carCost;
        }
        public Car()
        {
        }
        public override string ToString()
        {
            return string.Format($"(CarId={this.CarId}; CarBrand={this.CarBrand}; CarType={this.CarType}; " +
                $"CarYear={this.CarYear}; CarCost={this.CarCost})");
        }
    }
}
