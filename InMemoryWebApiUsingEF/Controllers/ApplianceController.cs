using InMemoryWebApiUsingEF.Models;
using InMemoryWebApiUsingEF.Models.DataManager; 
using Microsoft.AspNetCore.Mvc;

namespace InMemoryWebApiUsingEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplianceController : ControllerBase
    {
        private readonly ApplianceManager _applianceManager;
        //private readonly IDataRepository<Appliance> _appliance;

        private readonly ElectroContext electroContext;
        public ApplianceController(ApplianceManager appManager)
        {
            _applianceManager = appManager;
        }

        // POST api/<A>
        [HttpPost]
        public void Post()
        {
            Random random = new Random();
            ApplianceStatus AppStatus = new ApplianceStatus();

            List<Appliance> appList = electroContext.Appliances.ToList();

            for (int i = 0; i < appList.Count; i++)
            {
                AppStatus.ApplianceID = appList.ElementAt(i).ApplianceID;

                int RanNum = random.Next();

                bool status = true;
                if (RanNum % 2 == 0)
                {
                    status = false;
                }
                AppStatus.Status = status;
                AppStatus.DateOfStatus = DateTime.Now;

            }
            _applianceManager.Add(AppStatus);
        }
    }
}