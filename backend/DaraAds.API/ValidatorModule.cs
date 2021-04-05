using DaraAds.API.Dto.Abuse;
using DaraAds.API.Dto.Abuse.Validators;
using DaraAds.API.Dto.Advertisement;
using DaraAds.API.Dto.Advertisement.Validators;
using DaraAds.API.Dto.Users;
using DaraAds.API.Dto.Users.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace DaraAds.API
{
    public static class Validator
    {
        public static IServiceCollection ValidatorModule(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();
            
            services
                .AddTransient<IValidator<UserLoginRequest>, UserLoginRequestValidator>()
                .AddTransient<IValidator<UserRegisterRequest>, UserRegisterRequestValidator>()
                .AddTransient<IValidator<ChangeRoleRequest>,ChangeRoleRequestValidator>()
                .AddTransient<IValidator<DomainUserUpdateRequest>, DomainUserUpdateRequestValidator>()
                .AddTransient<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
            
            services
                .AddTransient<IValidator<AdvertisementCreateRequest>, AdvertisementCreateRequestValidator>()
                .AddTransient<IValidator<AdvertisementUpdateRequest>, AdvertisementUpdateRequestValidator>();

            services
                .AddTransient<IValidator<CreateAbuseBinding>, CreateAbuseBindingValidator>();
            
            return services;
        }
    }
}