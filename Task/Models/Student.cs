using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Class")]
        public int ClassId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public int Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }


        //Navigation Property
        public Class? Class { get; set; }
    }
}
