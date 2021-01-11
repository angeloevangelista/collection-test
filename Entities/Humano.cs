using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionTest.Entities
{
  public class Humano
  {
    private readonly IList<Apelido> _apelidos;

    public Humano()
    {
      _apelidos = new List<Apelido>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Apelido> Apelidos { get => _apelidos.AsEnumerable(); }

    public void DarApelido(Apelido apelido)
    {
      if (_apelidos.Any(pre => pre.Conteudo == apelido.Conteudo))
        throw new Exception("Chegou tarde, campeão.");

      _apelidos.Add(apelido);
    }
  }
}