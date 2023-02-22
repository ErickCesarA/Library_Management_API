using static System.Reflection.Metadata.BlobBuilder;

namespace Library_ManagementAPI.Services.GenresService
{
    public class GenresService : IGenresService
    {
        private static List<GenresModels> genres = new List<GenresModels>
        {
            new GenresModels
            {

            }
        };
        private readonly DataContext _context;
        public GenresService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<GenresModels>> GetAllGenres()
        {
            var genres = await _context.GenresPropety.ToListAsync();
            return genres;
        }

        public async Task<GenresModels?> GetGenres(string genresname)
        {
            var genre = await _context.GenresPropety.Where(gn => gn.genresName.Contains(genresname)).FirstOrDefaultAsync();
            if (genre == null)
                return null;

            return genre;
        }
        public async Task<List<GenresModels>> AddGenres(GenresModels genre)
        {
                _context.GenresPropety.Add(genre);
                await _context.SaveChangesAsync();
                return genres;
            }
        public async Task<List<GenresModels>?> UpdGenres(string genresname, GenresModels request)
        {
            var genre = await _context.GenresPropety.Where(gn => gn.genresName.Contains(genresname)).FirstOrDefaultAsync();
            if (genre == null)
                return null;

            genre.genresName = request.genresName;
    
            await _context.SaveChangesAsync();

            return genres;
        }
        public async Task<List<GenresModels>?> DelGenres(string genresname)
        {
            var genre = await _context.GenresPropety.Where(gn => gn.genresName.Contains(genresname)).FirstOrDefaultAsync();
            if (genre == null)
                return null;

            _context.GenresPropety.Remove(genre);
            await _context.SaveChangesAsync();
            return genres;
        }
       
    }
}
