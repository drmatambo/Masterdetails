using System;
using System.Threading.Tasks;

namespace VumbaSoft.Masterdetails.Components.Mail
{
    public interface IMailClient
    {
        Task SendAsync(String email, String subject, String body);
    }
}
