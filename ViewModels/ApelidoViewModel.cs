using System.Collections.Generic;
using CollectionTest.Entities;

namespace CollectionTest.ViewModels
{
  public class ApelidoViewModel
  {
    public ApelidoViewModel()
    {
    }

    public ApelidoViewModel(Apelido apelido)
    {
      Conteudo = apelido.Conteudo;
    }

    public string Conteudo { get; set; }
  }
}