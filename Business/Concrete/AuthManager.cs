using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string sifre)
        {
            byte[] sifreHash, sifreSalt;
            HashingHelper.CreatePasswordHash(sifre, out sifreHash, out sifreSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Ad = userForRegisterDto.Ad,
                Soyad = userForRegisterDto.Soyad,
                SifreHash = sifreHash,
                SifreSalt = sifreSalt,
                Durum = true,
                Tarih = DateTime.Now
            };
            IResult result = BusinessRules.Run(UserExists(user.Email));
            if (result==null)
            {
                _userService.Add(user);
                UserOperationClaim userOperationClaim = new UserOperationClaim();
                userOperationClaim.OperationClaimId = 2;
                userOperationClaim.UserId = user.Id;
                _userOperationClaimService.Add(userOperationClaim);
                return new SuccessDataResult<User>(user, "Kayıt Başarılı...");
            }
            else
            {
                return new ErrorDataResult<User>(user, result.Message);
            }

        }

        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı.");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Sifre, userToCheck.SifreHash, userToCheck.SifreSalt))
            {
                return new ErrorDataResult<User>("Şifre Hatalı.");
            }

            return new SuccessDataResult<User>(userToCheck, "Giriş Başarılı...");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("E-posta adresi kullanılıyor.");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }
    }
}
