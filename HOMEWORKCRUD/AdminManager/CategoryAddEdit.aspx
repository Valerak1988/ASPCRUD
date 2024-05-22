<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManager/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryAddEdit.aspx.cs" Inherits="HOMEWORKCRUD.AdminManager.CategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
        <div class="row">
    <div class="col-lg-12">
        <h1 class="page-header">ניהול קטגוריות</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
<div class="row">
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                עריכה/הוספה קטגוריה
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:HiddenField ID="HidCid" runat="server" value="-1"/>
                        <div class="form-group">
                            <label>שם קטגוריה</label>

                            <asp:TextBox ID="TxtCname" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה" />
                        </div>
                        <div class="form-group">
                            <label>תיאור קטגוריה</label>
                            <asp:TextBox ID="TxtCdesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן שם תיאור" />
                        </div>
                        <div class="form-group">
                            <label>שם תמונה</label>
                            <asp:TextBox ID="TxtPicname" CssClass="form-control" runat="server" placeholder="נא הזן שם תמונה" />
                        </div>

                        <asp:button ID="BtnSave" runat="server" class="btn btn-primary" OnClick="BtnSave_Click" Text="שמירה"/>

                    </div>
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooter" runat="server">
</asp:Content>
