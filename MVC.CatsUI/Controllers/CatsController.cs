using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.CatsUI.Common;
using MVC.CatsUI.Models;

namespace MVC.CatsUI.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;

        public CatsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet("[action]")]
        public virtual async Task<IEnumerable<KeyValuePair<string,string>>> CatByGender()
        {
            try
            {
                // Retrieve data from API and deserialize
                string jsonResponse = await AppHelper.APIGetData(_appSettings.Value.CatsMediaType, _appSettings.Value.CatsUrl, APIResponseType.Json);
                

                // Filter and retrieve required Data
                IEnumerable<KeyValuePair<string, string>> cats = new List<KeyValuePair<string, string>>();

                return cats;
            }
            catch (Exception ex)
            {
                // Log errors

                // Throw exception
                throw new Exception("Error retrieving data");
            }
        }
    }
}