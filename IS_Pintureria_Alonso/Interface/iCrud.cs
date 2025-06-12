namespace Interface
{
    public interface iCrud<t> where t : class
    {
        t GetByID(int id);
        void Add(t entidad);
        void Update(t entidad);
        void Delete(t entidad);
        public List<t> DevolverTodos();
        public bool Existe(string nombre);
    }
}
