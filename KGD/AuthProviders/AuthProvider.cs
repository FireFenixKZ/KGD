using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using KGD.Application.Utility;
using Microsoft.AspNetCore.Components.Authorization;
using static System.Net.WebRequestMethods;

namespace KGD.AuthProviders;

public class AuthProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymous;

    public AuthProvider(
        ILocalStorageService localStorage
        )
    {
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //{
    //    var token = await _localStorage.GetItemAsync<string>("accessToken");
    //    if (string.IsNullOrEmpty(token))
    //    {
    //        return _anonymous;
    //    }
    //    return new AuthenticationState(new ClaimsPrincipal(
    //          new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt")));
    //}
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = await _localStorage.GetItemAsStringAsync("accessToken");

        var identity = new ClaimsIdentity();

        if (!string.IsNullOrEmpty(token))
        {
            identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    public void NotifyUserAuthentication(string token)
    {
        var authUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt"));
        var authState = Task.FromResult(new AuthenticationState(authUser));
        NotifyAuthenticationStateChanged(authState);

    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}
