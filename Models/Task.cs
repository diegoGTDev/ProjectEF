using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEF {
    public class Task{

        //[Key]
        public Guid TaskID {get;set;}
        [ForeignKey("CategoriaID")]
        public Guid CategoryID {get;set;}
        [Required]
        [MaxLength(200)]
        public string Title {get;set;}
        public string Description {get;set;}
        
        public Priority TaskPriority {get;set;}

        public DateTime CreationDate {get;set;}

        public Category Category {get;set;}

        public Boolean IsCompleted {get;set;}
        
        //[NotMapped]
        public string Resume {get;set;}
    }
}

public enum Priority{
    Low,
    Medium,
    High
}