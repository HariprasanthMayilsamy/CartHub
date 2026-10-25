using CartHubData.CartHubUserModel;
using CartHubData.DBContext;
using ICartHubService.ICartHubUserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartHubService.CarthubUserService
{
    public class CartHubUserService:ICartHubUserService
    {
        private readonly CartHubDBContext objCarthubDBContext;
        public CartHubUserService(CartHubDBContext cartHubDBContext)
        {
            objCarthubDBContext = cartHubDBContext;
        }
        public async Task<User> SaveUserDetails(User objUser)
        {
            try
            {
                objCarthubDBContext.Add(objUser);
                await objCarthubDBContext.SaveChangesAsync();
                return objUser;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public async Task<List<User>> CheckIsAuthenticated(UserLoginCredentials objUserLoginCredentials)
        {
            try
            {
                List<User> lstUser = new List<User>();
                lstUser = await objCarthubDBContext.T_User.Where(x =>x.UserName == objUserLoginCredentials.UserName &&x.Password == objUserLoginCredentials.Password).ToListAsync();
                return lstUser;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Country>>GetCountrylst()
        {
            try
            {
                List<Country> lstCountry = new List<Country>();
                lstCountry = await objCarthubDBContext.T_Country.Where(x => x.IsActive == true && x.IsDelete == false).ToListAsync();
                return lstCountry;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<State>>GetStatelst(int CountryID)
        {
            try
            {
                List<State> lstState = new List<State>();
                lstState = await objCarthubDBContext.T_State.Where(x => x.IsActive == true && x.IsDelete == false && x.CountryID == CountryID).ToListAsync();
                return lstState;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<City>>GetCitylst(int StateID)
        {
            try
            {
                List<City> lstCity = new List<City>();
                lstCity = await objCarthubDBContext.T_City.Where(x => x.IsActive == true && x.IsDelete == false && x.StateID == StateID).ToListAsync();
                return lstCity;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public bool ChkAttributeExistency(AttributeExistency objAttributeExistency)
        {
            try
            {
                bool Result = false;
                
                if (objAttributeExistency.ActionType == 1)
                {
                    var Value = objCarthubDBContext.T_User.Where(x => x.UserName == objAttributeExistency.AttributeValue).ToList();
                    if (Value != null && Value.Count>0)
                    {
                        Result = true;
                    }
                }
                if (objAttributeExistency.ActionType == 2)
                {
                    var Value = objCarthubDBContext.T_User.Where(x => x.MobileNo == objAttributeExistency.AttributeValue || x.MobileNo_2 == objAttributeExistency.AttributeValue).ToList();
                    if (Value != null && Value.Count > 0)
                    {
                        Result = true;
                    }
                }
                if(objAttributeExistency.ActionType==3){
                    var Value = objCarthubDBContext.T_User.Where(x => x.EmailID == objAttributeExistency.AttributeValue).ToList();
                    if (Value != null && Value.Count > 0)
                    {
                        Result = true;
                    }
                }
                return Result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
