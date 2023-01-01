using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Student_Info.Models
{
    [Index(nameof(IdProof), IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? MemberId { get; set; }
       
        public string? Name { get; set; }
        [StringLength(10)]
        public string? Phone { get; set; }
       
        public string IdProof { get; set; }
        public DateTime? Joining_Date { get; set; } = DateTime.Now;
    }
}
