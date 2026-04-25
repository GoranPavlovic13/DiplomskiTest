using GraphQL.Authentication.Payloads;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Authentication
{
    [ExtendObjectType(typeof(Mutation))]
    public class AuthenticationMutation
    {
        public async Task<RegisterUserPayload> RegisterUserAsync(UserForRegistrationDto input, [Service] IServiceManager service)
        {
            var result = await service.AuthenticationService.RegisterUserAsync(input);

            if (result.Succeeded)
            {
                return new RegisterUserPayload
                {
                    Success = true
                };
            }

            return new RegisterUserPayload
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<AuthPayload> LoginAsync(
            UserForAuthenticationDto user,
            [Service] IServiceManager service)
        {
            var isValid = await service.AuthenticationService.ValidateUser(user);

            if (!isValid)
            {
                throw new GraphQLException(ErrorBuilder.New()
                    .SetMessage("Invalid username or password.")
                    .SetCode("AUTH_NOT_AUTHORIZED")
                    .Build());
            }

            var token = await service.AuthenticationService.CreateToken();

            return new AuthPayload
            {
                Token = token
            };
        }
    }
}
