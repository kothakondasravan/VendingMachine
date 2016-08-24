<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportGeneration.aspx.cs" Inherits="VendingMachine.ReportGeneration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtBxFrom" runat="server" AutoPostBack="true"></asp:TextBox>
            <asp:LinkButton ID="lnkBtnFrom" runat="server" Text="From" OnClick="lnkBtnFrom_Click"></asp:LinkButton>

            To
            
            <asp:TextBox ID="txtBxTo" runat="server" AutoPostBack="true"></asp:TextBox>
            <asp:LinkButton ID="lnkBtnTo" runat="server" Text="To" OnClick="lnkBtnTo_Click"></asp:LinkButton>
        </div>


        <div>
            <asp:Calendar ID="CalendarFrom" runat="server" Visible="False" OnSelectionChanged="CalendarFrom_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>

            <asp:Calendar ID="CalenderTo" runat="server" Visible="False" OnSelectionChanged="CalenderTo_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </div>
        <br />
        <br />
        <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="GenerateReport" Visible="false" />
        <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
        <br />
        <br />
        <br />
        <br />
        <br />


        <asp:GridView ID="GridViewReport" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceReport" Visible="false">
            <Columns>

                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
                <asp:BoundField DataField="Sold Soda" HeaderText="Sold Soda" ReadOnly="True" SortExpression="Sold Soda" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceReport" runat="server" ConnectionString="<%$ ConnectionStrings:VendingMachineConnectionString %>" SelectCommand="
select dbo.soda.sodaName as 'Name', sum(dbo.vending.priceent) as Total, sum(dbo.vending.soldqnt) as 'Sold Soda' from dbo.vending join dbo.soda on dbo.vending.sodaId = dbo.soda.sodaId where dbo.vending.boughttime between @Time1 and @Time2 group by dbo.soda.sodaName;">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBxFrom" Name="Time1" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtBxTo" Name="Time2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
