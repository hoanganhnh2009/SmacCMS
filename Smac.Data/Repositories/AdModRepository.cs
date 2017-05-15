using Smac.Data.Infrastructure;
using Smac.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedu.Common.Result;

namespace Smac.Data.Repositories
{
    public class AdModRepository : RepositoryBase<AdMod>
    {
        public AdModRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
