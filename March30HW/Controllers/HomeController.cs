using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using March30HW.Models;
using ClassLibrary2;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace March30HW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home(int page)
        {
            Ads ad = new Ads(@"Data Source=.\sqlexpress;Initial Catalog=ADS;Integrated Security=True;");
            AdViewModel vm = new AdViewModel();
            if(page <= 0)
            {
                page = 1;
            }
            int pagecount = 3;
            if(page > 1)
            {
                vm.NextPage = page -1;
            }
            int from = (page - 1) * pagecount;
            int to = from + pagecount;
            int total = ad.GetCount();
            if(to < total)
            {
                vm.PreviousPage = page + 1;
            }
            vm.Ad = ad.Get3(from, pagecount);
            List<int> x = new List<int>();
            if (HttpContext.Session.Get<List<int>>("user") != null)
            {
                x = HttpContext.Session.Get<List<int>>("user");
            }
            vm.UserId = x;
            return View(vm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addad(string name, string number, string text)
        {
            if(name == null)
            {
                name = "";
            }
            List<int> x = new List<int>();
            if(HttpContext.Session.Get<List<int>>("user") != null)
            {
                x = HttpContext.Session.Get<List<int>>("user");
            }
            Ads ad = new Ads(@"Data Source=.\sqlexpress;Initial Catalog=ADS;Integrated Security=True;");
            int y = ad.Add(name, number, text);
            x.Add(y);
            HttpContext.Session.Set("user", x);
            return Redirect("/home/home");
        }
        public IActionResult delete(int id)
        {
            Ads ad = new Ads(@"Data Source=.\sqlexpress;Initial Catalog=ADS;Integrated Security=True;");
            ad.delete(id);
            return Redirect("/home/home");
        }
    }
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
