<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab2_2ÄventyrligaKontakter.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:ListView ID="ContactListView" runat="server"
              ItemType="Lab2_2ÄventyrligaKontakter.Model.Contact"
             SelectMethod="ContactListView_GetData"
             InsertMethod="ContactListView_InsertItem"
             UpdateMethod="ContactListView_UpdateItem"
             DeleteMethod="ContactListView_DeleteItem"
             DataKeyNames="ContactID"
             InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn
                        </th>
                        <th>Efternamn
                        </th>
                        <th>EmailAdress
                        </th>
                        <th></th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
                <asp:DataPager ID="DataPager" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" << "
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" >> "
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.FirstName %>
                        </td>
                        <td>
                            <%#: Item.LastName %>
                        </td>
                        <td>
                            <%#: Item.EmailAddress %>
                        </td>
                        <td class="command">
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                                OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0}?\")", Item.FirstName) %>'/>
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Kontaktuppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr>

                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' class="postal-code" />
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <EditItemTemplate>
                <tr>

                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' class="postal-code" />
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>

        </asp:ListView>

    </div>
    </form>
</body>
</html>
