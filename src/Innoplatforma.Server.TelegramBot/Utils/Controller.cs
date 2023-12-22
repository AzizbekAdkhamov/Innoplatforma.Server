using Telegram.Bot.Types;
using Telegram.Bot;
using Innoplatforma.Server.TelegramBot.Handlers.Users;

namespace Innoplatforma.Server.TelegramBot.Utils;

public class Controller
{
    private readonly StartCommand _startHandler;

    public Controller()
    {
        _startHandler = new StartCommand();
    }
    public async Task HandleUpdateAsync(ITelegramBotClient _botClient, Update update, CancellationToken _cts)
    {
        if (update.Message is not { } message)
            return;
        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;

        Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
        if (messageText == "/start")
        {
            await _startHandler.HandleStartAsync(_botClient, _cts, chatId);
        }

    }

}
