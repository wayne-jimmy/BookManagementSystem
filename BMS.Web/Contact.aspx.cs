using BMS.BLL.IServices;
using Microsoft.Practices.Unity;
using System;
using System.Web.UI;

namespace WebApplication2
{
    public partial class Contact : Page
    {
        [Dependency]
        public IBookService _bookService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authors = _bookService.GetAll("");
        }

    }
}