using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw2_FaberJ
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)        //For initial page creation
            {
                ListItem[] availableCourses = buildAvailableCourseList();
                lbxAvailableClasses.DataSource = availableCourses;
                lbxAvailableClasses.DataTextField = "Text";
                lbxAvailableClasses.DataValueField = "Value";
                lbxAvailableClasses.DataBind();
            }

        }

        private ListItem[] buildAvailableCourseList()
        {
            ListItem[] tempList = { new ListItem("CS 1301-4", "CS 1301-4"),
                                new ListItem("CS 1302-4", "CS 1302-4"),
                                new ListItem("CS 1303-4", "CS 1303-4"),
                                new ListItem("CS 2202-2", "CS 2202-2"),
                                new ListItem("CS 2224-2", "CS 2224-2"),
                                new ListItem("CS 3300-3", "CS 3300-3"),
                                new ListItem("CS 3301-1", "CS 3301-1"),
                                new ListItem("CS 3302-1", "CS 3302-1"),
                                new ListItem("CS 3340-3", "CS 3340-3"),
                                new ListItem("CS 4321-3", "CS 4321-3"),
                                new ListItem("CS 4322-3", "CS 4322-3")
                              };
            return tempList;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            for(int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lbxAvailableClasses.Items[i];
                if (li.Selected && HoursRegisteredFor() < 19)
                {
                    lbxAvailableClasses.Items.Remove(li);
                    lbxRegisteredClasses.Items.Add(li);
                }
                if (li.Selected && HoursRegisteredFor() >= 19)
                    lblTooMany.Visible = true;
            }
            double hours = HoursRegisteredFor();
            lblHours.Text = hours.ToString();
            double cost = hours * 100.00 + ExtrasCost();
            lblCost.Text = cost.ToString();
            lblHours.Visible = true;
            lblCost.Visible = true;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = lbxRegisteredClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lbxRegisteredClasses.Items[i];

                if(li.Selected)
                {
                    lbxRegisteredClasses.Items.Remove(li);
                    lbxAvailableClasses.Items.Add(li);

                }
            }

            double hours = HoursRegisteredFor();
            lblHours.Text = hours.ToString();
            double cost = hours * 100.00;
            lblCost.Text = cost.ToString();
            lblHours.Visible = true;
            lblCost.Visible = true;
            if (hours > 19)
                lblTooMany.Visible = true;
            if (hours <= 19)
                lblTooMany.Visible = false;
        }

        protected int HoursRegisteredFor()
        {
            int totHours = 0;
            for (int i = lbxRegisteredClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lbxRegisteredClasses.Items[i];
                string value = li.Value;
                string[] hrs = value.Split('-');
                int hours = Convert.ToInt32(hrs[1]);
                totHours += hours;

            }

            return totHours;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = lbxRegisteredClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lbxRegisteredClasses.Items[i];

                lbxRegisteredClasses.Items.Remove(li);
                lbxAvailableClasses.Items.Add(li);

                double hours = 0;
                double cost = 0;
                lblCost.Text = cost.ToString();
                lblHours.Text = hours.ToString();
                lblCost.Visible = false;
                lblHours.Visible = false;
            }
        }

        protected double ExtrasCost()
        {
            double extraCost = 0;

            for (int i = ckbExtras.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = ckbExtras.Items[i];

                if (li.Selected)
                    extraCost += Convert.ToDouble(li.Value);
            }

            return extraCost;
        }

        protected void btnMakeAvailable_Click(object sender, EventArgs e)
        {
            string course = txtClassNum.Text;
            string credits = txtCredits.Text;
            string newCourse = course + "-" + credits;
            ListItem li = new ListItem(newCourse);
            Boolean different = true;
            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem available = lbxAvailableClasses.Items[i];
                if (available.Text.Contains(course))
                {
                    different = false;
                    lblSame.Visible = true;
                }

            }

            for (int j = lbxRegisteredClasses.Items.Count - 1; j >= 0; j--)
            {
                ListItem registered = lbxRegisteredClasses.Items[j];
                if (newCourse.Equals(registered.Text))
                {
                    different = false;
                    lblSame.Visible = true;
                }
            }
            if (different == true)
            {
                lbxAvailableClasses.Items.Add(li);
                lblSame.Visible = false;
            }

        }

        protected void btnRemoveFromAvail_Click(object sender, EventArgs e)
        {
            string remFromAvail = txtClassNum.Text;
            bool found = false;

            for (int i = lbxAvailableClasses.Items.Count - 1; i >= 0; i--)
            {
                ListItem liAvail = lbxAvailableClasses.Items[i];
                string check = liAvail.Text;

                if (check.Contains(remFromAvail))
                {
                    found = true;
                    lbxAvailableClasses.Items.Remove(liAvail);
                    lblNotRemRegFor.Visible = false;
                }
            }

            for (int k = lbxRegisteredClasses.Items.Count - 1; k >= 0; k--)
            {
                ListItem liRegistered = lbxRegisteredClasses.Items[k];
                string check = liRegistered.Text;

                if (check.Contains(remFromAvail))
                {
                    found = true;
                    lblNotRemRegFor.Visible = true;
                }
            }

            if (found == false)
            {
                lblNotFound.Visible = true;
            }
        }
    }
}