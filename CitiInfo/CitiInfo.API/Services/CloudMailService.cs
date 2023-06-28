namespace CitiInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";
        public void Send(string subject, string message)
        {
            Console.WriteLine("************* Sending Mail From Cloud Service *************");

            Console.WriteLine($"\tMail from {_mailFrom} to {_mailTo}, with {nameof(CloudMailService)}.");
            Console.WriteLine($"\t\tSubject: {subject}");
            Console.WriteLine($"\t\tMessage: {message}");

            Console.WriteLine("*************************************************");
        }
    }
}
