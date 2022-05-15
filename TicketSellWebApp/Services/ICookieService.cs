using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Services
{
    public interface ICookieService
    {
        public T GetCookie<T>(HttpRequest request,String name);
        public void SetCookie<T>(HttpResponse _httpResponse,String name, T value);
        
    }
}
