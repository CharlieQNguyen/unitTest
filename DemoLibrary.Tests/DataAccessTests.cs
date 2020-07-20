using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" }; // created newPerson model
            List<PersonModel> people = new List<PersonModel>(); // create a list of PersonModel

            DataAccess.AddPersonToPeopleList(people, newPerson); // add newPerson to the people list

            Assert.True(people.Count == 1); // checking to see if the count of the person is 1 because originally list start at 0
            Assert.Contains<PersonModel>(newPerson, people); // check to see if you have a new person
        }

        [Theory]
        [InlineData("Tim", "", "LastName")]
        [InlineData("", "Corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName }; // created newPerson model
            List<PersonModel> people = new List<PersonModel>(); // create a list of PersonModel

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }
    }
}
