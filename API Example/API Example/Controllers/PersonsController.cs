using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Example.Controllers
{
    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    public class PersonsController : ApiController
    {
        static List<Person> people = new List<Person>()
        {
            new Person(){Id=101, Name="Shakib", Salary=30000},
            new Person(){Id=102, Name="Tamim", Salary=20000},
        };

        /*public IHttpActionResult GetPersons() 
        {
            return Ok(people);
        }*/
        public IHttpActionResult Get()
        {
            return Ok(people);
        }
        public IHttpActionResult Get(int id)
        {
            var person=people.Find(i => i.Id == id);
            if (person == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(person);
        }

        public IHttpActionResult Post(Person person)
        {
            people.Add(person);
            return StatusCode(HttpStatusCode.Created);
        }

    }
}
