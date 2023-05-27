using BMS.BLL.IServices;
using BMS.Common;
using BMS.DTO;
using BMS.Entity.DataContext;
using Microsoft.Practices.Unity;
using System;
using System.Web.UI;

namespace BMS.Web.Views
{
    public partial class AddBook : Page
    {
        [Dependency]
        public IBookService _bookService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region Save
        private void Save()
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
                Clear();
            }

            hdMessageType.Value = responseModel.MessageType.ToString();
            hdMessage.Value = responseModel.Message;
            
        }
        #endregion

        #region Clear
        private void Clear()
        {
            hdBookId.Value = "0";
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
        #endregion
    }
}