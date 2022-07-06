using Newtonsoft.Json.Linq;
using RateBox.Bot.DTOs;
using System.Net;

namespace RateBox.Bot.ApiHandler;
public static class OmdbHandler
{
    private static string ApiKey = "139acb79";
    public static async Task<List<MovieDto>> SearchByName(string query)
    {
        var url = new Uri($"http://www.omdbapi.com/?s={query}&apikey={ApiKey}");
        var response = await new WebClient().DownloadStringTaskAsync(url);

        return await JsonToDtos(response);
    }
    public static async Task<MovieDto> GetMovieDetails(string imdbId)
    {
        var url = new Uri($"http://www.omdbapi.com/?i={imdbId}&apikey={ApiKey}");
        var response = await new WebClient().DownloadStringTaskAsync(url);

        return await JsonToDto(response);
    }

    private static async Task<List<MovieDto>> JsonToDtos(string json)
    {
        var decrypted = JObject.Parse(json);
        var movies = new List<MovieDto>();
        if (decrypted["Search"] is not null)
            foreach (var item in decrypted["Search"])
            {
                MovieDto movie = new MovieDto()
                {
                    Id = item.SelectToken("imdbID").ToString(),
                    Title = item.SelectToken("Title").ToString(),
                    Year = item.SelectToken("Year").ToString(),
                    Poster = item.SelectToken("Poster").ToString()
                };
                movies.Add(movie);
            }

        return await Task.FromResult(movies);
    }

    private static async Task<MovieDto> JsonToDto(string json)
    {
        var decrypted = JObject.Parse(json);
        MovieDto movie = new MovieDto()
        {
            Id = decrypted.SelectToken("imdbID").ToString(),
            Title = decrypted.SelectToken("Title").ToString(),
            Year = decrypted.SelectToken("Year").ToString(),
            Poster = decrypted.SelectToken("Poster").ToString(),
            Plot = decrypted.SelectToken("Plot").ToString(),
            Country = decrypted.SelectToken("Country").ToString(),
            Rated = decrypted.SelectToken("Rated").ToString(),
            Runtime = decrypted.SelectToken("Runtime").ToString(),
            IMDBRating = decrypted.SelectToken("imdbRating").ToString(),
            IMDBRates = decrypted.SelectToken("imdbVotes").ToString(),
            Metascore = decrypted.SelectToken("Metascore").ToString(),
            Actors = decrypted.SelectToken("Actors").ToString(),
            Genre = decrypted.SelectToken("Genre").ToString(),
            Language = decrypted.SelectToken("Language").ToString(),
            Type = decrypted.SelectToken("Type").ToString(),
            Director = decrypted.SelectToken("Director").ToString(),
            Writer = decrypted.SelectToken("Writer").ToString(),
        };

        return await Task.FromResult(movie);
    }
}