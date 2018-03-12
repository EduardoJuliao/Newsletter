using ApplicationForm.Models;

namespace ApplicationForm.Interface
{
    public interface INewsletterRepository
    {
        void Apply(ApplyModel email);
        bool AlreadySubscribed(string email);
    }
}
