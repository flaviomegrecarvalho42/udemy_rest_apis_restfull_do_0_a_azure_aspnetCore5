﻿using RestWithAspNet5Udemy.Models;
using System.Collections.Generic;

namespace RestWithAspNet5Udemy.Repositories.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Method responsible for returning all books
        /// </summary>
        /// <returns></returns>
        List<Book> FindAll();

        /// <summary>
        /// Method responsible for returning one book by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book FindById(long id);

        /// <summary>
        /// Method responsible to crete one new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Book Create(Book book);

        /// <summary>
        /// Method responsible for updating one book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Book Update(Book book);

        /// <summary>
        /// Method responsible for deleting a book from an ID
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(long id);
    }
}
