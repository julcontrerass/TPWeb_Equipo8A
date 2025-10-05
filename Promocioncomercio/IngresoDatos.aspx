<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngresoDatos.aspx.cs" Inherits="Promocioncomercio.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Ingresa tus datos</h2>
        <div style="margin-bottom: 15px;">
            <p>DNI:</p>
            <asp:TextBox ID="tbxDNI" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server"
                ControlToValidate="tbxDNI"
                ErrorMessage="El DNI es requerido"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDNI" runat="server"
                ControlToValidate="tbxDNI"
                ValidationExpression="^\d+$"
                ErrorMessage="El DNI debe contener solo números"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>NOMBRE:</p>
            <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                ControlToValidate="tbxNombre"
                ErrorMessage="El nombre es requerido"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>APELLIDO:</p>
            <asp:TextBox ID="tbxApellido" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                ControlToValidate="tbxApellido"
                ErrorMessage="El apellido es requerido"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>EMAIL:</p>
            <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="tbxEmail"
                ErrorMessage="El email es requerido"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ControlToValidate="tbxEmail"
                ValidationExpression="^[\w\.-]+@[\w\.-]+\.com$"
                ErrorMessage="El email debe contener @ y terminar en .com"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>DIRECCION:</p>
            <asp:TextBox ID="tbxDireccion" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                ControlToValidate="tbxDireccion"
                ErrorMessage="La dirección es requerida"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>CIUDAD:</p>
            <asp:TextBox ID="tbxCiudad" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvCiudad" runat="server"
                ControlToValidate="tbxCiudad"
                ErrorMessage="La ciudad es requerida"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <p>CP:</p>
            <asp:TextBox ID="tbxCP" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvCP" runat="server"
                ControlToValidate="tbxCP"
                ErrorMessage="El CP es requerido"
                ForeColor="Red"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 15px;">
            <asp:CheckBox ID="ckbTersYCond" runat="server" Text="Acepto los terminos y condiciones" />
            <br />
            <asp:CustomValidator ID="cvTerminos" runat="server"
                ErrorMessage="Debe aceptar los términos y condiciones"
                ForeColor="Red"
                Display="Dynamic"
                OnServerValidate="cvTerminos_ServerValidate">
            </asp:CustomValidator>
        </div>

        <p>
            <asp:Button ID="btnParticipar" runat="server" BackColor="#0066FF" ForeColor="White" Text="Participar!" Width="147px" OnClick="btnParticipar_Click" />
        </p>
    </main>
</asp:Content>
