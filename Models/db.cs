using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Quiz_App.Models;
using System.Globalization;

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

        public int LoginCheck(SuperAdmin_Login sa)
        {
            SqlCommand cmd = new SqlCommand("sp_superLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SuperAdminPassword", sa.supAdminPassword);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@IsValid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oblogin);
            con.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
        public Int32 normalAdminLoginCheck(SuperAdmin_Login sa)
        {
            SqlCommand cmd = new SqlCommand("sp_normalAdminLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adminUserName", sa.normalAdminUserName);
            cmd.Parameters.AddWithValue("@adminPassword", sa.normalAdminPassword);
            cmd.Parameters.AddWithValue("@ret", SqlDbType.Int);
            cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
            cmd.Dispose();
            con.Close();
            return k;

            //SqlParameter oblogin = new SqlParameter();
            //oblogin.ParameterName = "@IsValid";
            //oblogin.SqlDbType = SqlDbType.Bit;
            //oblogin.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(oblogin);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //int res = Convert.ToInt32(oblogin.Value);
            //con.Close();
            //return res;
        }
        public DataSet normalAdminDisplay()
        {
            DataSet ds = new DataSet();
            // msg = string.Empty;
            //sp_dispAPIUserRegistration
            // sp_dispNormalAdmin
            try
            {
                SqlCommand cmd = new SqlCommand("sp_dispNormalAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                //  msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                //  msg = ex.Message;
                return ds;
            }
        }
        public DataSet normalAdminDisplayByID(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_dispNormalAdminbyID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", id);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //(ex.Message.ToString());
                return ds;
            }
        }
        public void normalAdminDelete(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteNormalAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adminID", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string normalAdminSaveUpdate(normalAdmin na)
        {
            String msg = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_saveNormalAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adminName", na.adminName);
                cmd.Parameters.AddWithValue("@adminMobile", na.adminMobile);
                cmd.Parameters.AddWithValue("@adminUserName", na.adminUserName);
                cmd.Parameters.AddWithValue("@adminPassword", na.adminUserPassword);
                cmd.Parameters.AddWithValue("@adminDateCreated", DateTime.Now);
                //cmd.Parameters.AddWithValue("@adminDateModified", na.adminDateModified);
                con.Open();
                //  cmd.ExecuteNonQuery();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();
                return result;
                // return ("Data Inserted Successfuly");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                // msg = ex.Message;
                return (ex.Message.ToString());
            }
        }

        public void normalAdminUpdate(normalAdmin na)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_updateNormalAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adminID", na.adminID);
                cmd.Parameters.AddWithValue("@adminName", na.adminName);
                cmd.Parameters.AddWithValue("@adminMobile", na.adminMobile);
                cmd.Parameters.AddWithValue("@adminUserName", na.adminUserName);
                cmd.Parameters.AddWithValue("@adminPassword", na.adminUserPassword);
                //cmd.Parameters.AddWithValue("@adminDateCreated", DateTime.Now);
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
                return cont;
            }
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
                cmd.Parameters.AddWithValue("@adminLocation", cont.adminLocation);
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
