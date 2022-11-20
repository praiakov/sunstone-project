using SunstoneProject.Application.Interfaces.Repository;
using SunstoneProject.Infrastructure.Persistence.EntityFramework.Context;

namespace SunstoneProject.Infrastructure.Persistence.EntityFramework.Repository
{
    public class GemstoneRepository : Repository<Domain.Entities.Gemstone>, IGemstoneRepository
    {
        public GemstoneRepository(SunstoneContext context) 
            : base(context)
        {

        }
    }
}