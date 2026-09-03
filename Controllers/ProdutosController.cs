using MeuPrimeiroEstudoDeAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace MeuPrimeiroEstudoDeAPI.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController
    {
        static private List<Produto> produtos = new List<Produto>();

        [HttpGet]
        public List<Produto> GetProduto()
        {
            return produtos;
        }

        [HttpPost]
        public string NovoProduto([FromBody] Produto produto)
        {
            produtos.Add(produto);
            return "Produto adicionado com sucesso!";
        }

        [HttpGet]
        [Route("{id}")]
        public Produto GetProdutoPorId([FromRoute] int id)
        {
            Produto resultado = null;
            foreach (var produto in produtos)
            {
                if (produto.Id == id)
                {
                    resultado = produto;
                }
            }

            return resultado;
        }

         [HttpDelete]
        [Route("{id}")]
        public string DeletarProduto([FromRoute] int id)
        {
            Produto produtoParaDeletar = null;
            foreach (var produto in produtos)
            {
                if (produto.Id == id)
                {
                    produtoParaDeletar = produto;
                    break;// Somente para interromper o loop pois já achamos oq queriamos
                }
            }
            if (produtoParaDeletar == null)
            {
                return "Não foi encontrado usaurio com o id" + id;
            }
            else
            {
                produtos.Remove(produtoParaDeletar);
                return $"usuario de id {id} deletado";
            }
        } 
        [HttpPut]
        [Route("{id}")]
        public string AtuLizarProduto([FromBody] int id, [FromRoute] Produto produtoAtualizado)
        {
            Produto selecionado = ObterProduto(id);

            if(selecionado == null)
            {
                return "produto nao encontrado";
            }
            selecionado.Id = produtoAtualizado.Id;
            selecionado.Nome = produtoAtualizado.Nome;

            return "produto atualizado";
        }
          private Produto ObterProduto(int id)
        {
            Produto selecionado = null;
            foreach (var produto in produtos)
            {
                if( produto.Id == id)
                {
                    selecionado = produto;
                    break;
                }
            }
            return selecionado;
        }
    }
}

