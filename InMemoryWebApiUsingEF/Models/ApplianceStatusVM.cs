namespace ApplianceAPI.Models
{
    public class ApplianceStatusVM
    {
        public string ApplianceID { get; set; }
        public bool ApplianceStatus { get; set; }
    }
    public class ApplianceCustomerVM
    {
        public string ApplianceID { get; set; }

        public string FactoryNo { get; set; }
        public DateTime DateOfStatus { get; set; }
        public string? Name { get; set; }
        public bool ApplianceStatus { get; set; }
    }
}
