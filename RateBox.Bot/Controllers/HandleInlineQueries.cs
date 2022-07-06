namespace RateBox.Bot.Controllers;
public class HandleInlineQueries
{
    public async Task CheckText(ITelegramBotClient bot, InlineQuery query)
    {
        if (query.Query.Trim() != "" && query.Query.Length >= 4)
        {
            var list = new List<InlineQueryResult>();
            foreach (var item in await ApiHandler.OmdbHandler.SearchByName(query.Query))
            {
                var text = $"- Title: {item.Title}" +
                    $"\n- Year: {item.Year}";

                var iqrp = new InlineQueryResultArticle(
                    id: item.Id,
                    title: $"{item.Title}",
                    inputMessageContent: new InputTextMessageContent(text)
                   )
                {
                    Description = $"Year: {item.Year}",
                    ThumbUrl = item.Poster,
                    //ThumbHeight = 300,
                    //ThumbWidth = 120,
                    ReplyMarkup = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("🔗 Rate Box Channel", "https://t.me/RateBox")
                        }
                    })
                };
                list.Add(iqrp);
            }
            var results = list.ToArray();

            try
            {
                await bot.AnswerInlineQueryAsync(inlineQueryId: query.Id, results: results,cacheTime: 0);
            }
            catch (Exception ex)
            {
               // await bot.AnswerInlineQueryAsync(query.Id, new InlineQueryResultArticle("nothingtoshow", ))
            }
        }
    }
}