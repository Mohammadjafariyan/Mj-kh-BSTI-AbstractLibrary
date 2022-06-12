using System;
using System.Collections.Generic;
using System.IO;
using BigPardakht.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AbstractLibrary.Service.Theme
{
    public class DashboardThemeProvider
    {
        
        private IHostingEnvironment Environment;
 
        public DashboardThemeProvider(IHostingEnvironment _environment,IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Environment = _environment;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;



        public List<Theme> GetThemes()
        {
          
            return new List<Theme>
            {
                new Theme
                {
                    Name = "signal",
                    Color="#0f81c7",
                    Translate =MyGlobal.GetTranslate()["signal"] 
                }, new Theme
                {
                    Name = "greyson",
                    Color="#5c8f94",
                    Translate =MyGlobal.GetTranslate()["greyson"] 
                }, new Theme
                {
                    Name = "fresca",
                    Color="#a2d5f2",
                    Translate =MyGlobal.GetTranslate()["fresca"] 
                }, new Theme
                {
                    Name = "darkster",
                    Color="#0d0d0d",
                    Translate =MyGlobal.GetTranslate()["darkster"] 
                }, new Theme
                {
                    Name = "hello_kiddie",
                    Color="#ee6188",
                    Translate =MyGlobal.GetTranslate()["hello_kiddie"] 
                }, new Theme
                {
                    Name = "blue_voltage",
                    Color="#7ebcfa",
                    Translate =MyGlobal.GetTranslate()["blue_voltage"] 
                },
                new Theme
                {
                    Name = "hootstrap",
                    Color="#63e792",
                    Translate =MyGlobal.GetTranslate()["hootstrap"] 
                },
                new Theme
                {
                    Name = "herbie",
                    Color="#74dbef",
                    Translate =MyGlobal.GetTranslate()["herbie"] 
                }, new Theme
                {
                    Name = "boldstrap",
                    Color="#27a2fc",
                    Translate =MyGlobal.GetTranslate()["boldstrap"] 
                }, new Theme
                {
                    Name = "lovey",
                    Color="#d80e70",
                    Translate =MyGlobal.GetTranslate()["lovey"] 
                }, new Theme
                {
                    Name = "bootstrap_purple",
                    Color="#563d7c",
                    Translate =MyGlobal.GetTranslate()["bootstrap_purple"] 
                }
                , new Theme
                {
                    Name = "monotony",
                    Color="#515151",
                    Translate =MyGlobal.GetTranslate()["monotony"] 
                }
                , new Theme
                {
                    Name = "poypull",
                    Color="#7f0fff",
                    Translate =MyGlobal.GetTranslate()["poypull"] 
                }
                , new Theme
                {
                    Name = "tequila",
                    Color="#2f414a",
                    Translate =MyGlobal.GetTranslate()["tequila"] 
                }
                
            };
        }
    }



    public class Theme
    {
        public string Name { get; set; }
        public string Translate { get; set; }
        public string Color { get; set; }
    }
}