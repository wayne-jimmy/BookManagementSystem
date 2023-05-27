using BMS.Common;
using BMS.DAL.IRepositories;
using BMS.DTO;
using BMS.Entity.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BMS.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region GetAll
        public List<BookViewModel> GetAll(string keywords)
        {
            using (var context = new BMSDataContext())
            {
                var query =(from data in context.Books
                            orderby data.BookId
                            select new BookViewModel
                            {
                                BookId = data.BookId,
                                Title = data.Title,
                                Author = data.Author,
                                Genre = data.Genre,
                                PublicationYear = data.PublicationYear,
                                Price = data.Price
                            });

                if(string.IsNullOrEmpty(keywords) == false)
                {
                    query = query.Where(x => x.Title.ToLower().Contains(keywords)
                                    || x.Author.ToLower().Contains(keywords)
                                    || x.Genre.ToLower().Contains(keywords));
                }

                return query.ToList();
            }
        }
        #endregion

        #region GetById
        public BookViewModel GetById(int id)
        {
            using (var context = new BMSDataContext())
            {
                var query = (from data in context.Books
                             where data.BookId == id
                             select new BookViewModel
                             {
                                 BookId = data.BookId,
                                 Title = data.Title,
                                 Author = data.Author,
                                 Genre = data.Genre,
                                 PublicationYear = data.PublicationYear,
                                 Price = data.Price
                             }).FirstOrDefault();

               
                return query;
            }
        }
        #endregion

        #region AddorUpdate
        public ResponseModel AddorUpdate(Book objData)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                using (var context = new BMSDataContext())
                {
                    if(objData.BookId == 0)
                    {
                        context.Books.Add(objData);
                        int totalRecord =  context.SaveChanges();

                        if(totalRecord > 0)
                        {
                            responseModel.MessageType = iConstance.RESULT_SUCCESS;
                            responseModel.Message = String.Format(iMessage.MSG_SUCCESS, "Save");
                        }
                        else
                        {
                            responseModel.MessageType = iConstance.RESULT_FAIL;
                            responseModel.Message = String.Format(iMessage.MSG_FAIL, "Save");
                        }
                    }
                    else
                    {
                        var book = context.Books.FirstOrDefault(x => x.BookId == objData.BookId);

                        if(book != null)
                        {
                            context.Books.FirstOrDefault(x => x.BookId == objData.BookId).Title = objData.Title;
                            context.Books.FirstOrDefault(x => x.BookId == objData.BookId).Author = objData.Author;
                            context.Books.FirstOrDefault(x => x.BookId == objData.BookId).Genre = objData.Genre;
                            context.Books.FirstOrDefault(x => x.BookId == objData.BookId).PublicationYear = objData.PublicationYear;
                            context.Books.FirstOrDefault(x => x.BookId == objData.BookId).Price = objData.Price;

                            int totalRecord = context.SaveChanges();

                            if (totalRecord > 0)
                            {
                                responseModel.MessageType = iConstance.RESULT_SUCCESS;
                                responseModel.Message = String.Format(iMessage.MSG_SUCCESS, "Update");
                            }
                            else
                            {
                                responseModel.MessageType = iConstance.RESULT_FAIL;
                                responseModel.Message = String.Format(iMessage.MSG_FAIL, "Update");
                            }
                        }
                    }
                }
            }
            catch
            {

            }

            return responseModel;
        }
        #endregion

        #region Delete
        public ResponseModel Delete(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                using (var context = new BMSDataContext())
                {
                    var book = context.Books.FirstOrDefault(x => x.BookId == id);

                    if (book != null)
                    {
                        context.Books.Remove(book);
                        int totalRecord = context.SaveChanges();
                        if (totalRecord > 0)
                        {
                            responseModel.MessageType = iConstance.RESULT_SUCCESS;
                            responseModel.Message = String.Format(iMessage.MSG_SUCCESS, "Delete");
                        }
                        else
                        {
                            responseModel.MessageType = iConstance.RESULT_FAIL;
                            responseModel.Message = String.Format(iMessage.MSG_FAIL, "Delete");
                        }
                    }
                }
            }
            catch
            {

            }

            return responseModel;
        }
        #endregion
    }
}
