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
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt=new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("select BoligEier.BoligID,Eier.Adresse,Eier.PostNR,BoligEier.ID, Eier.Fornavn,Eier.Etternavn,TelefonNR FROM BoligEier INNER JOIN Eier ON Eier.ID = BoligEier.ID INNER JOIN Bolig ON Bolig.BoligID = BoligEier.BoligID where TelefonNR = @tlf", conn);
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
        public DataTable GetBoligByFornavn(string Fnavn)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("select BoligEier.BoligID,Eier.Adresse,Eier.PostNR,BoligEier.ID, Eier.Fornavn,Eier.Etternavn,TelefonNR FROM BoligEier INNER JOIN Eier ON Eier.ID = BoligEier.ID INNER JOIN Bolig ON Bolig.BoligID = BoligEier.BoligID where Fornavn = @Fnavn", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@Fnavn", SqlDbType.NVarChar);
                param.Value = Fnavn; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }
        public DataTable GetBoligByBoligType(string BTID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("SELECT Fornavn, Eier.ID, Bolig.BoligID, Bolig.BoligTypeID, BoligType.BoligType, AntallSoverom FROM Eier Inner JOIN BoligEier ON Eier.ID = BoligEier.ID Inner JOIN Bolig ON Bolig.BoligID = BoligEier.BoligID Inner JOIN BoligType ON BoligType.BoligTypeID = Bolig.BoligTypeID Inner JOIN PostNR ON Eier.PostNR = PostNR.PostNR WHERE Bolig.BoligTypeID = @BTID", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@BTID", SqlDbType.NChar);
                param.Value = BTID; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }
        public DataTable GetBoligByPostNR(string PostNR)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("SELECT Fornavn, Bolig.BoligID, Bolig.BoligTypeID, BoligType.BoligType, AntallSoverom, PostNR.PostNR, Sted FROM Eier Inner JOIN BoligEier ON Eier.ID = BoligEier.ID Inner JOIN Bolig ON Bolig.BoligID = BoligEier.BoligID Inner JOIN BoligType ON BoligType.BoligTypeID = Bolig.BoligTypeID Inner JOIN PostNR ON Eier.PostNR = PostNR.PostNR WHERE PostNR.PostNR = @PostNR", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@PostNR", SqlDbType.NChar);
                param.Value = PostNR; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
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
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
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
        /// <summary>
        /// Returnerer alt fra tabellen Eier. Ikke hensiktsmessig om det er mange Eiere.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllEier()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Eier", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt;
        }
        public DataTable SortBoligByPostSted()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligDatabase"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Fornavn, Bolig.BoligID, Bolig.BoligTypeID, BoligType.BoligType, AntallSoverom, PostNR.PostNR, Sted FROM Eier Inner JOIN BoligEier ON Eier.ID = BoligEier.ID Inner JOIN Bolig ON Bolig.BoligID = BoligEier.BoligID Inner JOIN BoligType ON BoligType.BoligTypeID = Bolig.BoligTypeID Inner JOIN PostNR ON Eier.PostNR = PostNR.PostNR WHERE PostNR.Sted = 'Sarpsborg'", conn);
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