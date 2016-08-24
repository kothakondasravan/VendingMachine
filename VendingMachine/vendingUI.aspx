<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vendingUI.aspx.cs" Inherits="VendingMachine.vendingUI1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td>Soda</td>
                    <td>
                        <asp:DropDownList ID="DropDownSoda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSoda_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Price:</td>
                    <td>
                        <asp:Label ID="lblprice" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td>
                        <%--<asp:TextBox ID="txtboxQnty" runat="server" AutoPostBack="true" OnTextChanged="txtboxQnty_TextChanged"></asp:TextBox>--%>
                        <asp:DropDownList ID="DropDownQunatity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownQunatity_SelectedIndexChanged">
                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Total Price:</td>
                    <td>
                        <asp:Label ID="lbltotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btngetsoda" runat="server" Text="Get Soda" OnClick="btngetsoda_Click" />
                    </td>
                </tr>
            </table>
            <div>
                <asp:Label ID="label" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
