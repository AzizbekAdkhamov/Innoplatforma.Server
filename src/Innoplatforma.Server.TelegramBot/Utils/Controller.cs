using Telegram.Bot.Types;
using Telegram.Bot;
using Innoplatforma.Server.TelegramBot.Handlers.Users;
using System.Net.Http;

namespace Innoplatforma.Server.TelegramBot.Utils;

public class Controller
{
    private readonly StartCommand _startHandler;
    private readonly HttpClient _httpClient;
    private readonly string _apiRootPath;

    public Controller(string apiRootPath, HttpClient httpClient)
    {
        _startHandler = new StartCommand();
        _apiRootPath = apiRootPath;
        _httpClient = httpClient;
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
            await _startHandler.HandleStartAsync(_botClient, _cts, chatId, _apiRootPath, _httpClient);
        }

    }

}
