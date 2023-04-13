using RabbitMQ.Client;
using System.Text;

// RabbitMQ ya bağlantı oluşturmak için bağlantı bilgilerini
// factory instancemiz üzerinden ileteceğiz.


// Bağlantı Oluşturma
ConnectionFactory factory = new()
{
    Uri = new("")
};

// Connection aktifleştirme ve channel açma

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();


// Queue oluşturma

channel.QueueDeclare(queue: "example-queue", exclusive: false);

// Queue'ya mesaj gönderme.

// RabbitMQ kuyruğa atacağı mesajı byte türünden kabul etmektedir.

// Bu yüzden mesajları byt dizisine a dönüştürmek gerekmektedir.

//byte[] message = Encoding.UTF8.GetBytes("Hello world");


//// Oluşturulan channel ile kuyruk oluşturduk. Kuyruğa mesajı göndermek için
//// yine channel i kullanıcaz.

//// Burada default exchange yani directExchange i belirttik.
//channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

while (true)
{
    string input = Console.ReadLine();
    Console.WriteLine($"Mesaj Gönderiliyor... Mesajınız: {input}");

    byte[] message = Encoding.UTF8.GetBytes(input);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

    Console.WriteLine($"Mesaj gönderildi.");
    Console.WriteLine();
}


