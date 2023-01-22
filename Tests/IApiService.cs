using PitneyBowesQuestFG.Models;
using RestEase;

namespace Tests;

[Header("User-Agent", "RestEase")]
public interface IApiService
{
    [Get("Address")]
    Task<Address> GetLast();
    [Get("Address/{city}")]
    Task<List<Address>> GetAllByCity([Path] string city);
    [Post("Address")]
    Task<HttpResponseMessage> AddAddress(Address address);
}
