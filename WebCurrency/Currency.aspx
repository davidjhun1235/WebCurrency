<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Currency.aspx.cs" Inherits="WebCurrency.Currency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>
                <asp:Button ID="btnQuery" runat="server" Text="查詢"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label ID="lblToday" runat="server">本本本日匯率</asp:label>
                <asp:textbox ID="tbxTodayRate" runat="server"></asp:textbox>
                <asp:textbox ID="tbxTodayDate" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label ID="lblMonthMin" runat="server">本月最低匯率</asp:label>
                <asp:textbox ID="tbxlMonthMinRate" runat="server"></asp:textbox>
                <asp:textbox ID="tbxlMonthMinDate" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:label ID="lblHalfYearMin" runat="server">半年最低匯率</asp:label>
                <asp:textbox ID="lblHalfYearMinRate" runat="server"></asp:textbox>
                <asp:textbox ID="lblHalfYearMinDate" runat="server"></asp:textbox>
            </td>
        </tr>
    </table>
</asp:Content>

