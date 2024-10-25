using DALProject;
using DALProject.Models;
using E_Learning.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username };
                var result = await UserRepository.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.IsStudent)
                    {
                        var student = new Student { FName = model.Username };
                        user.Student = student; // Link student
                        await _context.Students.AddAsync(student);
                    }
                    else if (model.IsInstructor)
                    {
                        var instructor = new Instructor { Name = model.Username };
                        user.Instructor = instructor; // Link instructor
                        await _context.Instructors.AddAsync(instructor);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Username);
                if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);

                    if (user.StudentId.HasValue)
                    {
                        return RedirectToAction("StudentDashboard", "Home");
                    }
                    else if (user.InstructorId.HasValue)
                    {
                        return RedirectToAction("InstructorDashboard", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

    }
}
