using CartHubData.CartHubUserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICartHubService.ICartHubUserService
{
    public interface ICartHubUserService
    {
        public Task<User> SaveUserDetails(User objUser);
        public Task<List<User>> CheckIsAuthenticated(UserLoginCredentials objUserLoginCredentials);
        public Task<List<Country>> GetCountrylst();
        public Task<List<State>> GetStatelst(int CountryID);
        public Task<List<City>> GetCitylst(int StateID);
        public bool ChkAttributeExistency(AttributeExistency objAttributeExistency);
    }
}
