using MassTransit;
using MasstransitGrpcConsumerSample;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(mt =>
{
    mt.AddConsumer<EventMessageConsumer>();

    mt.UsingGrpc((context, cfg) =>
    {
        cfg.Host(h =>
        {
            h.Host = "grpcconsumertest";
            h.Port = 19701;
        });
        cfg.ConfigureEndpoints(context, filter => filter.Include<EventMessageConsumer>());
    });
});

var app = builder.Build();

app.UseStaticFiles();

app.Run();
