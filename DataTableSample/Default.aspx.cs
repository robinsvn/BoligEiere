using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataTableSample
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString);

        DBLayer dbl = new DBLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNumBoliger.Text = GetNumOfBoliger().ToString();//hvorfor ToString her?
        }

        /// <summary>
        /// Teller hvor mange boliger det er i tabellen Bolig. Returnerer kun et tall. Er det OK å ha en slik metode i her?
        /// </summary>
        private int GetNumOfBoliger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(BoligID) from Bolig", conn);
                cmd.CommandType = CommandType.Text;
                int num = (Int32)cmd.ExecuteScalar();//returner den første raden og den første kolonnen. sjekk i sql manager. Unboxing eksempel.

                conn.Close();
                return num;
            }

        }

        protected void ButtonShowAllBoliger_Click(object sender, EventArgs e)
        {
            GridViewBoligEiere.DataSource = dbl.GetAllBolig();
            GridViewBoligEiere.DataBind();
        }

        protected void ButtonPoststedSarpsborg_Click(object sender, EventArgs e)
        {
            GridViewPoststedSarpsborg.DataSource = dbl.SortBoligByPostSted();
            GridViewPoststedSarpsborg.DataBind();
        }

        protected void ButtonSearchByPhone_Click(object sender, EventArgs e)
        {
            GridViewSortBoligByTelefon.DataSource = dbl.GetBoligAndOwnersByTelefon(TextBoxSearchByPhone.Text);
            GridViewSortBoligByTelefon.DataBind();
        }

        protected void ButtonSearchByFornavn_Click(object sender, EventArgs e)
        {
            GridViewSortBoligByFornavn.DataSource = dbl.GetBoligByFornavn(TextBoxSearchByFornavn.Text);
            GridViewSortBoligByFornavn.DataBind();
        }

        protected void ButtonSearchByBTID_Click(object sender, EventArgs e)
        {
            GridViewSortBoligByBTID.DataSource = dbl.GetBoligByBoligType(TextBoxSearchByBTID.Text);
            GridViewSortBoligByBTID.DataBind();
        }

        protected void ButtonSearchByPostNR_Click(object sender, EventArgs e)
        {
            GridViewSortBoligByPostNR.DataSource = dbl.GetBoligByPostNR(TextBoxSearchByPostNR.Text);
            GridViewSortBoligByPostNR.DataBind();
        }

        protected void ButtonShowAllEier_Click(object sender, EventArgs e)
        {
            GridViewShowAllEier.DataSource = dbl.GetAllEier();
            GridViewShowAllEier.DataBind();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO Eier (ID, Fornavn, Etternavn, Adresse, TelefonNR, PostNR) VALUES({TextBoxInsertID.Text},'{TextBoxInsertFornavn.Text}','{TextBoxInsertEtternavn.Text}','{TextBoxInsertAdresse.Text}',{TextBoxInsertTelefonNR.Text},{TextBoxInsertPostNR.Text})", conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}