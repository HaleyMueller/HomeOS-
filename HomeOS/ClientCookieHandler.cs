using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS
{
    public static class ClientCookieHandler
    {
        public static string GetUUID(HttpResponse response, HttpRequest request)
        {
            string ret = GetCookie(request);

            if (string.IsNullOrEmpty(ret))
            {
                ret = WriteCookie(response);
            }

            return ret;
        }

        public static bool IsNewClient(string GUID)
        {
            var ret = true;

            var check = BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Where(x => x.Identifier_IP == GUID).FirstOrDefault();

            if (check == null || check == new BusinessImplementation.ClientSettings())
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        private static string GetUUID()
        {
            return Guid.NewGuid().ToString();
        }

        private static string WriteCookie(HttpResponse response)
        {
            var ret = GetUUID();

            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddYears(10);

            response.Cookies.Append("UUID", ret, option);

            return ret;
        }

        private static string GetCookie(HttpRequest request)
        {
            string ret = null;

            if (request.Cookies.ContainsKey("UUID"))
            {
                ret = request.Cookies["UUID"];
            }

            return ret;
        }
    }
}
