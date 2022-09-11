using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectroApiTest.Models
{
    public class ApplianceStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplianceStatusID { get; set; }

        
        [ForeignKey("Appliance")]
        public string ApplianceID { get; set; }
        public virtual Appliance Appliance { get; set; }
        public DateTime DateOfStatus { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
