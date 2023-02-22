namespace Library_ManagementAPI.Services.GenresService
{
    public interface IGenresService
    {
        Task<List<GenresModels>> GetAllGenres();
        Task<GenresModels?> GetGenres(string genresName);
        Task<List<GenresModels>> AddGenres(GenresModels genres);
        Task<List<GenresModels>?> UpdGenres(string genresName, GenresModels request);
        Task<List<GenresModels>?> DelGenres(string genresName);
    }
}
