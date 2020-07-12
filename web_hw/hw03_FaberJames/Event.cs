using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace hw03_FaberJames
{
    public class Event
    {
        public Event()
        {

        }

        public List<Seat> Seats
        {
            get;
            set;
        }

        public List<Person> People
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double TotalPrice
        {
            get
            {
                return TotalPrice;
            }

            set
            {
                for (int i = 0; i < People.Count; i++)
                    TotalPrice += People[i].Price;
            }
        }

        public double AvgPrice
        {
            get
            {
                return AvgPrice;
            }
            set
            {
                AvgPrice = TotalPrice / People.Count;
            }
        }

    }
}