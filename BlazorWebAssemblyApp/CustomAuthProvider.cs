using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorWebAssemblyApp
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        /// <summary>
        /// 未認証ステータスです。
        /// </summary>
        private static readonly AuthenticationState UnauthorizedAuthenticationState = new AuthenticationState(new ClaimsPrincipal());

        /// <summary>
        /// 認証情報です。
        /// </summary>
        private ClaimsPrincipal? _principal;

        /// <summary>
        /// 認証状態を返します。
        /// </summary>
        /// <returns>認証状態を返します。</returns>
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_principal is null) return Task.FromResult(UnauthorizedAuthenticationState);
            return Task.FromResult(new AuthenticationState(_principal));
        }

        /// <summary>
        /// ステータスの更新を行います。
        /// </summary>
        /// <param name="principal">認証情報を指定します。</param>
        /// <returns></returns>
        public Task UpdateSignInStatusAsync(ClaimsPrincipal? principal)
        {
            _principal = principal;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return Task.CompletedTask;
        }
    }
}
