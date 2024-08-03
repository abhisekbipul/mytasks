<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserPerformances.aspx.cs" Inherits="TaskManager.UserPerformances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 20px;">
        <h2>User Performances</h2>
        <asp:GridView ID="gvUserPerformances" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" style="margin-top: 20px;">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Full Name" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="TotalScore" HeaderText="Total Score" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
