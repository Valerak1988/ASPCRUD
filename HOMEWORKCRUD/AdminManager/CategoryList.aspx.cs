using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOMEWORKCRUD.AdminManager
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Category> CategoryList = (List<Category>)Application["Categories"];
                RptProd.DataSource = CategoryList;
                RptProd.DataBind();
            }
        }
    }
}