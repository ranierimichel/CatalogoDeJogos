using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {
                Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 01",
                    Produtora = "Produtora01", Preco = 200
                }
            },
            {
                Guid.Parse("1ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("1ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 02",
                    Produtora = "Produtora01", Preco = 190
                }
            },
            {
                Guid.Parse("2ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("2ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 03",
                    Produtora = "Produtora01", Preco = 180
                }
            },
            {
                Guid.Parse("3ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("3ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 04",
                    Produtora = "Produtora01", Preco = 170
                }
            },
            {
                Guid.Parse("4ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("4ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 05",
                    Produtora = "Produtora02", Preco = 80
                }
            },
            {
                Guid.Parse("5ca314a5-9282-45d8-92c3-2985f2a9fd04"),
                new Jogo
                {
                    Id = Guid.Parse("5ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Jogo 06",
                    Produtora = "Produtora03", Preco = 190
                }
            }
        };
        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values
                .Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();
            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar conexão com o banco
            throw new NotImplementedException();
        }
    }
}