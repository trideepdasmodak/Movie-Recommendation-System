<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminUser.aspx.cs" Inherits="FlimClubWeb.AdminUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.jqueryui.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.jqueryui.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <table id="example" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Image</th>
                    <th>Name</th>
                    <th>Email Id</th>
                    <th>DOB</th>
                    <th>Gender</th>
                    <th>UserType</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterProduct" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" ImageUrl='<%#Eval("User_Image") %>' Height="80px" runat="server" /></td>
                            <td><%#Eval("User_FName") %></td>
                            <td><%#Eval("User_EmailId") %></td>
                            <td><%#Eval("User_DOB") %></td>
                            <td><%#Eval("User_Gender") %></td>
                            <td><%#Eval("User_Type") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <th>Image</th>
                    <th>Name</th>
                    <th>Email Id</th>
                    <th>DOB</th>
                    <th>Gender</th>
                    <th>UserType</th>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
