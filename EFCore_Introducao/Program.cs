using EFCore_Introducao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Introducao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            AppDbContext db = new AppDbContext();

            //Client client = new Client()
            //{
            //    Name = "Matheus",
            //    Data_Nascimento = new DateTime(1998, 6, 20)
            //};

            //db.Client.Add(client);

            //client = new Client()
            //{
            //    Name = "Pedro",
            //    Data_Nascimento = new DateTime(1995, 5, 21)
            //};

            //db.Client.Add(client);

            //db.SaveChanges();

            //Buscando todos os registros de uma entidade
            var clients = db.Client.ToList();
            foreach (var item in clients)
            {
                Console.WriteLine($"id: {item.Id} - nome: {item.Name} - data nascimento: {item.Data_Nascimento}");
            }
            Console.WriteLine("-------");

            //Buscando registro e alterando propriedade
            var clientSelected = clients.Where(x => x.Id == 1).First();
            Console.WriteLine("selecionado = " + clientSelected.Name);
            clientSelected.Name = "Marcos";
            db.Entry<Client>(clientSelected);
            db.SaveChanges();

            //Excluíndo um registro
            db.Attach(clientSelected);
            db.Remove(clientSelected);
            db.SaveChanges();


            Console.ReadKey();
        }
    }
}
