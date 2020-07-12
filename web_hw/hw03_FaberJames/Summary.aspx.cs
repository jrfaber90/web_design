using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw03_FaberJames
{
    public partial class Summary : System.Web.UI.Page
    {
        string msg;
        Event MadeEvent
        {
            get { return (Event)Session["Event"]; }
            set { Session["Event"] = value; }
        }

        public List<Seat> Seats
        {
            get { return (List<Seat>)Session["Seats"]; }
            set { Session["Seats"] = value; }
        }

        public List<Person> People
        {
            get { return (List<Person>)Session["People"]; }
            set { Session["People"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["Event"] == null)
                {
                    msg += "No event made";
                    txtMessage.Text = msg;
                }

            }
            double totPrice = 0.00;
            for (int l = 0; l < People.Count; l++)
            {
                totPrice += People[l].Price;
            }
            double avgPrice = 0.00;
            avgPrice = totPrice / People.Count;
            string averagePrice = String.Format("{0:0.00}", avgPrice);
            string name = MadeEvent.Name;
            lblEventName.Text = name;
            lblEventName.Visible = true;
            if(ddlRemove.Items.Count <= 1)
            {
                for (int i = 0; i < People.Count; i++)
                {
                    ddlRemove.Items.Add(People[i].Name);
                }
            }
            msg = "Name                 " + " Seat   " + "Age   " + "    Price\n"
    +           "-----------------    " + "-----  " + "----   " + "    ------\n";
            for(int i = 0; i < People.Count; i++)
            {
                msg += People[i].Name + "                 " + People[i].SeatNum
                    + "      " + People[i].Age + "          " + "$" + People[i].Price + "\n";
            }
            msg += "-----------------    " + "-----  " + "----   " + "    ------\n";
            msg += "Tickets Sold: " + People.Count + "\n";
            msg += "Tickets Available: " + Seats.Count + "\n";
            msg += "Total Ticket Prices: $" + totPrice + "\n";
            msg += "Average Ticket Prices: $" + averagePrice + "\n";
            msg += "Available Seats: ";
            for (int k = 0; k < Seats.Count - 1; k++)
            {
                msg += Seats[k].SeatNum + ", ";
            }
            msg += Seats[Seats.Count - 1].SeatNum;
            txtMessage.Text = msg;

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

            int pos = ddlRemove.SelectedIndex;
            string name = ddlRemove.SelectedItem.Text;
            int retSeatNum = People[pos - 1].SeatNum;
            Seat retSeat = new Seat(retSeatNum);
            Seats.Add(retSeat);
            People.Remove(People[pos - 1]);
            ListItem li = ddlRemove.SelectedItem;
            ddlRemove.Items.Remove(li);
            double totPrice = 0.00;
            for (int l = 0; l < People.Count; l++)
            {
                totPrice += People[l].Price;
            }
            double avgPrice = 0.00;
            avgPrice = totPrice / People.Count;

            string averagePrice = String.Format("{0:0.00}", avgPrice);
            msg = "Name                 " + " Seat   " + "Age   " + "    Price\n"
+               "-----------------    " + "-----  " + "----   " + "    ------\n";
            for (int i = 0; i < People.Count; i++)
            {
                msg += People[i].Name + "                 " + People[i].SeatNum
                    + "      " + People[i].Age + "          " + "$" + People[i].Price + "\n";
            }
            msg += "-----------------    " + "-----  " + "----   " + "    ------\n";
            msg += "Tickets Sold: " + People.Count + "\n";
            msg += "Tickets Available: " + Seats.Count + "\n";
            msg += "Total Ticket Prices: $" + totPrice + "\n";
            msg += "Average Ticket Prices: $" + averagePrice + "\n";
            msg += "Available Seats: ";
            for (int k = 0; k < Seats.Count - 1; k++)
            {
                msg += Seats[k].SeatNum + ", ";
            }
            msg += Seats[Seats.Count - 1].SeatNum;
            txtMessage.Text = msg;
        }

        protected void btnPurchaseMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void radOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}