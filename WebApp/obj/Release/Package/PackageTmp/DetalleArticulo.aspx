﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebApp.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .CorregirImagen {
            width: 400px;
            height: 400px;
            object-fit: contain;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="Server"></asp:ScriptManager>

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código </label>
                <asp:TextBox ID="txtCodigo" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Complete el Campo" ControlToValidate="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre </label>
                <asp:TextBox ID="txtNombre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Complete el Campo" ControlToValidate="txtNombre" runat="server" />

            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion </label>
                <asp:TextBox ID="txtDescripcion" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Complete el Campo" ControlToValidate="txtDescripcion" runat="server" />

            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio </label>
                <asp:TextBox ID="txtPrecio" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Complete el Campo" ControlToValidate="txtPrecio" runat="server" />

            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoria</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca</label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="mb-3" style="visibility: hidden">
                        <label for="txtImage" class="form-label">Imagen </label>
                        <asp:TextBox ID="txtImage" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImage_TextChanged" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex align-items-center justify-content-center">
                        <asp:Image ID="imgArticulo" CssClass="img-fluid mb-3 CorregirImagen" ImageUrl="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

