<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManager/BackAdmin.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="HOMEWORKCRUD.AdminManager.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/plugins/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">ניהול מוצרים</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    מאגר מוצרים במערכת
       
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover" id="MainTbl">
                            <thead>
                                <tr>
                                    <th>קוד מוצר</th>
                                    <th>שם מוצר</th>
                                    <th>מחיר</th>
                                    <th>על המוצר</th>
                                    <th>תמונה ראשית</th>
                                    <th>מס קטגוריה</th>
                                    <th>ניהול</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptProd" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%#Eval("Pid") %></td>
                                            <td><%#Eval("Pname") %></td>
                                            <td><%#Eval("Price") %></td>
                                            <td><%#Eval("Pdesc") %></td>
                                            <td class="center">
                                                <img src="/uploads/product/<%#Eval("Picname") %>" width="30" /></td>
                                            <td><%#Eval("Cid") %></td>
                                            <td class="center"><a href="ProdAddEdit.aspx?Pid=<%#Eval("Pid") %>">ערוך <span class="fa fa-pencil"></span></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
    <!-- DataTables JavaScript -->
    <script src="js/jquery/jquery.dataTables.min.js"></script>
    <script src="js/bootstrap/dataTables.bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#MainTbl').dataTable({
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.0.7/i18n/he.json',
                }
            });
        });
</script>
</asp:Content>
