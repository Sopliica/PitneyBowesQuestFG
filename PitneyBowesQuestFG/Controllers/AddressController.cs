﻿using Microsoft.AspNetCore.Mvc;
using PitneyBowesQuestFG.Models;
using PitneyBowesQuestFG.Repository_Service;

namespace PitneyBowesQuestFG.Controllers;
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IRepository<Address> _addressRepository;
	public AddressController(IRepository<Address> addressRepository)
	{
		_addressRepository = addressRepository;	
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
	[HttpPost("{address}")]
	public async Task<IActionResult> AddAddress(Address address)
	{
		try
		{
			await _addressRepository.Create(address);
		}
		catch(Exception e)
		{
            return BadRequest(e.Message);
        }
		return Ok();
	}

}
