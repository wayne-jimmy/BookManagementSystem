<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="BMS.Web.Views.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bd-content ps-lg-4">
        <h2 id="overview">
            Book List
        </h2>
        <hr />
        <div class="row mb-3">
            <div class="col-12 text-right">
                <asp:HyperLink ID="btnAdd" CssClass="btn btn-primary" runat="server" NavigateUrl="~/Views/AddBook.aspx">
                    Create new book
                </asp:HyperLink>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-6">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control" placeholder="Enter Keywords"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-dark" OnClick="btnSearch_Click">Search</asp:LinkButton>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvList" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Genre" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblGenre" runat="server" Text='<%# Eval("Genre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publication Year" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("PublicationYear") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnView" runat="server" CssClass="btn btn-sm btn-secondary" CommandName="View" CommandArgument='<%# Eval("BookId") %>'>
                            View
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="btn btn-sm btn-primary" CommandName="Edit" CommandArgument='<%# Eval("BookId") %>'>
                            Edit
                        </asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
            </div>
        </div>

        

    </div>
</asp:Content>
