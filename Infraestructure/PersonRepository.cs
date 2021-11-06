using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Persona> pers;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                pers = JsonSerializer.Deserialize<IEnumerable<Persona>>(json).ToList();
            }
        }

        public IEnumerable<Persona> GetAll()
        {
            var query =  pers.Select(person => person);
            return query;
        }

        public IEnumerable<Object> GetFields()
        {
            var query = pers.Select(person => new {
                NombreCompleto = $"{person.FirstName} {person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1),
                Correo = person.Email
            });

            return query;
        }
        public IEnumerable<Persona> ObtenerGenero()
        {
            var gender = 'F';
            var query = pers.Where(person => person.Gender == gender);
            return query;
        }
        public IEnumerable<Persona> MayorEdad()
        {
            var age = 40;
            var query =  pers.Where(person => person.Age > age);
            return query;
        }

        public IEnumerable<Persona> GetDiferences()
        {
            var job = "Civil Engineer";
            var query = pers.Where(person => person.Job != job);
            return query;
        }
        public IEnumerable<Persona> GetContains()
        {            
            var query =  pers.Where(person => person.FirstName.Contains("ar"));
            return query;
        }
        public IEnumerable<Persona> GetByAges()
        {
            var ages = new List<int>{25,35,45};
            var query = pers.Where(Person => ages.Contains(Person.Age));
            return query;
        }
        public IEnumerable<Persona> GetByRangeAge()
        {
            var minAge = 20;
            var maxAge = 30;
            var query =  pers.Where(Person => Person.Age >= minAge && Person.Age <= maxAge);
            return query;
        }

        public IEnumerable<Persona> GetPersonsOrderedDescending()
        {
            var gender = 'M';
            var minAge = 20;
            var maxAge = 30;
            var query = pers.Where(person => person.Gender == gender && person.Age >= minAge && person.Age <= maxAge).OrderByDescending(person => person.Age);
            return query;
        }
        public int CountFemenino()
        {
            var gender = 'F';
            var query =  pers.Count(person => person.Gender == gender);
            return query;
        }
        public bool ExistPersona()
        {
            var lastName = "Shemelt";
            var query =  pers.Exists(person => person.LastName == lastName);
            return query;
        }


        public IEnumerable<Persona> TakePersonAngAge()
        {
            var job = "Software Consultant";
            var take = 1;
            var Age = 25;
            var query = pers.Where(person => person.Job == job && person.Age == Age).Take(take);
            return query;
        }
        public IEnumerable<Persona> TakePersona()
        {
            var job = "Software Consultant";
            var take = 3;
            var query =  pers.Where(person => person.Job == job).Take(take);
            return query;
        }
        
        public IEnumerable<Persona> SkipPersona()
        {
            var job = "Software Consultant";
            var skip = 3;
            var query = pers.Where(person => person.Job == job).Skip(skip);
            return query;
        }
        public IEnumerable<Persona> SkipTakePersona()
        {
            var job = "Software Consultant";
            var skip = 3;
            var take = 3;
            var query = pers.Where(person => person.Job == job).Skip(skip).Take(take);
            return query;
        }
    }
}