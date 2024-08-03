<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AssignScore.aspx.cs" Inherits="TaskManager.AssignScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-left: 71px; margin-right:70px">
        <h2>Assign Scores</h2>
        <asp:GridView ID="gvAssignScore" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAssignScore_RowCommand" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                <asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
<%--                <asp:BoundField DataField="Status" HeaderText="Status" />--%>
                <asp:TemplateField HeaderText="Score">
                    <ItemTemplate>
                        <asp:TextBox ID="txtScore" runat="server" Text='<%# Bind("Score") %>' Width="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnSaveScore" runat="server" CommandName="SaveScore" CommandArgument='<%# Eval("AssignmentID") %>' Text="Save" CssClass="btn btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    </div>
    </div>


</asp:Content>
