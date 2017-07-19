<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Currency.aspx.cs" Inherits="WebCurrency.Currency" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="true"></asp:DropDownList>
                <!--<asp:Button ID="btnQuery" runat="server" Text="查詢"/>-->
            </td>
        </tr>
        <tr>
            <td>
                <asp:label ID="lblToday" runat="server" >本本本日匯率</asp:label>
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
                <asp:textbox ID="tbxHalfYearMinRate" runat="server"></asp:textbox>
                <asp:textbox ID="tbxHalfYearMinDate" runat="server"></asp:textbox>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>