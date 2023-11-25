using System.ComponentModel.DataAnnotations;

namespace RukusRummy.DataAccess.Entities
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}