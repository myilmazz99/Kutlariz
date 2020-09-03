using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.Business.Abstract
{
    public interface IBirthdayPersonService
    {
        Task<Result> AddOrUpdate(AddOrUpdateBirthdayPersonDto entity);
        Task<Result> Delete(int Id);
        Task<DataResult<List<BirthdayPersonDto>>> GetAll();
        Task<DataResult<AddOrUpdateBirthdayPersonDto>> GetById(int Id);
        Task<DataResult<List<BirthdayPersonDto>>> GetClosestThree(string userId);
        Task<DataResult<List<BirthdayPersonDto>>> GetAllByUserId(string userId);
    }
}
