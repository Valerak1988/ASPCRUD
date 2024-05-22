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
    public partial class CategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cid = Request["Cid"] + "";
                if (string.IsNullOrEmpty(Cid))
                {
                    Cid = "-1";
                }
                else
                {
                    int cid = int.Parse(Cid);
                    List<Category> CategoryList = (List<Category>)Application["Categories"];
                    for(int i = 0; i<CategoryList.Count; i++)
                    {
                        if (CategoryList[i].Cid == cid)
                        {
                            TxtCname.Text = CategoryList[i].Cname;
                            TxtCdesc.Text = CategoryList[i].Cdesc;
                            TxtPicname.Text = CategoryList[i].Picname;
                            HidCid.Value = Cid;
                        }
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Sql = "";
            if(HidCid.Value == "-1")
            {
                Sql = "insert into T_Category (Cname,Cdesc,Picname) values ";
                Sql += $"(N'{TxtCname.Text}',N'{TxtCdesc.Text}',N'{TxtPicname.Text}'";
            }
            else
            {
                Sql = "update T_Category set";
                Sql += $"Cname = N'{TxtCname}'";
                Sql += $"Cdesc = N'{TxtCdesc}'";
                Sql += $"Picname = N'{TxtPicname}'";
            }

            string ConnStr = ConfigurationManager.ConnectionStrings["ConnStirng"].ConnectionString;
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            Cmd.ExecuteNonQuery();
            List<Category> CategoryList = new List<Category>();
            Sql = "select * from T_Category";
            Cmd.CommandText = Sql;
            SqlDataReader Dr = Cmd.ExecuteReader();
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
            Response.Redirect("CategoryList.aspx");
        }
    }
}