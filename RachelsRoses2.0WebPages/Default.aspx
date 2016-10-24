<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RachelsRoses2._0WebPages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Recipe Name Here:&nbsp;
        <asp:TextBox ID="recipeNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Ingredients:<br />
        <asp:TextBox ID="ingredientTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
    
    </div>
        <asp:Button ID="getPriceButton" runat="server" OnClick="getPriceButton_Click" Text="Get Price Of Ingredients" />
        <br />
        <br />
        <asp:Label ID="getIngredientLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="getPriceLabel" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
