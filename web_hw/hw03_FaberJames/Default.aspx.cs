using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw03_FaberJames
{
    public partial class Default : System.Web.UI.Page
    {
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
                    MadeEvent = new Event();
                    Seats = new List<Seat>();
                    People = new List<Person>();

                }

                for (int i = 0; i < Seats.Count; i++)
                {
                    ListItem li = new ListItem(Seats[i].SeatNum.ToString());
                    lbxAvailSeats.Items.Add(li);
                }
                lblAvailSeats.Text = Seats.Count.ToString();
                lblAvailSeats.Visible = true;

            }


        }

        protected void btnMakeEvent_Click(object sender, EventArgs e)
        {
            string name = txtEventName.Text;
            MadeEvent.Name = name;
            int first = Convert.ToInt32(txtFirstSeat.Text);
            int last = Convert.ToInt32(txtLastSeat.Text);
            for (int i = first; i <= last; i++)
            {
                Seat seat = new Seat(i);
                Seats.Add(seat);
                ListItem li = new ListItem(seat.SeatNum.ToString());
                lbxAvailSeats.Items.Add(li);
                lblAvailSeats.Text = lbxAvailSeats.Items.Count.ToString();
                lblAvailSeats.Visible = true;
            }
        }

        protected void btnStartOver_Click(object sender, EventArgs e)
        {
            lbxAvailSeats.Items.Clear();
            MadeEvent.Name = null;
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            string name = txtPersonName.Text;
            int age = Convert.ToInt32(txtPersonAge.Text);
            int seatNum = Convert.ToInt32(lbxAvailSeats.SelectedItem.Value);
            Person person = new Person(name, seatNum, age);
            int pos = lbxAvailSeats.SelectedIndex;
            Seats.Remove(Seats[pos]);
            People.Add(person);
            lbxAvailSeats.Items.Remove(lbxAvailSeats.SelectedItem);
            lblAvailSeats.Text = lbxAvailSeats.Items.Count.ToString();
            txtPersonAge.Text = "";
            txtPersonName.Text = "";
        }

        protected void btnEventSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Summary.aspx");
        }
    }
}