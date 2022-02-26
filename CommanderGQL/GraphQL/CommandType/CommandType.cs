using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace CommanderGQL.GraphQL.CommandType
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor
                .Field(x => x.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("this is the platform to which the command belongs");

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent]Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
            }
        }
    }
}
