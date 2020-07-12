using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05 {
	public partial class Patients1 : System.Web.UI.Page {
		string dbType = "Access_Patients";

		protected void Page_Load(object sender, EventArgs e) {
			txtMsg.Text = "";

			if (!Page.IsPostBack) {
				displayPatients(dbType);
			}
		}
		protected void btnAddPatient_Click(object sender, EventArgs e) {
            try
            {
                IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
                cmd.CommandText = "INSERT INTO Patients (LastName, FirstName, Address)" +
                    "VALUES (@LastName , @FirstName, @Address)";
                IDbDataParameter param = cmd.CreateParameter();
                param.ParameterName = "@LastName";
                param.Value = txtAddLName.Text;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@FirstName";
                param.Value = txtAddFName.Text;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Address";
                param.Value = txtAddAddress.Text;
                cmd.Parameters.Add(param);

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch(Exception ex)
            {
                txtMsg.Text += ex.ToString();
            }

            displayPatients(dbType);
            clearInputFields();
		}

		protected void btnDeletePatient_Click(object sender, EventArgs e) {
            try
            {
                IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
                cmd.CommandText = "DELETE FROM Patients WHERE PatientID = " + Convert.ToInt32(txtDelID.Text);
                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch(Exception ex)
            {
                txtMsg.Text += ex.ToString();
            }

            displayPatients(dbType);
            clearInputFields();
 
		}

		protected void btnUpdatePatient_Click(object sender, EventArgs e) {
            try
            {
                IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
                cmd.CommandText = "UPDATE Patients SET" +
                    "LastName = '" + txtUpdLName.Text + "', " +
                    "FirstName = '" + txtUpdFName.Text + "' , " +
                    "Address = '" + txtUpdAddress.Text + "'" +
                    "WHERE PatientID = " + Convert.ToInt32(txtUpdID.Text);
                //IDbDataParameter param = cmd.CreateParameter();
                //param.ParameterName = "@LastName";
                //param.Value = txtUpdLName.Text;
                //cmd.Parameters.Add(param);

                //param = cmd.CreateParameter();
                //param.ParameterName = "@FirstName";
                //param.Value = txtUpdFName.Text;
                //cmd.Parameters.Add(param);

                //param = cmd.CreateParameter();
                //param.ParameterName = "@Address";
                //param.Value = txtUpdAddress.Text;
                //cmd.Parameters.Add(param);

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch(Exception ex)
            {
                txtMsg.Text += ex.ToString();
            }

            displayPatients(dbType);
            clearInputFields();
		}

		private void displayPatients(string dbType) {
			try {
				IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
				cmd.CommandText = getSQL();
				cmd.Connection.Open();
				IDataReader dr = cmd.ExecuteReader();

				txtMsg.Text += "IDbConnection.State: " + cmd.Connection.State.ToString() + Environment.NewLine; ;
				txtMsg.Text += "IDataReader.IsClosed: " + dr.IsClosed + Environment.NewLine;
				txtMsg.Text += "cmd.CommandText: " + cmd.CommandText + Environment.NewLine + Environment.NewLine;

				txtPatients.Text = "";

				while (dr.Read()) {
					int id = dr.GetInt32(0);
					String lname = dr.GetString(1);
					String fname = dr.GetString(2);
					String address = dr.GetString(3);

					String patient = String.Format("{0,2:0} {1,-10:0} {2,-8:0} {3,-40:0}", id, lname, fname, address);
					txtPatients.Text += patient + Environment.NewLine;
				}

				dr.Close();
				cmd.Connection.Close();

			}
			catch (Exception ex) {
				txtMsg.Text = "\r\nError reading data\r\n";
				txtMsg.Text += ex.ToString();
			}
		}

		private String getSQL() {
			String sql =
				"SELECT " +
					"Patients.PatientID, " +
					"Patients.LastName, " +
					"Patients.FirstName, " +
					"Patients.Address " +
				"FROM " +
					"Patients " +
				"ORDER BY " + "Patients.LastName Asc";

			return sql;

		}

        private IDbCommand getCommand()
        {
            IDbConnection con;
            IDbCommand cmd;
            con = new System.Data.OleDb.OleDbConnection();
            cmd = new System.Data.OleDb.OleDbCommand();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Access_Patients"].ConnectionString;
            con.ConnectionString = connectionString;
            cmd.Connection = con;
            return cmd;
        }

        private void clearInputFields() {
			txtAddLName.Text = "";
			txtAddFName.Text = "";
			txtAddAddress.Text = "";
			txtDelID.Text = "";
			txtUpdID.Text = "";
			txtUpdLName.Text = "";
			txtUpdFName.Text = "";
			txtUpdAddress.Text = "";
		}

	}
}