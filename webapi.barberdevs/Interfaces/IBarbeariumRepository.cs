using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IBarbeariumRepository
    {
        //CRUD
        void Cadastrar(Barbearium barbearium);
        void Deletar(Guid id);
        List<Barbearium> Listar();
        Barbearium BuscarPorId(Guid id);
        void Atualizar(Guid id, Barbearium barbearium);
    }
}
