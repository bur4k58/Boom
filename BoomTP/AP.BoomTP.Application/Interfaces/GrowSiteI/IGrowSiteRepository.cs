using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Interfaces.GrowSiteI
{
    public interface IGrowSiteRepository : IGenericRepository<GrowSite>
    {
    }
}