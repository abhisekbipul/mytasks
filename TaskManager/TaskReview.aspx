<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TaskReview.aspx.cs" Inherits="TaskManager.TaskReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <script type="text/javascript">
               function showRejectionPopup() {
                   document.getElementById('rejectionPopup').style.display = 'block';
               }

               function hideRejectionPopup() {
                   document.getElementById('rejectionPopup').style.display = 'none';
               }
            </script>
       <div style="margin-left: 71px; margin-right:70px">
            <h2>Task Review</h2>
            <asp:GridView ID="gvTaskReview" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTaskReview_RowCommand" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="AssignmentID" HeaderText="ID" />
                    <asp:BoundField DataField="TaskName" HeaderText="Task Name" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:TemplateField HeaderText="Attachment">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkDownload" runat="server" Text="Download" NavigateUrl='<%# Eval("SolutionAttachment") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="IsLate" HeaderText="On Time/Late" DataFormatString="{0}" HtmlEncode="false" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" CommandName="ApproveTask" CommandArgument='<%# Eval("AssignmentID") %>' Text="Approve" CssClass="btn btn-success" />
                            <asp:Button ID="btnReject" runat="server" CommandName="RejectTask" CommandArgument='<%# Eval("AssignmentID") %>' Text="Reject" CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="rejectionPopup" style="display:none; position:fixed; top:20%; left:30%; width:40%; background-color:#fff; border:1px solid #ccc; padding:20px;">
            <h3>Enter Rejection Reason</h3>
            <asp:HiddenField ID="hfAssignmentID" runat="server" />
            <asp:TextBox ID="txtRejectionReason" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmitRejectionReason" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnReject_Click" />
            <asp:Button ID="btnCancelRejection" runat="server" Text="Cancel" OnClientClick="hideRejectionPopup(); return false;" CssClass="btn btn-secondary" />
        </div>

</asp:Content>
