using Microsoft.AspNetCore.Mvc;
using MeuPrimeiroEstudoDeAPI.Models;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController
    {
        static private List<Usuario> usuarios = new List<Usuario>();

        //Fazer um CRUD  Create, Read, Update, Delete  
        [HttpGet]
        public List<Usuario> GetUsuario()
        {
            return usuarios;
        }

        [HttpGet]
        [Route("{id}")]
        public Usuario GetUsuarioPorId([FromRoute] string id)
        {
            Usuario resultado = null;
            foreach (var usuario in usuarios)
            {
                if (usuario.Id == id)
                {
                    resultado = usuario;
                }
            }

            return resultado;
        }

        // app.MapGet("/usuarios/{id}/pedidos", GetPedidosUsuario);
        [HttpGet]
        [Route("{id}/pedidos")]
        public string GetPedidosUsuario([FromRoute] string id)
        {
            return "voce chamou o metodo Obter Pedidos do Usuario id " + id;
        }

        // app.MapPut("/usuarios", () => "voce chamou o metodo atualizar Usuarios");

        [HttpPut]
        [Route("{id}")]
        public string AtualizarUsuario([FromRoute] string id, [FromBody] Usuario usuarioAtualizado)
        {
            Usuario selecionado = null
;

foreach (var usuario in usuarios)
            {
                if(usuario.Id == id)
                {
                    selecionado = usuario;
                    break;
                }
            }
            if (selecionado == null)
            {
                return "usuario nao encontrdo";
            }
            //opçao de duas operaçoes. (para nosso caso faz sentido pq é teste)
            // usuarios.Remove(selecionado);
            // usuarios.Add(UsuarioAtualizado);

            selecionado.Id = usuarioAtualizado.Id;
            selecionado.Nome = usuarioAtualizado.Nome;
            selecionado.Idade = usuarioAtualizado.Idade;

            return "voce chamou o metodo atualizar Usuarios";
        }

        // app.MapDelete("/usuarios", () => "voce chamou o metodo excluir Usuarios");
        [HttpDelete]
        [Route("{id}")]
        public string DeletarUsuario([FromRoute] string id)
        {
            Usuario usuarioParaDeletar = null;
            foreach (var usuario in usuarios)
            {
                if (usuario.Id == id)
                {
                    usuarioParaDeletar = usuario;
                    break;// Somente para interromper o loop pois já achamos oq queriamos
                }
            }
            if (usuarioParaDeletar == null)
            {
                return "Não foi encontrado usaurio com o id" + id;
            }
            else
            {
                usuarios.Remove(usuarioParaDeletar);
                return $"usuario de id {id} deletado";
            }
        }
        // app.MapPost("/usuarios", CriarUsuario);
        [HttpPost]
        public string CriarUsuario([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);

            return "voce chamou o metodo criar Usuarios com o nome " + usuario.Nome + " e idade " + usuario.Idade;
        }
    }
}