using BMS.BLL.IServices;
using BMS.Common;
using BMS.DTO;
using BMS.Entity.DataContext;
using Microsoft.Practices.Unity;
using System;
using System.Web.UI;

namespace BMS.Web.Views
{
    public partial class EditBook : Page
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
                txtTitle.Text = model.Title;
                txtAuthor.Text = model.Author;
                txtGenre.Text = model.Genre;
                txtYear.Text = model.PublicationYear.ToString();
                txtPrice.Text = model.Price.ToString();
            }
        }

        #region btnUpdate_Click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        #endregion

        #region Update
        private void Update()
        {
            Book objBook = new Book();
            objBook.BookId = int.Parse(hdBookId.Value);
            objBook.Title = txtTitle.Text;
            objBook.Author = txtAuthor.Text;
            objBook.Genre = txtGenre.Text;
            objBook.PublicationYear = int.Parse(txtYear.Text);
            objBook.Price = decimal.Parse(txtPrice.Text);

            ResponseModel responseModel = _bookService.AddorUpdate(objBook);

            if(responseModel.MessageType == iConstance.RESULT_SUCCESS)
            {
                Response.Redirect("~/Views/BookList.aspx");
            }

            hdMessageType.Value = responseModel.MessageType.ToString();
            hdMessage.Value = responseModel.Message;
            
        }
        #endregion

    }
}