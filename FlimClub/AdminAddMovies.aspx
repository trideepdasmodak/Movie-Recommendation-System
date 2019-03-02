<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminAddMovies.aspx.cs" Inherits="FlimClubWeb.AdminAddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateRegister() {
            var status = true;
            if (document.getElementById('txtMovieName').value == '') {
                document.getElementById('txtMovieName').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('txtMovieSummery').value == '') {
                document.getElementById('txtMovieSummery').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('txtMovieDirector').value == '') {
                document.getElementById('txtMovieDirector').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('txtMovieWriters').value == '') {
                document.getElementById('txtMovieWriters').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('txtMovieStars').value == '') {
                document.getElementById('txtMovieStars').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('filMovieImage').value == '') {
                document.getElementById('filMovieImage').style.background = '#ff000038';
                status = false;
            }
            if (document.getElementById('txtMovieVideo').value == '') {
                document.getElementById('txtMovieVideo').style.background = '#ff000038';
                status = false;
            }
            return status;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="padding-top: 20px!important; padding-bottom: 20px!important;">ADD Movies</h1>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Name</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieName" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Year</div>
            <div class="col-lg-10">
                <asp:DropDownList ID="ddlMovieYear" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Type</div>
            <div class="col-lg-10">
                <asp:DropDownList ID="ddlMovieType" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Summery</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieSummery" ClientIDMode="Static" TextMode="MultiLine" Height="300px" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Director</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieDirector" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Writers</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieWriters" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Stars</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieStars" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Image</div>
            <div class="col-lg-10">
                <asp:FileUpload ID="filMovieImage" ClientIDMode="Static" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <div class="col-lg-12">
            <div class="col-lg-2">Movie Video</div>
            <div class="col-lg-10">
                <asp:TextBox ID="txtMovieVideo" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-12" style="height: 20px!important;"></div>
        <asp:Button ID="btnaddmovie" OnClientClick="return validateRegister()" OnClick="btnaddmovie_Click" runat="server" CssClass="btn btn-primary" style="float:right;" Text="Add Movie" />
        <div class="col-lg-12" style="height: 20px!important;"></div>
    </div>
</asp:Content>
