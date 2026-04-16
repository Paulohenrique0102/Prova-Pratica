using System;
using System.Collections.Generic;

public interface IManutencao
{
    string RealizarManutencao();
}
public abstract class Veiculo
{
protected string identificacao;
protected double capacidadeCarga;
protected string tipoCombustivel;

 public string Identificacao
  {
     get { return identificacao; }
     set { identificacao = value; }
  }

  public double CapacidadeCarga
  {
     get { return capacidadeCarga; }
     set { capacidadeCarga = value; }
   }

   public string TipoCombustivel
  {
      get { return tipoCombustivel; }
      set { tipoCombustivel = value; }
  }

  public abstract string RegistrarEntrega();
}

public class Caminhao : Veiculo, IManutencao
{
    public override string RegistrarEntrega()
    {
        return $"Caminhão {Identificacao} realizou entrega de grande volume.";
    }

  public string RealizarManutencao()
   {
        return $"Caminhão {Identificacao} passou por manutenção completa (motor e carga pesada).";
    }
}

public class Van : Veiculo, IManutencao
{
    public override string RegistrarEntrega()
    {
        return $"Van {Identificacao} realizou entrega urbana rápida.";
    }

  public string RealizarManutencao()
  {
        return $"Van {Identificacao} passou por manutenção leve (checagem geral).";
  }
}

class Program
{
    static void Main(string[] args)
    {
        
      Caminhao caminhao = new Caminhao()
      {
           Identificacao = "CAMDOPH",
           CapacidadeCarga = 67,
           TipoCombustivel = "Pespsi"
       };

      Van van = new Van()
       {
          Identificacao = "VANDOVICTOR",
           CapacidadeCarga = 2000,
           TipoCombustivel = "Cocacola"
       };
      
       List<Veiculo> veiculos = new List<Veiculo>();
       veiculos.Add(caminhao);
       veiculos.Add(van);

       foreach (Veiculo v in veiculos)
     {
      Console.WriteLine("=== Veículo ===");
     Console.WriteLine($"ID: {v.Identificacao}");
      Console.WriteLine($"Capacidade: {v.CapacidadeCarga} kg");
      Console.WriteLine($"Combustível: {v.TipoCombustivel}");

      Console.WriteLine(v.RegistrarEntrega());

 IManutencao manutencao = (IManutencao)v;
  Console.WriteLine(manutencao.RealizarManutencao());

    Console.WriteLine();
   }
  }
}
