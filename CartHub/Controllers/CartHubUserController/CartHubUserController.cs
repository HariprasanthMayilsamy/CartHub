using CartHubData.CartHubUserModel;
using ICartHubService.ICartHubUserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CartHub.Controllers.CartHubUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartHubUserController : ControllerBase
    {
        private readonly ICartHubUserService objICartHubUserService;
        public CartHubUserController(ICartHubUserService iCartHubUserService)
        {
            objICartHubUserService = iCartHubUserService;
        }

        [HttpPost]
        [Route("SaveUserDetails")]
        public async Task<IActionResult> SaveUserDetails([FromBody]User objUser)
        {
            try
            {
                var Result = await objICartHubUserService.SaveUserDetails(objUser);
                if (Result != null)
                {
                    return Ok(objUser);
                }
                else
                {
                    return BadRequest(objUser);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("CheckIsAuthenticated")]
        public async Task<IActionResult> CheckIsAuthenticated([FromBody] UserLoginCredentials objUserLoginCredentials)
        {
            try
            {
                var Result = await objICartHubUserService.CheckIsAuthenticated(objUserLoginCredentials);
                if (Result != null && Result.Count>0)
                {
                    if (Result[0].IsActive == true && Result[0].IsDelete==false)
                    {
                        return Ok(Result);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCountryDetails")]
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                var Result = await objICartHubUserService.GetCountrylst();
                if(Result!=null && Result.Count > 0)
                {
                    return Ok(Result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetStateDetails/{countryID}")]
        public async Task<IActionResult>GetState(int CountryID)
        {
            try
            {
                var Result = await objICartHubUserService.GetStatelst(CountryID);
                if (Result != null && Result.Count > 0)
                {
                    return Ok(Result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCityDetails/{stateID}")]
        public async Task<IActionResult> GetCity(int StateID)
        {
            try
            {
                var Result = await objICartHubUserService.GetCitylst(StateID);
                if (Result != null && Result.Count > 0)
                {
                    return Ok(Result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("ChectAttributeExistency")]
        public IActionResult chkAttributeExistency(AttributeExistency objAttributeExistency)
        {
            try
            {
                bool result = false;
                result = objICartHubUserService.ChkAttributeExistency(objAttributeExistency);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
