using System.Collections.Generic;
using CollectionTest.Entities;

namespace CollectionTest.ViewModels
{
  public class HumanoViewModel
  {
    public HumanoViewModel() 
    {
    }
    
    public HumanoViewModel(Humano humano)
    {
      Nome = humano.Nome;
      Apelidos = new List<ApelidoViewModel>();

      foreach (var apelido in humano.Apelidos)
        Apelidos.Add(new ApelidoViewModel(apelido));
    }

    public string Nome { get; set; }
    public List<ApelidoViewModel> Apelidos { get; set; }
  }
}