using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using var client = new HttpClient();

var data = new Dictionary<string, string>()
{
    ["username"] = "Bob",
    ["password"] = "hunter12"
};
var form = new FormUrlEncodedContent(data);

var response = await client.PostAsync("http://localhost:8000/index.php", form);
var result = await response.Content.ReadFromJsonAsync<Result>();

Console.WriteLine(result);

return;

record Result(
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("password_strength")] string PasswordStrength,
    [property: JsonPropertyName("success")] bool Success
);