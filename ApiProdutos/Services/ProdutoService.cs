using ApiProdutos;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Exceptions;
using ApiProdutos.DTOs;

namespace  ApiProdutos.Services;

public class ProdutoService
{
    private readonly ProdutoRepository _repository;

    public ProdutoService(ProdutoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ProdutoResponseDto> GetAll()
    {
        var produtos = _repository.GetAll();

        return produtos.Select(p => new ProdutoResponseDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Preco = p.Preco,
            DataCriacao = p.DataCriacao
        });
    }

    public Produto? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public int Add(ProdutoCreateDto dto)
    {
        if (dto.Preco <= 0)
            throw new BadRequestException("Preço deve ser maior que zero");

        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            DataCriacao = DateTime.Now
        };

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