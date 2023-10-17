﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using TRMDesktopUI.Library.Api;

namespace Portal.Authentication;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly IConfiguration _config;
    private readonly IAPIHelper _apiHelper;
    private readonly AuthenticationState _anonymous;

    public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, IConfiguration config, IAPIHelper apiHelper)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _config = config;
        _apiHelper = apiHelper;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string authTokenStorageKey = _config["authTokenStorageKey"];
        var token = await _localStorage.GetItemAsync<string>(authTokenStorageKey);

        if ( string.IsNullOrWhiteSpace(token))
        {
            return _anonymous;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
    }

    public async Task NotifyUserAuthentication(string token)
    {
        Task<AuthenticationState> authState;
        try
        {
            await _apiHelper.GetLoggedInUserInfo(token);
            var authenticatedUser = new ClaimsPrincipal(
                new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token),
                "jwtAuthType"));
            authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            string authTokenStorageKey = _config["authTokenStorageKey"];
            await _localStorage.RemoveItemAsync(authTokenStorageKey);
            authState = Task.FromResult(_anonymous);
        }
        
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        _apiHelper.LogOffUser();
        NotifyAuthenticationStateChanged(authState);
    }
}
