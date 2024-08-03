<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ReTask.aspx.cs" Inherits="TaskManager.ReTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div style="margin-left: 71px; margin-right:70px">
            <h2>Re-Tasks</h2>
            <asp:GridView ID="gvReTasks" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReTasks_RowCommand" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                    <asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:BoundField DataField="RejectionReason" HeaderText="Rejection Reason" />
                    <asp:TemplateField HeaderText="Attachment">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkDownload" runat="server" Text="Download" NavigateUrl='<%# Eval("SolutionAttachment") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:FileUpload ID="fuSolution" runat="server" />
                            <asp:Button ID="btnSubmit" runat="server" CommandName="ReSubmit" CommandArgument='<%# Eval("AssignmentID") %>' Text="Re-Submit" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>

</asp:Content>
