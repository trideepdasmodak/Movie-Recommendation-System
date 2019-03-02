using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Helper;
using System.Data;
using System.Net.Mail;

namespace FlimClubWeb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                divLogin.Visible = false;
                divlogout.Visible = true;
                Userprofile.Visible = true;
            }
            else
            {
                divLogin.Visible = true;
                divlogout.Visible = false;
                Userprofile.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_User_Authentication");
                proc.AddVarcharPara("@UserEmail", 50, txtEmailId.Text.ToString());
                proc.AddVarcharPara("@Password", 50, txtPassword.Text.ToString());
                dt = proc.GetTable();
                proc = null;

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["User_Type"].ToString() == "Admin")
                    {
                        Response.Redirect("AdminMovies.aspx");
                    }
                    else
                    {
                        Session["UserId"] = dt.Rows[0]["User_Id"].ToString();
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ErrorLogin();", true);
                }
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ProcedureExecute proc = new ProcedureExecute("AddNew_User");
                Guid id = Guid.NewGuid();
                proc.AddVarcharPara("@ID", 50, id.ToString());
                proc.AddVarcharPara("@Name", 50, txtname.Text.ToString());
                proc.AddVarcharPara("@Email", 50, txtEmailIdRegister.Text.ToString());
                proc.AddVarcharPara("@Password", 50, txtPasswordRegister.Text.ToString());
                proc.AddVarcharPara("@Gender", 50, ddlGender.SelectedValue.ToString());
                proc.AddVarcharPara("@DOB", 50, txtDOB.Text.ToString());

                if (fileUploadImage.HasFile)
                {
                    fileUploadImage.SaveAs(Server.MapPath("~/UserImage/") + fileUploadImage.FileName);
                    proc.AddVarcharPara("@UserImage", 50, "~/UserImage/" + fileUploadImage.FileName);
                }
                else
                {
                    proc.AddVarcharPara("UserImage", 50, "~/UserImage/user.jpg");
                }

                int i = proc.RunActionQuery();
                proc = null;
                if (i == -1)
                {
                    Session["UserId"] = id;
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsubsend_Click(object sender, EventArgs e)
        {
            try
            {
                ProcedureExecute proc = new ProcedureExecute("AddNew_Subscriber");
                proc.AddVarcharPara("@Email", 50, TextBoxemailsubscribe.Text);

                int i = proc.RunActionQuery();
                proc = null;
                if (i == -1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}