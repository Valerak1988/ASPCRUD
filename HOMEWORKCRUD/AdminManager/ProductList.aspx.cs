using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOMEWORKCRUD.AdminManager
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Product> ProductList = (List<Product>)Application["Products"];
                RptProd.DataSource = ProductList;
                RptProd.DataBind();
            }
        }
    }
}