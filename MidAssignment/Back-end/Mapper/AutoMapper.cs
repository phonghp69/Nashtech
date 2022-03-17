using AutoMapper;
using Back_end.Entities;
using Back_end.Models;
namespace Back_end.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book,BookModel>();
            CreateMap<BookModel,Book>();  
            CreateMap<User,UserModel>();
            CreateMap<UserModel,User>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
             CreateMap<BookBorrowingRequest, BookBorrowingRequestModel>();
            CreateMap<BookBorrowingRequestModel, BookBorrowingRequest>();
            
            CreateMap<BookBorrowingRequestDetails, BookBorrowingRequestDetailsModel>();
            CreateMap<BookBorrowingRequestDetailsModel, BookBorrowingRequestDetails>();
           
        }
    }
}