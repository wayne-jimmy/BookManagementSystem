using BMS.BLL.IServices;
using BMS.DTO;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace BMS.Web.Views
{
    public partial class BookList : Page
    {
        [Dependency]
        public IBookService _bookService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<BookViewModel> lst = _bookService.GetAll(txtKeywords.Text);

            gvList.DataSource = lst;
            gvList.DataBind();
        }

        protected void gvList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if(e.CommandName == "View")
            {
                Response.Redirect("~/Views/BookDetails.aspx?id=" + e.CommandArgument.ToString());
            }
            else
            {
                Response.Redirect("~/Views/EditBook.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}