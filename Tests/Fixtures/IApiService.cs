using PitneyBowesQuestFG.Models;
using RestEase;

namespace Tests.Fixtures;

[Header("User-Agent", "RestEase")]
public interface IApiService
{
    [Get("Address")]
    Task<Address> GetLast();

    [Get("Address/{city}")]
    Task<List<Address>> GetAllByCity([Path] string city);

    [Post("Address")]
    Task<HttpResponseMessage> AddAddress([Body] Address address);

}
