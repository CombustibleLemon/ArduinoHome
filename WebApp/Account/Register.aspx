<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Account.Register" %>

<asp:Content runat="server" ContentPlaceHolderID="PageInfo">
    <h2>Use the form below to create a new account.</h2>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <div class="form-horizontal">
                        <p class="message-info">
                            Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                        </p>

                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>

                        <fieldset>
                            <legend>Registration Form</legend>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-lg-2 control-label">User name</asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" required />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-lg-2 control-label">Email address</asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" type="email" required />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-lg-2 control-label">Password</asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" type="password" required />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <br />
                                    <asp:Button runat="server" CommandName="MoveNext" Text="Register" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
