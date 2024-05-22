using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace HOMEWORKCRUD
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            List<Product> ProductList = new List<Product>();
            List<Category> CategoryList = new List<Category>();

            string ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            string Sql = "Select * from T_product";
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            SqlDataReader Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                Product Tmp = new Product()
                {
                    Pid = int.Parse(Dr["Pid"] + ""),
                    Pname = Dr["Pname"] + "",
                    Price = float.Parse(Dr["Price"] + ""),
                    Pdesc = Dr["Pdesc"] + "",
                    Picname = Dr["Picname"] + "",
                    Cid = int.Parse(Dr["Cid"] + "")
                };
                ProductList.Add(Tmp);
            }
            Dr.Close();
            Application["Products"] = ProductList;

            Sql = "select * from T_Category";
            Cmd = new SqlCommand(Sql, Conn);
            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                Category Ctmp = new Category()
                {
                    Cid = int.Parse(Dr["Cid"] + ""),
                    Cname = Dr["Cname"] + "",
                    Cdesc = Dr["Cdesc"] + "",
                    Picname = Dr["Picname"] + ""
                };
                CategoryList.Add(Ctmp);
            }
            Application["Categories"] = CategoryList;
            Conn.Close();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}