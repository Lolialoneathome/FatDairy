using Dapper;
using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System;
using System.Data;
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
                    },
                    commandType: CommandType.StoredProcedure
                );

            fatty.Id = query.Single();
        }

        public async Task<Fatty> GetByEmail(string email)
        {
            var spName = "public.get_fatty_by_mail";
            var query = await _connection.QueryAsync<FattyDataFromDbDTO>(
                    spName,
                    new
                    {
                        mail = email
                    },
                    commandType: CommandType.StoredProcedure
                );
            var dto = query.SingleOrDefault();
            if (dto == null) return null;
            var userInfo = new UserInfo(dto.name, dto.surname, dto.password, dto.email, dto.birthday, (Sex)dto.sex);
            var fatty = new Fatty(userInfo, dto.hidefoodtrach, dto.hideage, dto.hideemail, dto.currentweight, dto.desiredweight, dto.heigth, null);
            fatty.Id = dto.id;
            return fatty;
        }

        public async Task<Fatty> GetById(int id)
        {
            var spName = "public.get_fatty_by_id";
            var query = await _connection.QueryAsync<FattyDataFromDbDTO>(
                    spName,
                    new
                    {
                        fatty_id = id
                    },
                    commandType: CommandType.StoredProcedure
                );
            var dto = query.SingleOrDefault();
            if (dto == null) return null;
            var userInfo = new UserInfo(dto.name, dto.surname, dto.password, dto.email, dto.birthday, (Sex)dto.sex);
            var fatty = new Fatty(userInfo, dto.hidefoodtrach, dto.hideage, dto.hideemail, dto.currentweight, dto.desiredweight, dto.heigth, null);
            fatty.Id = dto.id;
            return fatty;
        }


        protected class FattyDataFromDbDTO
        {
            public int id;
            public string name;
            public string surname;
            public string password;
            public string email;
            public DateTime birthday;
            public short sex;
            public bool hidefoodtrach;
            public bool hideage;
            public bool hideemail;
            public double currentweight;
            public double desiredweight;
            public double heigth;
            public int trainer_id;
        }
    }
}
