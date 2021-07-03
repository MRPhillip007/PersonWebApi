using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController: ControllerBase
    {
        // Database initialization

        private readonly AppDbContex _context;
        public PersonController(AppDbContex context)
        {
            _context = context;
        }
        
        [HttpGet]
        public  List<Person> GetPersons([FromQuery]string orderBy, string search)
        {
            var personList = new List<Person>();

            if(!String.IsNullOrWhiteSpace(search))
            {
                personList = _context.Persons.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            else
            {
                personList = _context.Persons.ToList();
            }

            if(!String.IsNullOrEmpty(orderBy))
            {
                switch(orderBy.ToLower())
                {
                    case "name":
                    personList = _context.Persons.OrderBy(x => x.Name).ToList();
                    break;

                    case "surname":
                    personList = _context.Persons.OrderBy(x => x.Surname).ToList();
                    break;

                    case "age":
                    personList = _context.Persons.OrderBy(x => x.Age).ToList();
                    break;

                }

            }

            return personList;
          
        }

        [HttpPost]
        public string AddUser([FromBody] Person person)
        {
            if(person == null)
            {
                throw new Exception();
            }

            var NewPerson = new Person
            {
                ID = person.ID,
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age
            };


            _context.Add(NewPerson);
            _context.SaveChanges();

            return "User added successfully! ";
            
        }
        


    }
}
