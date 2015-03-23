<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="currencyConverter.aspx.cs" Inherits="webServices.currencyConverter1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <table>
        <tr><td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td><td>
                <asp:DropDownList ID="ddFrom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddTo_SelectedIndexChanged">
                </asp:DropDownList>
             </td></tr>

        <tr><td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td><td>
    <asp:DropDownList ID="ddTo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddTo_SelectedIndexChanged">
    </asp:DropDownList>
        </td></tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Convert" OnClick="Button1_Click" />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
