using ApplianceAPI.Models;
using InMemoryWebApiUsingEF.Models;
using InMemoryWebApiUsingEF.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace InMemoryWebApiUsingEF.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ApplianceStatusController : ControllerBase
    {
        private const string ApplianceCache = "ApplianceStatusList";
        private readonly IDataRepository _dataRepository;
        private readonly IDataVMRepository<ApplianceCustomerVM> _dataVMRepository; 
        private IMemoryCache _cache;
        private ILogger<ApplianceStatusController> _logger;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public ApplianceStatusController(IDataRepository dataRepository,
            IMemoryCache cache,
            ILogger<ApplianceStatusController> logger,
            IDataVMRepository<ApplianceCustomerVM> applianceCustomerVM
            )
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
            _dataVMRepository = applianceCustomerVM ?? throw new ArgumentNullException(nameof(applianceCustomerVM));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{
        //    if (_cache.TryGetValue(ApplianceCache, out IEnumerable<ApplianceCustomerVM> appliancestatus))
        //    {
        //        _logger.Log(LogLevel.Information, "Appliance status found in cache.");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            await semaphore.WaitAsync();

        //            if (_cache.TryGetValue(ApplianceCache, out appliancestatus))
        //            {
        //                _logger.Log(LogLevel.Information, "Appliance status found in cache.");
        //            }
        //            else
        //            {
        //                _logger.Log(LogLevel.Information, "Appliance status not found in cache. Fetching from database."); 
        //                appliancestatus = _dataVMRepository.GetAll(); 
        //                var cacheEntryOptions = new MemoryCacheEntryOptions()
        //                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
        //                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
        //                        .SetPriority(CacheItemPriority.Normal);
        //                _cache.Set(ApplianceCache, appliancestatus, cacheEntryOptions);
        //            }
        //        }
        //        finally
        //        {
        //            semaphore.Release();
        //        }
        //    }
        //    return Ok(appliancestatus);
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] ApplianceStatusVM appliancestatus)
        //{
        //    if (appliancestatus == null)
        //    {
        //        return BadRequest("Appliance Status is null.");
        //    }

        //    var entity = new ApplianceStatus()
        //    {
        //        ApplianceID = appliancestatus.ApplianceID,
        //        DateOfStatus = DateTime.Now,
        //        Status = appliancestatus.ApplianceStatus                
        //    };
        //    _dataRepository.Add(entity);
        //    _cache.Remove(ApplianceCache); 
        //    return new ObjectResult(appliancestatus) { StatusCode = (int)HttpStatusCode.Created };
        //}


    }
}
