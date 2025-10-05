<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Promocioncomercio._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .input-error {
            border: 2px solid red !important;
        }
        .input-valid {
            border: 2px solid green !important;
        }
        .error-message {
            color: red;
            font-size: 12px;
            display: none;
            margin-top: 3px;
        }
        .btn-siguiente {
            background-color: #0066FF;
            color: white;
            padding: 10px 30px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-siguiente:hover {
            background-color: #0052cc;
        }

        /* Toast */
        .toast-notification {
            position: fixed;
            top: 20px;
            right: 20px;
            min-width: 300px;
            max-width: 500px;
            padding: 16px 20px;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            display: none;
            z-index: 9999;
            animation: slideIn 0.3s ease-out;
            font-size: 14px;
            line-height: 1.5;
        }

        .toast-notification.show { display: block; }
        .toast-notification.success { background-color: #4caf50; color: white; }
        .toast-notification.error { background-color: #f44336; color: white; }

        @keyframes slideIn { from { transform: translateX(400px); opacity: 0; } to { transform: translateX(0); opacity: 1; } }
        @keyframes slideOut { from { transform: translateX(0); opacity: 1; } to { transform: translateX(400px); opacity: 0; } }
        .toast-notification.hiding { animation: slideOut 0.3s ease-out; }
    </style>

    <!-- Contenedor para toast -->
    <div id="toast" class="toast-notification"></div>

    <main>
        <p>INGRESÁ EL CÓDIGO DEL VOUCHER</p>

        <div class="form-group full-width">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <span id="errorCodigo" class="error-message"></span>
        </div>

        <br />

        <asp:Button ID="Button1" runat="server" Text="SIGUIENTE" CssClass="btn-siguiente"
            OnClick="Button1_Click" OnClientClick="return validarCodigo();" />
    </main>

    <script type="text/javascript">
        function mostrarToast(mensaje, tipo) {
            var toast = document.getElementById('toast');
            toast.textContent = mensaje;
            toast.className = 'toast-notification ' + tipo + ' show';

            setTimeout(function () {
                toast.classList.add('hiding');
                setTimeout(function () {
                    toast.classList.remove('show', 'hiding', tipo);
                }, 300);
            }, 4000);
        }

        function validarCodigo() {
            var codigo = document.getElementById('<%= TextBox1.ClientID %>');
            var errorCodigo = document.getElementById('errorCodigo');
            var esValido = true;

            if (codigo.value.trim() === '') {
                codigo.className = 'input-error';
                errorCodigo.textContent = 'Debe ingresar un código';
                errorCodigo.style.display = 'block';
                mostrarToast('Debe ingresar un código', 'error');
                esValido = false;
            } else {
                codigo.className = 'input-valid';
                errorCodigo.style.display = 'none';
            }

            return esValido;
        }
    </script>

</asp:Content>
