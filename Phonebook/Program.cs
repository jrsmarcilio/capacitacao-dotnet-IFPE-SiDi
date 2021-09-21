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
      ArrayList contato = new ArrayList(11);
      ArrayList contato2 = new ArrayList(11);
      ArrayList contato3 = new ArrayList(11);

      contato.Add("Vieira");
      contato.Add("Soveral");
      contato.Add((TipoContato)2);
      contato.Add(81);
      contato.Add(99999999);
      contato.Add("valentino@g.com");
      contato.Add("Engenho do Meio");
      contato.Add("Recife");
      contato.Add("PE");
      DateTime date = new DateTime(1993, 04, 02);
      contato.Add(date);
      contato.Add(quantDiasFaltamParaProximoAniversario(04, 02));
      contato.Add("Observações");

      contato2.Add("Rebeca");
      contato2.Add("Gaspar");
      contato2.Add((TipoContato)0);
      contato2.Add(81);
      contato2.Add(9999999);
      contato2.Add("beca-gaspar@g.com");
      contato2.Add("Santana");
      contato2.Add("Jaboatao");
      contato2.Add("PE");
      DateTime date2 = new DateTime(1995, 12, 01);
      contato2.Add(date2);
      contato2.Add(quantDiasFaltamParaProximoAniversario(12, 01));
      contato2.Add("Observações");

      contato3.Add("Feliz");
      contato3.Add("Natal");
      contato3.Add((TipoContato)0);
      contato3.Add(12);
      contato3.Add(25252525);
      contato3.Add("noite-feliz@g.com");
      contato3.Add("Natal");
      contato3.Add("Rio Grande do Norte");
      contato3.Add("PE");
      DateTime date3 = new DateTime(1995, 12, 25);
      contato3.Add(date3);
      contato3.Add(quantDiasFaltamParaProximoAniversario(12, 25));
      contato3.Add("Ho! ho! ho!");

      phonebook.Add(contato);
      phonebook.Add(contato2);
      phonebook.Add(contato3);
      menu();
    }
    static void inserirContato()
    {
      ArrayList contato = new ArrayList(11);

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
      int dia = int.Parse(Console.ReadLine());

      Console.WriteLine("Informe o mês do aniversário: ");
      int mes = int.Parse(Console.ReadLine());

      Console.WriteLine("Informe o ano de nascimento: ");
      int ano = int.Parse(Console.ReadLine());

      DateTime date = new DateTime(ano, mes, dia);
      contato.Add(date);
      contato.Add(quantDiasFaltamParaProximoAniversario(mes, dia));

      Console.WriteLine("Observações: ");
      contato.Add(Console.ReadLine());

      phonebook.Add(contato);
    }
    static void imprimirContato(ArrayList contato, int index)
    {
      var aniversarioEm = (int)contato[10] == 0 ? "Próximo ano" : (contato[10] + " dias");
      using (DataTable dt = new DataTable("Contato"))
      {
        dt.Columns.Add("#", typeof(int));
        dt.Columns.Add("Nome", typeof(string));
        dt.Columns.Add("Tipo", typeof(string));
        dt.Columns.Add("Telefone", typeof(string));
        dt.Columns.Add("Email", typeof(string));
        dt.Columns.Add("Dias p/ Aniversário", typeof(string));

        dt.Rows.Add(index, contato[0], contato[2], (contato[3] + " " + contato[4]), contato[5], aniversarioEm);

        foreach (DataRow dr in dt.Rows)
        {
          Console.WriteLine("# {0} \tNome: {1} \tTipo: {2} \tTelefone: {3} \tEmail: {4} \tAniversário em: {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
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
    static int quantDiasFaltamParaProximoAniversario(int mes, int dia)
    {
      if (mes > DateTime.Now.Month && dia > DateTime.Now.Day)
      {
        DateTime DataAniversario = new DateTime(2021, mes, dia);
        return (int)DataAniversario.Subtract(DateTime.Today).TotalDays;
      }
      else
      {
        return 0;
      }
      // CultureInfo culture = new CultureInfo("pt-BR");
      // Console.WriteLine(thisDate.ToString("d", culture));
    }
    static void menu()
    {
      int opcao = 1;
      do
      {
        Console.WriteLine("1 - Adicionar contato\n2 - Buscar pelo primeiro nome\n3 - Buscar por nome completo\n4 - Buscar por Tipo de Contato\n5 - Buscar por cidade\n6 - Remover contato\n7 - Listar contatos\n0 - Sair");
        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
          case 1:
            System.Console.WriteLine("A opção para adicionar contato foi selecionada.");
            inserirContato();
            break;
          case 2:
            System.Console.WriteLine("Buscar contato pelo primeiro nome: >>> ");
            buscarPeloPrimeiroNome(Console.ReadLine());
            break;
          case 3:
            System.Console.WriteLine("Buscar contato por nome completo: >>> ");
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
            System.Console.WriteLine("Buscar contato pela cidade: >>> ");
            buscarPorCidade(Console.ReadLine());
            break;
          case 6:
            System.Console.WriteLine("A opção para deletar contato foi selecionada.");
            foreach (ArrayList contato in phonebook)
            {
              imprimirContato(contato, (int)phonebook.IndexOf(contato));
            }
            Console.WriteLine("\nA opção remover contato foi selecionada: ");
            Console.WriteLine("Informe o id do contato para remoção: ");
            removerContato(int.Parse(Console.ReadLine()));
            break;
          case 7:
          System.Console.WriteLine("Listando os contatos armazenados.");
          foreach (ArrayList contato in phonebook)
          {
            imprimirContato(contato, (int)phonebook.IndexOf(contato));
          }
          break;
          case 0:
            System.Console.WriteLine("Saindo do app phonebook...Bye!");
            Environment.Exit(0);
            break;
        }
      } while (true);
    }
    static void Main(string[] args)
    {
      mockContatos();
      menu();
    }
  }
}
