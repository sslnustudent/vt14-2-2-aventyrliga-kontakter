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
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Ett fel inträffade" />
        <asp:ValidationSummary ValidationGroup="EditG" ID="ValidationSummary2" runat="server" HeaderText="Ett fel inträffade" />
        <div id="OkDiv" runat="server" visible="false">
            <asp:Label ID="LabelOk" runat="server" Text="Label"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='~/Default.aspx'>
                <asp:Image  ImageUrl="~/DeleteRed.png" Width="20px" ID="Delete" runat="server" /></asp:HyperLink>
        </div>
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
                                OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0} {1}?\")", Item.FirstName, Item.LastName) %>'/>
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
                        <asp:TextBox ID="FirstName1" runat="server" Text='<%# BindItem.FirstName %>' />
                        <asp:RequiredFieldValidator ControlToValidate="FirstName1" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName1" runat="server" Text='<%# BindItem.LastName %>' />
                        <asp:RequiredFieldValidator ControlToValidate="LastName1" ID="RequiredFieldValidator21" runat="server" ErrorMessage="Ange ett Efternamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress1" runat="server" Text='<%# BindItem.EmailAddress %>' class="postal-code" />
                        <asp:RequiredFieldValidator ControlToValidate="EmailAddress1" ID="RequiredFieldValidator31" runat="server" ErrorMessage="Ange en emailadress" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="EmailAddress1" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Ange en giltig emailadress" ValidationExpression="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b" Display="None"></asp:RegularExpressionValidator>
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
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50" ValidationGroup="EditG" />
                        <asp:RequiredFieldValidator ValidationGroup="EditG" ControlToValidate="FirstName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ValidationGroup="EditG" ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50" />
                        <asp:RequiredFieldValidator ValidationGroup="EditG" ControlToValidate="LastName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange ett Efternamn" Display="None"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                        <asp:TextBox ValidationGroup="EditG" ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' class="postal-code" MaxLength="50" />
                        <asp:RequiredFieldValidator ValidationGroup="EditG" ControlToValidate="EmailAddress" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ange en emailadress" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="EditG" ControlToValidate="EmailAddress" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ange en giltig emailadress" ValidationExpression="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b" Display="None"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:LinkButton ValidationGroup="EditG" runat="server" CommandName="Update" Text="Spara" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>

        </asp:ListView>

    </div>
    </form>
</body>
</html>
