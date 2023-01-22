using Microsoft.AspNetCore.Mvc;
using PitneyBowesQuestFG.Models;
using PitneyBowesQuestFG.Repository_Service;
using Serilog;
using System.Runtime.CompilerServices;

namespace PitneyBowesQuestFG.Controllers;
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IRepository<Address> _addressRepository;
	private readonly ILogger<Repository<Address>> _logger;
	public AddressController(IRepository<Address> addressRepository, ILogger<Repository<Address>> logger)
	{
		_addressRepository = addressRepository;
		_logger = logger;
	}
	[HttpGet]
	public async Task<IActionResult> GetLast()
	{
		Address result;
		try 
		{
            result = (await _addressRepository.GetAll()).Last();			
        }
		catch(Exception e)
		{
			return BadRequest(e.Message);
		}
		return Ok(result);
	}
	[HttpGet("{city}")]
	public async Task<IActionResult> GetAllByCity(string city)
	{
		List<Address> result;
		try
		{
			result = (await _addressRepository.GetAll()).Where(x => x.City == city).ToList();
        }
		catch (Exception e)
		{
			return BadRequest(e.Message);
		}
		return Ok(result);
	}
	[HttpPost]
	public async Task<IActionResult> AddAddress(Address address)
	{
		Address result;
		try
		{
			result = await _addressRepository.Create(address);
		}
		catch(Exception e)
		{
            return BadRequest(e.Message);
        }
		return CreatedAtAction("GetLast", new { id = result.Id });
	}
}
