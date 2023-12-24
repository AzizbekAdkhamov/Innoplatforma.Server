using System.Net.Http;
using Telegram.Bot;

namespace Innoplatforma.Server.TelegramBot.Handlers.Users;

public class StartCommand
{
    public async Task<bool> HandleStartAsync(ITelegramBotClient _botClient, CancellationToken _cts, long chatId, 
                                string apiRootPath, HttpClient _httpClient)
    {
        string apiUrl = $"{apiRootPath}Users/CheckUser/{chatId}";

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl, _cts);

        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Welcome",
                cancellationToken: _cts);
        }
        else
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Iltimos telefon raqmingizni yuboring.",
                cancellationToken: _cts);
        }

        
        return true;
    }
}
