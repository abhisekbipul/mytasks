<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AssignTask.aspx.cs" Inherits="TaskManager.AssignTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Assign Task</h2>
    <div class="form-group">
        <label for="txtTaskName">Task Name:</label>
        <asp:TextBox ID="txtTaskName" runat="server" CssClass="form-control" placeholder="Enter Task Name"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="fileAttachment">Attachment:</label>
        <asp:FileUpload ID="fileAttachment" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="ddlBatch">Select Batch:</label>
        <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
            <asp:ListItem Text="Batch 1" Value="1"></asp:ListItem>
            <asp:ListItem Text="Batch 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Batch 3" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlUsers">Select User:</label>
        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" Multiple="true">
            <asp:ListItem Text="Select All" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAssignTask" runat="server" Text="Assign Task" CssClass="btn btn-primary" OnClick="btnAssignTask_Click"  />
    </div>
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
</asp:Content>
