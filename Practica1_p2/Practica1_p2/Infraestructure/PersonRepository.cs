// Cauich Collí Rafael
// 4A DSM

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
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }
        // Lista de las consultas



        // retornar todos los datos
        public IEnumerable<Person> GetAll()
        {
            var query = _persons.Select(person => person);
            return query;
        }

        // retornar campos especificos
        public IEnumerable<Object> GetFields()
        {
            var query = _persons.Select(person => new {
                NombreCompleto = $"{person.FirstName} {person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1),
                Correo = person.Email
            });

            return query;
        }
        // retornar elementos que sean iguales
        public IEnumerable<Person> GetById()
        {
            var generador = new Random(DateTime.Now.Millisecond);
            var id = generador.Next(1000);
            var query = _persons.Where(person => person.Id == id);
            return query;
        }

        public IEnumerable<Person> GetByGender()
        {
            var gender = 'M';
            var query = _persons.Where(person => person.Gender == gender);
            return query;
        }

        public IEnumerable<Person> GetByGenderAndAge()
        {
            var gender = 'M';
            var age = 33;
            var query = _persons.Where(person => person.Gender == gender && person.Age == age);
            return query;
        }
        // Retornar elementos que sean diferentes
        public IEnumerable<Person> GetDiferences()
        {
            var job = "Civil Engineer";
            var query = _persons.Where(person => person.Job != job);
            return query;
        }
        public IEnumerable<string> GetDistinct()
        {            
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        }
        // retornar valores que contengan
        public IEnumerable<Person> GetContains()
        {            
            var query = _persons.Where(person => person.FirstName.Contains("ar"));
            return query;
        }
        public IEnumerable<Person> GetByAges()
        {
            var ages = new List<int>{15,25,35,45,55,65};
            var query = _persons.Where(Person => ages.Contains(Person.Age));
            return query;
        }
        // retornar valores entre un rango
        public IEnumerable<Person> GetByRangeAge()
        {
            var minAge = 30;
            var maxAge = 40;
            var query = _persons.Where(Person => Person.Age >= minAge && Person.Age <= maxAge);
            return query;
        }
        // retornar elementos ordenados
        public IEnumerable<Person> GetPersonsOrdered()
        {
            var job = "Payment Adjustment Coordinator";
            var query = _persons.Where(person => person.Job == job).OrderBy(person => person.LastName);
            return query;
        }

        public IEnumerable<Person> GetPersonsOrderedDescending()
        {
            var job = "Payment Adjustment Coordinator";
            var query = _persons.Where(person => person.Job == job).OrderByDescending(person => person.LastName);
            return query;
        }
        // retorno cantidad de elementos
        public int CountPerson()
        {
            var gender = 'F';
            var query = _persons.Count(person => person.Gender == gender);
            return query;
        }
        // Evalua si un elemento existe
        public bool ExistPerson()
        {
            var lastName = "Tuffell";
            var query = _persons.Exists(person => person.LastName == lastName);
            return query;
        }
        // retornar solo un elemento
        public Person GetPerson()
        {
            var id = 340;
            var query = _persons.FirstOrDefault(person => person.Id == id);
            return query;
        }
        // retornar solamente unos elementos
        public IEnumerable<Person> TakePerson()
        {
            var job = "Geological Engineer";
            var take = 3;
            var query = _persons.Where(person => person.Job == job).Take(take);
            return query;
        }
        public IEnumerable<Person> TakeLastPerson()
        {
            var job = "Geological Engineer";
            var take = 3;
            var query = _persons.Where(person => person.Job == job).TakeLast(take);
            return query;
        }
        // retornar elementos saltando posición
        public IEnumerable<Person> SkipPerson()
        {
            var job = "Professor";
            var skip = 4;
            var query = _persons.Where(person => person.Job == job).Skip(skip);
            return query;
        }
        public IEnumerable<Person> SkipTakePerson()
        {
            var job = "Professor";
            var skip = 4;
            var take = 3;
            var query = _persons.Where(person => person.Job == job).Skip(skip).Take(take);
            return query;
        }
    }
}