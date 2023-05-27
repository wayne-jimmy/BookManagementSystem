using BMS.BLL.IServices;
using BMS.DTO;
using Microsoft.Practices.Unity;
using System;
using System.Web.UI;

namespace BMS.Web.Views
{
    public partial class BookDetails : Page
    {
        [Dependency]
        public IBookService _bookService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindData(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }

        private void BindData(int id)
        {
            BookViewModel model = _bookService.GetById(id);

            if(model != null)
            {
                hdBookId.Value = model.BookId.ToString();
                lblTitle.Text = model.Title;
                lblAuthor.Text = model.Author;
                lblGenre.Text = model.Genre;
                lblYear.Text = model.PublicationYear.ToString();
                lblPrice.Text = model.Price.ToString();
            }
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/EditBook.aspx?id=" + hdBookId.Value);
        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/DeleteBook.aspx?id=" + hdBookId.Value);
        }
    }
}