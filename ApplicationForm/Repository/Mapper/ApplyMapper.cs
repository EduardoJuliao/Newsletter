using ApplicationForm.Models;
using DapperExtensions.Mapper;

namespace ApplicationForm.Repository.Mapper
{
    public class ApplyMapper : ClassMapper<ApplyModel>
    {
        public ApplyMapper()
        {
            Table("NewsletterSubscribers");

            Map(x => x.Email)
                .Column("EmailAddress")
                .Key(KeyType.Assigned);
        }
    }
}