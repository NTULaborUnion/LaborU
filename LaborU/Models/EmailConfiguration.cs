using System.Text;
using MailKit.Security;

namespace LaborU.Models;

public class EmailConfiguration
{
    public string Host { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string Sender { get; set; }
    public string SenderName { get; set; }
    public int Port { get; set; }
    public bool UseSSL { get; set; }
}