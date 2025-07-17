<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="FLAWAD.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!-- page heading -->
    <div class="recordheading">
        <h2>Manage Records</h2>

    </div>

<div class="flowerform">

    <!------- enter flower id ------->
    <div class="formrow">
        <asp:Label ID="lblFlwID" runat="server" Text="Flower ID:"></asp:Label>
        <asp:TextBox ID="txtFlwID" runat="server"></asp:TextBox>
    </div>

    <!---------------- name of the flower --------->
    <div class="formrow">
        <asp:Label ID="lblFlwName" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="txtFlwName" runat="server"></asp:TextBox>
    </div>

    <!--------------- flower colour ----------->
    <div class="formrow">
        <asp:Label ID="lblFlwColour" runat="server" Text="Colour:"></asp:Label>
        <asp:TextBox ID="txtFlwColour" runat="server"></asp:TextBox>
    </div>

    <!------------ price input ------------>
    <div class="formrow">
        <asp:Label ID="lblFlwPrice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="txtFlwPrice" runat="server"></asp:TextBox>
    </div>

    <!------------- stock available -------------->
    <div class="formrow">
        <asp:Label ID="lblFlwStock" runat="server" Text="Stock:"></asp:Label>
        <asp:TextBox ID="txtFlwStock" runat="server"></asp:TextBox>
    </div>

    <!-------------- expiry date input ----------->
    <div class="formrow">
        <asp:Label ID="lblFlwExpiry" runat="server" Text="Expiry Date (YYYY-MM-DD):"></asp:Label>
        <asp:TextBox ID="txtFlwExpiry" runat="server"></asp:TextBox>
    </div>

    <!------------- image file name goes here ----------------->
    <div class="formrow">
        <asp:Label ID="lblImageFileName" runat="server" Text="Image File Name:"></asp:Label>
        <asp:TextBox ID="txtImageFileName" runat="server"></asp:TextBox>
    </div>

    <!--------------- dropdown to select supplier --------->
    <div class="formrow">
        <asp:Label ID="lblSupplierID" runat="server" Text="Supplier ID:"></asp:Label>
        <asp:DropDownList ID="ddlSupplierID" runat="server"></asp:DropDownList>
    </div>

    <!----------- action buttons ----->
    <div class="formbuttons">
        <asp:Button ID="btnAddFlower" runat="server" Text="Add Flower" OnClick="btnAddFlower_Click" />
        <asp:Button ID="btnDeleteFlower" runat="server" Text="Delete Flower" OnClick="btnDeleteFlower_Click" />
        <asp:Button ID="btnRetrieveFlower" runat="server" Text="Retrieve Flower" OnClick="btnRetrieveFlower_Click" />
        <asp:Button ID="btnUpdateFlower" runat="server" Text="Update Flower" OnClick="btnUpdateFlower_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Reset Form" OnClick="btnReset_Click" CssClass="formbutton" />

    </div>

    <!------ message area and image preview --->
    <div class="formmessage">
        <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
        <asp:Image ID="imgFlower" runat="server" Width="200px" Visible="false" />
    </div>

</div>

</asp:Content>

