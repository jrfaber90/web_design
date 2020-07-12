using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw06_dgibson {
	public partial class Default : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
		}

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            dsPatients.InsertParameters["LastName"].DefaultValue = txtLName.Text;
            dsPatients.InsertParameters["FirstName"].DefaultValue = txtFName.Text;
            dsPatients.InsertParameters["Address"].DefaultValue = txtAddress.Text;

            dsPatients.Insert();

            clearInputFields();
        }

        private void clearInputFields()
        {
            txtAddress.Text = null;
            txtLName.Text = null;
            txtFName.Text = null;
            txtCharge.Text = null;
            txtDate.Text = null;
            txtNotes.Text = null;
        }

        protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lName = gvPatients.SelectedRow.Cells[2].Text;
            string fName = gvPatients.SelectedRow.Cells[3].Text;
            string name = lName + ", " + fName;
            lblPatient.Text = name;
            lblPatient.Visible = true;
        }

        protected void btnAddVisit_Click(object sender, EventArgs e)
        {
            dsVisits.InsertParameters["VisitDate"].DefaultValue = txtDate.Text;
            dsVisits.InsertParameters["Charge"].DefaultValue = txtCharge.Text;
            dsVisits.InsertParameters["Notes"].DefaultValue = txtNotes.Text;

            dsVisits.Insert();

            clearInputFields();
        }

        protected void gvVisits_SelectedIndexChanged(object sender, EventArgs e)
        {
            string visit = gvVisits.SelectedRow.Cells[2].Text;
            lblVisitDate.Text = visit;

        }
    }
}