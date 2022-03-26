using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public interface ICoverTypeRepository :IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}