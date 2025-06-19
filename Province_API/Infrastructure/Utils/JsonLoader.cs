using Province_API.Core.Application.Interfaces.Repositories;
using Province_API.Core.Domain.Entities;
using Province_API.Infrastructure.Models;
using System;
using System.Text.Json;
using static Province_API.Core.Domain.Enums;


namespace Province_API.Infrastructure.Utils
{
    public class JsonLoader
    {
        private List<AdminstrativeUnit> _administrativeUnits;
       

        public JsonLoader()
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

        public List<AdminstrativeUnit> LoadAdminstrativeUnits()
        {
            return _administrativeUnits;
        }
    }
}
