using HotChocolate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    //[GraphQLDescription("represents any software or service that has a command line interface.")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [GraphQLDescription("represents a purchased, valid license for that platform.")]
        public string LicenseKey { get; set; }
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
