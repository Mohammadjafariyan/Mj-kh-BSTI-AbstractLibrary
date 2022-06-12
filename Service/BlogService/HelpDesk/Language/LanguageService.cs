using System.Linq;
using AbstractLibrary.Repository;
using BigPardakht.Data;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Http;


namespace SignalRMVCChat.Service.HelpDesk.Language
{
    public class LanguageService: SafeDeleteRepository<Models.HelpDesk.Language,BigPardakht.Data.ApplicationDbContext>
    {
     
     

        /*
        public Models.HelpDesk.Language GetByCountryCode(string countryCode, string nativeName, string alpha2Code,
            bool createIfNotExist, string flag)
        {
          
            var langue= Get().FirstOrDefault(c => c.Name == countryCode &&
                c.nativeName==nativeName &&
                c.alpha2Code==alpha2Code
            );
            if (createIfNotExist && langue==null)
            {
                langue=new Models.HelpDesk.Language
                {
                    Name = countryCode,
                    nativeName=nativeName,
                    alpha2Code=alpha2Code,
                    flag=flag
                    
                };

                Save(langue);
            }

            return langue;
        }
        */

        public LanguageService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }
    }
    
    
}