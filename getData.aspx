<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="getData.aspx.cs" Inherits="getData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
        .auto-style4 {
        }
        .auto-style6 {
            width: 297px;
        }
        .auto-style7 {
            width: 248px;
        }
        .auto-style16 {
            width: 248px;
            height: 21px;
        }
        .auto-style17 {
            width: 279px;
            height: 21px;
        }
        .auto-style20 {
            width: 248px;
            height: 23px;
        }
        .auto-style21 {
            width: 279px;
            height: 23px;
        }
        .auto-style22 {
    }
        .auto-style23 {
            width: 100px;
            height: 21px;
        }
        .auto-style25 {
            width: 100px;
            height: 23px;
        }
        .auto-style26 {
            width: 553px;
            height: 21px;
        }
        .auto-style28 {
            width: 553px;
            height: 23px;
        }
        .auto-style29 {
            width: 553px;
        }
        .auto-style30 {
            width: 279px;
        }
    .auto-style31 {
        width: 100px;
        height: 25px;
    }
    .auto-style32 {
        height: 25px;
    }
    .auto-style33 {
            width: 279px;
            height: 25px;
        }
    .auto-style34 {
        width: 553px;
        height: 25px;
    }
        .auto-style35 {
            width: 143px;
            height: 21px;
        }
        .auto-style37 {
            width: 143px;
            height: 23px;
        }
        .auto-style38 {
            width: 143px;
        }
        .auto-style39 {
            width: 143px;
            height: 25px;
        }
        .auto-style40 {
            width: 106px;
            height: 21px;
        }
        .auto-style42 {
            width: 106px;
            height: 23px;
        }
        .auto-style43 {
            width: 106px;
        }
        .auto-style44 {
            width: 106px;
            height: 25px;
        }
        .auto-style45 {
            width: 100px;
        }
        .auto-style46 {
            height: 26px;
        }
        .auto-style47 {
            width: 248px;
            height: 26px;
        }
        .auto-style48 {
            width: 143px;
            height: 26px;
        }
        .auto-style49 {
            width: 279px;
            height: 26px;
        }
        .auto-style50 {
            width: 106px;
            height: 26px;
        }
        .auto-style51 {
            width: 553px;
            height: 26px;
        }
        </style>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
              <span class="auto-style3">Get Attendance Record Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>             
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="7">
                                
                                  <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style16"><asp:Label ID="Label2" runat="server" Text="Machine:"></asp:Label>
                              </td>
                              <td class="auto-style35">&nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style6" rowspan="6">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style25"></td>
                              <td class="auto-style20">
                                  <asp:DropDownList ID="ddlMchNo" runat="server" Height="29px" Width="149px" AutoPostBack="True" OnSelectedIndexChanged="ddlMchNo_SelectedIndexChanged">
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style37">
                                  </td>
                              <td class="auto-style21">
                              </td>
                              <td class="auto-style42">
                                  </td>
                              <td class="auto-style28">
                                  <asp:Label ID="lblId" runat="server" Text="Label" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style28">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style45">
                                  </td>
                              <td class="auto-style7">
                                  <asp:UpdateProgress id="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
                                  <asp:Button ID="butSave" runat="server" class="btn btn-primary" ForeColor="White" Height="29px" OnClick="Button3_Click" Text="Save" Width="72px" />
                              </td>
                              <td class="auto-style38">
                                  </td>
                              <td class="auto-style30">
                                  </td>
                              <td class="auto-style43">
                                  </td>
                              <td class="auto-style29">
                                  </td>
                              <td class="auto-style29">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style46">
                                  </td>
                              <td class="auto-style47">
                                  &nbsp;</td>
                              <td class="auto-style48">
                                  </td>
                              <td class="auto-style49">
                                  </td>
                              <td class="auto-style50">
                                  </td>
                              <td class="auto-style51">
                                  </td>
                              <td class="auto-style51">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style31"></td>
                              <td class="auto-style32">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style33">
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style31">&nbsp;</td>
                              <td class="auto-style32" colspan="6">
                                  <asp:Label ID="lblMSG1" runat="server"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22" colspan="8">
                            
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [tblMachine] ORDER BY [id] DESC"></asp:SqlDataSource>
                              </td>
                          </tr>
                          </table>


    </ContentTemplate>
</asp:UpdatePanel>          
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
</asp:Content>


