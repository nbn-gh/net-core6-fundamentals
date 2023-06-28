namespace CitiInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";

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
