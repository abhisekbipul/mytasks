<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DateWisePerformers.aspx.cs" Inherits="TaskManager.DateWisePerformers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 20px;">
        <h2>Date Wise Top Performers</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="form-group">
            <label for="txtFromDate">From Date:</label>
            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Placeholder="yyyy-mm-dd" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtToDate">To Date:</label>
            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Placeholder="yyyy-mm-dd" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
        <asp:GridView ID="gvTopPerformersByDate" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" style="margin-top: 20px;">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Full Name" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="TotalScore" HeaderText="Total Score" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
