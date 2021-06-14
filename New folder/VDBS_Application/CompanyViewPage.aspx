<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyViewPage.aspx.cs" Inherits="VDBS_Application.CompanyViewPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand1">
        <Columns>
            <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblCompanyID" runat="server" Text='<%# Eval("CompanyID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField DataField="CompanyID" HeaderText="CompanyID" ItemStyle-Width="150px" />--%>
            <asp:BoundField DataField="Name" HeaderText="Company Name" ItemStyle-Width="150px" />
            <asp:BoundField DataField="FileName" HeaderText="File Name" ItemStyle-Width="150px" />
            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="150px" />



            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
    <br />
    <div id="companyDetails" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Text="Company ID :-"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyID" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Company Name :-"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFileUpload" runat="server" Text="File Upload :-"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFileUploadName" runat="server" />

            </td>
            </tr><tr>
            <td>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />

            </td>
            <td>
                <asp:Button ID="btnDisapprove" runat="server" Text="Disapprove" OnClick="btnDisapprove_Click" />

            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    </div>
</asp:Content>
