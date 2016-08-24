<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OwnerPage.aspx.cs" Inherits="VendingMachine.OwnerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button ID="btnUpdatePrice" runat="server" OnClick="btnUpdatePrice_Click" Text="Update Price" />

                <asp:Button ID="btnUpdateQuantity" runat="server" OnClick="btnUpdateQuantity_Click" Text="Update Quantity" />

                <asp:Button ID="btnGenerateReport" runat="server" OnClick="btnGenerateReport_Click" Text="Generate Report" />
                <br />
            </div>

            <asp:Label ID="lblLow" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="GridViewVending" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceVending">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Price per unit" HeaderText="Price per unit" SortExpression="Price per unit" />
                    <asp:BoundField DataField="Sold Quantity" HeaderText="Sold Quantity" SortExpression="Sold Quantity" />
                    <asp:BoundField DataField="Sold Price" HeaderText="Sold Price" SortExpression="Sold Price" />
                    <asp:BoundField DataField="boughttime" HeaderText="boughttime" SortExpression="boughttime" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceVending" runat="server" ConnectionString="<%$ ConnectionStrings:VendingMachineConnectionString %>" SelectCommand="Select dbo.soda.sodaName as 'Name', dbo.vending.orgprice as 'Price per unit',
dbo.vending.soldqnt as 'Sold Quantity',dbo.vending.priceent as 'Sold Price', dbo.vending.boughttime 
from dbo.vending join dbo.soda on dbo.vending.sodaId = dbo.soda.sodaId join dbo.quantity on dbo.vending.sodaQnt = dbo.quantity.qntId;"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
