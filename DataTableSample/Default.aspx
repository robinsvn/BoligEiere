<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTableSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <styles>
        <link rel="stylesheet" href="styles.css"/>
    </styles>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            Antall boliger i databasen:
            <asp:Label ID="LabelNumBoliger" runat="server" Text="LabelNumBoliger"></asp:Label>
            <br />
            <br />
            <%--Bolig sortert etter telefonnr--%>
            Søk med telefonnummer
            <asp:TextBox ID="TextBoxSearchByPhone" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByPhone" runat="server" Text="Søk" OnClick="ButtonSearchByPhone_Click"  />
            <br />
            <br />
            <%--Bolig sortert etter fornavn--%>
            Søk etter person (fornavn)
            <asp:TextBox ID="TextBoxSearchByFornavn" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByFornavn" runat="server" Text="Søk" OnClick="ButtonSearchByFornavn_Click"  />
            <br />
            <br />
            <%--Bolig sortert etter BoligTypeID--%>
            Søk etter BoligType (1-3)
            <asp:TextBox ID="TextBoxSearchByBTID" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByBTID" runat="server" Text="Søk" OnClick="ButtonSearchByBTID_Click"  />
            <br />
            <br />
            <%--Bolig sortert etter PostNR--%>
            Søk etter PostNR
            <asp:TextBox ID="TextBoxSearchByPostNR" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByPostNR" runat="server" Text="Søk" OnClick="ButtonSearchByPostNR_Click"  />
            <br />
            <br />
            <%--Vis alle boliger i databasen i en table--%>
            Viser alle boliger
            <asp:Button ID="ButtonShowAllBoliger" runat="server" Text="Vis alle Boliger" OnClick="ButtonShowAllBoliger_Click" />
            <br />
            <br />
            <%--Boliger sortert etter Sarpsborg--%>
            Vis alle boliger i poststed Sarpsborg
            <asp:Button ID="ButtonPoststedSarpsborg" runat="server" Text="Vis alle boliger i Sarpsborg" OnClick="ButtonPoststedSarpsborg_Click" />
            <br />
            <br />
            <%--Vis alle boliger i databasen i en table--%>
            Viser alle Eiere
            <asp:Button ID="ButtonShowAllEier" runat="server" Text="Vis alle eiere" OnClick="ButtonShowAllEier_Click" />
            <br />
            <br />
             <%--Insert statement for --%>
            Insert ny eier
            <br />
            <br />
            ID
            <br />
            <asp:TextBox ID="TextBoxInsertID" runat="server"></asp:TextBox>
            <br />
            <br />
            Fornavn
            <br />
            <asp:TextBox ID="TextBoxInsertFornavn" runat="server"></asp:TextBox>
            <br />
            <br />
            Etternavn
            <br />
            <asp:TextBox ID="TextBoxInsertEtternavn" runat="server"></asp:TextBox>
            <br />
            <br />
            Adresse
            <br />
            <asp:TextBox ID="TextBoxInsertAdresse" runat="server"></asp:TextBox>
            <br />
            <br />
            Telefonnummer
            <br />
            <asp:TextBox ID="TextBoxInsertTelefonNR" runat="server"></asp:TextBox>
            <br />
            <br />
            Postnummer
            <br />
            <asp:TextBox ID="TextBoxInsertPostNR" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonInsert" runat="server" Text="Insert" OnClick="ButtonInsert_Click" />
            <br />
            <br />
            <%--GridView tables--%>
            <asp:GridView class="GridView" ID="GridViewShowAllEier" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewSortBoligByTelefon" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewSortBoligByFornavn" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewSortBoligByBTID" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewSortBoligByPostNR" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewBoligEiere" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
            <asp:GridView class="GridView" ID="GridViewPoststedSarpsborg" runat="server"><AlternatingRowStyle BackColor="#CCCCCC"/></asp:GridView>
        </div>
    </form>
</body>
</html>
