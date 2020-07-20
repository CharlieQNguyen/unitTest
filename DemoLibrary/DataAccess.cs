using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class DataAccess
    {
        private static string personTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = GetAllPeople(); // get the people

            AddPersonToPeopleList(people, person); // add person to the list

            List<string> lines = ConvertModelsToCSV(people); // convert person to people list to CSV file

            File.WriteAllLines(personTextFile, lines); // finally we write that into the file
        }

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if(string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "FirstName");
            }
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "LastName");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            List<string> output = new List<string>(); // get list of people

            foreach (PersonModel user in people)     // taking people list and for each one I will create my CSV
            {
                output.Add($"{user.FirstName}, {user.LastName}");
            }

            return output;
        }

        public static List<PersonModel> GetAllPeople()
        {
            List<PersonModel> output = new List<PersonModel>();
            string[] content = File.ReadAllLines(personTextFile);

            foreach (string line in content)
            {
                string[] data = line.Split(',');
                output.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
            }

            return output;
        }
    }
}
