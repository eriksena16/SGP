//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;

//namespace LuxGenerics.Extensions
//{
//    public static class ClaimsPrincipalExtensions
//    {
//        public static long GetAccountId(this ClaimsPrincipal principal)
//        {
//            var accountId = principal.Claims.FirstOrDefault(c => c.Type == "lastAccountId").Value;
//            return Int64.Parse(accountId);
//        }

//        public static long GetUserId(this ClaimsPrincipal principal)
//        {
//            var userId = principal.Claims.FirstOrDefault(c => c.Type == "id").Value;
//            return Int64.Parse(userId);
//        }

//        public static bool GetIsAdm(this ClaimsPrincipal principal)
//        {
//            var IsAdm = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
//            if (IsAdm == "admin")
//                return true;
//            else
//                return false;
//        }
//        private static JwtSecurityToken GetToken(string token, bool invalidToken)
//        {
//            if (string.IsNullOrEmpty(token))
//                throw new Exception("invalidToken");

//            var tokenS = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

//            if (invalidToken)
//                return tokenS;

//            var data = tokenS.Claims.First(claim => claim.Type == "exp").Value;
//            DateTime exp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToInt64(data));
//            if (exp > DateTime.UtcNow)
//                return tokenS;
//            else
//                throw new Exception("expiredToken");
//        }
//        public static string GetInvalidTokenUserId(string token)
//        {
//            return GetToken(token, true).Claims.First(claim => claim.Type == "client_id").Value;
//        }
//        public static string GetTokenUserId(string token)
//        {
//            return GetToken(token, false).Claims.First(claim => claim.Type == "client_id").Value;
//        }
//        public static string GetTokenUserEmail(string token)
//        {
//            return GetToken(token, false).Claims.First(claim => claim.Type == "scope").Value;
//        }
//    }
//}
