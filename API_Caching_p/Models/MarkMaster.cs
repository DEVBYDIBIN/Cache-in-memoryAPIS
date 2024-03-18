using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Caching_p.Models
{
    public class MarkMaster
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StudentMaster")]
        public int  SId  { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string Sub4 { get; set; }
        public bool Status { get; set; }
        public StudentMaster StudentMaster { get; set; }
    }
}
