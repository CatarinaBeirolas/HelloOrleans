using Grains.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

try
{
    using (var client = await ConnectClientAsync())
    {
        Console.WriteLine("\n\n My clientID is 0 and I will try to register with the DAF.\n\n");
        await RegisterClient(client);
        Console.WriteLine("\n\n Press Enter to terminate...\n\n");
        Console.ReadLine();
    }

    return 0;
}
catch (Exception e)
{
    return 1;
}

static async Task<IClusterClient> ConnectClientAsync()
{
    var client = new ClientBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "DAF";
            options.ServiceId = "RegisterExample";
        })
        .ConfigureLogging(logging => logging.AddConsole())
        .Build();

    await client.Connect();
    Console.WriteLine("Client successfully connected to silo host! \n");

    return client;
}

static async Task RegisterClient(IClusterClient client)
{
    var registerGrain = client.GetGrain<IRegister>(0);
    var response = await registerGrain.Register(0, "This an example client trying to register with the DAF.");

    Console.WriteLine($"The DAF answered: \n\n{response}\n\n");
}