<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MovieDetail.aspx.cs" Inherits="FlimClubWeb.MovieDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/simplePlayer.js"></script>
    <script>
        $("document").ready(function () {
            $("#video").simplePlayer();
        });
        function validate() {
            var status = true;
            if (document.getElementById('txtComment').value == '') {
                document.getElementById('txtComment').style.background = '#ff000038';
                status = false;
            }
            return status;
        }
        function removecolor() {
            document.getElementById('txtComment').style.background = 'white';
        }
        function ErrorUser() {
            alert('Login to Continue!');
        }

        jQuery(document).ready(function ($) {

            $(".btnrating").on('click', (function (e) {

                var previous_value = $("#selected_rating").val();

                var selected_value = $(this).attr("data-attr");
                $("#selected_rating").val(selected_value);

                $(".selected-rating").empty();
                $(".selected-rating").html(selected_value);
                $("#HiddenFieldStar").val(selected_value);

                for (i = 1; i <= selected_value; ++i) {
                    $("#rating-star-" + i).toggleClass('btn-warning');
                    $("#rating-star-" + i).toggleClass('btn-default');
                }

                for (ix = 1; ix <= previous_value; ++ix) {
                    $("#rating-star-" + ix).toggleClass('btn-warning');
                    $("#rating-star-" + ix).toggleClass('btn-default');
                }

            }));


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenFieldStar" ClientIDMode="Static" Value="0" runat="server" />
    <div class="single-page-agile-main">
        <div class="container">
            <div class="single-page-agile-info">
                <div class="show-top-grids-w3lagile">
                    <div class="col-sm-8 single-left">
                        <div class="song">
                            <div class="song-info">
                                <h3>
                                    <asp:Label ID="lblMovieName" runat="server" Text="Label"></asp:Label></h3>
                            </div>
                            <div class="col-lg-12" style="padding-left: 0px!important; padding-bottom: 10px!important;">
                                <div class="col-lg-5" style="padding-left: 0px!important;">
                                    <asp:Image ID="movieImage" Width="290px" Height="450px" class="img-responsive" runat="server" />
                                </div>
                                <div class="col-lg-7">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <h4>Summery :</h4>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:Label ID="lblSummery" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="height: 10px!important"></div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <h4>Director :</h4>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:Label ID="lblDirector" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="height: 10px!important"></div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <h4>Writers :</h4>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:Label ID="lblWriters" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="height: 10px!important"></div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <h4>Stars :</h4>
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:Label ID="lblStars" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="height: 10px!important"></div>
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <h4>Rating :</h4>
                                        </div>
                                        <div class="col-lg-8">
                                            <div class="block-stars" style="float: left!important;">
                                                <ul class="w3l-ratings">
                                                    <asp:Repeater ID="Repeater_Stars" runat="server">
                                                        <ItemTemplate>
                                                            <li><i class='<%#Eval("Class") %>' aria-hidden="true"></i></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="video-grid-single-page-agileits">
                                <%--<iframe style="width: 740px; height: 400px;" src="https://www.youtube.com/embed/dKrVegVI0Us" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
                                <asp:Literal ID="LiteralIframe" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="all-comments">
                            <div class="all-comments-info">
                                <div class="form-group" id="rating-ability-wrapper">
                                    <label class="control-label" for="rating">
                                        <span class="field-label-header">How would you rate the Movie?</span><br>
                                        <span class="field-label-info"></span>
                                        <input type="hidden" id="selected_rating" name="selected_rating" value="" required="required">
                                    </label>
                                    <h2 class="bold rating-header" style="">
                                        <span class="selected-rating">0</span><small> / 5</small>
                                    </h2>
                                    <button type="button" class="btnrating btn btn-default btn-lg" data-attr="1" id="rating-star-1">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btnrating btn btn-default btn-lg" data-attr="2" id="rating-star-2">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btnrating btn btn-default btn-lg" data-attr="3" id="rating-star-3">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btnrating btn btn-default btn-lg" data-attr="4" id="rating-star-4">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </button>
                                    <button type="button" class="btnrating btn btn-default btn-lg" data-attr="5" id="rating-star-5">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </button>
                                    <asp:Button ID="btnRate" OnClick="btnRate_Click" Style="width: 100px; height: 45px; float: right; margin-right: 145px;" CssClass="btn btn-warning" runat="server" Text="Rate" />
                                </div>
                                <div class="agile-info-wthree-box">
                                    <div>
                                        <asp:TextBox ID="txtComment" ClientIDMode="Static" onfocus="removecolor()" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnComment" CssClass="btn btn-success" OnClientClick="return validate();" OnClick="btnComment_Click" runat="server" Text="Comment" />
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="media-grids">
                                <asp:Repeater ID="RepeaterComments" runat="server">
                                    <ItemTemplate>
                                        <div class="media" style="margin: 1em 0!important;">
                                            <div class="media-left">
                                                <asp:Image ID="Image1" Height="50px" Width="40px" title="One movies" alt=" " ImageUrl='<%#Eval("User_Image") %>' runat="server" /></a>
                                            </div>
                                            <div class="media-body">
                                                <p><%#Eval("Comment_Text")%></p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 single-right">
                        <h3>Similar Movies</h3>
                        <div class="single-grid-right">
                            <asp:Repeater ID="RepeaterSimilar" runat="server">
                                <ItemTemplate>
                                    <div class="single-right-grids">
                                        <div class="col-md-6 single-right-grid-left">
                                            <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>">
                                                <asp:Image ID="Image1" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" /></a>
                                        </div>
                                        <div class="col-md-6 single-right-grid-right">
                                            <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="title"><%#Eval("Movie_Name") %></a>
                                            <p class="share" style="padding: 1em 1em 1em 0em!important;"><a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="author"><%#Eval("Movie_Director") %></a></p>
                                            <p class="author" style="padding: 0em 1em 0em 0em!important;"><a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="author"><%#Eval("Movie_Writers") %></a></p>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
