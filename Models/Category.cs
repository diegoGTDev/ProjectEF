
using System.ComponentModel.DataAnnotations;

namespace ProjectEF{
    public class Category{
        [Key]
        public Guid CategoryID {get;set;}

        public string name {get;set;}

        public string description {get;set;}
        
        public int weight {get;set;}
        public virtual ICollection<Task> Tasks {get;set;}
    }

}