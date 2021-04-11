using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private readonly ICustomerDal _customerDal;
        private readonly IFindeksDal _findeksDal;
        private readonly IFindeksService _findeksService;


        public UserManager(IUserDal userDal, IFindeksDal findeksDal, IFindeksService findeksService, ICustomerDal customerDal)
          
        {
            _userDal = userDal;
            _customerDal = customerDal;
            _findeksDal = findeksDal;
            _findeksService = findeksService;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(User user)
        {
            IResult result = BusinessRules.Run(CheckUserExists(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        [SecuredOperation("user.get,moderator,admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserGetAllSuccess);
        }
        [SecuredOperation("user.get,moderator,admin")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserGetByIdSuccess);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            IResult result = BusinessRules.Run(CheckUserExists(user.Id));
            if (result != null)
            {
                return result;
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        private IResult[] CheckUserExists(int userID)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var user = GetById(userDetailForUpdate.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash,
                user.PasswordSalt)) return new ErrorResult(Messages.UserPasswordError);

            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userDal.Update(user);

            var customer = _customerDal.Get(c => c.CustomerID == userDetailForUpdate.CustomerId);
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _customerDal.Update(customer);

            if (!string.IsNullOrEmpty(userDetailForUpdate.NationalIdentity))
            {
                var findeks = _findeksService.GetByCustomerId(userDetailForUpdate.CustomerId).Data;
                if (findeks == null)
                {
                    var newFindeks = new Findeks
                    {
                        CustomerId = userDetailForUpdate.CustomerId,
                        NationalIdentity = userDetailForUpdate.NationalIdentity
                    };
                    _findeksService.Add(newFindeks);
                }
                else
                {
                    findeks.NationalIdentity = userDetailForUpdate.NationalIdentity;
                    var newFindeks = _findeksService.CalculateFindeksScore(findeks).Data;
                    _findeksDal.Update(newFindeks);
                }
            }

            return new SuccessResult(Messages.UserDetailsUpdated);
        }

        public IDataResult<UserDetailDto> GetUserDetailByMail(string email)
        {
            var userDetailDto = _userDal.GetUserDetail(email);
            if (userDetailDto == null)
                return new ErrorDataResult<UserDetailDto>(Messages.UserNotFoundError);

            return new SuccessDataResult<UserDetailDto>(userDetailDto,Messages.UserGetByMailSuccess);
        }
    }

        //business rules
        //private IResult CheckUserExists(int id)
        //{
        //    var result = _userDal.Get(u => u.UserID == id);
        //    if (result == null)
        //    {
        //        return new ErrorResult(Messages.UserEmailAlreadyExists);
        //    }

        //    return new SuccessResult();
        //}
    }
