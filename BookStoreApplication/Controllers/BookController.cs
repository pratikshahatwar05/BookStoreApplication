using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;
        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                var result = this.bookManager.AddBook(book);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to add Book" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                var result = this.bookManager.DeleteBook(bookId);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Book Deleted Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to delete Book" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            try
            {
                var result = this.bookManager.GetAllBook();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of book get successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to get list of Book" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                var result = this.bookManager.UpdateBook(book);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book updated Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to update Book" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}