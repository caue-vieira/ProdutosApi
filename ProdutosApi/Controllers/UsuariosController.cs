using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.context;
using ProdutosApi.models;

namespace ProdutosApi.controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApiDbContext _context;

    public UsuariosController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpPost("users/signup")]
    public ActionResult UsuarioModel (UsuarioModel usuario)
    {
        try
        {
            if (usuario is null)
            {
                return BadRequest("O usuário não pôde ser criado");
            }
            else if (usuario.Senha is null ||
                usuario.ConfirmaSenha is null ||
                usuario.NomeUsu is null ||
                usuario.Email is null)
            {
                return BadRequest("Este campo não pode estar vazio!");
            }
            usuario.TipoUsuario = "cliente";
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Created();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao criar o usuário");
        }
    }

    [HttpGet("users/{id: int}")]
    public ActionResult<UsuarioModel> UsuarioById(int id)
    {
        try
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if(usuario is null)
            {
                return NotFound("Usuário não encontrado");
            }
            return usuario;
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao buscar os dados do usuário");
        }
    }

    //[HttpPost("users/login")] realizar depois por conter token JWT

    [HttpPut("users/update/{id: int}")]
    public ActionResult UpdateUsuario(int id, UsuarioModel usuario)
    {
        try
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao alterar os dados do usuário");
        }
    }

    [HttpDelete("users/{id: int}")]
    public ActionResult DeleteUsuario(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if(usuario is null)
        {
            return NotFound("Usuário não encontrado");
        }
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();

        return Ok();
    }
}
