<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Perfomances.aspx.cs" Inherits="TaskManager.Perfomances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 20px;">
        <h2>Top Performers</h2>
        <asp:GridView ID="gvTopPerformers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Full Name" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="TotalScore" HeaderText="Total Score" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
