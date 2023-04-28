using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlatformsController : ControllerBase
  {
    private readonly IPlatformRepo _platformRepo;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
    {
      _platformRepo = platformRepo;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
      Console.WriteLine("---> Getting Platforms...");
      var platforms = _platformRepo.GetAllPlatforms();

      return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
      var platformItem = _platformRepo.GetPlatformById(id);
      if (platformItem != null)
      {
        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
      }
      return NotFound();
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
      var platformModel = _mapper.Map<Platform>(platformCreateDto);
      _platformRepo.CreatePlatform(platformModel);
      _platformRepo.SaveChanges();

      var platformItem = _mapper.Map<PlatformReadDto>(platformModel);

      return CreatedAtRoute(nameof(GetPlatformById), new { id = platformModel.Id }, platformItem);
    }
  }                                                                                                                         
}
