<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WebServicePage.aspx.cs" Inherits="WebServicePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        <strong>Convert Temperatures</strong></p>
    <p>
        Temperature:
        <asp:TextBox ID="TemperatureTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ConvertButton" runat="server" onclick="ConvertButton_Click" 
            Text="Convert" />
    </p>
    <p>
        The vollowing displays the value you converted as indicated:</p>
    <p>
        Fahrenheit -&gt; Celsius:&nbsp;&nbsp;
        <asp:Label ID="FahrenheitLabel" runat="server"></asp:Label>
    </p>
    <p>
        Celsius -&gt; Fahrenheit:&nbsp;&nbsp;
        <asp:Label ID="CelsiusLabel" runat="server"></asp:Label>
    </p>
</asp:Content>

