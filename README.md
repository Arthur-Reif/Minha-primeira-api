Criar uma controller de Produtos que possua criar o crud com as seguintes Rotas: 

- [POST] /produtos 
    - Deve inserir um novo produto em uma lista estatica 
    - Deve receber este produto via Body
- [GET] /produtos
    - deve retornar todos os intens que estão na lista de produtos.
- [GET] /produtos/{id}
    - deve retornar o produto com o id passado, se não existir retorna produto não encontrado
- [DELETE]/produtos/{id}
    -  deve excluir o produto com o id informado, se não existir retorna produto não encontrado
- [PUT]/produtos/{id}
    -  deve Atualizar o produto com o id informado, se não existir retorna produto não encontrado. 
    - Recebe o produto a ser atualizado no body



Objeto produto 

```csharp 
public class Produto {
    public int Id {get; set;}
    public string Nome { get; set;}
}
```