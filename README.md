# API de Produtos com ASP.NET

Esta é uma API de exemplo construída com ASP.NET para gerenciar produtos.

## Pré-requisitos

- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/) (opcional)

- ## Configuração do Projeto

1. Clone este repositório:

    ```bash
    git clone https://github.com/seu-usuario/api-produtos-aspnet.git
    ```

2. Abra o projeto no Visual Studio ou Visual Studio Code.

3. Execute a aplicação:

    ```bash
    dotnet run
    ```

4. Acesse a API através do Swagger.

## Endpoints

## Produtos:

### Listar produto por ID (GET)
```bash
products/{id: int}
```
Retorna um produto através de seu ID

### Listar produtos (GET)
```bash
products
```
Lista todos os produtos

### Cadastrar produto (POST)
```bash
products/new
```
Cadastra um novo produto no sistema

### Editar produto (PUT)
```bash
products/update/{id: int}
```
Edita um produto cadastrado no sistema tendo como referência o seu ID

### Excluir produtos (DELETE)
```bash
products/delete/{id: int}
```
Exclui um produto cadastrado no sistema tendo como referência seu ID

## Usuários:

### Cadastrar um usuário (POST)
```bash
users/signup
```
Cadastra um novo usuário no sistema. Por padrão, todos os usuários cadastrados através desta endpoint serão do tipo "cliente"

### Listar usuário por ID (GET)
```bash
users/{id: int}
```
Lista um usuário cadastrado no sistema através de seu ID

### Alterar usuário (PUT)
```bash
users/update/{id: int}
```
Altera um usuário cadastrado no sistema tendo como referência seu ID

### Excluir usuário (DELETE)
```bash
users/delete/{id: int}
```
Exclui um usuário cadastrado no sistema tendo como referência seu ID

## Categorias:

### Cadastrar categoria (GET)
```bash
categories/new
```
Cadastra uma nova categoria no sistema

### Listar categorias (GET)
```bash
categories
```
Lista todas as categorias cadastradas no sistema

### Listar produtos de uma categoria (GET)
```bash
categories/{id: int}/products
```
Lista todos os produtos de uma categoria tendo como referência seu ID

### Excluir categoria (DELETE)
```bash
categories/{id: int}
```
Exclui uma categoria cadastrada no sistema tendo como referência seu ID

## Funcionários:

### Cadastrar funcionário (POST)
```bash
users/employees/new
```
Cadastra um funcionário no sistema. Por padrão, todos os usuários cadastrados nessa endpoint serão do tipo "funcionário"
