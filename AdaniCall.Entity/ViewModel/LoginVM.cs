using AdaniCall.Entity;
using AdaniCall.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaniCall.Entity
{
    [Serializable]
    public class LoginVM
    {
        public LoginVM()
        {
            UserName = FirstName = LastName = AlternateEmail = Password = Avatar = Profile_Logo = Source = SessionId = string.Empty;
        }
        public bool IsFirstTimeLogin { get; set; }

        public Int64 Id { get; set; }
        //public StateEnums.Mode Mode { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AlternateEmail { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
        public string Profile_Logo { get; set; }
      
        public byte StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public char Initial { get; set; }
        public string InitialChars { get; set; }
        public bool IsSendNotificationMail { get; set; }
        public string Source { get; set; }

        public string UserIds { get; set; }     //comma separated user ids : eg. 1, 2 etc

        public string Flag { get; set; }
        public Int32 UserRole { get; set; }
        public byte RoleId { get; set; }

        public Int64 ParentId { get; set; }
        public bool IsEmailVerified { get; set; }
        public string EmailVerficationCode { get; set; }
        public DateTime EmailVerificationDate { get; set; }
        public bool IsEmailSent { get; set; }
        public string LogoName { get; set; }
        public string DisplayRole { get; set; }
        public long LanguageId { get; set; }
        //public Int64 CompanyID { get; set; }
        public Int64 LocationID { get; set; }
        public string CallerID { get; set; }
        public string KioskID { get; set; }

        public bool isRemember { get; set; }
          
        public string ProfileLanguage { get; set; }
        public string SelectedLanguage { get; set; }
    }
}
