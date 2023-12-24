using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Innoplatforma.Server.TelegramBot.Handlers.Errors;
using Innoplatforma.Server.TelegramBot.Utils;

namespace Innoplatforma.Server.TelegramBot;

class Program
{
    public static readonly TelegramBotClient botClient = new TelegramBotClient("6810292886:AAGpm1YDV4mdZg2h_YE26w-WcnC6HWl9woI");
    public static readonly CancellationTokenSource cts = new();
    public static readonly string apiRootPath = "https://localhost:7162/api/";


    static async Task Main()
    {
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = new UpdateType[] { UpdateType.Message }
        };

        var pollingErrorHandler = new PollingError();
        var echoHandler = new Controller(apiRootPath, new HttpClient());

        try
        {
            botClient.StartReceiving(
                updateHandler: echoHandler.HandleUpdateAsync,
                pollingErrorHandler: pollingErrorHandler.HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");
            await Task.Delay(Timeout.Infinite, cts.Token);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error occurred: " + ex.Message);
        }
        finally
        {
            cts.Cancel();
        }
    }
}
