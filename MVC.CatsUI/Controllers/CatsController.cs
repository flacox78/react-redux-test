using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.CatsUI.Common;
using MVC.CatsUI.Models;
using MVC.CatsUI.UIModels;
using Newtonsoft.Json;

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
        public virtual async Task<IEnumerable<PetNameByGender>> CatByGender()
        {
            try
            {
                // Retrieve data from API and deserialize
                string jsonResponse = await AppHelper.APIGetData(_appSettings.Value.CatsMediaType, _appSettings.Value.CatsUrl, APIResponseType.Json);
                List<Owner> ownwers = JsonConvert.DeserializeObject<List<Owner>>(jsonResponse);

                // Filter and retrieve required Data                
                IEnumerable<PetNameByGender> cats = ownwers.Where(p => p.Pets != null).SelectMany(m => m.Pets.Where(n => (n.Type == PetType.Cat)).Select(o => new PetNameByGender() { OwnerGender = m.Gender.ToString(), PetName = o.Name })).ToList();

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