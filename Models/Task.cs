namespace ProjectEF {
    public class Task{
        public Guid TaskID {get;set;}
        public Guid CategoryID {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        
        public Priority TaskPriority {get;set;}

        public DateTime CreationDate {get;set;}


    }
}

public enum Priority{
    Low,
    Medium,
    High
}