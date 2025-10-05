<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="seleccionarProducto.aspx.cs" Inherits="Promocioncomercio.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .img-producto {
            width: 100%;
            max-height: 450px; 
            object-fit: cover; 
            border-radius: 10px; 
        }
    </style>

   <h2 id="title">Elegí el producto!</h2>
    <div class="row row-cols-1 row-cols-md-2 g-4">
        <%
        foreach (dominio.Producto producto in ListadoProductos)
        {
    %>
    <div class="col">
        <div class="card">

           
            <div id="carousel<%: producto.Id %>" class="carousel slide" data-bs-ride="false">
                <div class="carousel-inner">
                    <%
                        bool isFirstImage = true;
                        foreach (dominio.Imagen imagen in producto.imagenes)
                        {
                    %>
                    <div class="carousel-item <%= isFirstImage ? "active" : "" %>">
                        <img src="<%: imagen.URL %>" class="img-producto" alt="imagen Producto">
                    </div>
                    <%
                            isFirstImage = false;
                        }
                    %>
                </div>

              
                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%: producto.Id %>" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Anterior</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%: producto.Id %>" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Siguiente</span>
                </button>
            </div>

            
            <div class="card-body">
                <h5 class="card-title"><%: producto.Nombre %></h5>
                <p class="card-text"><%: producto.Descripcion %></p>
                <button type="button" class="btn btn-primary">Elegir</button>
            </div>

        </div>
    </div>
    <%
        }
    %>
    </div>
    
</asp:Content>
