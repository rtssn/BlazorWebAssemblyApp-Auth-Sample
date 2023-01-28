﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorWebAssemblyApp
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private static readonly AuthenticationState UnauthorizedAuthenticationState = new AuthenticationState(new ClaimsPrincipal());
        private ClaimsPrincipal? _principal;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_principal is null) return Task.FromResult(UnauthorizedAuthenticationState);
            return Task.FromResult(new AuthenticationState(_principal));
        }

        // これ呼んでサインインしてもらう
        public Task UpdateSignInStatusAsync(ClaimsPrincipal? principal)
        {
            _principal = principal;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return Task.CompletedTask;
        }
    }
}
