using System.ComponentModel.DataAnnotations;

namespace API_Caching_p.Models
{
    public class StudentMaster
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Adress { get; set; }
        public string MailId { get; set; }
        public string Number { get; set; }
        public int CourseId { get; set;}
        public bool Status { get; set; }
         
    }
}
