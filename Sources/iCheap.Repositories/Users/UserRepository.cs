using System;
using iCheap.Models;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IUserRepository
    {
        Users UserLogin(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly string storedName = "sp_Users";

        public Users UserLogin(string username, string password)
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: "UserLogin");
            param.Add("Username", username, DbType.String);
            param.Add("Password", password, DbType.String);

            var users = SQLHelper.QuerySP<Users>(storedName, param);
            if (users != null && users.Any())
                return users.Single();

            return null;
        }
    }
}
