using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication.Migrations;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private Model1 db = new Model1();

        private string CalculateSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(str));

            string hashValuestr = Encoding.Default.GetString(hashValue);

            return hashValuestr;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod ]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string LoginResult(string username, string passwd)
        {
            passwd = CalculateSHA256(passwd);
            var row = db.users
                .Where(user => user.username == username)
                .Where(user => user.passwd == passwd)
                .SingleOrDefault();
            if (row != null)
            {
                if (row.userApiToken == null)
                {
                    row.userApiToken = Guid.NewGuid().ToString("N");

                    db.SaveChanges();
                }
                var rowCol = db.users
                    .Where(user => user.id == row.id)
                    .Select(user => new { user.userApiToken })
                    .SingleOrDefault();

                return rowCol.userApiToken;
                // return row;
            }
            else
            {
                string LoginMsgError = "Invalid login od password.";
                return LoginMsgError;
            }
        }

        // [WebMethod]
        // [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        // public string ActivePlayers(string token)
        // {
        //     var row = db.users
        //         .Where(user => user.userApiToken = token)
        //         .SingleOrDefault();
        // }
    }
}