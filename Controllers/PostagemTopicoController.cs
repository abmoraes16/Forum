using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoForum.Models;

namespace ProjetoForum.Controllers
{
    [Route ("api/[controller]")]
    public class PostagemTopicoController:Controller
    {
        DAOPostagem dao = new DAOPostagem();

        [HttpGet("{Id}")]
        
        public IActionResult Get(int id){
            var rs = new JsonResult(dao.Listar().Where(x=>x.IdTopico==id)); //retorna primeiro dado que encontrar da lista que tiver o id informado
            rs.ContentType = "application/json";

            if(rs.Value==null){
                rs.StatusCode = 204;
                rs.Value = $"Resultado para id: {0} não retornou dados.";
            }
            else
            {
                rs.StatusCode = 200;
            }

            return Json(rs);
        }

    }
}