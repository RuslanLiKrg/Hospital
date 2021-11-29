using Hospital.Models.ViewModels;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        /*IdentityUser - Представляет пользователя в системе удостоверений*/
        /* Предоставляет API-интерфейсы для управления пользователем в хранилище сохраняемости.*/
        private UserManager<IdentityUser> userManager;
        /*Предоставляет API для входа пользователя. сервис SignInManager, который позволяет аутентифицировать пользователя и устанавливать или удалять его куки.*/
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hospital.Models.User user = new User { Email = model.Email, UserName = model.UserName, Year = model.Year};
                /*Создает указанного пользователя в резервном хранилище с заданным паролем в качестве асинхронной операции.*/
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    /*устанавливаем аутентификационные куки для добавленного пользователя.*/
                    
                    await signInManager.SignInAsync(user, false);//BOOL variable надо ли хранить куки долго
                    return RedirectToAction("MainPage", "Hospital");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl">URL, на который браузер должен быть перенаправлен, если запрос на аутентификацию завершился успешно.</param>
        /// <returns></returns>
        [AllowAnonymous]       
       public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel 
            {
                ReturnURL = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    /*SignOutAsync - Выключает текущего пользователя из приложения.*/
                    await signInManager.SignOutAsync();
                    /*Пытается войти в систему с указанной комбинацией пользователя и пароля в качестве асинхронной операции.*/
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnURL??"/Hospital/MainPage");
                    }    
                }
            }
            ModelState.AddModelError("", "Неверный логин или пароль. Попробуйте еще раз");
            return View(loginModel);
        }
        public async Task<RedirectResult>Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
