using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.DTOs;

public class ProdutoCreateDto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}