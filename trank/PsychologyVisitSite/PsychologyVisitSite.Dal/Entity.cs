using System.ComponentModel.DataAnnotations;

namespace PsychologyVisitSite.Dal
{
    public abstract class Entity : Entity<long>
    {
    }

    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
