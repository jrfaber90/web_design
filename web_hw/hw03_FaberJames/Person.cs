using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace hw03_FaberJames
{
    public class Person
    {
        public Person(string name, int seatNum, int age)
        {
            Name = name;
            SeatNum = seatNum;
            Age = age;
            if(this.Age <= 12)
            {
                Price = 5.00;
            }
            else
            {
                Price = 10.00;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public int SeatNum
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
    }
}