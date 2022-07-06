using RateBox.Bot.TextGenerators;

namespace RateBox.Bot.Controllers;
public class HandleChosenInlineResults
{
    public async Task CheckMessage(ITelegramBotClient bot, ChosenInlineResult message)
    {
        var movieId = message.ResultId;
        var movie = await ApiHandler.OmdbHandler.GetMovieDetails(movieId);
        var tuple = EnglishTextGenrators.MovieDetails(movie);
        
        await bot.EditMessageTextAsync(message.InlineMessageId, tuple.Item1, ParseMode.Markdown, replyMarkup: tuple.Item2);
    }
}