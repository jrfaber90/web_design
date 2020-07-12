using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw05 {
	public partial class Default : System.Web.UI.Page {
		string dbType = "Access_Property";
        int numProperties = 0;
        double avgPrice = 0.0;
        int numAboveAvg = 0;
        List<Property> Properties;
		protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
            {
                Properties = new List<Property>();
                //getProperties();
                displayPropertiesByPrice(dbType);
            }
		}
		protected void rblSortType_SelectedIndexChanged(object sender, EventArgs e) {
		}

        public void displayPropertiesByPrice(string dbType)
        {
            try
            {
                IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
                cmd.CommandText = getSQLByPrice();
                cmd.Connection.Open();
                IDataReader dr = cmd.ExecuteReader();
                txtProperties.Text = "";
                while (dr.Read())
                {
                    double listPrice = dr.GetDouble(0);
                    double sqFeet = dr.GetDouble(1);
                    double bedNum = dr.GetDouble(2);
                    double bathNum = dr.GetDouble(3);
                    double yrBuilt = dr.GetDouble(4);
                    double pricePerSqFoot = listPrice / sqFeet;
                    Property p = new Property(listPrice, sqFeet, bedNum, bathNum, yrBuilt, pricePerSqFoot);
                    txtProperties.Text += p.ToString();
                }

                dr.Close();
                cmd.Connection.Close();
            }
            catch(Exception ex)
            {
                txtMsg.Text += ex.ToString();
            }


        }

        //private void getProperties()
        //{
        //    try
        //    {
        //        IDbCommand cmd = ConnectionFactory.GetCommand(dbType);
        //        cmd.CommandText = getSQLByPrice();
        //        cmd.Connection.Open();
        //        IDataReader dr = cmd.ExecuteReader();
        //        txtProperties.Text = "";
        //        while (dr.Read())
        //        {
        //            double listPrice = dr.GetDouble(0);
        //            double sqFeet = dr.GetDouble(1);
        //            double bedNum = dr.GetDouble(2);
        //            double bathNum = dr.GetDouble(3);
        //            double yrBuilt = dr.GetDouble(4);
        //            double pricePerSqFoot = listPrice / sqFeet;
        //            Property p = new Property(listPrice, sqFeet, bedNum, bathNum, yrBuilt, pricePerSqFoot);
        //            Properties.Add(p);
        //        }

        //        dr.Close();
        //        cmd.Connection.Close();
        //        lblNumProperties.Text = Properties.Count().ToString();
        //        lblNumProperties.Visible = true;
        //        foreach(Property pr in Properties)
        //        {
        //            avgPrice += pr.ListPrice;
        //        }
        //        avgPrice /= Properties.Count();
        //        lblAveragePrice.Text = String.Format("{0,10:c}", avgPrice);
        //        lblAveragePrice.Visible = true;
        //        foreach(Property pro in Properties)
        //        {
        //            if (pro.ListPrice >= avgPrice)
        //                numAboveAvg += 1;
        //        }
        //        lblNumAboveAvgPrice.Text = numAboveAvg.ToString();
        //        lblNumAboveAvgPrice.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        txtMsg.Text += ex.ToString();
        //    }
        //}

        private string getSQLByPrice()
        {
            string sql = "SELECT " +
                "Properties.ListPrice , Properties.SqFeet , Properties.Beds " +
                "Properties.Baths , Properties.YearBuilt " +
                "FROM Properties " +
                "ORDER BY " + "Properties.ListPrice Asc";
            return sql;
        }

	}
}