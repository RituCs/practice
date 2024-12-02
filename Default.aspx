<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="crud_first_version._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table-style">
        <tr>
            <td colspan="2" class="header">CRUD OPERATION</td>
        </tr>
        <tr>
            <td>Product Id</td>
            <td>
                <asp:TextBox runat="server" ID="productid"></asp:TextBox><asp:RequiredFieldValidator runat="server" ErrorMessage="Enter Product Id" ForeColor="Red" ControlToValidate="productid"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Item Name</td>
            <td>
                <asp:TextBox runat="server" ID="itemname"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Specification</td>
            <td>
                <asp:TextBox runat="server" ID="specification"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Unit</td>
            <td>
                <asp:DropDownList runat="server" ID="unit">
                 <asp:ListItem Value="" >Select</asp:ListItem>
                <asp:ListItem>PCS</asp:ListItem>
                <asp:ListItem>KG</asp:ListItem>
                <asp:ListItem>Ltr</asp:ListItem>
                <asp:ListItem>DZ</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Status</td>
            <td>
                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="status">
                    <asp:ListItem>Running</asp:ListItem>
                    <asp:ListItem>Unused</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>Creation Date</td>
            <td>
                <asp:TextBox runat="server" ID="creationdate" TextMode="Date"></asp:TextBox></td>
        </tr>
         <tr>
          <td></td>

          <td>
         <asp:Button ID="Button1" runat="server" Text="Insert" BackColor="#7494ec" ForeColor="	#FFFFFF" OnClick="Button1_Click" />
              <asp:Button runat="server" Text="Update" BackColor="#7494ec" ForeColor="#FFFFFF"  OnClick="Unnamed1_Click"></asp:Button>
              <asp:Button runat="server" Text="Delete" BackColor="#7494ec" ForeColor="	#FFFFFF" OnClientClick="return confirm('are you sure to Delete');" OnClick="Unnamed2_Click"></asp:Button>
          </td>

            
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server"  CssClass="gridview-style" HeaderStyle-BackColor="#7494ec" HeaderStyle-ForeColor="#FFFFFF"></asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
