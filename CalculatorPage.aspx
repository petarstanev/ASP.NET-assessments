<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CalculatorPage.aspx.cs" Inherits="CalculatorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Exercise 1 - Calculator<br />
    <asp:TextBox ID="txt_num1" runat="server"></asp:TextBox>
    <asp:Label ID="lbl_operand" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txt_num2" runat="server"></asp:TextBox>
    <asp:Label ID="lbl_result" runat="server" Text="Result"></asp:Label>
    <asp:RadioButtonList ID="rad_operations" runat="server">
        <asp:ListItem Value="add">+</asp:ListItem>
        <asp:ListItem Value="subtract">-</asp:ListItem>
        <asp:ListItem Value="multiply">*</asp:ListItem>
        <asp:ListItem Value="division">/</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="BtnCalculate" runat="server" OnClick="Calculate_Click" Text="Calculate" />
</asp:Content>