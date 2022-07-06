namespace RateBox.Bot.TextGenerators;
public class PersianTextGenrators
{
    public static Tuple<string, InlineKeyboardMarkup> MovieDetails(MovieDto movie)
    {
        var type = movie.Type == "series" ? "سریال" : "فیلم";
        var time = movie.Runtime.Replace("min", "دقیقه");
        var text = $"*🆔 شناسه:* `{movie.Id}`" +
            $"\n- _{type}_" +
            $"\n*🎦 عنوان:* {movie.Title} _[{movie.Year}]_" +
            $"\n🕛 زمان: {time}" +// _({ time})_
            $"\n*⭐ امتیاز:* _{movie.IMDBRating}/10_ از _{movie.IMDBRates}_ رای" +
            $"\n*🌎 کشور:* {EnglishToPersianConverter.ConvertCountries(movie.Country)}" +
            $"\n*ℹ️ رده سنی:* {EnglishToPersianConverter.ConvertRate(movie.Rated)}" +
            $"\n*🎭 ژانرها:* {EnglishToPersianConverter.ConvertGenres(movie.Genre)}" +
            $"\n*👥 ستارگان:* {movie.Actors}" +
            $"\n*🎬 کارگردان:* {movie.Director}" +
            $"\n*✍️ نویسنده:* {movie.Writer}" +
            $"\n*📝 خلاصه داستان:* _{movie.Plot}_" +
            $"\n\n[پوستر]({movie.Poster})";

        var keyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithUrl("🎦 دیدن در IMDB",$"https://imdb.com/title/{movie.Id}")
            },
            new[]
            {
                InlineKeyboardButton.WithUrl("🔗 عضویت در کانال ریت باکس", "https://t.me/RateBox")
            }
        });

        return new Tuple<string, InlineKeyboardMarkup>(text, keyboard);
    }
}