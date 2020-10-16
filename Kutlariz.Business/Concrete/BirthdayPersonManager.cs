using AutoMapper;
using Kutlariz.Business.Abstract;
using Kutlariz.Business.Caching;
using Kutlariz.Business.Validation.FluentValidation;
using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Core.Constants;
using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kutlariz.Business.Concrete
{
    public class BirthdayPersonManager : IBirthdayPersonService
    {
        private readonly IBirthdayPersonDal _birthdayPersonDal;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public BirthdayPersonManager(IBirthdayPersonDal birthdayPersonDal, IMapper mapper, ICacheService cacheService)
        {
            _birthdayPersonDal = birthdayPersonDal;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<Result> AddOrUpdate(AddOrUpdateBirthdayPersonDto entity)
        {
            var validation = Validator.Validate(entity, new BirthdayPersonValidator());
            if (!validation.IsSuccess) return validation;

            if (entity.Id == 0)
            {
                await _birthdayPersonDal.Create(_mapper.Map<BirthdayPerson>(entity));
                return new SuccessResult(ResultMessages.CreateBirthdaySuccess);
            }
            else
            {
                await _birthdayPersonDal.Update(_mapper.Map<BirthdayPerson>(entity));
                return new SuccessResult(ResultMessages.UpdateBirthdaySuccess);
            }
        }

        public async Task<Result> Delete(int Id)
        {
            await _birthdayPersonDal.Delete(Id);
            return new SuccessResult(ResultMessages.DeleteBirthdaySuccess);
        }

        public async Task<DataResult<List<BirthdayPersonDto>>> GetAll()
        {
            var birthdays = _mapper.Map<List<BirthdayPersonDto>>(await _birthdayPersonDal.GetAll());
            return new SuccessDataResult<List<BirthdayPersonDto>>(birthdays);
        }

        public async Task<DataResult<List<BirthdayPersonDto>>> GetAllByUserId(string userId)
        {
            var birthdays = _mapper.Map<List<BirthdayPersonDto>>(await _birthdayPersonDal.GetAll(i => i.UserId == userId));
            return new SuccessDataResult<List<BirthdayPersonDto>>(birthdays);
        }

        public async Task<DataResult<AddOrUpdateBirthdayPersonDto>> GetById(int Id)
        {
            var birthdayPerson = _mapper.Map<AddOrUpdateBirthdayPersonDto>(await _birthdayPersonDal.GetById(i => i.Id == Id));
            return new SuccessDataResult<AddOrUpdateBirthdayPersonDto>(birthdayPerson);
        }

        public async Task<DataResult<List<BirthdayPersonDto>>> GetClosestThree(string userId)
        {
            var birthdayPersons = _mapper.Map<List<BirthdayPersonDto>>(await _birthdayPersonDal.GetClosestThree(userId));
            return new SuccessDataResult<List<BirthdayPersonDto>>(birthdayPersons);
        }
    }
}
