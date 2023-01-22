using FluentAssertions;
using PitneyBowesQuestFG.Models;
using RestEase;
using System.Net;
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
        
        var resultAddresses = await ApiService.GetAllByCity(city);

        resultAddresses.Count.Should().Be(expectedAddressCount);
        foreach (var address in resultAddresses)
        {
            
            address.City.Should().Be(city);

            address.Should().BeOfType<Address>();
            
            address.Id.Should().NotBe(0);
           
            address.Street.Should().NotBeNull();
            address.Street.Should().NotBeEmpty();
            
            address.HouseNumber.Should().NotBeNull();
            address.HouseNumber.Should().NotBeEmpty();
            
            address.ZipCode.Should().NotBeNull();
            address.ZipCode.Should().NotBeEmpty();
            address.ZipCode.Should().Contain("-");
            address.ZipCode.Should().NotContain("abcdefghijklmnopqrstuvwxyz");
            address.ZipCode.Should().NotContain("abcdefghijklmnopqrstuvwxyz".ToUpper());
        }
    }
    [Fact]
    public async Task AddAddress_ShouldCorrectlyAddAddress_003()
    {
        var addressToAdd = new Address()
        {
            City = "Tychy",
            Street = "Sezamkowa",
            HouseNumber = "33",
            ZipCode = "99-333"
        };

        var createResult = await ApiService.AddAddress(addressToAdd);
        
        createResult.Should().NotBeNull();
        createResult.EnsureSuccessStatusCode();
        createResult.StatusCode.Should().Be(HttpStatusCode.Created);

        var getResult = await ApiService.GetLast();

        getResult.Should().NotBeNull();
        getResult.Should().BeOfType<Address>();
        getResult.City.Should().Be(addressToAdd.City);
        getResult.Street.Should().Be(addressToAdd.Street);
        getResult.HouseNumber.Should().Be(addressToAdd.HouseNumber);
        getResult.ZipCode.Should().Be(addressToAdd.ZipCode);
    }
}