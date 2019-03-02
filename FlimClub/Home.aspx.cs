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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTopAllMovies();
                BindAdventureMovies();
                BindRomanceMovies();
                BindHorrorMovies();
                BindScienceFictionMovies();
            }
        }

        private void BindScienceFictionMovies()
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MoviesByCategory");
                proc.AddVarcharPara("@Category", 50, "Science fiction");
                dt = proc.GetTable();
                proc = null;
                RepeaterScienceFiction.DataSource = dt;
                RepeaterScienceFiction.DataBind();
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

        private void BindHorrorMovies()
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MoviesByCategory");
                proc.AddVarcharPara("@Category", 50, "Horror");
                dt = proc.GetTable();
                proc = null;
                RepeaterHorror.DataSource = dt;
                RepeaterHorror.DataBind();
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

        private void BindRomanceMovies()
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MoviesByCategory");
                proc.AddVarcharPara("@Category", 50, "Romance");
                dt = proc.GetTable();
                proc = null;
                RepeaterRomance.DataSource = dt;
                RepeaterRomance.DataBind();
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

        private void BindAdventureMovies()
        {
            DataTable dt = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("Select_MoviesByCategory");
                proc.AddVarcharPara("@Category", 50, "Adventure");
                dt = proc.GetTable();
                proc = null;
                RepeaterAdventure.DataSource = dt;
                RepeaterAdventure.DataBind();
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

        private void BindTopAllMovies()
        {
            if (Session["UserId"] != null)
            {
                DataTable dt = new DataTable();
                try
                {
                    ProcedureExecute proc = new ProcedureExecute("Select_MoviesAllForTop_ByUser");
                    proc.AddVarcharPara("@UserId", 50, Session["UserId"].ToString());
                    dt = proc.GetTable();
                    if (dt.Rows.Count > 0)
                    {
                        proc = null;
                        Repeater_TopAll.DataSource = dt;
                        Repeater_TopAll.DataBind();
                    }
                    else
                    {
                        dt = new DataTable();
                        try
                        {
                            proc = new ProcedureExecute("Select_MoviesAllForTop");
                            dt = proc.GetTable();
                            proc = null;
                            Repeater_TopAll.DataSource = dt;
                            Repeater_TopAll.DataBind();
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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dt = null;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                try
                {
                    ProcedureExecute proc = new ProcedureExecute("Select_MoviesAllForTop");
                    dt = proc.GetTable();
                    proc = null;
                    Repeater_TopAll.DataSource = dt;
                    Repeater_TopAll.DataBind();
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

        protected void Repeater_TopAll_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void RepeaterScienceFiction_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void RepeaterHorror_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void RepeaterRomance_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
    }
}