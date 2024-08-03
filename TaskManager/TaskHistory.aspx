<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="TaskHistory.aspx.cs" Inherits="TaskManager.TaskHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-left: 71px; margin-right:70px">
            <h2>Task History</h2>
            <asp:GridView ID="gvTaskHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                    <asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Score" HeaderText="Score" />
                    <asp:TemplateField HeaderText="Attachment">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlDownload" runat="server" NavigateUrl='<%# Eval("SolutionAttachment") %>' Text="Download" />
                        </ItemTemplate>
                    </asp:TemplateField>
<%--                    <asp:BoundField DataField="TaskStatus" HeaderText="TaskStatus" />--%>
                </Columns>
            </asp:GridView>
        </div>

</asp:Content>
