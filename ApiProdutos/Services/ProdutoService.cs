using ApiProdutos;
using ApiProdutos.Models;
using ApiProdutos.Repositories;

namespace  ApiProdutos.Services;

public class ProdutoService
{
    private readonly ProdutoRepository _repository;

    public ProdutoService(ProdutoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Produto> GetAll()
    {
        return _repository.GetAll();
    }

    public Produto? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public int Add(Produto produto)
    {
        //regra de negocio
        if(produto.Preco <= 0)
            throw new Exception("O preço deve ser maior que zero");
        
        return _repository.Add(produto);
    }

    public void Update(int id, Produto produto)
    {
        _repository.Update(id, produto);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}