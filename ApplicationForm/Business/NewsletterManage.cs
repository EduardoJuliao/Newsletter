using ApplicationForm.Infra;
using ApplicationForm.Models;
using System;

namespace ApplicationForm.Business
{
    public class NewsletterManager
    {
        public event EventHandler Applyied;
         
        public void Apply(ApplyModel model)
        {
            if (!Persistence.NewsletterRepository.AlreadySubscribed(model.Email))
            {
                Persistence.NewsletterRepository.Apply(model);
                Applyied?.Invoke(model.Email, EventArgs.Empty);
            }
            else
                throw new Exception($"The e-mail {model.Email} is alread registred in our database!");
        }
    }
}