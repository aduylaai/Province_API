using Province_API.Domain.Entities;
using Province_API.Infrastructure.Models;

namespace Province_API.Infrastructure.Utils
{
    public class FlatAdministrativeUnit
    {
        public static List<AdminstrativeUnit> FlattenAdministrativeUnit(List<LocationLevels.Level1> levels)
        {
            var result = new List<AdminstrativeUnit>();
            foreach (var l1 in levels)
            {
                result.Add(new AdminstrativeUnit
                (
                   l1.Level1Id, l1.Name, l1.Type, null
               ));

                foreach (var l2 in l1.Level2s)
                {
                    result.Add(new AdminstrativeUnit
                    (
                        l2.Level2Id, l2.Name, l2.Type, l1.Level1Id
                    ));
                    foreach (var l3 in l2.Level3s)
                    {
                        result.Add(new AdminstrativeUnit
                        (
                            l3.Level3Id, l3.Name, l3.Type, l2.Level2Id
                        ));
                    }
                }
            }
            return result;
        }
    }
}
