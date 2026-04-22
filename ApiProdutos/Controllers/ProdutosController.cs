using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Models;
using ApiProdutos.Services;
using ApiProdutos.Exceptions;
using ApiProdutos.DTOs;

namespace ApiProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutosController(ProdutoService service)
    {
        _service = service;
    }

    // GET: api/produtos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    // GET: api/produtos/1
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = _service.GetById(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    // POST
    [HttpPost]
    public IActionResult Post([FromBody] ProdutoCreateDto dto)
    {
        var id = _service.Add(dto);

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produto)
    {
        var existente = _service.GetById(id);

        if (existente == null)
            return NotFound();

        _service.Update(id, produto);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existente = _service.GetById(id);

        if (existente == null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }
}
