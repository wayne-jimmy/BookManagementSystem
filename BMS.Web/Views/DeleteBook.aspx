<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="BMS.Web.Views.DeleteBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2 class="mt-3">
            Delete Book
        </h2>
        <hr />
        <asp:HiddenField ID="hdBookId" runat="server"  Value="0" />
        <div class="row g-3 align-items-center">
          <div class="col-3">
            <label class="col-form-label fw-bold">Title</label>
          </div>
          <div class="col">
            <asp:Label ID="lblTitle" runat="server" />
          </div>
        </div>
        <div class="row g-3 align-items-center">
          <div class="col-3">
            <label class="col-form-label fw-bold">Author</label>
          </div>
          <div class="col">
            <asp:Label ID="lblAuthor" runat="server" />
          </div>
        </div>
        <div class="row g-3 align-items-center">
          <div class="col-3">
            <label class="col-form-label fw-bold">Genre</label>
          </div>
          <div class="col">
            <asp:Label ID="lblGenre" runat="server" />
          </div>
        </div>
         <div class="row g-3 align-items-center">
          <div class="col-3">
            <label class="col-form-label fw-bold">Publication Year</label>
          </div>
          <div class="col">
            <asp:Label ID="lblYear" runat="server" />
          </div>
        </div>
        <div class="row g-3 align-items-center">
          <div class="col-3">
            <label class="col-form-label fw-bold">Price</label>
          </div>
          <div class="col">
            <asp:Label ID="lblPrice" runat="server" />
          </div>
        </div>
        
        <div class="row">
            <div class="col">
                <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="btn btn-primary" OnClick="lnkbtnEdit_Click">
                    Edit
                </asp:LinkButton>
                <asp:LinkButton ID="lnkbtnDelete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure to Delete?')" OnClick="lnkbtnDelete_Click">
                    Delete
                </asp:LinkButton>
                 <asp:HyperLink ID="hpCancel" runat="server" CssClass="btn btn-secondary" NavigateUrl="~/Views/BookList.aspx">
                    Cancel
                </asp:HyperLink>
            </div>
            
        </div>
        
</asp:Content>
