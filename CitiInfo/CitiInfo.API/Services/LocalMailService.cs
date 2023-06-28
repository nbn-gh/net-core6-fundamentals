namespace CitiInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];

        }


        public void Send(string subject, string message)
        {
            // Sending Mail- writing to console.
            Console.WriteLine("************* Sending Mail Service *************");

            Console.WriteLine($"\tMail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}.");
            Console.WriteLine($"\t\tSubject: {subject}");
            Console.WriteLine($"\t\tMessage: {message}");

            Console.WriteLine("*************************************************");

        }
    }
}
