<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTableSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            DataTable - et eksempel med Bolig og Eiere<br />
            <br />
            Antall boliger i databasen:
            <asp:Label ID="LabelNumBoliger" runat="server" Text="LabelNumBoliger"></asp:Label>
            <br />
            <br />
            Søk med telefonnummer
            <asp:TextBox ID="TextBoxSearchByPhone" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByPhone" runat="server" Text="Søk"  />
            <br />
            Viser alle boliger
            <asp:Button ID="ButtonShowAllBoliger" runat="server" Text="Vis alle Boliger" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewBoligEiere" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
