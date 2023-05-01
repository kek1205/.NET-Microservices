using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlatformService.Dtos;
using Microsoft.Extensions.Configuration;

namespace PlatformService.SyncDataServices
{
  public class HttpCommandDataClient : ICommandDataClient
  {
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient client, IConfiguration configuraton)
    {
      _httpClient = client;
      _configuration = configuraton;
    }
    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
      var httpContent = new StringContent(
        JsonSerializer.Serialize(plat),
        Encoding.UTF8,
        "application/json"
      );

      var response = await _httpClient.PostAsync(_configuration["CommandService"], httpContent);

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("--> Sync POST to CommanService was OK!");
      }
      else
      {
        Console.WriteLine("--> Sync POST to CommanService was NOT OK!");
      }

    }
  }
}