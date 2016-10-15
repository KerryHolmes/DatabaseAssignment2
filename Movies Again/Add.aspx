<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Movies_Again.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Movie</title>
</head>
<body>
   <asp:Label ID="Label1" runat="server" />
 <form id="form1" runat="server"> 
     <asp:TextBox ID="Movie" runat="server"></asp:TextBox>
     <asp:TextBox ID="Director" runat="server"></asp:TextBox>
     <asp:TextBox ID="Release" runat="server"></asp:TextBox>
     <asp:TextBox ID="Rating" runat="server"></asp:TextBox>
     <asp:Button ID="Button1" runat="server" Text="Submit" onclick="On_submit" />
 </form>
</body>
</html>
