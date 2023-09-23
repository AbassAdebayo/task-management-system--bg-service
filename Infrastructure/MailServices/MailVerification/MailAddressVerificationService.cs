//using Cloudmersive.APIClient.NETCore.Validate.Api;
//using Domain.Entities;
//using Infrastructure.Models;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.MailServices.MailVerification
//{
//    public class MailAddressVerificationService : IMailAddressVerificationService
//    {
//        private readonly IConfiguration _configuration;
//        private readonly EmailApi _emailApi;
//        public string _verificationServiceApiKey;

//        public MailAddressVerificationService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//            _verificationServiceApiKey = _configuration.GetSection("emailVerifyApi")["verificationKey"];
//            _emailApi = new EmailApi(_verificationServiceApiKey);
//        }

//        public async Task<BaseResponse<User>> VerifyMailAddress(string emailAddress)
//        {
//            //Using Cloudmersive Api
//            var response = await _emailApi.EmailFullValidationAsync(emailAddress);
//            if (response.ValidAddress is false) return new BaseResponse<User> { Message = "Email validation unsuccessful", IsSuccess = false };

//            return new BaseResponse<User> { Message = "Email Verified", IsSuccess = true };
//        }
//    }
//}
