using PerfectSound.Model.Requests;
using PerfectSound.Model.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Interfaces
{
    public interface IUserService
    {
        //Model.Model.User Authenticate(UserLoginRequest request);
        List<Model.Model.User> Get(UserSearchRequest search);
        Model.Model.User GetById(int Id);
        Model.Model.User Insert(UserUpsertRequest request);
        Model.Model.User Update(int Id, UserUpsertRequest request);
        Model.Model.User Delete(int Id);
        Task<Model.Model.User> Login(string username, string password);
    }
}
