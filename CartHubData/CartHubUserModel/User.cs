using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartHubData.CartHubUserModel
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        //[Required]
        public string Name { get; set; } = null!;
        [Required]
        public string MobileNo { get; set; } = null!;
        public string? MobileNo_2 { get; set; }
        [Required]
        public string EmailID { get; set; } = null!;
        public string? Address { get;set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        [Required]
        public string UserType { get; set; } = null!;
    }
    public class UserLoginCredentials
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; } = null!;
        public string StateCode { get; set; }=null!;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        [ForeignKey("CountryID")]
        public Country Country { get; set; }
    }
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string CityName { get; set; } = null!;
        public string CityCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        [ForeignKey("StateID")]
        public State State { get; set; }
    }
    public class AttributeExistency
    {
        public int ActionType { get; set; }
        public string AttributeValue { get; set; } = null!;
    }
}
