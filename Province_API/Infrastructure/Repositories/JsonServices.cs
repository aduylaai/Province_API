using System;
using Province_API.Domain;
using System.Text.Json;
using Province_API.Application.Interfaces;
using Province_API.Application.DTOs;
using Province_API.Infrastructure.Utils;


namespace Province_API.Location.Infrastructure.Repositories
{
    public class JsonServices : ILocationService
    {
        private readonly List<AdminstrativeUnit> _administrativeUnits;

        // Constructor to initialize the administrative units from a JSON file
        public JsonServices()
        {
            var jsonFilePath = File.ReadAllText("Infrastructure/Data/dvhcvn.json");
            var root = JsonSerializer.Deserialize<LocationLevels.LocationRoot>(jsonFilePath);

            // Fix for CS8602: Ensure 'root' and 'root.Data' are not null before dereferencing
            if (root?.Data != null)
            {
                _administrativeUnits = FlattenAdministrativeUnit(root.Data);
            }
            else
            {
                _administrativeUnits = new List<AdminstrativeUnit>();
            }
        }
        //--

        // All method to get the administrative units
       



        public List<AdministrativeUnit_DTO> GetProvinces() => _administrativeUnits
            .Where(u => u.ParentId == null)
            .Select(ToDto)
            .ToList();

        public List<AdministrativeUnit_DTO> GetDistricts(string provinceId) => _administrativeUnits
           .Where(u => u.ParentId == provinceId)
           .Select(ToDto)
           .ToList();


        public List<AdministrativeUnit_DTO> GetWards(string districtId) => _administrativeUnits
            .Where(u => u.ParentId == districtId)
            .Select(ToDto)
            .ToList();

        // ---

        //Method to change the administrative units to DTOs
        private AdministrativeUnit_DTO ToDto(AdminstrativeUnit u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            Type = u.Type
        };
        //--

        // Method to flattern the administrative tree into a list
        private List<AdminstrativeUnit> FlattenAdministrativeUnit(List<LocationLevels.Level1> levels)
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


        //--


    }
}
