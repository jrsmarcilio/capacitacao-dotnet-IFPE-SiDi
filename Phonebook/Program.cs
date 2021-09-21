using System;
using System.Collections;
using System.Data;

namespace Phonebook
{
  class Program
  {
    static ArrayList phonebook = new ArrayList(100);
    enum TipoContato
    {
      Celular, Trabalho, Casa, Principal, Pager, FaxTrabalho, FaxCasa, Outro
    }
    static void mockContatos()
    {
      ArrayList contato = new ArrayList(13);
      ArrayList contato2 = new ArrayList(13);

      contato.Add("Marcilio");
      contato.Add("Junior");
      contato.Add((TipoContato)2);
      contato.Add(81);
      contato.Add(95919313);
      contato.Add("jrsmarcilio@gmail.com");
      contato.Add("Eng do Meio");
      contato.Add("Recife");
      contato.Add("PE");
      contato.Add(02);
      contato.Add(04);
      contato.Add(1993);
      contato.Add("Observações");

      contato2.Add("Marcilio");
      contato2.Add("Mendonca");
      contato2.Add((TipoContato)0);
      contato2.Add(81);
      contato2.Add(95919313);
      contato2.Add("mdmendonca@gmail.com");
      contato2.Add("Santana");
      contato2.Add("Jaboatao");
      contato2.Add("PE");
      contato2.Add(02);
      contato2.Add(04);
      contato2.Add(1993);
      contato2.Add("Observações");

      phonebook.Add(contato);
      phonebook.Add(contato2);
      menu();
    }
    static void inserirContato()
    {
      ArrayList contato = new ArrayList(13);
      Console.WriteLine("Informe seu nome: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe seu sobrenome: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o tipo de contato desejado: ");
      foreach (var i in Enum.GetNames(typeof(TipoContato)))
      {
        Console.WriteLine((int)Enum.Parse(typeof(TipoContato), i) + " - " + i);
      }
      contato.Add((TipoContato)(int.Parse(Console.ReadLine())));

      Console.WriteLine("Informe o DDD da região: ");
      contato.Add(int.Parse(Console.ReadLine()));

      Console.WriteLine("Informe o telefone: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o Email: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o bairro: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o cidade: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o estado: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o dia do aniversário: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o mês do aniversário: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Informe o ano de nascimento: ");
      contato.Add(Console.ReadLine());

      Console.WriteLine("Observações: ");
      contato.Add(Console.ReadLine());

      phonebook.Add(contato);
    }
    static void imprimirContato(ArrayList contato, int index)
    {

      using (DataTable dt = new DataTable("Contato"))
      {
        dt.Columns.Add("#", typeof(int));
        dt.Columns.Add("Nome", typeof(string));
        dt.Columns.Add("Sobrenome", typeof(string));
        dt.Columns.Add("Telefone", typeof(string));
        dt.Columns.Add("Tipo", typeof(string));
        dt.Columns.Add("Cidade", typeof(string));

        dt.Rows.Add(index, contato[0], contato[1], (contato[3] + " " + contato[4]),
         contato[2], contato[7]);

        foreach (DataRow dr in dt.Rows)
        {
          Console.WriteLine("# {0} \t Nome: {1} \t Sobrenome: {2} \t Telefone: {3} \t Tipo: {4} \t Cidade: {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
        }
      }
    }
    static void buscarPeloPrimeiroNome(string nome)
    {
      bool isNotExist = true;
      foreach (ArrayList contato in phonebook)
      {
        if (contato[0].ToString().Equals(nome))
        {
          imprimirContato(contato, (int)phonebook.IndexOf(contato));
          isNotExist = false;
        }
      }
      if (isNotExist)
      {
        System.Console.WriteLine("\nNenhum contato foi encontrado.");
      }
    }
    static void buscarPorNomeCompleto(string nomeCompleto)
    {
      bool isNotExist = true;
      foreach (ArrayList contato in phonebook)
      {
        if ((contato[0].ToString() + " " + contato[1].ToString()).Equals(nomeCompleto))
        {
          imprimirContato(contato, (int)phonebook.IndexOf(contato));
          isNotExist = false;
        }
      }
      if (isNotExist)
      {
        System.Console.WriteLine("\nNenhum contato foi encontrado.");
      }
    }
    static void buscarPorTipoContato(TipoContato tpContato)
    {
      bool isNotExist = true;
      foreach (ArrayList contato in phonebook)
      {
        if (contato[2].Equals(tpContato))
        {
          imprimirContato(contato, (int)phonebook.IndexOf(contato));
          isNotExist = false;
        }
      }
      if (isNotExist)
      {
        System.Console.WriteLine("\nNenhum contato foi encontrado com o tipo escolhido.");
      }
    }
    static void buscarPorCidade(string cidade)
    {
      bool isNotExist = true;
      foreach (ArrayList contato in phonebook)
      {
        if (contato[7].Equals(cidade))
        {
          imprimirContato(contato, (int)phonebook.IndexOf(contato));
          isNotExist = false;
        }
      }
      if (isNotExist)
      {
        System.Console.WriteLine("\nNenhum contato foi encontrado com o tipo escolhido.");
      }
    }
    static void removerContato(int id)
    {
      bool isNotExist = true;
      if (isNotExist)
      {
        phonebook.RemoveAt(id);
        isNotExist = false;
      }
      else
      {
        System.Console.WriteLine("O ID informado não confere com os contatos cadastrados.");
      }
    }
    static void menu()
    {
      int opcao = 1;
      do
      {
        Console.WriteLine("1 - Adicionar contato\n2 - Buscar pelo primeiro nome\n3 - Buscar por nome completo\n4 - Buscar por Tipo de Contato\n5 - Buscar por cidade\n6 - Remover contato\n0 - Sair");
        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
          case 1:
            inserirContato();
            break;
          case 2:
            buscarPeloPrimeiroNome(Console.ReadLine());
            break;
          case 3:
            buscarPorNomeCompleto(Console.ReadLine());
            break;
          case 4:
            Console.WriteLine("Informe o tipo de contato desejado para pesquisa: ");
            foreach (var i in Enum.GetNames(typeof(TipoContato)))
            {
              Console.WriteLine((int)Enum.Parse(typeof(TipoContato), i) + " - " + i);
            }
            buscarPorTipoContato((TipoContato)(int.Parse(Console.ReadLine())));
            break;
          case 5:
            buscarPorCidade(Console.ReadLine());
            break;
          case 6:
            foreach (ArrayList contato in phonebook)
            {
              imprimirContato(contato, (int)phonebook.IndexOf(contato));
            }
            // Console.WriteLine("\nA opção remover contato foi selecionada: ");
            // Console.WriteLine("Informe o id do contato para remoção: ");
            removerContato(int.Parse(Console.ReadLine()));
            break;
          case 0:
            Environment.Exit(0);
            break;
        }
      } while (true);
    }
    static void Main(string[] args)
    {

      mockContatos();
      menu();

      int i = 0;
      foreach (ArrayList contato in phonebook)
      {
        Console.WriteLine("Nome: {0}\nTelefone: {1}\nTipo de Contato: {2}\n", contato[i], contato[i + 1], contato[i + 2]);
      }

      System.Console.WriteLine(phonebook);
    }
  }
}
