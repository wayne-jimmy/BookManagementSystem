<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BMS.Web.Views.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2 class="mt-3">
            Create Book
        </h2>
        <hr />
        <asp:HiddenField ID="hdBookId" runat="server"  Value="0" />
        <asp:HiddenField ID="hdMessageType" runat="server" Value="0" />
        <asp:HiddenField ID="hdMessage" runat="server" Value="" />
        <div class="row mb-3">
            <div class="col-4">
                <div class="form-group">
                    <label for="MainContent_txtTitle" class="form-label">Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" required />
                    <asp:RequiredFieldValidator ID="rvTitle" runat="server" CssClass="help-block" ControlToValidate="txtTitle">
                        The title field is required.
                    </asp:RequiredFieldValidator>    
                </div>
                
                
            </div>
             <div class="col-4">
                <label for="MainContent_txtAuthor" class="form-label">Author</label>
                <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control" required/>
                 <asp:RequiredFieldValidator ID="rvAuthor" runat="server" CssClass="help-block" ControlToValidate="txtAuthor">
                        The author field is required.
                 </asp:RequiredFieldValidator>
            </div>
             <div class="col">
                <label for="MainContent_txtGenre" class="form-label">Genre</label>
                <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control" required/>
                <asp:RequiredFieldValidator ID="rvGenre" runat="server" CssClass="help-block" ControlToValidate="txtGenre">
                        The genre field is required.
                 </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-4">
                <label for="MainContent_txtYear" class="form-label">Publication Year</label>
                <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" TextMode="Number" required/>
               <asp:RequiredFieldValidator ID="rvYear" runat="server" CssClass="help-block" ControlToValidate="txtYear">
                        The publication year field is required.
                 </asp:RequiredFieldValidator>
                
            </div>
             <div class="col-4">
                <label for="MainContent_txtPrice" class="form-label">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rvPrice" runat="server" CssClass="help-block" ControlToValidate="txtPrice">
                        The price field is required.
                 </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-12 text-center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                <asp:HyperLink ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" NavigateUrl="~/Views/BookList.aspx" />
            </div>
        </div>
        <script>
            

            $(document).ready(function() {
                var messageType = '<%= hdMessageType.ClientID %>';
                var message = '<%= hdMessage.ClientID %>';
                if ($("#" + messageType).val() == "1") {
                    Swal.fire({
                        icon: 'success',
                        title: $("#" + message).val()
                    });
                } else if ($("#" + message).val() == "2") {
                    Swal.fire({
                        icon: 'error',
                        title: $("#" + message).val()
                    });
                }
            });
        </script>
        <script>
            function extendedValidatorUpdateDisplay(obj) {
                // Appelle la méthode originale
                if (typeof originalValidatorUpdateDisplay === "function") {
                    originalValidatorUpdateDisplay(obj);
                }
                // Récupère l'état du control (valide ou invalide) 
                // et ajoute ou enlève la classe has-error
                var control = document.getElementById(obj.controltovalidate);
                if (control) {
                    var isValid = true;
                    for (var i = 0; i < control.Validators.length; i += 1) {
                        if (!control.Validators[i].isvalid) {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid) {
                        $(control).closest(".form-group").removeClass("has-error");
                    } else {
                        $(control).closest(".form-group").addClass("has-error");
                    }
                }
            }
            // Remplace la méthode ValidatorUpdateDisplay
            var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
            window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
        </script>
</asp:Content>
