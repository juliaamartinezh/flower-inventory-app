

<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="FLAWAD.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <!-- this section handles sorting and filtering the flower records by price and supplier -->
    <!-- it is mainly dropdowns and buttons for the user to control the view -->
    <!-- Sort and Filter Sections -->
<div class="tablesection sortsection">
    <asp:Label ID="lblSortPrice" runat="server" Text="Sort by Price:" CssClass="sortlabel"></asp:Label>
    <asp:DropDownList ID="ddlSortPrice" runat="server">
        <asp:ListItem Text="Low to High" Value="ASC" />
        <asp:ListItem Text="High to Low" Value="DESC" />
    </asp:DropDownList>
    <asp:Button ID="btnSort" runat="server" Text="Sort" OnClick="btnSort_Click" CssClass="sortbtn" />

    <asp:Label ID="lblSupplierFilter" runat="server" Text="Filter by Supplier:" CssClass="sortlabel"></asp:Label>
    <asp:DropDownList ID="ddlSupplierFilter" runat="server"></asp:DropDownList>
    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" CssClass="sortbtn" />
</div>


     <!-- heading shown above the flower table -->

    <div class="tblflowerh">

        <h2>Flowers Table</h2>
    </div>

    <!-- this section displays flower records using a gridview table -->
    <!-- each row shows info about each flower record like name, price, colour, ID (PK), supplierID (FK), image etc. -->

<div class="tablesection tblflw">
    <asp:GridView ID="GridViewFlowers" runat="server" CssClass="gridview" AutoGenerateColumns="False" DataKeyNames="FlwID">
        <Columns>
            <asp:BoundField DataField="FlwID" HeaderText="FlwID" ReadOnly="True" SortExpression="FlwID" />
            <asp:BoundField DataField="FlwName" HeaderText="FlwName" SortExpression="FlwName" />
            <asp:BoundField DataField="FlwColour" HeaderText="FlwColour" SortExpression="FlwColour" />
            <asp:BoundField DataField="FlwPrice" HeaderText="FlwPrice" SortExpression="FlwPrice" />
            <asp:BoundField DataField="FlwStock" HeaderText="FlwStock" SortExpression="FlwStock" />
            <asp:BoundField DataField="FlwExpiry" HeaderText="FlwExpiry" SortExpression="FlwExpiry" />
            <asp:BoundField DataField="ImageFileName" HeaderText="ImageFileName" SortExpression="ImageFileName" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="SupplierName" />
        </Columns>
    </asp:GridView>
</div>

 <!-- heading shown above the supplier table -->

    <div class="tblsuppliersh">

    <h2>Suppliers Table</h2>
</div>

     <!-- this gridview shows all suppliers from the database -->
    <!-- it is connected directly to the sql data source below -->


<div class="tablesection tblsuppliers">
    <asp:GridView ID="GridViewSuppliers" runat="server" CssClass="gridview" AutoGenerateColumns="False" DataKeyNames="SupplierID" DataSourceID="SqlDataSourceSuppliers">
        <Columns>
            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ReadOnly="True" SortExpression="SupplierID" />
            <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
            <asp:BoundField DataField="SupplierContact" HeaderText="SupplierContact" SortExpression="SupplierContact" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
        </Columns>
    </asp:GridView>
     <!-- this pulls supplier data from your database and feeds it to the table above -->
    <asp:SqlDataSource ID="SqlDataSourceSuppliers" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM suppliers">
    </asp:SqlDataSource>
</div>

</asp:Content>