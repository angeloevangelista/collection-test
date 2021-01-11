using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionTest.Data;
using CollectionTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CollectionTest.Controllers
{
  [ApiController]
  [Route("humanos")]
  public class HumanoController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<Humano> Index()
    {
      var context = new Context();

      var humanos = context.Humanos.AsNoTracking().ToList();

      return humanos;
    }

    [HttpPost]
    public Humano Create()
    {
      var apelido = new Apelido
      {
        Conteudo = $"Angelao - {DateTime.Now.GetHashCode()}"
      };

      var humano = new Humano();
      humano.DarApelido(apelido);

      var context = new Context();

      context.Humanos.Add(humano);
      context.SaveChanges();

      return humano;
    }
  }
}
