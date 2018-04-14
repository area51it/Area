using Area51.ApiRepositoryContracts;
using Area51.ApiRepositoryContracts.Entities;
using Area51.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51.ApiRepository
{
    public class PersonRepository : Repository, IPersonRepository
    {
     
        public IList<PersonDTO> GetAll()
        {
            return DbContext.Person.ToList().Select(a => new PersonDTO() { Id = a.Id, First_Name = a.First_Name, Last_Name = a.Last_Name}).ToList();
        }
    }

}
