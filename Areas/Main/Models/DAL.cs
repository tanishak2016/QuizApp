using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Quiz_App.Areas.Main.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Quiz_App.Areas.Main.Models
{
    public class DAL
    {
        SqlConnection con = new SqlConnection();
        public DAL()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }





        public String apiNoticeBoardSave(NoticeBoardProperties noticeboardmodel, String username)
        {
            String msg = String.Empty;
            String _ExpiryDateTime = string.Empty;

            try
            {

                _ExpiryDateTime = noticeboardmodel.NoticeDateExpiry;
                DateTime _ConvertedExpiryDateTime = DateTime.Parse(_ExpiryDateTime);
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardCreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeTitle", noticeboardmodel.NoticeTitle);
                cmd.Parameters.AddWithValue("@NoticeDescription", noticeboardmodel.NoticeDescription);
                cmd.Parameters.AddWithValue("@NoticeCreatedBy", username);
                cmd.Parameters.AddWithValue("@NoticeDateCreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@NoticeDateExpiry", _ConvertedExpiryDateTime);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                msg = "Success";
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
            return msg;
        }

        public DataSet apiNoticeBoardDisplay()
        {
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardDisplay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }
            return ds;

        }

        public DataSet apiNoticeBoardDisplayByID(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardDisplayByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeID", id);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }
                ex.Message.ToString();
            }
            return ds;
        }

        public void apiNoticeBoardUpdate(NoticeBoardProperties noticeboardmodel)
        {
            String _ExpiryDateTime = string.Empty;
            _ExpiryDateTime = noticeboardmodel.NoticeDateExpiry;
            DateTime _ConvertedExpiryDateTime = DateTime.Parse(_ExpiryDateTime);

            String _NoticeDateModified = string.Empty;
            _NoticeDateModified = DateTime.Now.ToString();
            DateTime _ConvertedNoticeDateModified = DateTime.Parse(_NoticeDateModified);

            string dis = noticeboardmodel.NoticeDescription;
            Regex rx = new Regex("<[^>]*>");
            dis = rx.Replace(dis, string.Empty);


            try
            {

                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeID", noticeboardmodel.NoticeID);
                cmd.Parameters.AddWithValue("@NoticeTitle", noticeboardmodel.NoticeTitle);
                cmd.Parameters.AddWithValue("@NoticeDescription", dis);
                cmd.Parameters.AddWithValue("@NoticeDateExpiry", _ConvertedExpiryDateTime);
                cmd.Parameters.AddWithValue("@NoticeDateModified", _ConvertedNoticeDateModified);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    ex.Message.ToString();
                }

            }
        }

        public void apiNoticeBoardDelete(Int32 id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }
        }




        public DataSet getContributor()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_getContributor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public contributor getContributorById(int? id)
        {
            contributor cont = new contributor();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_getContributorById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contributorId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cont.contributorId = Convert.ToInt32(dt.Rows[i]["contributorId"]);
                        cont.fullName = dt.Rows[i]["fullName"].ToString();
                        cont.address = dt.Rows[i]["address"].ToString();
                        cont.mobileNo = dt.Rows[i]["mobileNo"].ToString();
                        cont.emailId = dt.Rows[i]["emailId"].ToString();
                        cont.userName = dt.Rows[i]["userName"].ToString();
                        cont.password = dt.Rows[i]["password"].ToString();
                        cont.contributor_createdBy = dt.Rows[i]["contributor_createdBy"].ToString();
                        cont.adminLocation = dt.Rows[i]["adminLocation"].ToString();
                        cont.dateCreated = Convert.ToDateTime(dt.Rows[i]["dateCreated"]);
                        cont.dateModified = Convert.ToDateTime(dt.Rows[i]["dateModified"]);
                    }
                }
                return cont;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }
                ex.Message.ToString();
            }
            return cont;

            //try
            //{
            //    SqlCommand cmd = new SqlCommand("sp_getContributorById", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@contributorId", id);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows != null && dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            cont.contributorId = Convert.ToInt32(dt.Rows[i]["contributorId"]);
            //            cont.fullName = dt.Rows[i]["fullName"].ToString();
            //            cont.address = dt.Rows[i]["address"].ToString();
            //            cont.mobileNo = dt.Rows[i]["mobileNo"].ToString();
            //            cont.emailId = dt.Rows[i]["emailId"].ToString();
            //            cont.userName = dt.Rows[i]["userName"].ToString();
            //            cont.password = dt.Rows[i]["password"].ToString();
            //            cont.contributor_createdBy = dt.Rows[i]["contributor_createdBy"].ToString();
            //            cont.adminLocation = dt.Rows[i]["adminLocation"].ToString();
            //            cont.dateCreated = Convert.ToDateTime(dt.Rows[i]["dateCreated"]);
            //            cont.dateModified = Convert.ToDateTime(dt.Rows[i]["dateModified"]);
            //        }
            //    }
            //    return cont;
            //}
            //catch (Exception ex)
            //{
            //    return cont;
            //}
        }

        public string saveContributor(contributor cont)
        {
            String msg = string.Empty;
            String createdby = "abcAdmin";
            String location = "india";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_saveContributor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fullName", cont.fullName);
                cmd.Parameters.AddWithValue("@address", cont.address);
                cmd.Parameters.AddWithValue("@mobileNo", cont.mobileNo);
                cmd.Parameters.AddWithValue("@emailId", cont.emailId);
                cmd.Parameters.AddWithValue("@userName", cont.userName);
                cmd.Parameters.AddWithValue("@password", cont.password);
                cmd.Parameters.AddWithValue("@contributor_createdBy", createdby);
                cmd.Parameters.AddWithValue("@adminLocation", cont.adminLocation);
                cont.dateCreated = DateTime.Now;
                cmd.Parameters.AddWithValue("@dateCreated", cont.dateCreated);
                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

        public void updateContributor(contributor cont)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_updateContributor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contributorId", cont.contributorId);
                cmd.Parameters.AddWithValue("@fullName", cont.fullName);
                cmd.Parameters.AddWithValue("@address", cont.address);
                cmd.Parameters.AddWithValue("@mobileNo", cont.mobileNo);
                cmd.Parameters.AddWithValue("@emailId", cont.emailId);
                cmd.Parameters.AddWithValue("@userName", cont.userName);
                cmd.Parameters.AddWithValue("@password", cont.password);
                cmd.Parameters.AddWithValue("@contributor_createdBy", cont.contributor_createdBy);
                cmd.Parameters.AddWithValue("@dateModified", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    ex.Message.ToString();
                }
            }
        }

        public void deleteContributor(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteContributor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@contributorId", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }




    }
}
