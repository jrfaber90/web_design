using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace hw03_FaberJames
{
    public class Seat
    {
        public Seat(int seatNum)
        {
            SeatNum = seatNum;
        }

        public int SeatNum
        {
            get;
            set;

        }
    }
}