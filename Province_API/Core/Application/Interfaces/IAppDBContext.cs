using Microsoft.EntityFrameworkCore;
using Province_API.Core.Domain.AdministrativeAggregate;

namespace Province_API.Core.Application.Interfaces
{
    public interface IAppDBContext
    {
        DbSet<AdminstrativeUnit> AdministrativeUnits { get; set; }

    }
}
