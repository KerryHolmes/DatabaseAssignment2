<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Movies_Again.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Movie</title>
    <style>
        body {
            background-color: black;
            color: white;
        }
        td {
            padding: 1em;
        }
        .container {
            position:relative;
            height: 100%;
            width: 100%;
        }
        .submit_table {
            position: absolute;
            margin-left: 40%;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="submit_table">
         <asp:Label ID="Label1" runat="server" />
         <form id="form1" runat="server">
             <table border="1">
                 <tr>
                    <td>Movie</td>
                     <td><asp:TextBox ID="Movie" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                    <td>Director</td>
                    <td><asp:TextBox ID="Director" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><p>Release Date</p></td>
                     <td><asp:TextBox ID="Release" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                    <td>Rating</td>
                    <td><asp:TextBox ID="Rating" runat="server"></asp:TextBox></td>
                 </tr>
             </table> 
             <br />
             <asp:Button ID="Button1" runat="server" Text="Submit" onclick="On_submit" style="margin-left:79%"/>  
         </form>
        </div>
    </div>
</body>
</html>

