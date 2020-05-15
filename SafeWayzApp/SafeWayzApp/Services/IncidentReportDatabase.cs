using SafeWayzApp.Enums;
using SafeWayzApp.Models;
using SafeWayzApp.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayzApp.Services
{
    public class IncidentReportDatabase : IReport
    {
        private SQLiteAsyncConnection userDatabase;
        public IList<TypeOfIncident> _allIncidents;

        public IncidentReportDatabase()
        {
            ServerityOfIncidents();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Incidents.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<IncidentReport>().Wait();
        }

        public Task<List<IncidentReport>> GetAllInformationData()
        {
            return userDatabase.Table<IncidentReport>().ToListAsync();

        }

        public Task<int> SaveItemAsync(IncidentReport incidentReport)
        {
            if (incidentReport.Id != 0)
            {
                return userDatabase.UpdateAsync(incidentReport);
            }
            else
            {
                return userDatabase.InsertAsync(incidentReport);
            }
        }

        private void ServerityOfIncidents()
        {
            _allIncidents = new List<TypeOfIncident>();

            var type = new TypeOfIncident
            {
                IncidentName = "",
                IncidentColor = "",
                IncidentServerity = IncidentServerityEnum.best,
            };
            _allIncidents.Add(type);

             type = new TypeOfIncident
            {
                IncidentName = "",
                IncidentColor = "",
                IncidentServerity = IncidentServerityEnum.okay,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "",
                IncidentColor = "",
                IncidentServerity = IncidentServerityEnum.nuetral,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "",
                IncidentColor = "",
                IncidentServerity = IncidentServerityEnum.bad,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "",
                IncidentColor = "",
                IncidentServerity = IncidentServerityEnum.worst,
            };
            _allIncidents.Add(type);
        }
        
    }
}
