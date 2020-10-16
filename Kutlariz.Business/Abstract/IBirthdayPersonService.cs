using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kutlariz.Business.Abstract
{
    public interface IBirthdayPersonService
    {
        Task<Result> AddOrUpdate(BirthdayPersonDto entity);
        Task<Result> Delete(int Id);
        Task<DataResult<List<BirthdayPersonDto>>> GetAll();
        Task<DataResult<BirthdayPersonDto>> GetById(int Id);
        Task<DataResult<List<BirthdayPersonDto>>> GetClosestThree(string userId);
        Task<DataResult<List<BirthdayPersonDto>>> GetAllByUserId(string userId);
    }
}
