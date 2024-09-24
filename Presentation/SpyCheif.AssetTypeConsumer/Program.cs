
using MassTransit;
using SpyCheif.AssetTypeConsumer.Consumer;
using SpyCheif.Infrastructure.MessageBroker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<AssetTypeConsume>();
    config.UsingRabbitMq((context, conf) =>
    {
        conf.Host(builder.Configuration["RabbitMQConnection"]);
        conf.ReceiveEndpoint(BrokerEndpoints.Asset_AddedEndPoint,cfg => cfg.ConfigureConsumer<AssetTypeConsume>(context));
    });
});

var app = builder.Build();

app.Run();

