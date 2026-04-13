using System.Data;
using System.Data.SqlClient;
using Dapper;
using ApiProdutos.Models;

namespace ApiProdutos.Repositories;

public class ProdutoRepository
{
    private readonly string _connectionString;

    public ProdutoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection Connection()
    {
        return new SqlConnection(_connectionString);
    }

    // 🔹 GET ALL
    public IEnumerable<Produto> GetAll()
    {
        using var db = Connection();
        return db.Query<Produto>("SELECT * FROM Produtos");
    }

    // 🔹 GET BY ID
    public Produto? GetById(int id)
    {
        using var db = Connection();
        return db.QueryFirstOrDefault<Produto>(
            "SELECT * FROM Produtos WHERE Id = @Id",
            new { Id = id });
    }

    // 🔹 INSERT
    public int Add(Produto produto)
    {
        using var db = Connection();

        var sql = @"INSERT INTO Produtos (Nome, Preco, DataCriacao)
                    OUTPUT INSERTED.Id
                    VALUES (@Nome, @Preco, @DataCriacao)";

        return db.ExecuteScalar<int>(sql, produto);
    }

    // 🔹 UPDATE
    public void Update(int id, Produto produto)
    {
        using var db = Connection();

        var sql = @"UPDATE Produtos 
                    SET Nome = @Nome, 
                        Preco = @Preco, 
                        DataCriacao = @DataCriacao
                    WHERE Id = @Id";

        db.Execute(sql, new
        {
            Id = id,
            produto.Nome,
            produto.Preco,
            produto.DataCriacao
        });
    }

    // 🔹 DELETE
    public void Delete(int id)
    {
        using var db = Connection();
        db.Execute("DELETE FROM Produtos WHERE Id = @Id", new { Id = id });
    }
}