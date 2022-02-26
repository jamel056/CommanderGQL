using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("represents any software or service that has a command line interface.");
            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(x => x.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("this is the list of available commands for this platform");

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent]Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(x => x.PlatformId == platform.Id);
            }
        }
    }
}
