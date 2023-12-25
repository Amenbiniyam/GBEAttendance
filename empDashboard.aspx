<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="empDashboard.aspx.cs" Inherits="empDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">



    <style type="text/css">
        .style1
        {
            height: 41px;
        }
        .style2
        {
            height: 39px;
        }
        .style4
        {
            height: 40px;
            text-align: left;
        }
        .style5
        {
            height: 41px;
            text-align: left;
        }
        .style6
        {
            height: 39px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <span class="auto-style3">Dashboard</span>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
              <asp:Label ID="lblMSG" runat="server" ForeColor="#CC0000"></asp:Label>
           </h1>
        
        
        </section>
    <section class="content">

       <div class="row">
            <div class="col-lg-3 col-xs-4" >
              <!-- small box -->
              <div class="small-box bg-aqua">
                  <h2 class="small-box-footer">Leave as of Today </h2>              
                <div class="inner" >
                 
                    <table class="nav-justified">
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Leave Balance:-[  "></asp:Label>
                                <asp:Label ID="lblBal" runat="server" Font-Size="14pt"></asp:Label>
                                 <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text=" ]"></asp:Label>
                            </td>
                            <td class="style2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Total Leave Taken:- "></asp:Label>
                                <asp:Label ID="lblTaken" runat="server" Font-Size="14pt"></asp:Label>
                            </td>
                            <td class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Leave Entitlement:- "></asp:Label>
                                <asp:Label ID="lblEnit" runat="server" Font-Size="14pt"></asp:Label>
                            </td>
                            <td class="user-image">
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Una. Leave Request:- "></asp:Label>
                                <asp:Label ID="lblUNa" runat="server" Font-Size="14pt"></asp:Label>
                            </td>
                            <td class="user-image">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>


                 
                  
                </div>
              <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="/AttendanceAndLeave/EmpLeaveBalance.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
           
            <div class="col-lg-3 col-xs-4">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <h2 class="small-box-footer" style="font-size: x-large">Attendance Report The Last 30 days </h2>    
                  
                <div class="inner">
                  
                    <table class="nav-justified">
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="On Time:- "></asp:Label>
                                <asp:Label ID="lblONtime" runat="server" Font-Size="14pt"></asp:Label>
                                <asp:Label ID="Label10" runat="server" Text=" Punches"></asp:Label>
                            </td>
                            <td class="style2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Late:- "></asp:Label>
                                <asp:Label ID="lblLate" runat="server" Font-Size="14pt"></asp:Label>
                                <asp:Label ID="Label11" runat="server" Text=" Punches"></asp:Label>
                            </td>
                            <td class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="14pt" 
                                    Text="Unjustified Absences:- "></asp:Label>
                                <asp:Label ID="lblUNJ" runat="server" Font-Size="14pt"></asp:Label>
                                <asp:Label ID="Label12" runat="server" Text=" Punches"></asp:Label>
                            </td>
                            <td class="user-image">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="/AttendanceAndLeave/EmpAttReport.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-4">
              <!-- small box -->
              
              <div class="small-box bg-red">
              <h2 class="small-box-footer">Expirable Leave After&nbsp;&nbsp; 30 Days</h2> 

                <div class="inner">
                  <h3>
<asp:Label ID="lblEXP" runat="server" Text=""></asp:Label>
                 
                 
                   </h3>
                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="/AttendanceAndLeave/EmpLeaveBalance.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->

            <div class="col-lg-3 col-xs-4">
             <div class="small-box bg-red">
              <h2 class="small-box-footer">Scheduled Leave due to COVID 19 will expire on Sep. 30, 2020</h2>
                <div class="inner">
                 
                      <table class="nav-justified">
                          <tr>
                              <td>
                         
                                 
                              </td>
                          </tr>
                          <tr>
                              <td>
                                 
                                  &nbsp;&nbsp;</td>
                          </tr>
                          <tr>
                              <td>
                             
                              </td>
                          </tr>
                      </table>
                    
                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
               
              </div>
              </div>

          </div>

    </section>
    </ContentTemplate>
    </asp:UpdatePanel>


<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js" type="text/javascript"></script>

<script src="visualize.js" type="text/javascript"></script>
<script>

    $(document).ready(function () {
        $('.pie').visualize({
            width: 300,
            height: 300,
            type: 'pie', // pie or chart
            legend: true
        });
    });
</script>
</asp:Content>