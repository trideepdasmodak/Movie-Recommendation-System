<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Home.aspx.cs" Inherits="FlimClubWeb.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#owl-demo").owlCarousel({
                autoPlay: 3000, //Set AutoPlay to 3 seconds
                items: 5,
                itemsDesktop: [640, 4],
                itemsDesktopSmall: [414, 3]
            });
        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="slidey" style="display: none;">
        <ul>
            <li>
                <img src="images/5.jpg" alt=" "><p class='title'>Godzilla </p>
                <p class='description'>Members of the crypto-zoological agency Monarch face off against a battery of god-sized monsters, including the mighty Godzilla, who collides with Mothra, Rodan, and his ultimate nemesis, the three-headed King Ghidorah.</p>
            </li>
            <li>
                <img src="images/2.jpg" alt=" "><p class='title'>Alita Battle Angel</p>
                <p class='description'>Set several centuries in the future, the abandoned Alita is found in the scrapyard of Iron City by Ido, a compassionate cyber-doctor who takes the unconscious cyborg Alita to his clinic.</p>
            </li>
            <li>
                <img src="images/3.jpg" alt=" "><p class='title'>The Hidden World</p>
                <p class='description'>From DreamWorks Animation comes a surprising tale about growing up, finding the courage to face the unknown…and how nothing can ever train you to let go</p>
            </li>
            <li>
                <img src="images/4.jpg" alt=" "><p class='title'>Avengers Endgame</p>
                <p class='description'>Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers.</p>
            </li>
            <li>
                <img src="images/6.jpg" alt=" "><p class='title'>Men in Black </p>
                <p class='description'>Agent J goes back in time to stop his partner Agent K from being killed by Boris The Animal, an alien criminal who was imprisoned by K</p>
            </li>
            <li>
                <img src="images/7.jpg" alt=" "><p class='title'>Dark Phoenix</p>
                <p class='description'>The X-Men face their most formidable and powerful foe when one of their own, Jean Grey, starts to spiral out of control. During a rescue mission in outer space, Jean is nearly killed when she's hit by a mysterious cosmic force.</p>
            </li>
        </ul>
    </div>
    <script src="js/jquery.slidey.js"></script>
    <script src="js/jquery.dotdotdot.min.js"></script>
    <script type="text/javascript">
        $("#slidey").slidey({
            interval: 8000,
            listCount: 5,
            autoplay: false,
            showList: true
        });
        $(".slidey-list-description").dotdotdot();
    </script>
    <div class="banner-bottom">
        <div class="container">
            <div class="w3_agile_banner_bottom_grid">
                <div id="owl-demo" class="owl-carousel owl-theme">
                    <asp:Repeater OnItemDataBound="Repeater_TopAll_ItemDataBound" ID="Repeater_TopAll" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="w3l-movie-gride-agile w3l-movie-gride-agile1">
                                    <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                        <asp:Image ID="Image1"  Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
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
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <div class="general">
        <h4 class="latest-text w3_latest_text">Featured Movies</h4>
        <div class="container">
            <div class="bs-example bs-example-tabs" role="tabpanel" data-example-id="togglable-tabs">
                <ul id="myTab" class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#home" id="home-tab" role="tab" data-toggle="tab" aria-controls="home" aria-expanded="true">Adventure</a></li>
                    <li role="presentation"><a href="#profile" role="tab" id="profile-tab" data-toggle="tab" aria-controls="profile" aria-expanded="false">Romance</a></li>
                    <li role="presentation"><a href="#rating" id="rating-tab" role="tab" data-toggle="tab" aria-controls="rating" aria-expanded="true">Horror</a></li>
                    <li role="presentation"><a href="#imdb" role="tab" id="imdb-tab" data-toggle="tab" aria-controls="imdb" aria-expanded="false">Science fiction</a></li>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <div role="tabpanel" class="tab-pane fade active in" id="home" aria-labelledby="home-tab">
                        <div class="w3_agile_featured_movies">
                            <asp:Repeater OnItemDataBound="RepeaterAdventure_ItemDataBound" ID="RepeaterAdventure" runat="server">
                            <ItemTemplate>
                                <div class="col-md-2 w3l-movie-gride-agile">
                                    <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                        <asp:Image ID="Image2"  Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
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
                    <div role="tabpanel" class="tab-pane fade" id="profile" aria-labelledby="profile-tab">
                        <asp:Repeater OnItemDataBound="RepeaterRomance_ItemDataBound" ID="RepeaterRomance" runat="server">
                            <ItemTemplate>
                                <div class="col-md-2 w3l-movie-gride-agile">
                                    <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                        <asp:Image ID="Image2"  Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
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
                    <div role="tabpanel" class="tab-pane fade" id="rating" aria-labelledby="rating-tab">
                        <asp:Repeater OnItemDataBound="RepeaterHorror_ItemDataBound" ID="RepeaterHorror" runat="server">
                            <ItemTemplate>
                                <div class="col-md-2 w3l-movie-gride-agile">
                                    <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                        <asp:Image ID="Image2"  Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
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
                    <div role="tabpanel" class="tab-pane fade" id="imdb" aria-labelledby="imdb-tab">
                        <asp:Repeater OnItemDataBound="RepeaterScienceFiction_ItemDataBound" ID="RepeaterScienceFiction" runat="server">
                            <ItemTemplate>
                                <div class="col-md-2 w3l-movie-gride-agile">
                                    <a href="MovieDetail.aspx?MovieId=<%#Eval("Movie_Id")%>" class="hvr-shutter-out-horizontal">
                                        <asp:Image ID="Image2"  Width="170px" Height="265px" class="img-responsive" ImageUrl='<%#Eval("Movie_Image") %>' runat="server" />
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
            </div>
        </div>
    </div>
</asp:Content>
