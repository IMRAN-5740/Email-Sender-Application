namespace EmailSenderApplication.Models
{
    public class EmailViewModel
    {
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> BCc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }    

    }
}
