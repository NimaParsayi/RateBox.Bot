namespace RateBox.Bot.Controllers;
public class HandleMessages
{
    public async Task CheckMessage(ITelegramBotClient bot, Message msg)
    {
        var msgId = msg.MessageId;
        var msgText = msg.Text;
        var msgFrom = msg.From;

        if (msgText.Equals("/start"))
        {
            await bot.SendTextMessageAsync(msgFrom.Id, "🐝 ویسبی برای شما فعال است !");
        }
        else
            await bot.SendTextMessageAsync(msgFrom.Id, msgId.ToString());
    }
}
