using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using PathCase.IdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathCase.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var exist = await _userManager.FindByEmailAsync(context.UserName);

            if (exist == null)
            {
                var errors = new Dictionary<string, object>();

                errors.Add("errors", new List<string> { "email veya şifreniz hatalı" });
                context.Result.CustomResponse = errors;

                return;
            }

            var pass = await _userManager.CheckPasswordAsync(exist, context.Password);

            if (!pass)
            {
                var errors = new Dictionary<string, object>();

                errors.Add("errors", new List<string> { "email veya şifreniz hatalı" });
                context.Result.CustomResponse = errors;

                return;
            }

            context.Result = new GrantValidationResult(exist.Id.ToString(), OidcConstants.AuthenticationMethods.Password);

        }
    }
}
