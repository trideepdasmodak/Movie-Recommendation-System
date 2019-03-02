<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Movies.aspx.cs" Inherits="FlimClubWeb.Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3l-agile-horror">
        <div class="w3l-medile-movies-grids">
            <div class="movie-browse-agile">
                <div class="browse-agile-w3ls general-w3ls">
                    <div class="container">
                        <div class="browse-inner-come-agile-w3">
                            <asp:Repeater OnItemDataBound="RepeaterAll_ItemDataBound" ID="RepeaterAll" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-2 w3l-movie-gride-agile">
                                        <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                             <asp:Image ID="Image1" Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
                                            <div class="w3l-action-icon"><i class="fa fa-play-circle" aria-hidden="true"></i></div>
                                        </a>
                                        <div class="mid-1">
                                            <div class="w3l-movie-text">
                                                 <h6><a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>"><%#Eval("Movie_Name") %></a></h6>
                                            </div>
                                            <div class="mid-2">
                                                <p><%#Eval("Movie_Year") %></p>
                                                <div class="block-stars">
                                                    <ul class="w3l-ratings">
                                                        <asp:Repeater ID="Repeater_Stars" runat="server">
                                                        <ItemTemplate>
                                                            <li><i class='<%#Eval("Class") %>' aria-hidden="true"></i></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    </ul>
                                                </div>
                                                <div class="clearfix"></div>
                                                <asp:HiddenField ID="HiddenFieldMovie_Id" Value='<%#Eval("Movie_Id") %>' runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
