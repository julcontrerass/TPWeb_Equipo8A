<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="seleccionarProducto.aspx.cs" Inherits="Promocioncomercio.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .img-producto {
            width: 100%;
            max-height: 450px; 
            object-fit: contain; 
            border-radius: 10px; 
        }

        .card-shadow{
            box-shadow: 0 0 10px 1px rgba(0,0,0,0.4);
        }
    
        .text-align-center{
            text-align: center;
        }

        .btn-center{
            align-self:center;
        }

        .card-body-flex{
            display: flex;
            flex-direction: column;
            align-items: center;
            
        }

        </style>

   <h2 id="title" class="text-align-center">Elegí el producto!</h2>
    <div class="row row-cols-1 row-cols-md-2 g-4 mt-4">
        <%
        foreach (dominio.Producto producto in ListadoProductos)
        {
    %>
    <div class="col">
        <div class="card card-shadow h-100">

           
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

            
            <div class="card-body card-body-flex">
                <h5 class="card-title"><%: producto.Nombre %></h5>
                <p class="card-text"><%: producto.Descripcion %></p>
                <button type="button" class="btn btn-primary btn-center">Elegir</button>
            </div>

        </div>
    </div>
    <%
        }
    %>
    </div>
    
</asp:Content>
