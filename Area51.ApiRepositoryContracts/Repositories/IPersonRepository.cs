using Area51.ApiRepositoryContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51.ApiRepositoryContracts
{
    public interface IPersonRepository
    {
        IList<PersonDTO> GetAll();
    }

}
