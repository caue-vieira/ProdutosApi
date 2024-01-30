using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("users/employees/new")]
    public ActionResult CadastraFuncionario(UsuarioModel funcionario)
    {
        try{
            if(funcionario is null)
            {
                return BadRequest("O funcionário não pôde ser criado");
            } else if (funcionario.Senha is null ||
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
        } catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao criar o funcionário");
        }
    }
}
