using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Helper;

namespace FlimClubWeb
{
    public partial class AdminAddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPageDetails();
            }
        }

        private void LoadPageDetails()
        {
            for(int i = 2019; i > 1979; i--)
            {
                ddlMovieYear.Items.Add(i.ToString());
            }
            ddlMovieType.Items.Add("Adventure");
            ddlMovieType.Items.Add("Romance");
            ddlMovieType.Items.Add("Horror");
            ddlMovieType.Items.Add("Science fiction");
            ddlMovieType.Items.Add("Animated");
        }

        protected void btnaddmovie_Click(object sender, EventArgs e)
        {
            try
            {
                ProcedureExecute proc = new ProcedureExecute("AddNew_Movie");
                proc.AddVarcharPara("@Movie_Name", 50, txtMovieName.Text.ToString());
                proc.AddVarcharPara("@Movie_Year", 50, ddlMovieYear.Text.ToString());
                proc.AddVarcharPara("@Movie_Type", 50, ddlMovieType.Text.ToString());
                proc.AddVarcharPara("@Movie_Summery", 500, txtMovieSummery.Text.ToString());
                proc.AddVarcharPara("@Movie_Director", 50, txtMovieDirector.Text.ToString());
                proc.AddVarcharPara("@Movie_Writers", 50, txtMovieWriters.Text.ToString());
                proc.AddVarcharPara("@Movie_Stars", 50, txtMovieStars.Text.ToString());
                proc.AddVarcharPara("@Movie_Video", 500, txtMovieVideo.Text.ToString());

                if (filMovieImage.HasFile)
                {
                    filMovieImage.SaveAs(Server.MapPath("~/ProductImage/") + filMovieImage.FileName);
                    proc.AddVarcharPara("@Movie_Image", 50, "~/ProductImage/" + filMovieImage.FileName);
                }
                else
                {
                    proc.AddVarcharPara("@Movie_Image", 50, "Null");
                }
                int i = proc.RunActionQuery();
                proc = null;
                if (i == -1)
                {
                    Response.Redirect("AdminMovies.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}