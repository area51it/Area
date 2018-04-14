using Area51.NHibernate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51.ApiRepository
{
    public abstract class Repository 
    {
        private ApiContext _dbContext;
        public ApiContext DbContext
        {
            get
            {
                return _dbContext ?? CurrentSession();
            }
        }
        private ApiContext CurrentSession()
        {
            var optionsBuilder = new DbContextOptions<ApiContext>();
            ApiContext ctx = new ApiContext(optionsBuilder);
            return ctx;
        }
    }

}
