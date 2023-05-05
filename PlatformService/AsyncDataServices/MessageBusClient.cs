using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices
{
  public class MessageBusClient : IMessageBusClient
  {
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageBusClient(IConfiguration configuration)
    {
      _configuration = configuration;

      var factory = new ConnectionFactory()
      {
        HostName = _configuration["RabbitMQHost"],
        Port = int.Parse(_configuration["RabbitMQPort"])
      };
      _connection = factory.CreateConnection();

      try
      {
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: _configuration["RabbitMQExchange"], type: ExchangeType.Fanout);

        _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        Console.WriteLine("--> Connected to Message Bus.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"--> Could not connect to Message Bus:{ex.Message}");
      }
    }


    public void PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
    {
      var message = JsonSerializer.Serialize(platformPublishedDto);

      if (_connection.IsOpen)
      {
        Console.WriteLine("--> RabbitMQ connection is open, send message.");
        SendMessage(message);
      }
      else
      {
        Console.WriteLine("--> RabbitMQ connection closed, not sending.");
      }
    }

    #region private
    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
      Console.WriteLine("--> RabbitMQ was shutdown.");
    }

    private void SendMessage(string message)
    {
      var body = Encoding.UTF8.GetBytes(message);
      Console.WriteLine($"--> Debug SendMessage(): {message}");
      Console.WriteLine($"--> Debug RabbitMQExchange(): {_configuration["RabbitMQExchange"]}");

      _channel.BasicPublish(exchange: _configuration["RabbitMQExchange"],
        routingKey: "",
        basicProperties: null,
        body: body);

      Console.WriteLine($"--> We have sent {message}");

    }
    #endregion
  }
}