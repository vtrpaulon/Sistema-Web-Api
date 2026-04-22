# 🚀 API de Produtos - .NET com Dapper

## 📌 Descrição

Esta é uma API REST desenvolvida em **.NET** com foco em boas práticas de arquitetura backend.
O projeto implementa um CRUD completo de produtos utilizando **Dapper** para acesso a dados e **SQL Server** como banco de dados.

A aplicação foi estruturada seguindo o padrão de **arquitetura em camadas**, com separação clara de responsabilidades entre Controller, Service e Repository.

---

## 🧱 Arquitetura

A estrutura do projeto segue o padrão:

```
Controller → Service → Repository → Banco de Dados
```

* **Controller**: Responsável por lidar com as requisições HTTP
* **Service**: Contém as regras de negócio
* **Repository**: Responsável pelo acesso ao banco de dados (Dapper)

---

## ⚙️ Tecnologias utilizadas

* .NET 8/9
* ASP.NET Core Web API
* Dapper
* SQL Server
* Insomnia (testes de API)

---

## 📂 Funcionalidades

✔ Listar todos os produtos
✔ Buscar produto por ID
✔ Criar novo produto
✔ Atualizar produto
✔ Deletar produto

---

## 🧠 Conceitos aplicados

* Arquitetura em camadas
* Injeção de dependência
* DTO (Data Transfer Object)
* Middleware para tratamento global de erros
* Boas práticas de organização de código

---

## ▶️ Como executar o projeto

### 1. Clonar o repositório

```
git clone https://github.com/vtrpaulon/Sistema-Web-Api.git
```

---

### 2. Configurar o banco de dados

No SQL Server, execute:

```sql
CREATE DATABASE ApiProdutosDB;

USE ApiProdutosDB;

CREATE TABLE Produtos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    DataCriacao DATETIME NOT NULL
);
```

---

### 3. Configurar a connection string

No arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ApiProdutosDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 4. Executar a aplicação

```
dotnet run
```

A API estará disponível em:

```
http://localhost:5180
```

---

## 🔎 Exemplos de uso

### 📥 Criar produto (POST)

```json
{
  "nome": "Produto Teste",
  "preco": 100
}
```

---

### 📤 Resposta de erro (exemplo)

```json
{
  "mensagem": "Preço deve ser maior que zero"
}
```

---

## 📈 Melhorias futuras

* Implementar autenticação (JWT)
* Adicionar validações com DataAnnotations
* Implementar métodos assíncronos (async/await)
* Documentação com Swagger

---

## 👨‍💻 Autor

**Vitor Paulon**
🔗 https://github.com/vtrpaulon
🔗 https://www.linkedin.com/in/vitorpaulon

---

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo e portfólio.
