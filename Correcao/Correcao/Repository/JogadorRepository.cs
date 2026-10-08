using Correcao.Interfaces;
using Correcao.Models;

namespace Correcao.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly List<Jogador> jogadores = new List<Jogador>();

        public void Adicionar(Jogador jogador)
        {
            jogadores.Add(jogador);
        }

        public List<Jogador> Listar()
        {
            return jogadores;
        }

        public Jogador BuscarPorCpf(string cpf)
        {
            return jogadores.FirstOrDefault(j => j.CPF == cpf);
        }

        public bool RegistrarResultado(string cpf, bool aprovado)
        {
            Jogador jogador = BuscarPorCpf(cpf);

            if (jogador == null)
            {
                return false;
            }

            if (jogador.Aprovado != null)
            {
                return false;
            }

            jogador.Aprovado = aprovado;

            return true;
        }

        public List<Jogador> ListarAprovados()
        {
            return jogadores
                .Where(j => j.Aprovado == true)
                .ToList();
        }
    }
}