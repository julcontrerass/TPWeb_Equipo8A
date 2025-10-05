<%@ Page Title="Éxito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Promocioncomercio.Exito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div style="text-align: center; margin-top: 50px;">
            <h2 id="title" style="color: #0066FF;">¡Felicitaciones!</h2>
            <p style="font-size: 18px; margin: 30px 0;">Tu participacion ha sido registrada exitosamente.</p>
            <p style="font-size: 16px; color: #666;">¡Gracias por participar en nuestra promocion!</p>
            <br />
            <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" BackColor="#0066FF" ForeColor="White" Width="200px" OnClick="btnVolver_Click" />
        </div>
    </main>
</asp:Content>
