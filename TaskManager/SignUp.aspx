<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TaskManager.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet">
    <title>SignUp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">

            <label class="col-xs-11">UserName:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtUname" runat="server" Class="form-control" placeholder="Enter Your UserName"></asp:TextBox>
            </div>

            <label class="col-xs-11">Your Full Name:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Enter Your Name"></asp:TextBox>
            </div>

            <label class="col-xs-11">Email:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>

            <label class="col-xs-11">Batch:</label>
            <div class="col-xs-11">
                <asp:DropDownList ID="ddlBatch" runat="server" Class="form-control">
                    <asp:ListItem Text="Select Batch" Value="0" />
                    <asp:ListItem Text="Batch 1" Value="1" />
                    <asp:ListItem Text="Batch 2" Value="2" />
                    <asp:ListItem Text="Batch 3" Value="3" />
                </asp:DropDownList>
            </div>

            <label class="col-xs-11">Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your password"></asp:TextBox>
            </div>


            <label class="col-xs-11">Confirm Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" Class="form-control" placeholder="Enter Your Confirm password"></asp:TextBox>
            </div>

            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="txtsignup" Class="btn btn-success" runat="server" Text="SignUP"  BackColor="#003399" OnClick="txtsignup_Click" />
                &nbsp;<asp:Label ID="lblMsg" runat="server" Text=" "></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
