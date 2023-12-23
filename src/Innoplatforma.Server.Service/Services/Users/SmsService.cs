using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Interfaces.Users;
using Innoplatforma.Server.Service.Services.Accounts.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Innoplatforma.Server.Service.Exceptions;

namespace Innoplatforma.Server.Service.Services.Users;

public class SmsService : ISmsService
{
    private readonly IConfiguration configuration;
    private readonly IRepository<User, long> userRepository;
    public SmsService(
        IConfiguration configuration,
        IRepository<User, long> userRepository)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }
    public async Task<string> GenerateTokenAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://notify.eskiz.uz/api/auth/login");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent($"{configuration["SmsConfig:Email"]}"), "email");
        content.Add(new StringContent($"{configuration["SmsConfig:Password"]}"), "password");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadAsStringAsync();

        var jsonToken = JsonConvert.DeserializeObject<JObject>(token);

        var tokenGenereted = jsonToken["data"]["token"].ToString();

        return tokenGenereted;
    }

    public async Task<bool> SendAsync(Message message)
    {
        var users = this.userRepository.SelectAll();
        

        if (users is null)
            throw new InnoplatformException(404, "Users is not found");


        var token = await GenerateTokenAsync();
        foreach (var user in users)
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://notify.eskiz.uz/api/message/sms/send");

            // Add the Authorization header with the Bearer token
            request.Headers.Add("Authorization", $"Bearer {token}");

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent($"{user.Phone}"), "mobile_phone");
            content.Add(new StringContent($"{message.Subject} \n {message.Body}"), "message");
            content.Add(new StringContent($"{configuration["SmsConfig:from"]}"), "from");
            request.Content = content;
            await client.SendAsync(request);


        }

        return true;
    }

    public Task<bool> SendMessageByTelegramAsync(long groupId, string url, string text)
    {
        throw new NotImplementedException();
    }
}
