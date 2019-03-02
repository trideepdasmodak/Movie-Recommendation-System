using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Helper;
using System.Data;


namespace FlimClubWeb
{
    public partial class AdminSubs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSubs();
            }
        }

        public void GetSubs()
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_Subs");
                dt = proc.GetTable();
                proc = null;
                RepeaterProduct.DataSource = dt;
                RepeaterProduct.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt = null;
            }
        }
    }
}