<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>    
    <!-- Bootstrap 3.3.2 -->
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <%--<link href="Content/bootstrap-theme.min.css" rel="stylesheet" />--%>
    <link href="css1/lightbox.css" rel="stylesheet" type="text/css" media="screen" />
    <%--<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>    
    <!-- FontAwesome 4.3.0 -->
 <%--   <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />--%>
    <!-- Ionicons 2.0.0 -->
  <%--  <link href="http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css" rel="stylesheet" type="text/css" />    --%>
   <%-- <link href="dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />--%>
    <!-- AdminLTE Skins. Choose a skin from the css/skins 
         folder instead of downloading all of them to reduce the load. -->
    <link href="dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="plugins/iCheck/flat/blue.css" rel="stylesheet" type="text/css" />
    <!-- Morris chart -->
    <link href="plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
    <link href="plugins/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" type="text/css" />
    <!-- Date Picker -->
    <link href="plugins/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />
    <!-- Daterange picker -->
    <link href="plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />
 
    <style type="text/css">
        .user-image {
            height: 40px;
        }
        .style1
        {
            width: 100px;
            height: 66px;
        }
        .style2
        {
            width: 100%;
            height: 151px;
        }
        .style3
        {
        }
        .style4
        {
            width: 191px;
        }
        .style5
        {
            width: 191px;
            height: 33px;
        }
        .style6
        {
            width: 106px;
            height: 33px;
        }
        .style8
        {
            width: 191px;
            height: 30px;
        }
        .style9
        {
            width: 106px;
            height: 30px;
        }
        .style10
        {
            height: 30px;
        }
        .style11
        {
            height: 33px;
        }
    </style>
</head>
<body class="login-page">
    <div class="login-box">
    
      <div class="login-box-body">
       
          <img alt="" class="style1" src="Images/icon.png" /><img src="Images/login.jpg" 
              style="width: 580px; height: 59px" />
          <form id="form1" runat="server">
          <div class="form-group has-feedback">
            &nbsp;<span class="glyphicon glyphicon-envelope form-control-feedback"></span><table 
                  class="style2">
                  <tr>
                      <td class="style4">
                          &nbsp;</td>
                      <td class="style3">
                          <asp:Login ID="Login1" runat="server" BorderColor="#EBEBEB" 
                              DisplayRememberMe="False" Height="124px" onauthenticate="Login1_Authenticate" 
                              Width="347px">
                          </asp:Login>
                      </td>
                      <td>
                          &nbsp;</td>
                  </tr>
                 
              </table>
          </div>
          <div class="form-group has-feedback">
            &nbsp;<span class="glyphicon glyphicon-lock form-control-feedback"></span></div>
          <div class="row">
              <!-- /.col -->
          </div>
          </form>

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <!-- jQuery 2.1.3 -->
    <script src="../../plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="../../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="../../plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
  </body>
</html>
