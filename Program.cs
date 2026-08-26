var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.MapGet("/", () => $"Hello World! ");

app.MapGet("/banana", () => "voce chamou o metodo Banana");

app.MapGet("/usuarios", () => GetUsuario);
app.MapPost("/usuarios", () => CriarUsuario);
app.MapPut("/usuarios", () => "voce chamou o metodo atualizar Usuarios");
app.MapDelete("/usuarios", () => "voce chamou o metodo excluir Usuarios");

app.MapGet("/usuarios/{id}", (int id) => "voce chamou o metodo Obter Usuarios id: " + id);
//se colocar (string id) da pra colocar texto


string GetUsuario()
{
    return "Voce chamou o metodo obter usuarios";
}

string CriarUsuario(Usuario usuario) => "voce chamou o metodo criar Usuarios com o nome " + usuario.Nome + " e idade " + usuario.Idade;

app.MapGet("/preencher", (string nome, int idade) => $"voce chamou o metodo Receber Query com nome {nome} e idade {idade}");


app.Run();

class Usuario
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}
