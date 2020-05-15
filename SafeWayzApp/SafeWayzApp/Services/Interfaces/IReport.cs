using SafeWayzApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayzApp.Services.Interfaces
{
    public interface IReport
    {
         Task<int> SaveItemAsync(IncidentReport incidentReport);
         Task<List<IncidentReport>> GetAllInformationData();
    }
}
