using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Quiz_App.Models;
namespace Quiz_App.Models
{
    public class db
    {
        SqlConnection con;
        //string connectionstring = "Data Source=DESKTOP-TAU5C2E;Initial Catalog=QuizApp;Integrated Security=True;Pooling=False";

        public db()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public String apiUserRegistrationSave(apiUserRegistrationModel userregistration)
        {
            string msg = String.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userfullname", userregistration.userFullName);
                cmd.Parameters.AddWithValue("@usermobile", userregistration.userMobile);
                cmd.Parameters.AddWithValue("@useremailid", userregistration.userEmailID);
                cmd.Parameters.AddWithValue("@userusername", userregistration.userUserName);
                cmd.Parameters.AddWithValue("@userpassword", userregistration.userPassword);
                cmd.Parameters.AddWithValue("@userdatecreated", DateTime.Now);
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

        public List<apiUserRegistrationModel> apiUserRegistrationDisplay()
        {
            List<apiUserRegistrationModel> apiuserregist = new List<apiUserRegistrationModel>();
            SqlCommand cmd = new SqlCommand("sp_dispAPIUserRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    apiUserRegistrationModel obj = new apiUserRegistrationModel();
                    obj.userFullName = dt.Rows[i]["userFullName"].ToString();
                    obj.userMobile = dt.Rows[i]["userMobile"].ToString();
                    obj.userEmailID = dt.Rows[i]["userEmailID"].ToString();
                    obj.userUserName = dt.Rows[i]["userUserName"].ToString();
                    obj.userPassword = dt.Rows[i]["userPassword"].ToString();
                    obj.userDateCreated = dt.Rows[i]["userDateCreated"].ToString();
                    obj.userDateModified = dt.Rows[i]["userDateModified"].ToString();
                    apiuserregist.Add(obj);
                }
            }
            return apiuserregist;

            // msg = string.Empty;
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("sp_dispAPIUserRegistration", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    //SqlDataAdapter da = new SqlDataAdapter();
            //    //da.SelectCommand = cmd;
            //    //da.Fill(ds.Tables[0]
            //    //  msg = "OK
            //    using (SqlDataAdapter da = new SqlDataAdapter())
            //    {
            //        da.SelectCommand = new SqlCommand("sp_dispAPIUserRegistration", con);
            //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //        //DataSet ds = new DataSet();
            //        da.Fill(ds, "tblAPIUserRegistration");

            //        dt = ds.Tables["tblAPIUserRegistration"];

            //        foreach (DataRow row in dt.Rows)
            //        {
            //            //manipulate your data
            //        }
            //    }
            //    return dt;

            //}
            //catch (Exception ex)
            //{
            //    //  msg = ex.Message;
            //   return dt;
            //}

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
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }

            return ds;
        }

        public DataSet getContributorById(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_getContributorById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contributorId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
              if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }
            return ds;
        }

        public string saveContributor(contributor cont)
        {
            String msg = string.Empty;
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
                cmd.Parameters.AddWithValue("@contributor_createdBy", cont.contributor_createdBy);
                cmd.Parameters.AddWithValue("@adminLocation", cont.adminLocation);
                cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);
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
                cmd.Parameters.AddWithValue("@fullName", cont.fullName);
                cmd.Parameters.AddWithValue("@address", cont.address);
                cmd.Parameters.AddWithValue("@mobileNo", cont.mobileNo);
                cmd.Parameters.AddWithValue("@emailId", cont.emailId);
                cmd.Parameters.AddWithValue("@userName", cont.userName);
                cmd.Parameters.AddWithValue("@password", cont.password);
                cmd.Parameters.AddWithValue("@contributor_createdBy", cont.contributor_createdBy);
                cmd.Parameters.AddWithValue("@adminLocation", cont.adminLocation);
                cmd.Parameters.AddWithValue("@adminDateModified", DateTime.Now);
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

        public void deleteContributor(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteContributor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@contributorId", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public String apiNoticeBoardSave(apiNoticeBoardModel noticeboardmodel)
        {
            String msg = String.Empty;
            try
            {     
                
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardCreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeTitle", noticeboardmodel.NoticeTitle);
                cmd.Parameters.AddWithValue("@NoticeDescription", noticeboardmodel.NoticeDescription);
                cmd.Parameters.AddWithValue("@NoticeCreatedBy", noticeboardmodel.NoticeCreatedBy);
                cmd.Parameters.AddWithValue("@NoticeDateCreated", noticeboardmodel.NoticeDateCreated);
                cmd.Parameters.AddWithValue("@NoticeDateExpiry", noticeboardmodel.NoticeDateExpiry);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                msg = "Notice Inserted Successfuly";
            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
            return msg;
        }

        public DataSet apiNoticeBoardDisplay(apiNoticeBoardModel noticeboardmodel)
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
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }
            return ds;
           
        }

        public void apiNoticeBoardUpdate(apiNoticeBoardModel noticeboardmodel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_apiNoticeBoardUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoticeID", noticeboardmodel.NoticeID);
                cmd.Parameters.AddWithValue("@NoticeTitle", noticeboardmodel.NoticeTitle);
                cmd.Parameters.AddWithValue("@NoticeDescription", noticeboardmodel.NoticeDescription);
                cmd.Parameters.AddWithValue("@NoticeDateModified", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
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
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                ex.Message.ToString();
            }
        }




    }
}
