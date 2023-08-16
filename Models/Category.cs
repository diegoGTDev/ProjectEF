
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectEF{
    public class Category{
        [Key]
        public Guid CategoryID {get;set;}

        public string name {get;set;}

        public string description {get;set;}
        
        public int weight {get;set;}
        [JsonIgnore]
        public virtual ICollection<Task> Tasks {get;set;}
    }

}