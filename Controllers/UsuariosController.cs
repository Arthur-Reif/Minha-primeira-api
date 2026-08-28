using Microsoft.AspNetCore.Mvc;
using MeuPrimeiroEstudoDeAPI.Models;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController
    {
        static private List<Usuario> usuarios  = new List<Usuario>();

        //Fazer um CRUD  Create, Read, Update, Delete  
        [HttpGet]
        public List<Usuario> GetUsuario()  
        {   
            return usuarios;
        }     
        
        [HttpGet]
        [Route("{id}")]
        public Usuario GetUsuarioPorId([FromRoute] string id )
        {
            Usuario resultado = null; 
            foreach(var usuario in usuarios)
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
        public string GetPedidosUsuario([FromRoute]string id)
        {
            return "voce chamou o metodo Obter Pedidos do Usuario id " + id;
        }

        // app.MapPut("/usuarios", () => "voce chamou o metodo atualizar Usuarios");

        [HttpPut]
        public string AtualizarUsuario()
        {
            return "voce chamou o metodo atualizar Usuarios";
        }

        // app.MapDelete("/usuarios", () => "voce chamou o metodo excluir Usuarios");
        [HttpDelete]
        public string DeletarUsuario()
        {
            return "voce chamou o metodo excluir Usuarios";
        }
        // app.MapPost("/usuarios", CriarUsuario);
        [HttpPost]
        public string CriarUsuario([FromBody]Usuario usuario)
        {
            usuarios.Add(usuario);

            return "voce chamou o metodo criar Usuarios com o nome " + usuario.Nome + " e idade " + usuario.Idade;
        }
    }
}