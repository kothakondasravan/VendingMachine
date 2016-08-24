<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateQuantity.aspx.cs" Inherits="VendingMachine.UpdateQuantity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Updating Quantity</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewQuantity" runat="server" AutoGenerateColumns="False" DataKeyNames="qntId" OnRowEditing="GridViewQuantity_RowEditing" OnRowUpdating="GridViewQuantity_RowUpdating" OnRowCancelingEdit="GridViewQuantity_RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Soda ID" DataField="sodaId" ReadOnly="true" />


                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <%# Eval("quantity1") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBxQuantity" runat="server" Text='<%# Eval("quantity1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnGoBack" runat="server" OnClick="btnGoBack_Click" Text="Home" />
        </div>
        <br />
        <br />
        <div>
            <b>Look Up Table:</b>
            <asp:GridView ID="GridViewLookUp" runat="server" AutoGenerateColumns="False" DataKeyNames="sodaId" DataSourceID="SqlDataSourceLookUP">
                <Columns>
                    <asp:BoundField DataField="sodaId" HeaderText="Soda ID" InsertVisible="False" ReadOnly="True" SortExpression="sodaId" />
                    <asp:BoundField DataField="sodaName" HeaderText="Soda Name" SortExpression="sodaName" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceLookUP" runat="server" ConnectionString="<%$ ConnectionStrings:VendingMachineConnectionString %>" SelectCommand="SELECT [sodaId], [sodaName] FROM [soda]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
