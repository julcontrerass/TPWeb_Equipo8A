<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoDatos.aspx.cs" Inherits="Promocioncomercio.About" %>

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
        .success-message {
            color: green;
            font-size: 12px;
            display: none;
            margin-top: 3px;
        }
        .form-row {
            display: flex;
            gap: 15px;
            margin-bottom: 20px;
        }
        .form-group {
            flex: 1;
            display: flex;
            flex-direction: column;
        }
        .form-group.full-width {
            flex: 100%;
        }
        .form-group label {
            margin-bottom: 5px;
            font-weight: normal;
        }
        .form-group input[type="text"] {
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 100%;
            box-sizing: border-box;
        }
        .btn-participar {
            background-color: #0066FF;
            color: white;
            padding: 10px 30px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-participar:hover {
            background-color: #0052cc;
        }
    </style>

    <main aria-labelledby="title">
        <h2 id="title">Ingresá tus datos</h2>

        <div class="form-row">
            <div class="form-group full-width">
                <label>DNI</label>
                <asp:TextBox ID="tbxDNI" runat="server" AutoPostBack="true" OnTextChanged="tbxDNI_TextChanged"></asp:TextBox>
                <span id="errorDNI" class="error-message"></span>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox>
                <span id="errorNombre" class="error-message"></span>
                <span id="successNombre" class="success-message">Ok</span>
            </div>
            <div class="form-group">
                <label>Apellido</label>
                <asp:TextBox ID="tbxApellido" runat="server"></asp:TextBox>
                <span id="errorApellido" class="error-message"></span>
            </div>
            <div class="form-group">
                <label>Email</label>
                <asp:TextBox ID="tbxEmail" runat="server" placeholder="email@email.com"></asp:TextBox>
                <span id="errorEmail" class="error-message"></span>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label>Dirección</label>
                <asp:TextBox ID="tbxDireccion" runat="server"></asp:TextBox>
                <span id="errorDireccion" class="error-message"></span>
            </div>
            <div class="form-group">
                <label>Ciudad</label>
                <asp:TextBox ID="tbxCiudad" runat="server"></asp:TextBox>
                <span id="errorCiudad" class="error-message"></span>
            </div>
            <div class="form-group">
                <label>CP</label>
                <asp:TextBox ID="tbxCP" runat="server"></asp:TextBox>
                <span id="errorCP" class="error-message"></span>
            </div>
        </div>

        <div style="margin-bottom: 20px;">
            <asp:CheckBox ID="ckbTersYCond" runat="server" Text=" Acepto los términos y condiciones." />
            <br />
            <span id="errorTerminos" class="error-message"></span>
        </div>

        <div>
            <asp:Button ID="btnParticipar" runat="server" CssClass="btn-participar" Text="Participar!" OnClick="btnParticipar_Click" OnClientClick="return validarFormulario();" />
        </div>
    </main>

    <script type="text/javascript">
        function validarFormulario() {
            var esValido = true;

            // DNI
            var dni = document.getElementById('<%= tbxDNI.ClientID %>');
            var errorDNI = document.getElementById('errorDNI');
            if (dni.value.trim() === '') {
                dni.className = 'input-error';
                errorDNI.textContent = 'El DNI es requerido';
                errorDNI.style.display = 'block';
                esValido = false;
            } else if (!/^\d+$/.test(dni.value)) {
                dni.className = 'input-error';
                errorDNI.textContent = 'El DNI debe contener solo números';
                errorDNI.style.display = 'block';
                esValido = false;
            } else {
                dni.className = 'input-valid';
                errorDNI.style.display = 'none';
            }

            // Nombre
            var nombre = document.getElementById('<%= tbxNombre.ClientID %>');
            var errorNombre = document.getElementById('errorNombre');
            var successNombre = document.getElementById('successNombre');
            if (nombre.value.trim() === '') {
                nombre.className = 'input-error';
                errorNombre.textContent = 'El nombre es requerido';
                errorNombre.style.display = 'block';
                successNombre.style.display = 'none';
                esValido = false;
            } else {
                nombre.className = 'input-valid';
                errorNombre.style.display = 'none';
                successNombre.style.display = 'block';
            }

            // Apellido
            var apellido = document.getElementById('<%= tbxApellido.ClientID %>');
            var errorApellido = document.getElementById('errorApellido');
            if (apellido.value.trim() === '') {
                apellido.className = 'input-error';
                errorApellido.textContent = 'El apellido es requerido';
                errorApellido.style.display = 'block';
                esValido = false;
            } else {
                apellido.className = 'input-valid';
                errorApellido.style.display = 'none';
            }

            // Email
            var email = document.getElementById('<%= tbxEmail.ClientID %>');
            var errorEmail = document.getElementById('errorEmail');
            if (email.value.trim() === '') {
                email.className = 'input-error';
                errorEmail.textContent = 'El email es requerido';
                errorEmail.style.display = 'block';
                esValido = false;
            } else if (!/^[\w\.-]+@[\w\.-]+\.com$/.test(email.value)) {
                email.className = 'input-error';
                errorEmail.textContent = 'El email debe contener @ y terminar en .com';
                errorEmail.style.display = 'block';
                esValido = false;
            } else {
                email.className = 'input-valid';
                errorEmail.style.display = 'none';
            }

            // Dirección
            var direccion = document.getElementById('<%= tbxDireccion.ClientID %>');
            var errorDireccion = document.getElementById('errorDireccion');
            if (direccion.value.trim() === '') {
                direccion.className = 'input-error';
                errorDireccion.textContent = 'La dirección es requerida';
                errorDireccion.style.display = 'block';
                esValido = false;
            } else {
                direccion.className = 'input-valid';
                errorDireccion.style.display = 'none';
            }

            // Ciudad
            var ciudad = document.getElementById('<%= tbxCiudad.ClientID %>');
            var errorCiudad = document.getElementById('errorCiudad');
            if (ciudad.value.trim() === '') {
                ciudad.className = 'input-error';
                errorCiudad.textContent = 'La ciudad es requerida';
                errorCiudad.style.display = 'block';
                esValido = false;
            } else {
                ciudad.className = 'input-valid';
                errorCiudad.style.display = 'none';
            }

            // CP
            var cp = document.getElementById('<%= tbxCP.ClientID %>');
            var errorCP = document.getElementById('errorCP');
            if (cp.value.trim() === '') {
                cp.className = 'input-error';
                errorCP.textContent = 'El CP es requerido';
                errorCP.style.display = 'block';
                esValido = false;
            } else {
                cp.className = 'input-valid';
                errorCP.style.display = 'none';
            }

            // Términos y condiciones
            var terminos = document.getElementById('<%= ckbTersYCond.ClientID %>');
            var errorTerminos = document.getElementById('errorTerminos');
            if (!terminos.checked) {
                errorTerminos.textContent = 'Debe aceptar los términos y condiciones';
                errorTerminos.style.display = 'block';
                esValido = false;
            } else {
                errorTerminos.style.display = 'none';
            }

            return esValido;
        }
    </script>
</asp:Content>
