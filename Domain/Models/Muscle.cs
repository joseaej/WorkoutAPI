using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WorkoutApi.Domain.Models
{
    [Table("muscle")]
    public class Muscle:BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public Muscle() { }
        public Muscle(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
