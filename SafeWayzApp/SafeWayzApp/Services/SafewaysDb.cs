using SafeWayzApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayzApp.Services
{
    public class SafewaysDb
    {
        private SQLiteAsyncConnection userDatabase;
        public SafewaysDb()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Information.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<UserDetails>().Wait();
        }

        public Task<List<UserDetails>> GetAllInformationData()
        {
            return userDatabase.Table<UserDetails>().ToListAsync();

        }

        public Task<UserDetails> GetPeopleByEmail(string Email)
        {
            return userDatabase.Table<UserDetails>().Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<UserDetails>();
        }

        public Task<int> SaveUserAsync(UserDetails info)
        {
            return userDatabase.InsertAsync(info);
        }
    }
}