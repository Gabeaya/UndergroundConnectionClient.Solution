// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using UndergroundConnectionsClient.Models;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using System.Security.Claims;

// // using System.Dynamic;

// namespace UndergroundConnectionsClient.Controllers
// {
//   public class ArtistsController : Controller
//   {
      

//     private readonly UserManager<ApplicationUser> _userManager;
//     public ArtistsController(UserManager<ApplicationUser> userManager) {
//       _userManager = userManager;
//     }
//     public IActionResult Index()
//     {
//       var allArtists = Artist.GetArtists();
//       return View(allArtists);
//     }


//     // public IActionResult Details(int id)
//     // {
//     //   // dynamic mymodel = new ExpandoObject();
//     //   // var artist = Artist.GetDetails(id);
//     //   // var classification = Classification.GetDetails(id);
//     //   // mymodel.Artists = artist;
//     //   // mymodel.Classifications = classification;
//     //   // return View(mymodel);
//     //   // var artist = Artist.GetDetails(id);
//     //   // var thisArtist = artist.PostChild(Artist => Artist.JoinEntities).ThenInclude(join => join.Clssificaiton).FirstOrDefaut(Artist => Artist.ArtistId == id);
//     //   var thisArtist = Artist.GetDetails(id);
//     //   return View(thisArtist);
//     // }

//     // public IActionResult Edit(int id)
//     // {
//     //   var artist = Artist.GetDetails(id);
//     //   return View(artist);
//     // }

//     [HttpPost]
//     public IActionResult Details(int id, Artist artist)
//     {
//       artist.ArtistId = id;
//       Artist.Put(artist);
//       // Classification.Put(classification);
//       return RedirectToAction("Details", id);
//     }

//     public IActionResult Delete(int id)
//     {
//       Artist.Delete(id);
//       return RedirectToAction("Index");
//     }
//   }
// }
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using UndergroundConnectionsClient.Models;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using UndergroundConnectionsClient.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace UndergroundConnectionsClient.Controllers
{

  public class ArtistsController : Controller
  {

    private readonly UserManager<ApplicationUser> _userManager;
    public ArtistsController(UserManager<ApplicationUser> userManager) {
      _userManager = userManager;
    }

    public IActionResult Index()
    {
      var allArtists = Artist.GetArtists();
      return View(allArtists);
    }

    [HttpPost]
    public IActionResult Index(Artist artist)
    {
      Artist.Post(artist);
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
      var artist = Artist.GetDetails(id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      ViewBag.CurrentUser = currentUser;
      return View(artist);
    }
        public IActionResult Create(int artistClassificationId)
    {
      var allClassifications = Classification.GetClassifications();
      ViewBag.ClassificationId = new SelectList(allClassifications, "ClassificationId", "ClassificationName");
      ViewBag.ArtistClassificationId = artistClassificationId;
      return View();
    }

    [HttpPost]
    public IActionResult Create(Artist artist, ArtistClassification artistClassification, int classificationId)
    {
      artistClassification.ArtistClassificationId= classificationId;
      ArtistClassification.NewPost(artistClassification, classificationId);

      Artist.Post(artist);
      // // Classification.Post(classification);
      // if (ClassificationId != 0)
      // {
      //   ArtistClassification.Post(new ArtistClassification()
      //   { ClassificationId = ClassificationId, ArtistId = artist.ArtistId });
      //   // Classification.Post(new Classification(){ ClassificationId = ClassificationId});
      // }
      return RedirectToAction("Index", "Classifications");
    }
    public async Task<IActionResult> Edit(int id)
    {
      var artist = Artist.GetDetails(id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      if (artist.Email == currentUser.UserName) {
        return View(artist);
      }

      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Details(int id, Artist artist)
    {
      artist.ArtistId = id;
      Artist.Put(artist);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Artist.Delete(id);
      return RedirectToAction("Index");
    }
  }
}