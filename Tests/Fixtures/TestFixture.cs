using RestEase;

namespace Tests.Fixtures;
public class TestFixture
{
    public readonly IApiService ApiService;

	public TestFixture()
	{
		ApiService = RestClient.For<IApiService>("https://localhost:7263");
	}
}
