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
    public partial class MovieDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MovieId"] != null)
                {
                    if (Request.QueryString["MovieId"].ToString() != string.Empty)
                    {
                        GetProductDetails(Request.QueryString["MovieId"].ToString());
                    }
                }
                else
                {
                    Response.Redirect("Movies.aspx");
                }
            }
            if (Session["UserId"] != null)
            {
                txtComment.Enabled = true;
                btnComment.Enabled = true;
                btnRate.Enabled = true;
            }
            else
            {
                txtComment.Enabled = false;
                btnComment.Enabled = false;
                btnRate.Enabled = false;
            }
        }

        private void GetProductDetails(string MovieId)
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MovieByID");
                proc.AddVarcharPara("@MovieId", 50, MovieId);
                dt = proc.GetTable();
                proc = null;

                lblMovieName.Text = dt.Rows[0]["Movie_Name"].ToString() + " ( " + dt.Rows[0]["Movie_Year"].ToString() + " ) ";
                movieImage.ImageUrl = dt.Rows[0]["Movie_Image"].ToString();
                lblSummery.Text = dt.Rows[0]["Movie_Summery"].ToString();
                lblDirector.Text = dt.Rows[0]["Movie_Director"].ToString();
                lblStars.Text = dt.Rows[0]["Movie_Stars"].ToString();
                lblWriters.Text = dt.Rows[0]["Movie_Writers"].ToString();

                LiteralIframe.Text = "<iframe style='width: 740px; height: 400px; ' " + dt.Rows[0]["Movie_Video"].ToString() + "allowfullscreen></iframe>";

                GetSimilarProducts(dt.Rows[0]["Movie_Type"].ToString(), MovieId);
                Getcomments(MovieId);

                proc = new ProcedureExecute("Select_RatingForMovie");
                proc.AddVarcharPara("@Movie_Id", 50, MovieId);
                dt = proc.GetTable();
                Repeater_Stars.DataSource = CreateStarreating(dt);
                Repeater_Stars.DataBind();
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

        private void Getcomments(string movieId)
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_Comments");
                proc.AddVarcharPara("@MovieId", 50, movieId);
                dt = proc.GetTable();
                proc = null;
                RepeaterComments.DataSource = dt;
                RepeaterComments.DataBind();
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

        private void GetSimilarProducts(string Movie_Type, string MovieId)
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MoviesByCategory");
                proc.AddVarcharPara("@Category", 50, Movie_Type);
                dt = proc.GetTable();
                proc = null;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Movie_Id"].ToString() == MovieId)
                    {
                        dr.Delete();
                    }
                }

                RepeaterSimilar.DataSource = dt;
                RepeaterSimilar.DataBind();
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

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                string MovieId = Request.QueryString["MovieId"].ToString();
                try
                {
                    ProcedureExecute proc = new ProcedureExecute("AddNew_Comment");
                    proc.AddVarcharPara("@UserId", 50, Session["UserId"].ToString());
                    proc.AddVarcharPara("@MovieID", 50, MovieId);
                    proc.AddVarcharPara("@Comment", 500, txtComment.Text.ToString());
                    
                    int i = proc.RunActionQuery();
                    proc = null;
                    if (i == -1)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        Response.Redirect(url);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ErrorUser();", true);
            }
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            ProcedureExecute proc = new ProcedureExecute("Select_RatingForMovieBYUSER");
            proc.AddVarcharPara("@Movie_Id", 50, Request.QueryString["MovieId"].ToString());
            proc.AddVarcharPara("@User_Id", 50, Session["UserId"].ToString());
            dt = proc.GetTable();
            proc = null;

            string rating = HiddenFieldStar.Value;            
            if (Session["UserId"] != null)
            {
                string MovieId = Request.QueryString["MovieId"].ToString();
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        proc = new ProcedureExecute("Update_Rating");
                        proc.AddVarcharPara("@UserId", 50, Session["UserId"].ToString());
                        proc.AddVarcharPara("@MovieID", 50, MovieId);
                        proc.AddVarcharPara("@Rating", 500, rating);

                        int i = proc.RunActionQuery();
                        proc = null;
                        if (i == -1)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            Response.Redirect(url);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    try
                    {
                        proc = new ProcedureExecute("AddNew_Rating");
                        proc.AddVarcharPara("@UserId", 50, Session["UserId"].ToString());
                        proc.AddVarcharPara("@MovieID", 50, MovieId);
                        proc.AddVarcharPara("@Rating", 500, rating);

                        int i = proc.RunActionQuery();
                        proc = null;
                        if (i == -1)
                        {
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            Response.Redirect(url);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }             
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ErrorUser();", true);
            }
        }
    }
}