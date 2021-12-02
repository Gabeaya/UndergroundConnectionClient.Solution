using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UndergroundConnectionsClient.Models;
using System.Threading.Tasks;
using UndergroundConnectionsClient.ViewModels;

namespace UndergroundConnectionsClient.Controllers
{
  public class AccountController : Controller
  {
    private readonly UndergroundConnectionsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UndergroundConnectionsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("AddArtist");
      }
      else
      {
        return View();
      }
    }

    public ActionResult AddArtist()
    {
      return View();
    }
    // [HttpPost]
    // public IActionResult AddArtist(Artist artist)
    // {
    //   Artist.Post(artist);
    //   ClassificationsController Classifications = new ClassificationsController();
    //   return RedirectToAction("Index", Classifications);
    // }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}