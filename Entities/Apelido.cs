using System.Collections.Generic;
using System.Linq;

namespace CollectionTest.Entities
{
  public class Apelido
  {
    public int Id { get; set; }
    public int HumanoId { get; set; }
    public Humano Humano { get; set; }
    public string Conteudo { get; set; }
  }
}