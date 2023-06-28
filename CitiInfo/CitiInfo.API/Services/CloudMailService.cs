namespace CitiInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
                _mailTo = configuration["mailSettings:mailToAddress"];
                _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

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
