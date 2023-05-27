
using BMS.DTO;
using BMS.Entity.DataContext;
using System.Collections.Generic;

namespace BMS.DAL.IRepositories
{
    public interface IBookRepository
    {
        List<BookViewModel> GetAll(string keywords);

        BookViewModel GetById(int id);

        ResponseModel AddorUpdate(Book objData);

        ResponseModel Delete(int id);
    }
}
