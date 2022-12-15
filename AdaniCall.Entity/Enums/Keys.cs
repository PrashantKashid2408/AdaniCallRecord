using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaniCall.Entity.Enums
{
    public class KeyEnums
    {
        public enum JsonMessageType
        {
            PRIMARY,
            INFO,
            SUCCESS,
            WARNING,
            DANGER,
            ERROR,
            FAILURE,
            DEFAULT
        }

        public enum FileUploadApiKeys
        {
            FILE_UPLOAD_KEY,
            FILE_UPLOAD_VIRTUAL_PATH,
            FILE_UPLOAD_NAME,
            FILE_UPLOAD_DELETE_EXISTING,
            FILE_UPLOAD_FLAG
        }

        public enum MenuKeys
        {
            liViews,
            liUsers,
            liRegister,
            liCreate,
            liEditProfile,
            liChangePassword,
            liBookmark,
            liShare,
            liLikes,
            liMailer,
            liReport,
            liDashBoard,
            liRejected,
            liDisabled,
            liDeleted,
            liPlayList,
            liTransaction,
            liTransactionAll, 
            liLocationHead,
            liEmployees,
            liWordCloud,
            liWordCloudAssessments
        }

        public enum SessionKeys
        {
            UserId,
            UserCreatedById,
            UserName,
            UserRole,
            UserRoleName,
            FirstName,
            LastName,
            AlternateEmailID,
            UserLogo,
            IsEmailVerified,
            EmailVerficationCode,
            EmailVerificationDate,
            IsSendNotificationMail,
            GridPageSize,
            LibraryView,
            UserSession,
            UserLanguage,
            LanguageId,
            Mode,
            LandingLanguage,
            Overview,
            UserEmailID,
            CallerID,
            LocationID,
            KioskID,
        }

        public enum ApplicationKeys
        {
            Languages = 0,
            Formats = 1,
            Countries = 2,
            Communites = 3,
            SocialMediaMaster = 4,
            LanguagesSelectAll = 5,
        }

        public enum ListType
        {
            AllTran,
            WordCloud
        }

        public enum TempDataKeys
        {
            Flag,
            MessageToClient,
            WarningMessage,
            InfoMessage
        }
    }
}
