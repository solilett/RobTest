<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="weather.aspx.cs" Inherits="webServices.weather" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container weatherForm">

        <div>
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>    
         </div>

        <div>
        <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Get Forecast" />
        </div>

              <asp:RadioButtonList ID="rbGetType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbGetType_SelectedIndexChanged">
                <asp:ListItem Text="°F" Value="f" Selected="True"/>
                <asp:ListItem Text="°C" Value="c" />
              </asp:RadioButtonList>

        <div>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>

  

    </div>
      

</asp:Content>
