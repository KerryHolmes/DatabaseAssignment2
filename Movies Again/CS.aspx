<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CS.aspx.cs" Inherits="Movies_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movies</title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }
        table th
        {
            background-color: #B8DBFD;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }
        .hidden{display: none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="CS.aspx" Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="Add.aspx" Text="Add" Value="Add"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:GridView ID="GridView1" runat="server" EnableViewState="true" AutoGenerateColumns="false" AllowPaging="false" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
            OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="title" HeaderText="Title" />
                <asp:BoundField ItemStyle-Width="150px" DataField="director" HeaderText="Director" />
                <asp:BoundField ItemStyle-Width="150px" DataField="release" HeaderText="Release Date" />
                <asp:BoundField ItemStyle-Width="150px" DataField="rating" HeaderText="Rating out of 5" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
