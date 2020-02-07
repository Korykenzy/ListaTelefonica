<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contatos.aspx.cs" Inherits="MgContecnicaTeste.Contatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

      <link href="./Content/Site.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
     

        .auto-style2 {
            display: block;
            font-weight: normal;
            font-family: Calibri;
            font-size: 12pt;
            color: #656565;
            width: 561px;
            height: 24px;
            margin-left: 405px;
        }

      


        /*Precisa ser auto*/
        .auto-style6 {
            left: -19px;
            top: 22px;
            width: 101px;
            height: 27px;
        }
             
        .auto-style20 {
            border: 1px solid #dddddd;
            
           color:white;
            font-size: 11pt;
           
            -webkit-border-radius: 17px;
            -moz-border-radius: 17px;
            cursor: pointer;
        }
       
      
     
      
       
       
      
     
      
       
        .auto-style21 {
            width: 1043px;
            height: 133px;
        }
       
      
     
      
       
       
      
     
      
       
    </style>
</head>
<body style="height: 1458px">
    <form id="form1" runat="server">
        <div style="margin-left: 108px; margin-top: 40px;  width: 1011px; height: 586px;" >
            <div style="height: 636px;">
                <div class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="LISTA DE CONTATOS 0.1" Font-Names="Century Gothic" Font-Size="X-Large" Font-Bold="True" ForeColor="#124191"></asp:Label>
                    <br />
                    <div style=" height: 551px; width: 729px;
            margin-left: 0px;">
                         <div style="margin-left: -100px;">

            <table border="0" style=" margin-top: 3px; margin-left: -145px; height: 107px;  width: 657px;">
             <tr>
                    <td style=" width: 258px;">
                     
                        <asp:Button ID="Btn_Novo" CssClass="auto-style20" runat="server" Text="Novo" Width="108px" OnClick="Btn_Novo_Click" Font-Names="Century Gothic" ForeColor="White" Style="margin-left: 19px" BackColor="#124191" Height="32px" />
                        <asp:Button ID="Btn_Procura"  CssClass="auto-style20" runat="server" OnClick="Btn_Procura_Click" Text="Procurar" Width="108px" Font-Names="Century Gothic"  ForeColor="White" BackColor="#124191" Height="32px" />
                    </td>

                    <td>
                        <asp:TextBox ID="Txtb_Procura" style=" text-transform: uppercase; background: -webkit-gradient( linear, left bottom, left top, color-stop(0, rgb(250,250,250)), color-stop(1, rgb(230,230,230))); border-bottom: 1px solid #fff; font-size: 16px; margin: 4px; padding: 5px; -webkit-border-radius: 17px; /* Shadows */  -webkit-box-shadow: -1px -1px 2px rgba(0,0,0,.3), 0 0 1px rgba(0,0,0,.2); border-left-style: none; border-left-color: inherit; border-left-width: 0; border-right-style: none; border-right-color: inherit; border-right-width: 0; border-top-style: none; border-top-color: inherit; border-top-width: 0; margin-left:0px; height: 19px;"  placeholder="Digite aqui" runat="server" Width="224px"  MaxLength="60" Font-Names="Century Gothic"  OnTextChanged="Txtb_Procura_TextChanged"></asp:TextBox>
                    </td>
               <%--  12--%>
                    <td>
                        <asp:Button ID="Consulta" CssClass="auto-style20" runat="server" Height="32px" Text="Buscar" Width="108px" OnClick="Consulta_Click" Style="margin-left: 8px; " Font-Names="Century Gothic" BackColor="#124191" />
                        
                    </td>
                 </tr>
            </table>
        </div>
<div id="table" style="margin-top: -10px; margin-left: -225px " >

                                    <table border="0" style="margin-left: -10px; margin-top: 0px;   " class="auto-style21" >
                                        <tr>
                                            <td style="width: 257px">
                                                <asp:Label CssClass="label" ID="Label_Usuario" runat="server" Text="NOME" Font-Names="Century Gothic" Visible="False" Font-Size="Medium" margin-left="0" Width="104px" Style="margin-left: 3px" ForeColor="#124191"></asp:Label>
                                                <asp:TextBox ID="Txtb_nmUsuario" CssClass="campo" placeholder="Digite o nome" runat="server" Width="231px" Visible="false" MaxLength="35" margin-left="10px" Font-Names="Century Gothic" AutoPostBack="false"></asp:TextBox>
                                            </td>
                                           <td>
                                                <!-- <tr><td> </td></tr>  -->
                                                <asp:Label CssClass="label" ID="Label_Email" runat="server" Text="EMAIL" Font-Names="Century Gothic" Visible="False" Font-Size="Medium" Width="72px" Style="margin-left: 6px" ForeColor="#124191"></asp:Label>
                                                <asp:TextBox ID="Txtb_dsEmail" CssClass="campo" placeholder="Digite o email" runat="server" Width="231px" Visible="false" MaxLength="45" margin-left="10px" Font-Names="Century Gothic" ></asp:TextBox>

                                            </td>
                                            <!--       <br />     -->
                                            <td>
                                                <!--  <tr><td> <br /> </td></tr>   -->
                                                <asp:Label CssClass="label" ID="Label_Celular" runat="server" Text="TELEFONE" Font-Names="Century Gothic" Visible="False" Font-Size="Medium" margin-left="0" Width="114px" Style="margin-left: 0px" ForeColor="#124191"></asp:Label>
                                                <asp:TextBox ID="Txtb_dsCelular" CssClass="campo" placeholder="Digite o telefone" runat="server" Width="231px" Visible="false" TextMode="Phone" MaxLength="15" margin-left="10px" Font-Names="Century Gothic"></asp:TextBox>
                                            </td>
                                             <td style="width: 257px">

                                                <asp:Label CssClass="label" ID="Label_Status" runat="server" Text="STATUS" Font-Names="Century Gothic" Visible="False" Font-Size="Medium" Width="85px" Style="margin-left: 3px" ForeColor="#124191"></asp:Label>
                                                <asp:TextBox ID="Txtb_dsStatus" CssClass="campo" placeholder="Ativo ou Inativo" runat="server" Width="231px" Visible="false" MaxLength="7" margin-left="10px" Font-Names="Century Gothic" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <!-- <tr><td> </td></tr>  -->
                                                <asp:Label CssClass="label" ID="Label_Prioridade" runat="server" Text="PRIORIDADE" Font-Names="Century Gothic" Visible="False" Font-Size="Medium" Width="72px" Style="margin-left: 6px" ForeColor="#124191"></asp:Label>
                                                <asp:TextBox ID="Txtb_dsPrioridade" CssClass="campo" placeholder="Digite a prioridade" runat="server" Width="231px" Visible="false" MaxLength="45" margin-left="10px" Font-Names="Century Gothic" ></asp:TextBox>

                                            </td>
                                           
                                           
                                            <!-- 15  <br /> -->

                                            <td>
                                                <asp:Button ID="Btn_Salvar" CssClass="botao_N" style="font-size: 11pt; cursor: pointer; margin-top: 20px;"  runat="server" Font-Names="Century Gothic" Height="33px" Text="Salvar"   Width="127px" OnClick="Btn_Salvar_Click" BackColor="#124191" ForeColor="White" Visible="false" />
                                            </td>
                                        </tr>
                                        <!--  </ol> -->
                                    </table>
                                </div>



                        <div id="GridView" style=" height: 391px; margin-left: -220px;">


                        <asp:GridView ID="grdShow"   runat="server" Height="16px" Style="margin-left: -5px;  overflow: auto; border: solid 1px rgb(221, 221, 221); margin-top: 18px;  " Width="1023px"  BackColor="White"  Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#124191" ShowFooter="True" UseAccessibleHeader="False" OnRowCommand="grdShow_RowCommand" AutoGenerateColumns="False" GridLines="Horizontal"  OnSelectedIndexChanged="grdShow_SelectedIndexChanged">
                          
                          
          
                          
<HeaderStyle Width="60px" />

                           
                          
                          
                   
                            <AlternatingRowStyle BackColor="#FFFFFF"  ForeColor="#124191" HorizontalAlign="Left" />
      
                            
          
                          
                            <Columns>
                                <asp:BoundField  HeaderStyle-CssClass="noprint" ItemStyle-CssClass="noprint" DataField="Id"  HeaderText="NumId" SortExpression="Id"    >
                                
<HeaderStyle  Font-Size="0pt" Width="1px"></HeaderStyle>

<ItemStyle  Font-Size="0pt" Height="0px" Width="0px"></ItemStyle>
                                
                                </asp:BoundField>
                                <asp:BoundField DataField="nmUsuario" HeaderText="Nome" SortExpression="nmUsuario" >
                                <ItemStyle Wrap="True" Height="23px" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dsEmail" HeaderText="Email" SortExpression="dsEmail" >
                                <ItemStyle Height="23px" Width="280px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dsCelular" HeaderText="Celular" SortExpression="dsCelular" >
                                <ItemStyle Height="23px" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dsStatus" HeaderText="Status" SortExpression="dsStatus" >
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dsPrioridade" HeaderText="Prioridade" SortExpression="dsPrioridade" >
                              
                                <ItemStyle Height="23px" Width="50px" />
                                </asp:BoundField>
                              
                             <asp:TemplateField>
    <ItemTemplate>
        <asp:Button  ID="btnExcluir" CssClass="botao_cancela" Text="Excluir" runat="server"  CommandName="Deletar" />
                  
    </ItemTemplate>
                                 <ItemStyle Width="70px" Height="30px" HorizontalAlign="Center" />
</asp:TemplateField>
                                 <asp:TemplateField>
    <ItemTemplate>
        <asp:Button  ID="btnEditar" CssClass="botao_editar" Text="Editar" runat="server"  CommandName="Editar" />
                  
    </ItemTemplate>
                                 <ItemStyle Width="70px" Height="30px" HorizontalAlign="Center" />
</asp:TemplateField>
                            </Columns>
                          
                          
                          
                          
                   
                            <SortedDescendingHeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                           
                          
                          
                   
                        </asp:GridView>







                         </div>







                    </div>
                    
                    <br />
                    <br />
                    <div style="margin-left: -400px;  width: 171px; height: 481px;">
                        <div style=" margin-left: 147px; width: 16px;">
                         
                            <table border="0" style="margin-top: 0px;  height: 3px; width: 20px; margin-left: 0px;">
                                <tr>
                                    <td>   
                                        <div  class="wrapper" >
                                            <input id="navigation" type="checkbox" />
                                            <label for="navigation" class="auto-style6">
                                              <img src="/Imagem/menu_burguer.png" style=" width:25px " />
                                            </label>
                                            <nav>
                                                <ul>
                                                
                                                    <li><a href="/Contatos.aspx">Contatos</a> </li>
                                                   
                                                </ul>
                                            </nav>
                                        </div>
                                    </td>
                                   </tr>
                                        </table>
                            
   
       
        
                                        </div></div></div></div></div>

   
        <div></div>
    </form>
</body>
</html>
