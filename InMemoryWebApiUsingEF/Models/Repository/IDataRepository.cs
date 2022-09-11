using ApplianceAPI.Models;

namespace ElectroApiTest.Models.Repository
{
    public interface IDataVMRepository<TEntity>
    {
        List<TEntity> GetAll(); 
    }
    public interface IDataRepository
    {
        void Add();
    }
}
