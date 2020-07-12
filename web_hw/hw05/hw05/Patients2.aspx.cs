using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05 {
	public partial class Patients2 : System.Web.UI.Page {
		string dbType = "Access_Patients";

		protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
                displayVisits(dbType);
		}

        private void displayVisits(string dbType)
        {
            try
            {
                IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
                cmd.CommandText = getSQL();
                cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();

                txtPatientsAboveAvg.Text = "";

                while (dr.Read())
                {
                    DateTime dt = dr.GetDateTime(0);
                    String LastName = dr.GetString(1);
                    decimal charge = dr.GetDecimal(2);

                    String visit = dt + "      " + LastName + "    " + "$" + charge;
                    txtPatientsAboveAvg.Text += visit.ToString() + Environment.NewLine;
                }

                dr.Close();
                cmd.Connection.Close();
            }
            catch(Exception ex)
            {
                txtPatientsAboveAvg.Text = ex.ToString();
            }
        }

        private string getSQL()
        {
            string sql = "SELECT " +
                "Visits.VisitDate, Patients.LastName, Visits.Charge " +
                "FROM Visits " +
                "INNER JOIN " +
                "Patients on Visits.PatientID = Patients.PatientID " +
                "ORDER BY " +
                "Visits.VisitDate Asc";
            return sql;
        }
	}
}