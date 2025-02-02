using Grpc.Net.Client;
using Hello;

class Program
{
    static async Task Main(string[] args)
    {
        // Подключение к grpcbin (используется HTTPS)
        using var channel = GrpcChannel.ForAddress("https://grpcb.in:443");
        var client = new HelloService.HelloServiceClient(channel);

        try
        {
            // Вызов метода SayHello
            var request = new HelloRequest { Greeting = "gRPC" };
            var response = await client.SayHelloAsync(request);

            Console.WriteLine($"Ответ сервера: {response.Reply}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}