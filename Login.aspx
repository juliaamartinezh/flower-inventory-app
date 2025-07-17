<%@ Page Title="Login" Language="C#" MasterPageFile="~/FrontendSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FLAWAD.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <!-- Login form container styled w-------->
    <div class="logincontainer">

        <!------page title for the Login area ------>
        <h2 class="loginheading">Admin Login</h2>

        <!-- message label for the login feedback ---->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        <%-------------------- Login Labels --------%>
        <div class="loginlabels">

            <!--=---- username textbox Inserting ------->
            <br />
            Username:
            <asp:TextBox ID="txtUsername" runat="server" /><br />
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                ControlToValidate="txtUsername"
                ErrorMessage="Username is required"
                ForeColor="Red" /><br />

            <!-- -----password Textbox ------->
            Password:
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Password is required"
                ForeColor="Red" /><br /><br />

            <!-- Login button triggers for authentication --------->
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="loginbutton" />

        </div>
    </div>

</asp:Content>




