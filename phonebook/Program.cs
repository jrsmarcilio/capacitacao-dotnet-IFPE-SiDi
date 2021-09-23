using System;
using System.Collections;
using System.Data;

namespace Phonebook
{
  class Program
  {
    static ArrayList Phonebook = new ArrayList(100);
    public struct Contact
    {
      public int id { get; set; }
      public string firstName { get; set; }
      public string lastName { get; set; }
      public string cellphone { get; set; }
      public int cellphoneCode { get; set; }
      public ContactType contactType { get; set; }
      public string email { get; set; }
      public DateTime birthDate { get; set; }
      public string comments { get; set; }
      public string district { get; set; }
      public string city { get; set; }
      public string state { get; set; }

      public string DaysToBirthday(DateTime birthDate)
      {
        if (birthDate.Month >= DateTime.Now.Month && birthDate.Day >= DateTime.Now.Day)
        {
          return (int)birthDate.AddYears((DateTime.Now.Year - birthDate.Year)).Subtract(DateTime.Today).TotalDays + " dias";
        }
        return "No próximo ano";
      }

      public override String ToString() =>
        $"\n# {id} \tNome: {firstName} \tTipo: {contactType} \tTelefone: {cellphoneCode + " " + cellphone} \tEmail: {email} \tAniversário em: {DaysToBirthday(birthDate)}";
    }
    public enum ContactType
    {
      Celular, Trabalho, Casa, Principal, Pager, FaxTrabalho, FaxCasa, Outro
    }
    static void AddContact()
    {
      Contact contact = new Contact();

      contact.id = Phonebook.Count;

      Console.WriteLine("Informe o primeiro nome: ");
      contact.firstName = Console.ReadLine();

      Console.WriteLine("Informe o sobrenome: ");
      contact.lastName = Console.ReadLine();

      Console.WriteLine("Informe o tipo do contato: ");
      foreach (var i in Enum.GetNames(typeof(ContactType)))
      {
        Console.WriteLine((int)Enum.Parse(typeof(ContactType), i) + " - " + i);
      }
      contact.contactType = ((ContactType)(int.Parse(Console.ReadLine())));

      Console.WriteLine("Informe o DDD da região: ");
      contact.cellphoneCode = (int.Parse(Console.ReadLine()));

      Console.WriteLine("Informe o telefone: ");
      contact.cellphone = Console.ReadLine();

      Console.WriteLine("Informe o Email: ");
      contact.email = Console.ReadLine();

      Console.WriteLine("Informe o bairro: ");
      contact.district = Console.ReadLine();

      Console.WriteLine("Informe o cidade: ");
      contact.city = Console.ReadLine();

      Console.WriteLine("Informe o estado: ");
      contact.state = Console.ReadLine();

      Console.WriteLine("Informe o dia do aniversário: ");
      int day = (int.Parse(Console.ReadLine()));

      Console.WriteLine("Informe o mês do aniversário: ");
      int month = (int.Parse(Console.ReadLine()));

      Console.WriteLine("Informe o ano de nascimento: ");
      int year = (int.Parse(Console.ReadLine()));

      contact.birthDate = new DateTime(year, month, day);

      Console.WriteLine("Observações: ");
      contact.comments = Console.ReadLine();

      Phonebook.Add(contact);
    }
    static void RemoveContact(int id)
    {
      Phonebook.RemoveAt(id);
    }
    static void LoadContacts()
    {
      Contact contact = new Contact();
      Contact contact2 = new Contact();
      Contact contact3 = new Contact();

      contact.id = 0;
      contact2.id = 1;
      contact3.id = 2;

      contact.firstName = "Homer Simpson";
      contact2.firstName = "Bart Simpson";
      contact3.firstName = "Natal";

      contact.lastName = "LastName";
      contact2.lastName = "LastName";
      contact3.lastName = "LastName";

      contact.cellphone = "9 9999-9999";
      contact2.cellphone = "9 9999-9999";
      contact3.cellphone = "9 9999-9999";

      contact.cellphoneCode = 81;
      contact2.cellphoneCode = 81;
      contact3.cellphoneCode = 81;

      contact.contactType = ((ContactType)0);
      contact2.contactType = ((ContactType)1);
      contact3.contactType = ((ContactType)2);

      contact.email = "mailto.mail.com";
      contact2.email = "mailto.mail.com";
      contact3.email = "mailto.mail.com";

      contact.birthDate = new DateTime(1993, 04, 02);
      contact2.birthDate = new DateTime(2000, 08, 01);
      contact3.birthDate = new DateTime(2000, 12, 25);

      contact.district = "Engenho do meio";
      contact2.district = "Santana";
      contact3.district = "Maranguape I";

      contact.city = "Recife";
      contact2.city = "Jaboatão";
      contact3.city = "Paulista";

      contact.state = "PE";
      contact2.state = "PE";
      contact3.state = "PE";

      contact.comments = "null";
      contact2.comments = "null";
      contact3.comments = "null";

      Phonebook.Add(contact);
      Phonebook.Add(contact2);
      Phonebook.Add(contact3);
    }
    static Contact SearchContactFirstName(string firstName)
    {
      bool isExist = false;
      foreach (Contact contact in Phonebook)
      {
        if (contact.firstName.Equals(firstName))
        {
          isExist = true;
          System.Console.WriteLine(contact.ToString());
          return contact;
        }
      }
      if (!isExist)
      {
        System.Console.WriteLine("Nenhum contato encontrado com o nome {0}", firstName);
        return new Contact();
      }
      return new Contact();
    }
    static Contact SearchContactFullName(string firstName, string lastName)
    {
      bool isExist = false;
      foreach (Contact contact in Phonebook)
      {
        if (contact.firstName.Equals(firstName) && contact.lastName.Equals(lastName))
        {
          isExist = true;
          System.Console.WriteLine(contact.ToString());
          return contact;
        }
      }
      if (!isExist)
      {
        System.Console.WriteLine("Nenhum contato encontrado com o nome {0} e sobrenome {1}", firstName, lastName);
        return new Contact();
      }
      return new Contact();
    }
    static Contact SearchContactToContactType(ContactType contactType)
    {
      bool isExist = false;
      foreach (Contact contact in Phonebook)
      {
        if (contact.contactType.Equals(contactType))
        {
          isExist = true;
          System.Console.WriteLine(contact.ToString());
          return contact;
        }
      }
      if (!isExist)
      {
        System.Console.WriteLine("Nenhum contato encontrado com o tipo selecionado.");
        return new Contact();
      }
      return new Contact();
    }
    static Contact SearchContactCity(string city)
    {
      bool isExist = false;
      foreach (Contact contact in Phonebook)
      {
        if (contact.city.Equals(city))
        {
          isExist = true;
          System.Console.WriteLine(contact.ToString());
          return contact;
        }
      }
      if (!isExist)
      {
        System.Console.WriteLine("Nenhum contato encontrado com a cidade {0}", city);
        return new Contact();
      }
      return new Contact();
    }
    static void OptionsMenu()
    {
      int optionSelect = -1;
      do
      {
        System.Console.WriteLine("\n1 - Adicionar contato\n2 - Buscar pelo primeiro nome\n3 - Buscar por nome completo\n4 - Buscar por Tipo de Contato\n5 - Buscar por cidade\n6 - Remover contato\n7 - Listar contatos\n0 - Sair");

        optionSelect = int.Parse(System.Console.ReadLine());

        switch (optionSelect)
        {
          case 1:
            System.Console.WriteLine("A opção de adicionar contato foi selecionada.");
            AddContact();
            break;
          case 2:
            System.Console.WriteLine("A opção de buscar pelo primeiro nome foi selecionada.\nInforme o nome do contato: ");
            SearchContactFirstName(System.Console.ReadLine());
            break;
          case 3:
            System.Console.WriteLine("A opção de buscar por nome e sobrenome foi selecionada.\nInforme o nome do contato: ");
            string firstName = System.Console.ReadLine();
            System.Console.WriteLine("\nInforme o sobrenome do usuário");
            string lastName = System.Console.ReadLine();
            SearchContactFullName(firstName, lastName);
            break;
          case 4:
            System.Console.WriteLine("A opção de buscar pelo tipo do contato foi selecionada.");
            foreach (var enumItemName in Enum.GetNames(typeof(ContactType)))
            {
              System.Console.WriteLine((int)Enum.Parse(typeof(ContactType), enumItemName) + " - " + enumItemName);
            }
            System.Console.WriteLine("Informe o tipo de contato. Ex.: 0");
            SearchContactToContactType((ContactType)(int.Parse(System.Console.ReadLine())));
            break;
          case 5:
            System.Console.WriteLine("A opção de buscar por cidade do contato foi selecionada.");
            SearchContactCity(System.Console.ReadLine());
            break;
          case 6:
            System.Console.WriteLine("#### Atenção ####\nA opção de remover contato foi selecionada.");
            foreach (Contact contact in Phonebook)
            {
              System.Console.WriteLine(contact.ToString());
              System.Console.WriteLine("Informe o ID do usuário para Deleção:");
            }
            RemoveContact(int.Parse(System.Console.ReadLine()));
            break;
          case 7:
            System.Console.WriteLine("A opção de listagem dos contatos foi selecionada.");
            if (Phonebook.Count.Equals(0))
            {
              System.Console.WriteLine("Nenhum contato cadastrado.");
            }
            foreach (Contact contact in Phonebook)
            {
              System.Console.WriteLine(contact.ToString());
            }
            break;
          case 0:
            System.Console.WriteLine("Saindo do app Phonebook...");
            Environment.Exit(0);
            break;
        }

      } while (true);
    }
    static void Main(string[] args)
    {
      LoadContacts();
      OptionsMenu();
    }
  }
}
