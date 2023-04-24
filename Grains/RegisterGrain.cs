using Grains.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains
{
    public class RegisterGrain : Grain, IRegister
    {
        private readonly ILogger _logger;

        public RegisterGrain(ILogger<RegisterGrain> logger)
        {
            _logger = logger;
        }

        public Task<string> Register(int clientID, string description)
        {
            _logger.LogInformation($"The DAF received a registration request from client with ID '{clientID}' with the following description: '{description}'.");

            // Here there will be actual authentication checks

            return Task.FromResult($"\n Client '{clientID}' has been authenticated! They can now create/edit/delete (manage) authorization rights.");
        }
    }
}
