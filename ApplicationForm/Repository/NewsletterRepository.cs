using ApplicationForm.Interface;
using ApplicationForm.Models;
using DapperExtensions;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace ApplicationForm.Repository
{
    public class NewsletterRepository : INewsletterRepository
    {
        private string _connectionString { get; }


        public NewsletterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public bool AlreadySubscribed(string email)
        {
            using (IDbConnection cn = new SQLiteConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    return cn.Get<ApplyModel>(email) != null;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public void Apply(ApplyModel model)
        {
            using (IDbConnection cn = new SQLiteConnection(_connectionString))
            {
                try
                {
                    cn.Open();
                    cn.Insert(model);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}