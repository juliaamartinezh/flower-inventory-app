<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FLAWAD.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <!--------- welcome  intro area --------->
<div class="dashboardwelcome">
    <h2 class="dashboardheading">Welcome to the Dashboard</h2>
    <p class="userwelcome">You are logged in as: <asp:Label ID="lblUser" runat="server" /></p>
</div>
    <div>
     <img src="Imagesflw/flwbanner.png" alt="Dashboard Banner" width="600" height="400" class="banner">
    </div>

    <!-------- navigation cards --------->
    <div class="cards">
<!------------- card linking to the flower management page ------->
        <div class="card">
            <h3>Manage Records</h3>
            <a href="Manage.aspx" class="button">Go</a>
        </div>

        <!----------- card linking to the flower viewing page ------->
        <div class="card">
            <h3>View Records</h3>
            <a href="View.aspx" class="button">Go</a>
        </div>

    </div>

</asp:Content>
