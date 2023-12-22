using Telegram.Bot;

namespace Innoplatforma.Server.TelegramBot.Handlers.Users;

public class StartCommand
{
    public async Task<bool> HandleStartAsync(ITelegramBotClient _botClient, CancellationToken _cts, long chatId)
    {
        Console.WriteLine($"habri start niki message in chat {chatId}.");

        await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "siz tori start berdiz:\n/start",
            cancellationToken: _cts);
        return true;
    }
}
