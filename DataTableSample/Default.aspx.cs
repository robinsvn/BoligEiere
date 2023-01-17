using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataTableSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNumBoliger.Text = GetNumOfBoliger().ToString();//hvorfor ToString her?
        }

        /// <summary>
        /// Teller hvor mange boliger det er i tabellen Bolig. Returnerer kun et tall. Er det OK å ha en slik metode i her?
        /// </summary>
        private int GetNumOfBoliger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(BoligId) from Bolig", conn);
                cmd.CommandType = CommandType.Text;
                int num = (Int32)cmd.ExecuteScalar();//returner den første raden og den første kolonnen. sjekk i sql manager. Unboxing eksempel.

                conn.Close();
                return num;
            }
            
        }

       
    }
}