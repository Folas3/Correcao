using Correcao.Models;

namespace Correcao.Interfaces
{
    public interface IJogadorRepository
    {
        void Adicionar(Jogador jogador);

        List<Jogador> Listar();

        Jogador BuscarPorCpf(string cpf);

        bool RegistrarResultado(string cpf, bool aprovado);

        List<Jogador> ListarAprovados();
    }
}