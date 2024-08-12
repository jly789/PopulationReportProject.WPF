using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopAppMaster.Interfaces;
using UiDesktopAppMaster.Models;

namespace UiDesktopAppMaster.Services
{
    internal class GangnamguPopulationService : IDatabase<GangnamguPopulation>
    {
        private readonly WpfProjectDatabaseContext? _wpfProjectDatabaseContext;

        public GangnamguPopulationService(WpfProjectDatabaseContext wpfProjectDatabaseContext)
        {
            this._wpfProjectDatabaseContext = wpfProjectDatabaseContext;
        }

        public void Create(GangnamguPopulation entity)
        {
            this._wpfProjectDatabaseContext?.GangnamguPopulations.Add(entity);
            this._wpfProjectDatabaseContext?.SaveChanges();
        }

        public void Delete(int? id)
        {
            var validData = this._wpfProjectDatabaseContext?.GangnamguPopulations.FirstOrDefault(c=> c.Id == id);

            if (validData != null) 
            {
                this._wpfProjectDatabaseContext?.GangnamguPopulations.Remove(validData);
                this._wpfProjectDatabaseContext?.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<GangnamguPopulation>? Get()
        {
            return this._wpfProjectDatabaseContext?.GangnamguPopulations.ToList();
        }

        public GangnamguPopulation? GetDetail(int? id)
        {
            var vaildData = this._wpfProjectDatabaseContext?.GangnamguPopulations.FirstOrDefault(c=> c.Id == id);

            if (vaildData != null)
            {
                return vaildData;
            }
            else 
            {
                throw new InvalidOperationException();
            }
        }

        public void Update(GangnamguPopulation entity)
        {
            this._wpfProjectDatabaseContext?.GangnamguPopulations.Update(entity);
            this._wpfProjectDatabaseContext?.SaveChanges();
        }
    }
}
