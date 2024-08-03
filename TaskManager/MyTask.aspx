<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MyTask.aspx.cs" Inherits="TaskManager.MyTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div style="margin-left: 71px; margin-right:70px">
            <h2>My Tasks</h2>
            <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTasks_RowCommand" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                    <asp:BoundField DataField="AssignedDate" HeaderText="Assign Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:HyperLinkField DataTextField="Attachment" HeaderText="Download" DataNavigateUrlFields="Attachment" Text="Download" />
                    <asp:TemplateField HeaderText="Solution">
                        <ItemTemplate>
                            <asp:FileUpload ID="fuSolution" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" CommandArgument='<%# Eval("AssignmentID") %>' Text="Submit" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
