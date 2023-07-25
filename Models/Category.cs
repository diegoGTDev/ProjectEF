
namespace ProjectEF{
    public class Category{
        public Guid CategoryID {get;set;}

        public string name {get;set;}

        public string description {get;set;}

        public virtual ICollection<Task> Tasks {get;set;}
    }

}