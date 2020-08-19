using OAuth2.IDP.Models.Responses;
using OAuth2.IDP.Services.Services;
using OAuth2.Model.Enums;
using OAuth2.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.IDP.Process
{
    internal class AccountProcess
    {
        internal AccountControlResponse LoginProcess(string credentials, AuthenticationInfo authenticationInfo, TokenInfo tokenInfo)
        {
            try
            {
                switch (authenticationInfo.GrantType)
                {
                    case GrantType.AuthorizationCode:
                        {
                            return AuthenByAuthorizationCode(authenticationInfo);
                        }
                    case GrantType.ClientCredentials:
                        {
                            return AuthenByClientCredentials(credentials);
                        }
                    case GrantType.RefreshToken:
                        {
                            return AuthenByRefreshToken(tokenInfo);
                        }
                    default: return MappingAccountControlErrorResponse(ErrorCode.NotFound, "GrantType was not found.");
                }
            }
            catch (Exception ex)
            {
                return MappingAccountControlExceptionResponse(ex);
            }
        }

        internal AccountControlResponse LogoutProcess(string token)
        {
            try
            {
                return MappingAccountControlSuccessResponse();
            }
            catch (Exception ex)
            {
                return MappingAccountControlExceptionResponse(ex);
            }
        }

        private AccountControlResponse AuthenByAuthorizationCode(AuthenticationInfo authenticationInfo)
        {
            try
            {
                TokenInfo tokenResponse = new TokenInfo();
                tokenResponse.TokenType = TokenType.Bearer;
                return MappingAccountControlSuccessResponse(new AuthenticationInfo() { GrantType = GrantType.AuthorizationCode }, tokenResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private AccountControlResponse AuthenByClientCredentials(string credentials)
        {
            try
            {
                credentials = Encoding.ASCII.GetString(Convert.FromBase64String(credentials));
                string[] credentialsArr = credentials.Split(':');
                UserService userService = new UserService();
                List<UserInfo> listUserResponse = userService.GetUserByCriteria(new UserInfo() { Username = credentialsArr[0], Password = credentialsArr[1] });

                if (listUserResponse.Count > 0)
                {
                    AuthenticationInfo authenResponse = new AuthenticationInfo();
                    authenResponse.ClientId = "";
                    authenResponse.ClientSecret = "";
                    authenResponse.GrantType = GrantType.ClientCredentials;
                    authenResponse.Code = GetRandomNumber(40);

                    if (listUserResponse.FirstOrDefault().UserRole == UserRole.Admin)
                    {
                        authenResponse.Scopes = new string[]
                        {
                            Scope.Profile.ToString(),
                            Scope.ServiceAPI.ToString(),
                            Scope.Role.ToString()
                        };
                    }
                    else
                    {
                        authenResponse.Scopes = new string[]
                        {
                            Scope.Profile.ToString(),
                            Scope.ServiceAPI.ToString()
                        };
                    }

                    return MappingAccountControlSuccessResponse(authenResponse, null);
                }
                else
                {
                    return MappingAccountControlErrorResponse(ErrorCode.Unauthorized, "Authentication failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private AccountControlResponse AuthenByRefreshToken(TokenInfo tokenInfo)
        {
            try
            {
                TokenInfo tokenResponse = new TokenInfo();
                tokenResponse.TokenType = TokenType.Bearer;
                return MappingAccountControlSuccessResponse(new AuthenticationInfo() { GrantType = GrantType.RefreshToken }, tokenResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Other Function

        private string GetRandomNumber(int numberLength)
        {
            try
            {
                int length = numberLength > 0 ? numberLength : 1;
                byte[] randomNumber = new byte[length];

                using (RandomNumberGenerator numberGenerator = RandomNumberGenerator.Create())
                {
                    numberGenerator.GetBytes(randomNumber);
                }

                return Convert.ToBase64String(randomNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Other Function

        #region Mapping Response

        private AccountControlResponse MappingAccountControlSuccessResponse()
        {
            return new AccountControlResponse() { AuthenticationInfo = null, TokenInfo = null, IsSuccess = true, ErrorCode = (int)ErrorCode.Success, Description = ErrorCode.Success.ToString() };
        }

        private AccountControlResponse MappingAccountControlSuccessResponse(AuthenticationInfo authenticationInfo, TokenInfo tokenInfo)
        {
            return new AccountControlResponse() { AuthenticationInfo = authenticationInfo, TokenInfo = tokenInfo, IsSuccess = true, ErrorCode = (int)ErrorCode.Success, Description = ErrorCode.Success.ToString() };
        }

        private AccountControlResponse MappingAccountControlErrorResponse(ErrorCode errorCode, string description)
        {
            return new AccountControlResponse() { AuthenticationInfo = null, TokenInfo = null, IsSuccess = false, ErrorCode = (int)errorCode, Description = description };
        }

        private AccountControlResponse MappingAccountControlExceptionResponse(Exception ex)
        {
            return new AccountControlResponse() { AuthenticationInfo = null, TokenInfo = null, IsSuccess = false, ErrorCode = (int)ErrorCode.InternalServerError, Description = ErrorCode.InternalServerError.ToString(), ErrorMessage = ex.Message };
        }

        #endregion Mapping Response
    }
}