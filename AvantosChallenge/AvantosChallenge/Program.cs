using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var email = "krishnaveniv2025@gmail.com"; // Replace with your real email
        var url = "https://apply-to-avantos.dev-sandbox.workload.avantos-ai.net";
        var payload = $"{{\"email\": \"{email}\"}}";

        using var client = new HttpClient();

        // Set headers
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
