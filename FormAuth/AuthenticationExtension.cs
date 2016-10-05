using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace FormAuth
{
    public class AuthenticationExtension : IAuthenticationExtension2
    {

        public void GetUserInfo(IRSRequestContext requestContext, out System.Security.Principal.IIdentity userIdentity, out IntPtr userId)
        {
            //throw new NotImplementedException();

            userIdentity = null;
            if (requestContext.User != null)
            {
                userIdentity = requestContext.User;
            }
            
            

            // initialize a pointer to the current user id to zero
            userId = IntPtr.Zero;
        }

        public void GetUserInfo(out System.Security.Principal.IIdentity userIdentity, out IntPtr userId)
        {


            // If the current user identity is not null,
            // set the userIdentity parameter to that of the current user 
            if (HttpContext.Current != null
                  && HttpContext.Current.User != null)
            {
                userIdentity = HttpContext.Current.User.Identity;
            }
            else
            // The current user identity is null. This happens when the user attempts an anonymous logon.
            // Although it is ok to return userIdentity as a null reference, it is best to throw an appropriate
            // exception for debugging purposes.
            // To configure for anonymous logon, return a Gener
            {
                //System.Diagnostics.Debug.Assert(false, "Warning: userIdentity is null! Modify your code if you wish to support anonymous logon.");
                throw new NullReferenceException("Anonymous logon is not configured. userIdentity should not be null!");
            }

            // initialize a pointer to the current user id to zero
            userId = IntPtr.Zero;
        }

        /// <summary>
        /// The IsValidPrincipalName method is called by the report server when 
        /// the report server sets security on an item. This method validates 
        /// that the user name is valid for Windows.The principal name needs to 
        /// be a user, group, or builtin account name.
        /// </summary>
        /// <param name="principalName">A user, group, or built-in account name
        /// </param>
        /// <returns>true when the principle name is valid</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        public bool IsValidPrincipalName(string principalName)
        {
            return AuthenticationUtilities.VerifyUser(principalName);            
        }


        /// <summary>
        /// Indicates whether a supplied username and password are valid.
        /// </summary>
        /// <param name="userName">The supplied username</param>
        /// <param name="password">The supplied password</param>
        /// <param name="authority">Optional. The specific authority to use to
        /// authenticate a user. For example, in Windows it would be a Windows 
        /// Domain</param>
        /// <returns>true when the username and password are valid</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        public bool LogonUser(string userName, string password, string authority)
        {
            return AuthenticationUtilities.VerifyPassword(userName, password);
        }

        /// <summary>
        /// You must implement SetConfiguration as required by IExtension
        /// </summary>
        /// <param name="configuration">Configuration data as an XML
        /// string that is stored along with the Extension element in
        /// the configuration file.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        public void SetConfiguration(String configuration)
        {
            // No configuration data is needed for this extension
        }

        /// <summary>
        /// You must implement LocalizedName as required by IExtension
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        public string LocalizedName
        {
            get
            {
                return null;
            }
        }
    }
}
