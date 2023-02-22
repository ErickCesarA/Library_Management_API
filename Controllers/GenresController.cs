using Library_ManagementAPI.Services.GenresService;
using Microsoft.AspNetCore.Mvc;

namespace Library_ManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly IGenresService _genreService;

        public GenresController(IGenresService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenresModels>>> GetAllGenres()
        {

            return await _genreService.GetAllGenres();

        }
        [HttpGet("{genrename}")]
        public async Task<ActionResult<GenresModels>?> GetGenres(string genrename)
        {

            var result = await _genreService.GetGenres(genrename);
            if (result == null)
                return NotFound("Genre not found.");

            return Ok(result);

        }
        [HttpPost]
        public async Task<ActionResult<List<GenresModels>>> AddGenres(GenresModels book)
        {
            var result = await _genreService.AddGenres(book);
            return Ok(result);

        }
        [HttpPut("{genrename}")]
        public async Task<ActionResult<List<GenresModels>>> UpdGenres(string genrename, GenresModels request)
        {
            var result = await _genreService.UpdGenres(genrename, request);
            if (result == null)
                return NotFound("Genre not found.");

            return Ok(result);

        }
        [HttpDelete("{genrename}")]
        public async Task<ActionResult<List<GenresModels>>> DelGenres(string genrename)
        {
            var result = await _genreService.DelGenres(genrename);
            if (result == null)
                return NotFound("Genre not found.");

            return Ok(result);
        }
    }
}
