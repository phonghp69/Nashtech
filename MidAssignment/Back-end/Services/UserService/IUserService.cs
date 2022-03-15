using Back_end.Models;
namespace Back_end.Services
{
    public interface IUserService
    {
         List<string> GetUser();
         public void Add(User User);
        public void Update(int id, User category);
        public void Delete(int id);
    }
}