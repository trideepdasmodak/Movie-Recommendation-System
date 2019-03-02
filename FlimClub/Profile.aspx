<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Profile.aspx.cs" Inherits="FlimClubWeb.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="single-page-agile-main">
        <div class="container">
            <div class="col-lg-12">
                <h1>User Information</h1>
            </div>
            <div class="col-lg-12" style="height: 20px!important;"></div>
            <div class="col-lg-12">
                <div class="col-lg-3" style="padding-left:0px!important;">
                    <asp:Image ID="ImageProfile" Height="300px" Width="230px" runat="server" />
                </div>
                <div class="col-lg-9">
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User  Name : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User EmailId : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblEmailId" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User Date of Birth : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User Gender : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User Password : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            <h4>User Type : </h4>
                        </div>
                        <div class="col-lg-8">
                            <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-12" style="height: 10px!important;"></div>

                </div>
            </div>
            <div class="col-lg-12" style="height: 30px!important;"></div>
            <div class="col-lg-12">
                <h1>Movie Rated By You</h1>
            </div>
            <div class="col-lg-12" style="height: 30px!important;"></div>
            <div class="col-lg-12">
                <div class="w3_agile_featured_movies">
                    <asp:Repeater OnItemDataBound="RepeaterAdventure_ItemDataBound" ID="RepeaterAdventure" runat="server">
                        <ItemTemplate>
                            <div class="col-md-2 w3l-movie-gride-agile">
                                <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                    <asp:Image ID="Image2" Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
                                    <div class="w3l-action-icon"><i class="fa fa-play-circle" aria-hidden="true"></i></div>
                                </a>
                                <div class="mid-1 agileits_w3layouts_mid_1_home">
                                    <div class="w3l-movie-text">
                                        <h6><a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>"><%#Eval("Movie_Name") %></a></h6>
                                    </div>
                                    <div class="mid-2 agile_mid_2_home">
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
            <div class="col-lg-12" style="height: 30px!important;"></div>
            <div class="col-lg-12">
                <h1>Comment Given By You</h1>
            </div>
            <div class="col-lg-12">
                <div class="media-grids">
                    <asp:Repeater ID="RepeaterComments" runat="server">
                        <ItemTemplate>
                            <div class="media" style="margin: 1em 0!important;">
                                <div class="media-left">
                                    <asp:Image ID="Image1" Height="50px" Width="40px" title="One movies" alt=" " ImageUrl='<%#Eval("Movie_Image") %>' runat="server" /></a>
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
    </div>
</asp:Content>
