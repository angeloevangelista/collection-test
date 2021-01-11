using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionTest.Data;
using CollectionTest.Entities;
using CollectionTest.ViewModels;
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
    public ActionResult<IEnumerable<HumanoViewModel>> Index()
    {
      var context = new Context();

      var humanos = context.Humanos
        .AsNoTracking()
        .Include(pre => pre.Apelidos)
        .ToList()
        .Select(pre => new HumanoViewModel(pre));

      return Ok(humanos);
    }

    [HttpGet]
    [Route("{humanoId}")]
    public ActionResult<HumanoViewModel> Find(
      [FromRoute] int humanoId)
    {
      var context = new Context();

      var humano = context.Humanos
        .AsNoTracking()
        .Include(pre => pre.Apelidos)
        .FirstOrDefault(pre => pre.Id == humanoId);

      return humano != null
        ? Ok(new HumanoViewModel(humano))
        : BadRequest();
    }

    [HttpPost]
    public ActionResult<HumanoViewModel> Create(
      [FromBody] HumanoViewModel model)
    {
      var humano = new Humano
      {
        Nome = model.Nome,
      };

      foreach (var apelido in model.Apelidos)
        humano.DarApelido(new Apelido(apelido.Conteudo));

      var context = new Context();

      context.Humanos.Add(humano);
      context.SaveChanges();

      return new CreatedResult("", new HumanoViewModel(humano));
    }

    [HttpPut]
    [Route("{humanoId}")]
    public ActionResult<HumanoViewModel> Update(
      [FromRoute] int humanoId,
      [FromBody] HumanoViewModel model)
    {
      var context = new Context();

      var humano = context.Humanos
        .Include(pre => pre.Apelidos)
        .FirstOrDefault(pre => pre.Id == humanoId);

      if (humano == null)
        return BadRequest();

      humano.Nome = model.Nome;

      context.Entry<Humano>(humano).State = EntityState.Modified;
      context.SaveChanges();

      return Ok(new HumanoViewModel(humano));
    }

    [HttpDelete]
    [Route("{humanoId}")]
    public ActionResult Destroy(
    [FromRoute] int humanoId)
    {
      var context = new Context();

      var humano = context.Humanos.Find(humanoId);

      if (humano == null)
        return BadRequest();

      context.Entry<Humano>(humano).State = EntityState.Deleted;
      context.SaveChanges();

      return NoContent();
    }
  }
}
