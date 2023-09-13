namespace Task.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificationDate { get; set; }


        //Navigation Property
        public ICollection<Student>? Student { get; set; }
    }
}
