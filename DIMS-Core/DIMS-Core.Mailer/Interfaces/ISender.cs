using System.Threading.Tasks;

namespace DIMS_Core.Mailer.Interfaces
{
    public interface ISender
    {
        Task<bool> SendMessage(
            string subject,
            string html,
            params string[] emails);
    }
}