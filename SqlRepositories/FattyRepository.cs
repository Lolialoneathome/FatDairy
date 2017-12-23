using Dapper;
using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SqlRepositories
{
    public class FattyRepository : BaseSqlRepository, IFattyRepository
    {
        public FattyRepository(DbConnection connection) : base(connection)
        {
        }

        public async Task AddFatty(Fatty fatty)
        {
            var spName = "public.add_fatty";
            var query = await _connection.QueryAsync<int>(
                    spName,
                    new
                    {
                        name = fatty.UserInfo.Name,
                        surname = fatty.UserInfo.Surname,
                        password = fatty.UserInfo.Password,
                        email = fatty.UserInfo.Email,
                        birthday = fatty.UserInfo.Birthday,
                        sex = (short)fatty.UserInfo.Sex,
                        hidefoodtrach = fatty.HideFoodTrack,
                        hideage = fatty.HideAge,
                        hideemail =fatty.HideEmail,
                        currentweight = fatty.CurrentWeigth,
                        desiredweight = fatty.DesiredWeigth,
                        heigth = fatty.Heigth,
                        trainer_id = 0 
                    }
                );

            fatty.Id = query.Single();
        }

        public async Task<Fatty> GetByEmail(string email)
        {
            var spName = "public.get_fatty_by_mail";
            var query = await _connection.QueryAsync<Fatty>(
                    spName,
                    new
                    {
                        mail = email
                    }
                );
            return query.SingleOrDefault();
        }

        public async Task<Fatty> GetById(int id)
        {
            var spName = "public.get_fatty_by_id";
            var query = await _connection.QueryAsync<Fatty>(
                    spName,
                    new
                    {
                        fatty_id = id
                    }
                );
            return query.SingleOrDefault();
        }
    }
}
