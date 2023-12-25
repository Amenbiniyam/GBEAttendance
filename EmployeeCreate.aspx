<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="EmployeeCreate.aspx.cs" Inherits="EmployeeCreate" %>

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
        .auto-style10 {
            width: 248px;
            height: 5px;
        }
        .auto-style11 {
            width: 380px;
            height: 5px;
        }
        .auto-style13 {
            width: 187px;
        }
        .auto-style16 {
            width: 248px;
            height: 21px;
        }
        .auto-style17 {
            width: 380px;
            height: 21px;
        }
        .auto-style20 {
            width: 248px;
            height: 23px;
        }
        .auto-style21 {
            width: 380px;
            height: 23px;
        }
        .auto-style22 {
            width: 100px;
        }
        .auto-style23 {
            width: 100px;
            height: 21px;
        }
        .auto-style24 {
            width: 100px;
            height: 5px;
        }
        .auto-style25 {
            width: 100px;
            height: 23px;
        }
        .auto-style26 {
            width: 553px;
            height: 21px;
        }
        .auto-style27 {
            width: 553px;
            height: 5px;
        }
        .auto-style28 {
            width: 553px;
            height: 23px;
        }
        .auto-style29 {
            width: 553px;
        }
        .auto-style30 {
            width: 380px;
        }
    </style>
  
     <script type="text/javascript">




         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=imgEmp.ClientID%>').prop('src', e.target.result)
                        .width(110)
                        .height(110);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <triggers>
                             
                                    <asp:postbacktrigger controlid="Button3"  />
                                   </triggers>
                                   
                                  
            <ContentTemplate> 
    <section class="content-header">
         <h1>
              <span class="auto-style3">Create Employee Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style13" rowspan="11">
                                  <asp:Panel ID="root" runat="server" Height="301px" Width="148px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="#CC0000" />
                                      </asp:TreeView>
                                  </asp:Panel>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                                
                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                      TabIndex="1" DisplayMode="SingleParagraph" />
                                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style16"><asp:Label ID="Label2" runat="server" Text="EmpId:"></asp:Label>
                              </td>
                              <td class="auto-style17">
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                  </td>
                              <td class="auto-style17">
                                  <asp:Label ID="Label14" runat="server" Text="Department Name:"></asp:Label>
                              </td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style6" rowspan="5">
                                  <asp:Image ID="imgEmp" runat="server" Height="108px" style="text-align: center" Width="106px" />
                               <%--   <asp:FileUpload ID="FileUpload1" runat="server" Width="173px"  onchange="ShowImagePreview(this);"/>--%>
                                 
                                
                                    
                                      <asp:fileupload id="FileUpload1" runat="server" onclick="Button1_Click" onchange="ShowImagePreview(this);" />
                                      <br />
                                       
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style24">&nbsp;</td>
                              <td class="auto-style10">
                                  <asp:TextBox ID="txtEmpId" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style11">
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                      ControlToValidate="txtEmpId" ErrorMessage="Please Enter Only Numbers" 
                                      ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtEmpId" Display="None" ErrorMessage="* EmpId Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style11">
                                  <asp:TextBox ID="txtDepName" runat="server" Height="25px" Width="201px" 
                                      Enabled="False"></asp:TextBox>
                              </td>
                              <td class="auto-style27">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style25">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  <asp:Label ID="Label5" runat="server" Text="First Name:"></asp:Label>
                              </td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  <asp:Label ID="Label4" runat="server" Text="Middle Name:"></asp:Label>
                              </td>
                              <td class="auto-style28">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtFName" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style30">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                      ControlToValidate="txtFName" Display="None" ErrorMessage="* First Name Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style30">
                                  <asp:TextBox ID="txtMiddleName" runat="server" Height="25px" Width="201px"></asp:TextBox>
                              </td>
                              <td class="auto-style29">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMiddleName" Display="None" ErrorMessage="Enter a valid middle name" ForeColor="Red" ValidationExpression="^[a-zA-Z'.\s]{1,50}"></asp:RegularExpressionValidator>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style7">
                                  <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
                              </td>
                              <td class="auto-style30">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFName" Display="None" ErrorMessage="Enter a valid name" ForeColor="Red" ValidationExpression="^[a-zA-Z'.\s]{1,50}"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style30">
                                  <asp:Label ID="Label6" runat="server" Text="Gender:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtLastName" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style30">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" Display="None" ErrorMessage="Enter a Valid Last Name" ForeColor="Red" ValidationExpression="^[a-zA-Z'.\s]{1,50}"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style30">
                                  <asp:RadioButtonList ID="radGender" runat="server" RepeatDirection="Horizontal" Width="152px">
                                      <asp:ListItem Selected="True">Male</asp:ListItem>
                                      <asp:ListItem>Female</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                              <td class="auto-style6">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                      ControlToValidate="txtSalary" Display="None" ErrorMessage="*Salary Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="rgx" runat="server" 
                                      ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Only Decimals" 
                                      ForeColor="Red" 
                                      ValidationExpression="^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$"></asp:RegularExpressionValidator>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style7">
                                  <asp:Label ID="Label7" runat="server" Text="Date Of Birth:"></asp:Label>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:Label ID="Label8" runat="server" Text="Position:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  <asp:Label ID="Label15" runat="server" Text="Salary:"></asp:Label>
                              </td>
                              <td class="auto-style6">
                                  <asp:Label ID="Label16" runat="server" Text="Finger Print Required"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtDOB" runat="server" Height="25px" Width="177px"></asp:TextBox>
                                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <cc1:CalendarExtender  ID="CalendarExtender1" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtDOB" PopupButtonID="ImageButton1"/>
                              </td>
                              <td class="auto-style30">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                      ControlToValidate="txtDOB" Display="None" ErrorMessage="* DOB Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style30">
                                  <asp:DropDownList ID="ddlPosition" runat="server" Height="25px" Width="204px">
                                      <asp:ListItem>--Select Department--</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style29">
                                  <asp:TextBox ID="txtSalary" runat="server" Height="25px" Width="160px"></asp:TextBox>
                              </td>
                              <td class="auto-style6">
                                  <asp:DropDownList ID="ddlFP" runat="server">
                                      <asp:ListItem>YES</asp:ListItem>
                                      <asp:ListItem>NO</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style7">
                                  <asp:Label ID="Label9" runat="server" Text="Telephone:"></asp:Label>
                              </td>
                              <td class="auto-style30">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                      ControlToValidate="txtDOB" Display="None" 
                                      ErrorMessage="*Please Insert Valid DOB(dd-mmm-yyyy)" ForeColor="Red" 
                                      ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style30">
                                  <asp:Label ID="Label11" runat="server" Text="Mobile Number:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  <asp:Label ID="Label10" runat="server" Text="Address:"></asp:Label>
                              </td>
                              <td class="auto-style6">
                                  <asp:Label ID="Label12" runat="server" Text="Hired Date:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtTele" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:TextBox ID="txtMobNo" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style29">
                                  <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Height="25px"></asp:TextBox>
                              </td>
                              <td class="auto-style6">
                                  <asp:TextBox ID="txtHiredDate" runat="server" Height="25px" Width="147px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtHiredDate" PopupButtonID="ImageButton2"/>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                      ControlToValidate="txtHiredDate" Display="None" 
                                      ErrorMessage="*Please Insert Valid Hire Date(dd-mmm-yyyy)" ForeColor="Red" 
                                      ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$"></asp:RegularExpressionValidator>
                    
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:Label ID="Label13" runat="server" Text="Employment Type:"></asp:Label>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:Label ID="lblEndDAte" runat="server" Text="End Date:" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  <asp:Label ID="Label17" runat="server" Text="Employee Status:"></asp:Label>
                              </td>
                              <td class="auto-style6">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                      ControlToValidate="txtHiredDate" Display="None" 
                                      ErrorMessage="* Hire Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:DropDownList ID="ddlEmploymentType" runat="server" Height="33px" Width="177px" AutoPostBack="True" OnSelectedIndexChanged="ddlEmploymentType_SelectedIndexChanged">
                                      <asp:ListItem>Permanent</asp:ListItem>
                                      <asp:ListItem>Contract</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:TextBox ID="txtEndDate" runat="server" Height="25px" Width="177px" 
                                      Visible="False" Enabled="False"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False" Visible="False"  />
                                  <cc1:CalendarExtender ID="CalendarExtender3" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtEndDate" PopupButtonID="ImageButton3"/>
                              </td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlEmpSta" runat="server">
                                      <asp:ListItem>A</asp:ListItem>
                                      <asp:ListItem>T</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style6">
                                  &nbsp;</td>
                          </tr>
                          </table>
                  
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                  &nbsp;<asp:Button  class = "btn btn-primary" ID="Button3" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                       &nbsp;<asp:Button  class = "btn btn-primary" ID="butClear" runat="server" 
                          Height="29px" Text="Clear" Width="72px" ForeColor="White" onclick="butClear_Click" CausesValidation="False" 
                         />
                      <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" 
                          CausesValidation="False">Back to List</asp:LinkButton>
                              </div>
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
        
        </ContentTemplate>
     <%--   <Triggers>
       <asp:PostBackTrigger ControlID="FileUpload1" />
</Triggers>--%>
         
        </asp:UpdatePanel>
</asp:Content>


