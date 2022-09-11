using ElectroApiTest.Models.Repository;

namespace ElectroApiTest.Models.DataManager
{
    public class ApplianceManager : IDataRepository
    {
        readonly ElectroContext _context;
        Random random = new Random();

        public ApplianceManager(ElectroContext context)
        {
            _context = context;
        }

        public void Add()
        {
            var lst = _context.Appliances.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                int RanNum = random.Next();
                bool status = true;
                if (RanNum % 2 == 0)
                {
                    status = false;
                }
                var entityNew = new ApplianceStatus()
                {
                    ApplianceID = lst.ElementAt(i).ApplianceID,
                    DateOfStatus = DateTime.Now,
                    Status = status
                };
                _context.ApplianceStatuses.Add(entityNew);
                _context.SaveChanges();
            }
        }
    }
}
