using ApplicationForm.Interface;
using ApplicationForm.Repository;
using SimpleInjector;
using System.Configuration;
using System.Data.SQLite;
using System.Diagnostics;
using Dapper;

namespace ApplicationForm.Infra
{
    public sealed class Persistence
    {
        private static Container Container { get; set; }

        private Persistence() { }

        ~Persistence()
        {
            Container?.Dispose();
        }

        [Conditional("DEBUG")]
        public static void DatabaseCreation(string slqConnectionString)
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqliteDialect();
            using (SQLiteConnection cn = new SQLiteConnection(slqConnectionString))
            {
                try
                {
                    cn.Open();
                    using (var command = new SQLiteCommand(@"
                        drop table if exists NewsletterSubscribers", cn))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(@"
                        create table NewsletterSubscribers (emailaddress varchar(50) primary key)", cn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public static void RegisterContainer()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

#if DEBUG
            DatabaseCreation(dbConnectionString);
#endif

            Container = new Container();
            Container.Register<INewsletterRepository>(() => new NewsletterRepository(dbConnectionString));
        }

        public static INewsletterRepository NewsletterRepository 
            => Container.GetInstance<INewsletterRepository>();
    }
}