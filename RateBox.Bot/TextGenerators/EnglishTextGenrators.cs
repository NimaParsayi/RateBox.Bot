namespace RateBox.Bot.TextGenerators;
public static class EnglishTextGenrators
{
    public static Tuple<string, InlineKeyboardMarkup> MovieDetails(MovieDto movie)
    {
        var text = $"*🆔 IMDB Id:* `{movie.Id}`" +
            $"\n- _{movie.Type.ToUpperInvariant()}_" +
            $"\n*🎦 Title:* {movie.Title} _[{movie.Year}]_ _({movie.Runtime})_" +
            $"\n⭐ *IMDB* Rating is _{movie.IMDBRating}/10_ of _{movie.IMDBRates}_ Votes" +
            $"\n*Ⓜ️ MetaScore:* {movie.Metascore}" +
            $"\n*🌎 Country:* {movie.Country}" +
            $"\n*ℹ️ Rated:* {movie.Rated}" +
            $"\n*🎭 Genres:* {movie.Genre}" +
            $"\n*👥 Stars:* {movie.Actors}" +
            $"\n*🎬 Director:* {movie.Director}" +
            $"\n*✍️ Writer:* {movie.Writer}" +
            $"\n*📝 Storyline:* _{movie.Plot}_" +
            $"\n\n[Movie Poster]({movie.Poster})";
        var keyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithUrl("🎦 Open Movie IMDB",$"https://imdb.com/title/{movie.Id}")
            },
            new[]
            {
                InlineKeyboardButton.WithUrl("🔗 Join Ratebox Channel", "https://t.me/RateBox")
            }
        });

        return new Tuple<string, InlineKeyboardMarkup>(text, keyboard);
    }
}
