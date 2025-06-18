using Microsoft.EntityFrameworkCore;
using Province_API.Domain.Entities;

namespace Province_API.Application.Interfaces
{
    public interface IAppDBContext
    {
        DbSet<AdminstrativeUnit> administrativeunits { get; set; }

    }
}
