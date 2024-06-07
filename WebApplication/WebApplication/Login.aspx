<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
  <div>
            <section class="vh-100">
                <div class="container py-5 h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col col-xl-10">
                            <div class="card" style="border-radius: 1rem;">
                                <div class="row g-0">
                                    <div class="col-md-6 col-lg-5 d-none d-md-block">
                                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"
                                            alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                                    </div>
                                    <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                        <div class="card-body p-4 p-lg-5 text-black">

                                            <div>

                                                <div class="d-flex align-items-center mb-3 pb-1">
                                                    <span class="h1 fw-bold mb-0">Smart Brain</span>
                                                </div>

                                                <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Inicia Sesion</h5>

                                                <div class="form-outline mb-4">
                                                    <asp:TextBox ID="TextBoxUser" placeholder="Email" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="form-outline mb-4">
                                                    <asp:TextBox ID="TextBoxPassword" placeholder="Password" CssClass="form-control form-control-lg" TextMode="Password" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="pt-1 mb-4">
                                                    <asp:Button ID="Button1"  CssClass="btn btn-lg btn-block btn-outline-warning" Width="100%" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                                                </div>

                                                <p class="mb-5 pb-lg-2" style="color: #393f81;">
                                                    No tienes una Cuenta? <a href="Register.aspx"
                                                        style="color: #393f81;">Registrate Aqui!</a>
                                                </p>
                                                <a href="#" class="small text-muted">Terms of use.</a>
                                                <a href="#" class="small text-muted">Privacy policy</a>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
