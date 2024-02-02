using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.context;
using ProdutosApi.models;

namespace ProdutosApi.controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private ApiDbContext _context;

    public CategoriasController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpPost("new")]
    public ActionResult CadastrarCategoria(CategoriaModel categoria)
    {
        try
        {
            if (categoria is null)
            {
                return BadRequest("A categoria não pôde ser criada");
            }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return Created();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao criar a categoria");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoriaModel>> ListaCategorias()
    {
        try
        {
            return _context.Categorias.ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar as categorias");
        }
    }

    [HttpGet("{id:int}/products")]
    public ActionResult<IEnumerable<CategoriaModel>> ListaProdutoCategoria(int id)
    {
        try
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar os produtos da categoria");
        }
    }

    [HttpDelete("delete/{id:int}")]
    public ActionResult DeleteCategoria(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound("Categoria não encontrada");
        }
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return Ok();
    }
}
