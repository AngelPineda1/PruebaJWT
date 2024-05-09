HttpClient httpClient = new HttpClient()
{
    BaseAddress = new Uri("https://localhost:44383/")
};
var response = httpClient.GetStringAsync("api/Saludos").Result;

Console.WriteLine("Usuario: ");
string usuario=Console.ReadLine()??"";

Console.WriteLine("Password:");
string pass = Console.ReadLine() ?? "";

var token = httpClient.PostAsync($"api/login?username={usuario}&password={pass}",null).Result;

Console.WriteLine(token);

HttpRequestMessage rrm = new();
rrm.RequestUri = new Uri(httpClient.BaseAddress+"api/Saludos");
rrm.Method=HttpMethod.Get;
rrm.Headers.Add("Authorization",$"Bearer {token}");
var resp = httpClient.SendAsync(rrm).Result;

var saludo=resp.Content.ReadAsStringAsync().Result;
Console.WriteLine(saludo);
Console.ReadLine();
