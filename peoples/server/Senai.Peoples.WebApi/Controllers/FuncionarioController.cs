using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{

    [Produces("application/json")] // o q ta sendo passado
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        // Backend:
        // Criar o repositório correspondente que contenha as ações de: listar, buscar por id, deletar, atualizar e inserir;

        //Desafios Extras:
        //Criar um endpoint chamado /api/funcionarios/buscar/{nome}
        //passando como parâmetro o nome do funcionário e realizando a determinada busca no banco;
        //Criar um endpoint chamado /api/funcionarios/nomescompletos que na saída do json, o nome e o sobrenome venham na mesma chave.Ex.: { "nomeCompleto" : "Catarina Strada" };

        //Criar APENAS UM endpoint para que seja listado os nomes dos funcionários em ordem crescente ou decrescente.Da seguinte maneira:
        //GET /api/funcionarios/ordenacao/{ordem}
        //GET /api/funcionarios/ordenacao/asc ou GET /api/funcionarios/ordenacao/desc
        //Caso o usuário informe uma ordenação que não exista, retornar uma mensagem de erro e devolver o erro 400 BadRequest).

        public FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        [HttpGet]
        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> lista = funcionarioRepositorio.Listar();

            if (lista == null)
            {
                NotFound();
            }

            return lista;
        }

        [HttpGet("{id}")]
        public FuncionarioDomain BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = funcionarioRepositorio.BuscarPorId(id);

            if (funcionario == null)
            {
                NotFound();
            }

            return funcionario;
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain func)
        {
            funcionarioRepositorio.Cadastrar(func);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepositorio.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FuncionarioDomain func)
        {
            funcionarioRepositorio.Atualizar(id, func);
            return Ok();
        }

    }
}