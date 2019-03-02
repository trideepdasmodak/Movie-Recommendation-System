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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                DataSet dt = new DataSet();
                try
                {
                    ProcedureExecute proc = new ProcedureExecute("Select_UserInfo");
                    proc.AddVarcharPara("@UserEmail", 50, Session["UserId"].ToString());
                    dt = proc.GetDataSet();
                    proc = null;

                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        ImageProfile.ImageUrl = dt.Tables[0].Rows[0]["User_Image"].ToString();
                        lblUserName.Text = dt.Tables[0].Rows[0]["User_FName"].ToString();
                        lblEmailId.Text = dt.Tables[0].Rows[0]["User_EmailId"].ToString();
                        lblDOB.Text = dt.Tables[0].Rows[0]["User_DOB"].ToString();
                        lblGender.Text = dt.Tables[0].Rows[0]["User_Gender"].ToString();
                        lblPassword.Text = dt.Tables[0].Rows[0]["User_Password"].ToString();
                        lblType.Text = dt.Tables[0].Rows[0]["User_Type"].ToString();

                        RepeaterAdventure.DataSource = dt.Tables[1];
                        RepeaterAdventure.DataBind();

                        RepeaterComments.DataSource = dt.Tables[2];
                        RepeaterComments.DataBind();
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
        }

        protected void RepeaterAdventure_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    DataTable dt = new DataTable();
                    string Movie_Id = (e.Item.FindControl("HiddenFieldMovie_Id") as HiddenField).Value;
                    Repeater rptOrders = e.Item.FindControl("Repeater_Stars") as Repeater;
                    ProcedureExecute proc = new ProcedureExecute("Select_RatingForMovie");
                    proc.AddVarcharPara("@Movie_Id", 50, Movie_Id);
                    dt = proc.GetTable();
                    rptOrders.DataSource = CreateStarreating(dt);
                    rptOrders.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable CreateStarreating(DataTable dt)
        {
            int total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + Convert.ToInt32(dt.Rows[i]["Rating_Number"].ToString());
            }
            int finalRating = 0;
            if (total > 0)
            {
                finalRating = total / dt.Rows.Count;
            }

            DataTable dtrating = new DataTable();
            dtrating.Columns.Add("Class");
            if (finalRating == 0)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi4);
            }

            if (finalRating == 1)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi4);
            }

            if (finalRating == 2)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi4);
            }

            if (finalRating == 3)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi4);
            }

            if (finalRating == 4)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star-o";
                dtrating.Rows.Add(_ravi4);
            }
            if (finalRating == 5)
            {
                DataRow _ravi = dtrating.NewRow();
                _ravi["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi);

                DataRow _ravi1 = dtrating.NewRow();
                _ravi1["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi1);

                DataRow _ravi2 = dtrating.NewRow();
                _ravi2["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi2);

                DataRow _ravi3 = dtrating.NewRow();
                _ravi3["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi3);

                DataRow _ravi4 = dtrating.NewRow();
                _ravi4["Class"] = "fa fa-star";
                dtrating.Rows.Add(_ravi4);
            }
            return dtrating;
        }
    }
}