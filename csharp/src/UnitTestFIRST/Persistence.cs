using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestFIRST
{
    public class Persistence
    {
        private static readonly string SRC_MAIN_RESOURCES_CORE = "../src/resources/core/";
        public IEnumerable<string> RetrieveFromPersistence(string fileName)
        {
            try
            {
                var file = new FileInfo(SRC_MAIN_RESOURCES_CORE+fileName);
                return File.ReadAllLines(file.FullName).ToList();
            }
            catch(Exception exception) 
            {
                throw exception;
            }
            finally
            {
                new List<string>();
            }
        }

        public void StoreToPersistence(IEnumerable<Contact> contacts, string fileName)
        {
            using (var fileStream = new FileStream(new FileInfo(SRC_MAIN_RESOURCES_CORE + fileName).FullName, FileMode.Create))
            {
                using (var fileWriter=  new StreamWriter(fileStream))
                {
                    contacts.ToList().ForEach(c =>
                    {
                        fileWriter.WriteLine(c.PhoneNumber + ';' + c.Name);
                    });
                }
            }
        }
    }
}
