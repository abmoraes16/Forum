using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoForum.Models;

namespace ProjetoForum.Controllers
{
    [Route ("api/[controller]")]
    public class TopicoController:Controller
    {
        DAOTopico dao = new DAOTopico();

        [HttpGet]
        public IEnumerable<Topico> Get(){
            return dao.Listar();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Topico Topico){
            JsonResult resultado = null;

            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                else
                {
                    resultado = new JsonResult(""); 
                    resultado.ContentType = "application/json";

                    if(!dao.Cadastro(Topico))
                    {
                        resultado.StatusCode = 404;
                        resultado.Value = "Ocorreu um erro";
                    }
                    else{
                        resultado.StatusCode = 200;
                    }
                }
            }
            catch(Exception ex){
                resultado = new JsonResult("");
                resultado.StatusCode = 204;
                resultado.Value = ex.Message;
            }

            return (Json(resultado));
        }

        [HttpGet("{Id}",Name="ExibeTopico")]
        public IActionResult Get(int Id){
            var rs = new JsonResult(dao.Listar().Where(x=>x.Id==Id).FirstOrDefault()); //retorna primeiro dado que encontrar da lista que tiver o id informado
            rs.ContentType = "application/json";

            if(rs.Value==null){
                rs.StatusCode = 204;
                rs.Value = $"Resultado para id: {Id} não retornou dados.";
            }
            else
            {
                rs.StatusCode = 200;
            }

            return Json(rs);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Topico Topico){
           JsonResult resultado = null;

            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                else
                {
                    resultado = new JsonResult(""); 
                    resultado.ContentType = "application/json";

                    if(!dao.Atualizar(Topico))
                    {
                        resultado.StatusCode = 404;
                        resultado.Value = "Ocorreu um erro";
                    }
                    else{
                        resultado.StatusCode = 200;
                    }
                }
            }
            catch(Exception ex){
                resultado = new JsonResult("");
                resultado.StatusCode = 204;
                resultado.Value = ex.Message;
            }

            return (Json(resultado));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
        JsonResult resultado = null;

            try{
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                else
                {
                    resultado = new JsonResult(""); 
                    resultado.ContentType = "application/json";

                    if(!dao.Excluir(id))
                    {
                        resultado.StatusCode = 404;
                        resultado.Value = "Ocorreu um erro";
                    }
                    else{
                        resultado.StatusCode = 200;
                    }
                }
            }
            catch(Exception ex){
                resultado = new JsonResult("");
                resultado.StatusCode = 204;
                resultado.Value = ex.Message;
            }

            return (Json(resultado));
        }

    }
}