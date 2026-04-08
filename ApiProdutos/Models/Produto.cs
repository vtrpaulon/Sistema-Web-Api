namespace ApiProdutos.Models;

[Serializable]  // Indica que a classe é serializável

public class Produto
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public decimal Preco {get; set;}
    public DateTime DataCriacao {get; set;}
}