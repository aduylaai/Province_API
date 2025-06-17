using System;
using System.Text.Json;
using Province_API.Application.DTOs;
using Province_API.Domain.Entities;
using Province_API.Infrastructure.Models;
using Province_API.Infrastructure.Utils;
using Province_API.Application.Interfaces.Repositories;


namespace Province_API.Location.Infrastructure.Repositories
{
    public class JsonRepository : ILocationRepository
    {
        private readonly List<AdminstrativeUnit> _administrativeUnits;
       

        // Constructor to initialize the administrative units from a JSON file
        public JsonRepository()
        {
            var jsonFilePath = File.ReadAllText("Infrastructure/Data/dvhcvn.json");
            var root = JsonSerializer.Deserialize<LocationLevels.LocationRoot>(jsonFilePath);

            if (root?.Data != null)
            {
                _administrativeUnits = FlatAdministrativeUnit.FlattenAdministrativeUnit(root.Data);
            }
            else
            {
                _administrativeUnits = new List<AdminstrativeUnit>();
            }
        }

        public List<AdministrativeUnit_DTO> GetAll()
        {
            return _administrativeUnits.Select(unit => new AdministrativeUnit_DTO
            {
                Id = unit.Id,
                Name = unit.Name,
                ParentId = unit.ParentId,
                Type = unit.Type
            }).ToList();
        }
    }
}
