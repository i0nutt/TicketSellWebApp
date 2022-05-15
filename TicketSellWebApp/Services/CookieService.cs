using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Services
{
    public class CookieService : ICookieService
    {
        public T GetCookie<T>(HttpRequest request, string name)
        {
            try
            {
                if (request.Cookies.TryGetValue(name, out var cookieString))
                {
                    return JsonConvert.DeserializeObject<T>(cookieString);
                }
            }
            catch (Exception) { }
            return default;
        }

        public void SetCookie<T>(HttpResponse _httpResponse, string name, T value)
        {
            var cookiesString = JsonConvert.SerializeObject(value);
            _httpResponse.Cookies.Append(
                name,
                cookiesString,
                new CookieOptions { Secure = true, SameSite = SameSiteMode.Lax, MaxAge = TimeSpan.FromDays(365) });
        }
    }
}
