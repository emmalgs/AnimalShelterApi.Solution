using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class SavedAnimalsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public SavedAnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }
  }
}