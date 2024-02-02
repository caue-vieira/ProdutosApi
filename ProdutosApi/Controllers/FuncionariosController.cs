using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApi.context;
using ProdutosApi.models;

namespace ProdutosApi.controllers;

[Route("[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private ApiDbContext _context;

    public FuncionariosController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpPost("users/new")]
    public ActionResult CadastraFuncionario(UsuarioModel funcionario)
    {
        try
        {
            if (funcionario is null)
            {
                return BadRequest("O funcionário não pôde ser criado");
            }
            else if (funcionario.Senha is null ||
                funcionario.ConfirmaSenha is null ||
                funcionario.NomeUsu is null ||
                funcionario.Email is null)
            {
                return BadRequest("Este campo não pode estar vazio!");
            }
            funcionario.TipoUsuario = "funcionario";
            _context.Usuarios.Add(funcionario);
            _context.SaveChanges();

            return Created();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao criar o funcionário");
        }
    }

    [HttpGet("users/{id:int}")]
    public ActionResult<UsuarioModel> FuncionarioById(int id)
    {
        try
        {
            var funcionario = _context.Usuarios.FirstOrDefault(f => f.UsuarioId == id);
            if (funcionario is null)
            {
                return NotFound("Funcionário não encontrado");
            }
            else if ((funcionario.TipoUsuario ?? "").Equals("funcionario", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(funcionario);
            }
            else
            {
                return BadRequest("O usuário não é um funcionário");
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao listar o funcionário");
        }
    }

    [HttpPut("users/update/{id:int}")]
    public ActionResult UpdateFuncionario(int id, UsuarioModel funcionario)
    {
        try
        {
            if (id != funcionario.UsuarioId)
            {
                return BadRequest();
            }
            else if ((funcionario.TipoUsuario ?? "").Equals("funcionario", StringComparison.OrdinalIgnoreCase))
            {
                _context.Entry(funcionario).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao alterar o funcionário");
        }
    }

    [HttpDelete("users/delete/{id:int}")]
    public ActionResult DeleteFuncionario(int id)
    {
        try
        {
            var funcionario = _context.Usuarios.FirstOrDefault(f => f.UsuarioId == id);
            if (funcionario is null)
            {
                return NotFound("Funcionário não encontrado");
            }
            else if ((funcionario.TipoUsuario ?? "").Equals("funcionario"))
            {
                _context.Usuarios.Remove(funcionario);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao excluir o funcionário");
        }
    }
}
