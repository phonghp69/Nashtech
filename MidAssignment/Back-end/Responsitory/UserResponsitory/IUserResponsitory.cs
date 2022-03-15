using Back_end.Models;
namespace Back_end.Responsitory.UserResponsitory
{
    public interface IUserResponsitory
    {
          public List<User> GetUsers();
        public void Add(User user);
        public void Update(int id, User user);
        public void Delete(int id);
    }
}