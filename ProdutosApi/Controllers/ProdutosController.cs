using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.context;
using ProdutosApi.models;

namespace ProdutosApi.controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private ApiDbContext _context;

    public ProdutosController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpPost("products/new")]
    public ActionResult CadastraProduto(ProdutoModel produto)
    {
        try
        {
            if (produto is null)
            {
                return BadRequest("O produto não pôde ser criado");
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Created();
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao cadastrar o produto");
        }
    }

    [HttpPut("products/update/{id: int}")]
    public ActionResult AlteraProduto(int id, ProdutoModel produto)
    {
        try
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Id de produto inválido");
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar alterar o produto");
        }
    }

    [HttpGet("products/{id: int}")]
    public ActionResult<ProdutoModel> ProdutoById(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar o produto");
        }
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<ProdutoModel>> ListarProdutos() 
    {
        try
        {
            return _context.Produtos.ToList();
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar os produtos");
        }
    }

    [HttpDelete("products/delete/{id: int}")]
    public ActionResult DeleteProduto(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao excluir o produto");
        }
    }
}
