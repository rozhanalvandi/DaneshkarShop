using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using DaneshakrShop.Application.IServices;
using DaneshkarShop.Domain.Entity;
using DaneshkarShop.Domain.DTOs.SiteSide.Account;
using DaneshakrShop.Application.Utilities;

namespace DaneshkarShop.Presentation.Controllers;

public class AccountController : Controller
{
    #region Ctor

    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Register(UserRegisterDTO userDTO)
    {
        if (ModelState.IsValid)
        {
            bool result = _userService.RegisterUser(userDTO);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        TempData["ErrorMessage"] = "کابری با شماره موبایل وارد شده در سیستم وجود دارد .";
        return View();
    }

    #endregion

    #region Login

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDTO userDTO)
    {
        if (ModelState.IsValid)
        {
            var user = _userService.GetUserByMobile(userDTO.Mobile);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.MobilePhone, user.Mobile),
                new (ClaimTypes.Name, user.UserName),
            };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();
                //authProps.IsPersistent = model.RememberMe;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                return RedirectToAction("Index", "Home");
            }
        }

        TempData["ErrorMessage"] = "کاربری با مشخصات وارد شده یافت نشده است.";
        return View();
    }


    #endregion

    #region Log Out

    #endregion
}