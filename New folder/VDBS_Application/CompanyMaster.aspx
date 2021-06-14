<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="VDBS_Application._CompanyMaster" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Company Name :-"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <br />
        <tr>
            <td>
                <asp:Label ID="lblFileUpload" runat="server" Text="File Upload :-"></asp:Label>
            </td>
            <td>
                  <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                    
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>

</asp:Content>
