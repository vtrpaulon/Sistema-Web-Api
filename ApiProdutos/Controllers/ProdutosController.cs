using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Models;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();

    // GET: api/produtos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(produtos);
    }

    // GET: api/produtos/1
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    // POST: api/produtos
    [HttpPost]
    public IActionResult Post([FromBody] Produto produto)
    {
       if (produto == null)
       {
           return BadRequest();
       }
       produtos.Add(produto);
       return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    // PUT: api/produtos/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.DataCriacao = produtoAtualizado.DataCriacao;
        return NoContent();
    }

    // DELETE: api/produtos/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        produtos.Remove(produto);
        return NoContent();
    }
}
