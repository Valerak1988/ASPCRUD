using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOMEWORKCRUD.AdminManager
{
    public partial class ProdAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Pid = Request["Pid"] + "";
                if(string.IsNullOrEmpty(Pid))
                {
                    Pid = "-1";
                }
                else
                {
                    int pid = int.Parse(Pid);
                    List<Product> ProductList =(List<Product>)Application["Products"];
                    for(int i = 0; i<ProductList.Count; i++)
                    {
                        TxtPname.Text = ProductList[i].Pname;
                        TxtPrice.Text = ProductList[i].Price + "";
                        TxtPdesc.Text = ProductList[i].Pdesc;
                        TxtPicname.Text = ProductList[i].Picname;
                        TxtCid.Text = ProductList[i].Cid + "";
                        HidPid.Value = Pid;
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Sql = "";
            if (HidPid.Value == "-1")
            {
                Sql = "insert into T_Product (Pname,Price,Pdesc,Picname,Cid) values ";
                Sql += $" N'{TxtPname.Text}',{TxtPrice.Text} ,N'{TxtPdesc.Text}',N'{TxtPicname.Text}',{TxtCid.Text}";
            }
            else
            {
                Sql = "Update t_Product set ";
                Sql += $" Pname=N'{TxtPname.Text}',";
                Sql += $" Price={TxtPrice.Text},";
                Sql += $" Pdesc=N'{TxtPdesc.Text}',";
                Sql += $" Picname=N'{TxtPicname.Text}' ";
                Sql += $"Cid={TxtCid},";
                Sql += $" Where Pid={HidPid.Value}";
            }
            string ConnStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            Cmd.ExecuteNonQuery();
            List<Product> ProductList = new List<Product>();
            Sql = "select * from T_Product";
            Cmd.CommandText = Sql;
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
            Conn.Close();
            Application["Products"] = ProductList;
            Response.Redirect("ProductList.aspx");
        }
    }
}