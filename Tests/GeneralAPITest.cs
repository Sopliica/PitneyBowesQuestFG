using FluentAssertions;
using PitneyBowesQuestFG.Models;
using Tests.Fixtures;

namespace Tests;

public class GeneralAPITest : TestFixture
{
    public GeneralAPITest()
    {

    }
    [Fact]
    public async Task GetLastAddress_ShouldReturnCorrectData_001()
    {
        var result = await ApiService.GetLast();
        
        result.Should().NotBeNull();
        result.Should().BeOfType<Address>();
        result.Id.Should().NotBe(0);
        result.City.Should().NotBeNull();
        result.City.Should().NotBeEmpty();
        result.City.Should().NotContain("1234567890");
        result.Street.Should().NotBeNull();
        result.Street.Should().NotBeEmpty();
        result.HouseNumber.Should().NotBeNull();
        result.HouseNumber.Should().NotBeEmpty();
        result.ZipCode.Should().NotBeNull();
        result.ZipCode.Should().NotBeEmpty();
        result.ZipCode.Should().Contain("-");
        result.ZipCode.Should().NotContain("abcdefghijklmnopqrstuvwxyz");
        result.ZipCode.Should().NotContain("abcdefghijklmnopqrstuvwxyz".ToUpper());
    }
    [Fact]
    public async Task GetAllByCity_ShouldReturnCorrectAddresses_002()
    {
        var city = "Czechowice";
        var expectedAddressCount = 2;
        
        var result = await ApiService.GetAllByCity(city);

        result.Count.Should().Be(expectedAddressCount);


    }

    
}