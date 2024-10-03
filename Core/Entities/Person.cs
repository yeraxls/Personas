using Core.Entities.Base;

namespace Core.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
