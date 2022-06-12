using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.SiteCommonModel;
using BigPardakht.Data;
using Microsoft.AspNetCore.Localization;
using SignalRMVCChat.Models.HelpDesk;
using Xceed.Document.NET;

namespace AbstractLibrary.Model.MultiLanguageModel.MultiLanguageService
{
    public class LanguageHelpService
    {
        public static IEnumerable<CultureInfo> GetSupportedCulture()
        {
            //Get all culture 
            CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);

            //Find the location where application installed.
            string exeLocation =
                Path.GetDirectoryName(
                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            //Return all culture for which satellite folder found with culture code.
            return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
        }

        public static TranslateInputsSettingViewModel TranslateInputsSetting(object? val,
            List<Language> definedLangueges, IRequestCultureFeature requestCulture)
        {
            var translates = val as List<Translate>;

            if (translates == null)
            {
                translates = new List<Translate>();
            }


            foreach (var defined in definedLangueges)
            {
                if (translates.All(s => s.Code != defined.Code))
                {
                    translates.Add(new Translate
                    {
                        Code = defined.Code,
                        LanguageName = defined.nativeName
                    });
                }
            }

            for (var i = 0; i < translates.Count; i++)
            {
                var tr = translates[i];
                if (definedLangueges.All(d => d.Code != tr.Code))
                {
                    translates.Remove(tr);
                }
            }

            var defaultLanguage =
                definedLangueges.FirstOrDefault(f => f.Code == requestCulture.RequestCulture.Culture.Name);


            var def = translates.First(f => f.Code == defaultLanguage.Code);

            translates.Remove(def);


            return new TranslateInputsSettingViewModel
            {
                DefaultLanguage = def,
                Translates = translates
            };
        }

        public static string GetText(List<SiteConst> siteConsts, IRequestCultureFeature requestCulture, string label,
            string def = null)
        {
            var val = siteConsts.Where(s => s.Label == label)
                .Select(s => s.Title.FirstOrDefault(f => f.Code == requestCulture.RequestCulture.Culture.Name))
                .Where(s=>s!=null && s.Text!=null) .Select(s => s.Text).FirstOrDefault();
            if (val == null)
            {
                if (siteConsts.All(s => s.Label != label))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        db.SiteConsts.Add(new SiteConst
                        {
                            Label = label,
                            Title = new List<Translate>
                            {
                                new Translate
                                {
                                    Code = requestCulture.RequestCulture.Culture.Name,
                                    LanguageName = requestCulture.RequestCulture.Culture.DisplayName,
                                    Text = def
                                }
                            }
                        });

                        db.SaveChanges();
                    }
                }
            }


            return val ?? def;
        }
    }

    public static class TranslateExtentions
    {
        public static string GetSingleFileUrl(this int[] files,
            string def = "/_content/OneTechModule/OneTech/images/popular_1.png")
        {
            return files?.FirstOrDefault() != null ? $@"/file/byId?fileId={files?.FirstOrDefault()}" : def;
        }
    }

    public static class FileExtentions
    {
        public static string GetTranslateText(this List<Translate> translates, IRequestCultureFeature requestCulture,
            string def = null)
        {
            return translates.Where(s => s.Code == requestCulture.RequestCulture.Culture.Name)
                .Select(s => s.Text).FirstOrDefault() ?? def;
        }
    }

    public class TranslateInputsSettingViewModel
    {
        public Translate DefaultLanguage { get; set; }
        public List<Translate> Translates { get; set; }
    }
}