<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="FormAuth.Logon,FormAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



    <div style="width:100%; height:100%; position:absolute; top:0px; left:0px; background-color:#cacaca; overflow:hidden">
        <div style="position:relative; width:100%; height:50px; background-color:#3e3e3f">

        </div>

        <div 
        style="position:relative;height:100%;
        margin:auto;
        display:table ">

    <div style="display:table-cell; vertical-align:middle;">

        <div style="position:relative; width:400px; height:200px; background-color:#f9f9f9; ">
            <div style="width:100%; height:30px;background-color:#1e1f1f; 
                line-height:30px; vertical-align:central;">
                <span style=" color:#ffffff; font-weight:700; padding-left:5px">Login</span>
            </div>


        <form id="form1" runat="server">
        <div>       

            <style type="text/css">
            table tr td:first-child{
                width: 100px;
                
                font-weight: 700;
            }
                                            
            </style>
                  
            <table style="margin:auto">
                        <tr>
                            <td style="height:40px">
                                User Name
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName" Font-Size="Large" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Password
                            </td>
                            <td style="height:40px">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" Font-Size="Large" ></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                <asp:Panel ID="pnlError" runat="server" Visible="false">
                                    <div style="color:red">
                                        Wrong username or password
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <asp:Button OnClick="Login_Click" runat="server" ID="btnLogin" Text="Login" />  
                            </td>
                        </tr>

                </table>


        </div>
        </form>


        </div>

       
    </div>
        
        
        </div>


    </div>

    
</body>
</html>
