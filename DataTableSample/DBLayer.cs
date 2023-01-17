using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataTableSample
{
    public class DBLayer
    {
        public DataTable GetBoligAndOwnersByTelefon(string tlf)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt=new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("select BoligEier.BoligId,Bolig.Adresse,Bolig.PostNummer,BoligEier.EierId, Eier.ForNavn,Eier.EtterNavn,Telefon.Telefon FROM BoligEier INNER JOIN Eier ON Eier.EierId = BoligEier.EierId INNER JOIN Telefon ON Eier.EierId = Telefon.EierId INNER JOIN Bolig ON Bolig.BoligId = BoligEier.BoligId where Telefon.Telefon = @tlf", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@tlf", SqlDbType.NChar);
                param.Value = tlf; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
               
                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }

        /// <summary>
        /// Returnerer alt fra tabellen boliger. Ikke hensiktsmessig om det er mange boliger.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBolig()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bolig", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt;
        }
    }
}