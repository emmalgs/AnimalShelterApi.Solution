using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelterApi.Controllers;

public class CallApiController : Controller
{
    private readonly AnimalShelterApiContext _db;
    public CallApiController(AnimalShelterApiContext db)
    {
      _db = db;
    }
  public IActionResult Index(string message)
  {
    ViewBag.Message = message;
    return View();
  }

  [HttpPost]
   public async Task<IActionResult> Index(string username, string password)
  {
      User loginUser = await _db.Users.FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
      if (loginUser == null)
          return View((object)"Login Failed");

      var claims = new[] {
          new Claim(ClaimTypes.Role, loginUser.Role)
      };

      var accessToken = GenerateJSONWebToken(claims);
      SetJWTCookie(accessToken);

      return RedirectToAction("Animals");
  }
  private string GenerateJSONWebToken(Claim[] claims)
  {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          issuer: "https://www.yogihosting.com",
          audience: "https://www.yogihosting.com",
          expires: DateTime.Now.AddHours(3),
          signingCredentials: credentials,
          claims: claims
          );

      return new JwtSecurityTokenHandler().WriteToken(token);
  }
    private void SetJWTCookie(string token)
  {
      var cookieOptions = new CookieOptions
      {
          HttpOnly = true,
          Expires = DateTime.UtcNow.AddMinutes(1),
      };
      Response.Cookies.Append("jwtCookie", token, cookieOptions);
  }

}