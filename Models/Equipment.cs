
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WorkoutApi.Models
{
    [Table("equipment")]
    public class Equipment : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        public Equipment() { }
        public Equipment(string name, string description)
        {

            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"ID:{Id},Name:{Name},Description:{Description}";
        }
    }
}
