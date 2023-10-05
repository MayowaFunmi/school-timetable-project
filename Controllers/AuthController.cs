using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRegisterUser _registerUser;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(IRegisterUser registerUser, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _registerUser = registerUser;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterModelInput userModel)
        {
            if (ModelState.IsValid)
            {
                var regUser = await _registerUser.Create(userModel);
                if (regUser)
                {
                    TempData["msg"] = "User registered successfully";
                    return View();
                }
                else
                {
                    TempData["msg"] = "User registration failed";
                    return View();
                }
            }
            return View(userModel);
        }

        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(LoginModelInput modelInput)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(modelInput.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, modelInput.Password, isPersistent: true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        TempData["message"] = "Login Successful";
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["message"] = "Failed to login user";
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    return View();
                }
                TempData["message"] = "User not found";
                return View();
            }
            else
            {
                TempData["message"] = "Invalid Form Data";
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            TempData["message"] = "You are logged out";
            return RedirectToAction("Index", "Home");
        }
        
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users
                .Include(u => u.School)
                .Where(s => s.Id == s.School.AdminId)
                .OrderBy(u => u.CreatedAt)
                .ToListAsync();
            return View(users);
        }

        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            // get user, 
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var allRoles = await _roleManager.Roles.ToListAsync(); // all roles
                var userRoles = await _userManager.GetRolesAsync(user); // user specific roles
                var viewModel = new UserViewModelData
                {
                    User = user,
                    UserRoles = userRoles,
                    AllRoles = allRoles.Select(role => new RoleCheckbox
                    {
                        Id = role.Id,
                        Name = role.Name,
                        IsSelected = userRoles.Contains(role.Name)
                    }).ToList()
                };

                return View(viewModel);
            }
            TempData["msg"] = "User not found";
            return View();
        }

        public IActionResult AddRoleToUser()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(UserViewModelData modelData)
        {
            Console.WriteLine($"user id = {modelData.User.Id}");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(modelData.User.Id);
                if (user == null)
                {
                    TempData["msg"] = "user not found";
                    return RedirectToAction("GetAllUsers");
                }
                TempData["msg"] = $"user id {user.Id} found";
                return RedirectToAction("GetAllUsers");
            }
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    var errorMessage = error.ErrorMessage;
                    // Log or handle the validation error as needed
                    TempData["msg"] = errorMessage;
                    return RedirectToAction("GetAllUsers");
                }
            }
            TempData["msg"] = "Invalide form";
            return RedirectToAction("GetAllUsers");
        }
        // public async Task<IActionResult> AddRoleToUser(string userId, List<string> selectedRoles)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // Find the user by user ID
        //         Console.WriteLine($"user id = {userId}");
        //         var user = await _userManager.FindByIdAsync(userId);

        //         if (user == null)
        //         {
        //             // Handle the case where the user is not found
        //             TempData["msg"] = "User not found";
        //             return RedirectToAction("GetUserById", new { userId });
        //         }

        //         // Add the selected roles to the user
        //         var result = await _userManager.AddToRolesAsync(user, selectedRoles);

        //         if (result.Succeeded)
        //         {
        //             TempData["msg"] = "Roles added successfully.";
        //         }
        //         else
        //         {
        //             // Handle the case where adding the roles failed
        //             TempData["msg"] = "Failed to add roles.";
        //         }
        //     }
        //     else
        //     {
        //         // Handle model validation errors
        //         TempData["msg"] = "Invalid model data.";
        //     }

        //     return RedirectToAction("GetUserById", new { userId });
        // }

    }
}