using ApplianceAPI.Models;
using ElectroApiTest.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace ElectroApiTest.Models.DataManager
{
    public class ApplianceStatusManager : IDataVMRepository<ApplianceCustomerVM>
    {
        readonly ElectroContext _context;

        public ApplianceStatusManager(ElectroContext context)
        {
            _context = context;
        }

        public List<ApplianceCustomerVM> GetAll()
        {
            List<ApplianceCustomerVM> result = new List<ApplianceCustomerVM>();

            var lst = _context.ApplianceStatuses.Include(r => r.Appliance).Include(f => f.Appliance.Customer).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                string ApID = lst.ElementAt(i).ApplianceID;
                string FactoryNo = lst.ElementAt(i).Appliance.FactoryNo;
                string Name = lst.ElementAt(i).Appliance.Customer.Name;
                DateTime DateOfStatus = lst.ElementAt(i).DateOfStatus;
                bool ApplianceStatus = lst.ElementAt(i).Status;
                
                var entity = new ApplianceCustomerVM()
                {
                    ApplianceID = lst.ElementAt(i).ApplianceID,
                    DateOfStatus = lst.ElementAt(i).DateOfStatus,                    
                    ApplianceStatus = lst.ElementAt(i).Status,
                    FactoryNo = lst.ElementAt(i).Appliance.FactoryNo,
                    Name = lst.ElementAt(i).Appliance.Customer.Name
                };
                result.Add(entity);
            }
            return result;
        }
    }
}
