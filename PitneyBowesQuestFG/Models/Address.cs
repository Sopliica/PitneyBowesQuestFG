using PitneyBowesQuestFG.Repository_Service;

namespace PitneyBowesQuestFG.Models;

public class Address : IEntity<int>
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber  { get; set; }
    public string ZipCode { get; set; }

}
