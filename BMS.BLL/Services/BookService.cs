
using BMS.BLL.IServices;
using BMS.DAL.IRepositories;
using BMS.DTO;
using BMS.Entity.DataContext;
using System.Collections.Generic;

namespace BMS.BLL.Services
{
    public class BookService:IBookService
    {
        IBookRepository bookRepository;
        public BookService(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        public List<BookViewModel> GetAll(string keywords)
        {
            List<BookViewModel> lst = bookRepository.GetAll(keywords);
            return lst;
        }

        public BookViewModel GetById(int id)
        {
            BookViewModel model = bookRepository.GetById(id);
            return model;
        }

        public ResponseModel AddorUpdate(Book objData)
        {
            ResponseModel model = bookRepository.AddorUpdate(objData);
            return model;
        }

        public ResponseModel Delete(int id)
        {
            ResponseModel model = bookRepository.Delete(id);
            return model;
        }

    }
}
