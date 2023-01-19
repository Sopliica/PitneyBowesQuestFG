using PitneyBowesQuestFG.Models;

namespace PitneyBowesQuestFG.DB;

public class Seeder 
{
    public static async Task Seed(InMemoryDBContext context)
    {
        List<Address> addresses = new()
        {
            new Address()
            {
                City = "Czechowice",
                Street = "Szkolna",
                HouseNumber = "47",
                ZipCode = "43-502"
                
            },
            new Address()
            {
                City = "Czestochowa",
                Street = "Kielecka",
                HouseNumber = "22",
                ZipCode = "21-37"
            },
            new Address()
            {
                City = "Czechowice",
                Street = "Sezamkowa",
                HouseNumber = "55",
                ZipCode = "43-502"
            }
        };
        await context.AddRangeAsync(addresses);
        await context.SaveChangesAsync();
        
    }
}
