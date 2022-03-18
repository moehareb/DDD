using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Category: EntityAudit
    {
        public Category(string name)
        {
            Name = name;
        }

        protected Category() { }

        public string Name { get; private set; }
    }
}
