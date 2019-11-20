using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestFIRST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start generate phone book file");
            GenerateContacts();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void GenerateContacts()
        {
            Persistence persistence = new Persistence();
            IEnumerable<string> firstNames = persistence.RetrieveFromPersistence("first_name_aleatoire.csv");
            IEnumerable<string> lastNames = persistence.RetrieveFromPersistence("last_name_aleatoire.csv");

            List<string> names = firstNames.SelectMany(fn => lastNames.Select(ln => fn + " " + ln)).ToList();
            var contacts = new List<Contact>();
            names.ForEach(n=> contacts.Add(new Contact(n, GenerateNumber(n.Length/2))));
            persistence.StoreToPersistence(contacts.OrderBy(x => Guid.NewGuid()).ToList(), "my-contacts.csv");

        }

        private static string GenerateNumber(int count)
        {
            var random = new Random();
            var number = $"061";
            for (int i = 0; i < 7; i++)
            {
                number = number + random.Next(0, count);
            }

            return number;
        }
    }
}
