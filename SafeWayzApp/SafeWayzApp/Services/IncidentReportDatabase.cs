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
        public ObservableCollection<TypeOfIncident> _allIncidents;

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
            _allIncidents = new ObservableCollection<TypeOfIncident>();

            var type = new TypeOfIncident
            {
                //Name of Incident
                IncidentName = "Accident",
                //Purple
                IncidentColor = "#370359",
                IncidentServerity = IncidentServerityEnum.best,
            };
            _allIncidents.Add(type);

             type = new TypeOfIncident
            {
                IncidentName = "Robbery",
                //Blue
                IncidentColor = "#1bd3e0",
                IncidentServerity = IncidentServerityEnum.okay,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "Assault",
                //Grey
                IncidentColor = "#919491",
                IncidentServerity = IncidentServerityEnum.nuetral,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "Shooting",
                //Green
                IncidentColor = "#00b806",
                IncidentServerity = IncidentServerityEnum.bad,
            };
            _allIncidents.Add(type);

            type = new TypeOfIncident
            {
                IncidentName = "Murder",
                //Red
                IncidentColor = "#b80000",
                IncidentServerity = IncidentServerityEnum.worst,
            };
            _allIncidents.Add(type);
        }
    }
}
