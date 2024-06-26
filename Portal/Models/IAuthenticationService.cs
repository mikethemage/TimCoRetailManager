﻿namespace Portal.Models;

public interface IAuthenticationService
{
    Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
    Task Logout();
}