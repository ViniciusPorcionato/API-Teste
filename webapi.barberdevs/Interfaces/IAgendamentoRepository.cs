using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IAgendamentoRepository
    {
        public void Cadastrar(Agendamento agendamento);
        public Agendamento BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<Agendamento> ListarTodos();
        public List<Agendamento> ListarPorBarbeiro(Guid IdMedico);
        public List<Agendamento> ListarPorCliente(Guid IdPaciente);
    }
}
