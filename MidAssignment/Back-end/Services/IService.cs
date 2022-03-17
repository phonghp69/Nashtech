namespace Back_end.Services
{
     public interface IService<T>
    {
        public ICollection<T> GetAll();
        public T GetById(int id);

        public void Add(T item);
        
        public void Update(int id ,T item);

        public void Remove(int item);
    }
}