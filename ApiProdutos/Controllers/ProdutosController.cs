using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Models;
using ApiProdutos.Repositories;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoRepository _repository;

    public ProdutosController(ProdutoRepository repository)
    {
        _repository = repository;
    }

    // GET: api/produtos
    [HttpGet]
    public IActionResult Get()
    {
        var produtos = _repository.GetAll();
        return Ok(produtos);
    }

    // GET: api/produtos/1
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = _repository.GetById(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    // POST
    [HttpPost]
    public IActionResult Post([FromBody] Produto produto)
    {
        var id = _repository.Add(produto);
        produto.Id = id;

        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produto)
    {
        var existente = _repository.GetById(id);

        if (existente == null)
            return NotFound();

        _repository.Update(id, produto);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existente = _repository.GetById(id);

        if (existente == null)
            return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
}