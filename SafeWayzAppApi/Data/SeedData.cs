using SafeWayzLibrary.Models;
using System.Linq;

namespace SafeWayzAppApi.Data
{
    public class SeedData
    {
        public static void Initialize(UserDetailsContext context)
        {
            if (!context.UserDetail.Any())
            {
                context.UserDetail.AddRange(
                    new UserDetails
                    {
                        Name = "Abdul-khaaliq",
                        Surname = "Dollie",
                        UserName = "Admin",
                        Email = "Abdulkhaaliqdollie@gmail.com",
                        Points = 200,
                        Password = "Admin1234"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
