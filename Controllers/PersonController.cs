using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController: ControllerBase
    {
        // Add database initialization soon


        private int _IdCounter = 0;
        public void SetIdCounter(int idx)
        {


             _IdCounter = idx + 1;
        }

        public int GetIdCounter()
        {
            return _IdCounter;
        }
        private static readonly List<string> Names = new List<string>
        {
            "Vasya"
        };
        private static readonly List<string> Surnames = new List<string>
        {
            "Kit"
        };

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            SetIdCounter(0);
            var random = new Random();

            return Enumerable.Range(0, 4).Select(Index => new Person
            {
                ID = GetIdCounter(),
                Age = random.Next(10, 90),
                Name = Names[random.Next(Names.Count)],
                Surname = Surnames[random.Next(Surnames.Count)]

            }).ToArray();

        }

        [HttpPost]
        public string ReturnResponseMessage([FromRoute] Person person)
        {
            return "OK";
        }

        [HttpPut]
        public string AddNewPersonData([FromBody] Person person)
        {
            // Create new contact from json request.
            // Need database to add full user.

            // var NewPerson = new Person
            // {
            //    ID = person.ID,
            //    Age = person.Age,
            //    Name = person.Name,
            //    Surname = person.Surname       
            // };

            // if(NewPerson == null)
            // {
            //     throw new Exception();
            // }

            // Updating.
            Names.Add(person.Name);
            Surnames.Add(person.Surname);

            return "Person added successfully! ";

        }

        [HttpDelete]
        public string DeleteCurrentUser([FromBody] Person person)
        {
            if(Names.Contains(person.Name) && Surnames.Contains(person.Surname))
            {
                Names.Remove(person.Name);
                Surnames.Remove(person.Surname);

                return "Person deleted successfully! ";
            }

            return "Can not delete user. User does not exists! ";
        }
    }
}
