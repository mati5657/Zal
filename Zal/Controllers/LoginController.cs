using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zal.Entities;

namespace Zal.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(IFileProvider fileProvider, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _fileProvider = fileProvider;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/login")]
        public ActionResult Login()
        {
            var file = _fileProvider.GetFileInfo("/Home/login.html");
            if (file.Exists)
            {
                return File(file.CreateReadStream(), "text/html");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
                var result = await _signInManager.PasswordSignInAsync(model.username, model.password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var file = _fileProvider.GetFileInfo("/Home/index.html");
                    if (file.Exists)
                    {
                        return File(file.CreateReadStream(), "text/html");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var file = _fileProvider.GetFileInfo("/Home/login.html");
                    if (file.Exists)
                    {
                        return File(file.CreateReadStream(), "text/html");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            

            var file2 = _fileProvider.GetFileInfo("/Home/login.html");
            if (file2.Exists)
            {
                return File(file2.CreateReadStream(), "text/html");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }



    }
}
