using System.ComponentModel.DataAnnotations.Schema;

namespace ElectroApiTest.Models
{
    public class Appliance
    {
        public string ApplianceID { get; set; }
        public string FactoryNo { get; set; }

        [ForeignKey("Customer")]
        public long CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public IList<ApplianceStatus> ApplianceStatuses { get; set; }
    }
}
