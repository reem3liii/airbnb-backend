using airbnb.DTO;
using airbnb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace airbnb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainFeaturesController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public MainFeaturesController(AirbnbDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult getAll()
        {
            List<Place> places = _context.Places.Include(p=> p.Reviews).ToList();

            if (places.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<PlaceDTO> placesDTO = new List<PlaceDTO>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x=> x.PlaceId == p.PlaceId).Select(x=> x.ImageName).ToList();
                    placesDTO.Add(new PlaceDTO()
                    {
                      Location=p.Location,
                      Type=p.Type,
                      DailyPrice=p.DailyPrice,
                      AvgRating=avgRate,
                      ImagesUrls= imgUrls

                    }
                    );
                }
                return Ok(placesDTO);
            }
        }

    }
}
