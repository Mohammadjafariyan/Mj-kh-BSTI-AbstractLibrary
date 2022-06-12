using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using AbstractLibrary.Model.File;
using AbstractLibrary.Model.MarketModel;
using BigPardakht.Resource;
using MD.PersianDateTime;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TelegramBotsWebApplication.Service;

namespace BigPardakht.Model
{
    public static class UrlExtensions
    {
        public static string SetUrlParameter(this string url, string paramName, string value)
        {
            return new Uri(url).SetParameter(paramName, value).ToString();
        }

        public static Uri SetParameter(this Uri url, string paramName, string value)
        {
            var queryParts = HttpUtility.ParseQueryString(url.Query);
            queryParts[paramName] = value;
            return new Uri(url.AbsoluteUriExcludingQuery() + '?' + queryParts.ToString());
        }

        public static string AbsoluteUriExcludingQuery(this Uri url)
        {
            return url.AbsoluteUri.Split('?').FirstOrDefault() ?? String.Empty;
        }
    }

    public class SharedResourceSingleTon
    {
        private static StringLocalizer<SharedResource> _stringLocalizer;

        public static StringLocalizer<SharedResource> StringLocalizer
        {
            get
            {
                if (_stringLocalizer == null)
                {
                    var options =
                        Options.Create(
                            new LocalizationOptions()); // you should not need any params here if using a StringLocalizer<T>
                    var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
                    var localizer = new StringLocalizer<SharedResource>(factory);

                    _stringLocalizer = localizer;
                }

                return _stringLocalizer;
            }
        }
    }

    public class MyExtra
    {
        public static string HtmlFormHelp(dynamic entity, IHtmlHelper html, bool isAdmin)

        {
            return @$"
                <div class=""buttons_{entity.Id}"">
                    <div class=""spinner-border text-primary"" role=""status"" style=""display: none"">
                        <span class=""sr-only"">Loading...</span>
                        
                        <small>در حال فراخوانی سرور</small>
                    </div>
                    <div>
<br/>
<br/>



 <div class=""card"">
   	<div class=""card-title bg-primary text-white"">
فرم تایید یا رد تراکنش
</div>
   	<div class=""card-body"">
  
   <form method=""post"" action=""/Admin/Transaction/TransactionList?handler=ChangeStatus"">
{html.AntiForgeryToken().GetHtmlToString()}
                        <input class=""AcceptList"" type=""hidden"" name=""Accept"">
                       <input class=""RejectList"" type=""hidden"" name=""Reject"">

                        <label>تایید <input class=""acceptRadio"" type=""radio"" name=""@item.Id"" value=""{entity.Id}"" onclick=""function addToAcceptList(THIS,id) {{
                                              
                                                      
                                                THIS.parentElement.parentElement.querySelector('.AcceptList').value=id;
                                                THIS.parentElement.parentElement.querySelector('.RejectList').value='';
                                                
                                            }};addToAcceptList(this,'{entity.Id}');""></label> 
                        <label>رد <input class=""rejectRadio"" type=""radio"" name=""{entity.Id}"" value=""{entity.Id}"" onclick=""function addToRejectList(THIS,id) {{
                                              
                                                THIS.parentElement.parentElement.querySelector('.AcceptList').value='';
                                                THIS.parentElement.parentElement.querySelector('.RejectList').value=id;
                
                                                
                                            }};addToRejectList(this,'{entity.Id}');""></label> 
                    <br/>
  <div class=""alert alert-warning alert-dismissible fade show"" role=""alert"">
     <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
       <span aria-hidden=""true"">&times;</span>
     </button>
       <strong>تعیین وضعیت این تراکنش :</strong>
       <p>در صورت تایید نیازی به توضیح نیست </p>
       <p>در صورت عدم تایید توضیحات برای سایت درخواست کننده تراکنش نمایش داده خواهد شد</p>
   </div>
    <label>توضیح علت رد<textarea class=""RejectDesc form-control"" name=""RejectDesc"" cols=""60""></textarea></label> 
                   
{(isAdmin ? @" <input class="" btn btn-primary"" type=""submit"" value=""ذخیره تغییرات"">" : "")}

 </div>
</form>

                </div>

 	</div>
   </div>

            ";
        }
    }

    public class MyConstants
    {
        public const string PrintInLayoutEnd = "PrintInLayoutEnd";
        public const string SystemAdmin = "SystemAdmin";
        public const string AdminAndSystemAdmin = "SystemAdmin,Admin";
        public const string EveryUserAuthenticated = "SystemAdmin,Admin,Customer";
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string SelectedTheme = "SelectedTheme";
        public const string IsGuideDisabled = "IsGuideDisabled";
    }

    public class MyGlobal
    {
        public static StringLocalizer<SharedResource> GetTranslate()
        {
            return SharedResourceSingleTon.StringLocalizer;
        }

        public static EndPoint ParseEndpoint(string hostPort, int defaultPort)
        {
            if (!TryParseEndpoint(hostPort, defaultPort, out var endpoint))
                throw new FormatException("Invalid IP or DNS endpoint");
            return endpoint;
        }

        public static bool TryParseEndpoint(string hostPort, int defaultPort, out EndPoint endpoint)
        {
            if (hostPort == null)
                throw new ArgumentNullException(nameof(hostPort));
            if (defaultPort < 0 || defaultPort > ushort.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(defaultPort));
            hostPort = hostPort.Trim();
            endpoint = null;
            ushort port = (ushort) defaultPort;
            string host = hostPort;
            var index = hostPort.LastIndexOf(':');
            if (index != -1)
            {
                var index2 = hostPort.IndexOf(':');
                if (index2 == index || hostPort.IndexOf(']') != -1)
                {
                    var portStr = hostPort.Substring(index + 1);
                    if (ushort.TryParse(portStr, out port))
                    {
                        host = hostPort.Substring(0, index);
                    }
                    else
                    {
                        port = (ushort) defaultPort;
                    }
                }
                else // At least two ':', this should be considered IPv6 without port
                {
                    port = (ushort) defaultPort;
                }
            }

            if (IPAddress.TryParse(host, out var address))
            {
                endpoint = new IPEndPoint(address, port);
            }
            else
            {
                if (Uri.CheckHostName(host) != UriHostNameType.Dns ||
                    // An host name with a length higher than 255 can't be resolved by DNS
                    host.Length > 255)
                    return false;
                endpoint = new DnsEndPoint(host, port);
            }

            return true;
        }

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        public static bool IsAttached
        {
            get
            {
                return true;
                // return Debugger.IsAttached;
            }
        }

        public static bool FakeData = true;

        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";

        public static int TakeConst = 20;

        public static Color ContrastColor(string color)
        {
            Color iColor = Color.FromName(color);
            ;
            // Calculate the perceptive luminance (aka luma) - human eye favors green color... 
            double luma = ((0.299 * iColor.R) + (0.587 * iColor.G) + (0.114 * iColor.B)) / 255;

            // Return black for bright colors, white for dark colors
            return luma > 0.5 ? Color.Black : Color.White;
        }

        public static object GetPropValue(object src, string propName)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(src);
            if (JObject.Parse(json)?[propName] == null)
            {
                throw new NotBreakException("src.GetType().GetProperty(propName) is null");
            }

            return JObject.Parse(json)[propName];
        }

        public static DateFromToDateViewModel ParseDates(string dateFrom,
            string dateTo)
        {
            DateTime? DateFrom = null;
            DateTime? DateTo = null;
            if (string.IsNullOrEmpty(dateFrom) == false)
            {
                DateFrom = MyGlobal.ParseIranianDate(dateFrom);
            }

            if (string.IsNullOrEmpty(dateTo) == false)
            {
                DateTo = MyGlobal.ParseIranianDate(dateTo).AddDays(1);
            }

            return new DateFromToDateViewModel
            {
                DateFrom = DateFrom,
                DateTo = DateTo,
            };
        }

        public static async Task<MyDataTableResponse<T>> Paging<T>(IQueryable<T> queryable, int? take, int? page)
            where T : IEntity
        {
            int total = queryable.Count();

            page = page ?? 1;

            if (page > 1)
            {
                var _page = page - 1;
                queryable = queryable.OrderByDescending(e => e.Id).Skip(_page.Value * take.Value).Take(take.Value);
            }
            else
            {
                queryable = queryable.OrderByDescending(e => e.Id).Take(take.Value);
            }

            page = page == 0 ? 1 : page;

            return new MyDataTableResponse<T>
            {
                Total = total,
                EntityList = (queryable is IAsyncEnumerable<T>) ? await queryable.ToListAsync() : queryable.ToList(),
                TotalPages = total > 0 ? total / take.Value + (total % page > 0 ? 1 : 0) : 0,
                Page = page.Value
            };
        }

        public static readonly Dictionary<DayOfWeek, string> WeekNames = new Dictionary<DayOfWeek, string>
        {
            {DayOfWeek.Saturday, "شنبه"},
            {DayOfWeek.Sunday, "یکشنبه"},
            {DayOfWeek.Monday, "دوشنبه"},
            {DayOfWeek.Tuesday, "سه شنبه"},
            {DayOfWeek.Wednesday, "چهار شنبه"},
            {DayOfWeek.Thursday, "پنج شنبه"},
            {DayOfWeek.Friday, "جمعه"},
        };

        public static readonly Dictionary<DayOfWeek, int> WeekNums
            = new Dictionary<DayOfWeek, int>
            {
                {DayOfWeek.Saturday, 6},
                {DayOfWeek.Sunday, 0},
                {DayOfWeek.Monday, 1},
                {DayOfWeek.Tuesday, 2},
                {DayOfWeek.Wednesday, 3},
                {DayOfWeek.Thursday, 4},
                {DayOfWeek.Friday, 5},
            };

        public static readonly Dictionary<int, string> MonthNames = new Dictionary<int, string>
        {
            {1, "فروردین"},
            {2, "اردیبهشت"},
            {3, "خرداد"},
            {4, "تیر"},
            {5, "مرداد"},
            {6, "شهریور"},
            {7, "مهر"},
            {8, "آبان"},
            {9, "آذر"},
            {10, "دی"},
            {11, "بهمن"},
            {12, "اسفند"},
        };

        public static string ToIranianDate(DateTime mCdate, bool withDayName = false, bool noYear = false)
        {
            var pc = new PersianCalendar();
            string dayName = "";
            if (withDayName)
            {
                dayName = "  " + WeekNames[pc.GetDayOfWeek(mCdate)];
            }

            if (noYear)
            {
                return $@"{pc.GetMonth(mCdate)}-{pc.GetDayOfMonth(mCdate)}" + dayName;
            }

            var month = pc.GetMonth(mCdate);
            string showMonth = "";
            if (month < 10)
            {
                showMonth += "0" + month;
            }
            else
            {
                showMonth = month + "";
            }

            var day = pc.GetDayOfMonth(mCdate);
            string showDate = "";
            if (day < 10)
            {
                showDate += "0" + day;
            }
            else
            {
                showDate = day + "";
            }

            return $@"{pc.GetYear(mCdate)}-{showMonth}-{showDate}" + dayName;
        }

        public static string ToIranianDateWidthTime(DateTime? _date)
        {
            if (_date == null)
            {
                return "";
            }

            var mCdate = _date.Value;
            var pc = new PersianCalendar();
            var month = pc.GetMonth(mCdate);
            string showMonth = "";
            if (month < 10)
            {
                showMonth += "0" + month;
            }
            else
            {
                showMonth = month + "";
            }

            return
                $@"{mCdate.TimeOfDay.Hours}:{mCdate.TimeOfDay.Minutes}:{mCdate.TimeOfDay.Seconds} {pc.GetYear(mCdate)}-{showMonth}-{pc.GetDayOfMonth(mCdate)}";
        }

        public static DateTime ParseIranianDate(string modelFromDate)
        {
            try
            {
                return PersianDateTime.Parse(modelFromDate).ToDateTime();
            }
            catch (Exception e)
            {
                throw new Exception("فرمت تاریخ اشتباه است و قاoldListل نیست");
            }
        }

        public const string SecurityContextName = "security";

        public static string GetBaseUrl(string Url)
        {
            var uri = new Uri(Url);
            return uri.Scheme + "://" + uri.Host + ":" + uri.Port;
        }

        /*public static string ExtractChannelIds(IQueryable<SocialChannel> socialChannels)
        {
            string channelIds = string.Join(",", socialChannels
                .Select(s => s.ChatTitle + "_" + s.ChatId + "_" + s.ChannelType + "_" + s.Id).ToList());

            return channelIds;
        }*/
        public static string RecursiveExecptionMsg(Exception e)
        {
            string msg = null;
            Exception e2 = e;
            while (e2 != null)
            {
                msg += e2.Message;
                e2 = e2.InnerException;
            }

            return msg;
        }

        public static string ExtractUniqueNameForHandler(string callbackQueryData)
        {
            return callbackQueryData.Split('_')[0];
        }

        public static string ExtractValueInlineQuery(string idstr)
        {
            return idstr.Split('_')[1];
        }

        public static DateTime CreateDateFromTime(int year, int month, int day, DateTime time)
        {
            return new DateTime(year, month, day, time.Hour, time.Minute, 0);
        }

        public static int ValidateHash(string hash)
        {
            string userIdstr = EncryptionHelper.Decrypt(hash);

            userIdstr = userIdstr.Split('_')[0];

            int userId = int.Parse(userIdstr);
            return userId;
        }

        public static string Encrypt(string txt)
        {
            var now = txt + "_" + DateTime.Now;
            return EncryptionHelper.Encrypt(now);
        }


        public static string SplitAndGetRest(string str, string tosub)
        {
            var i = str.IndexOf(tosub, StringComparison.CurrentCulture);

            var start = i + tosub.Length;
            var length = str.Length - start;
            return str.Substring(start, length);
        }

        public static string GetTelegramChatId(string address)
        {
            return MyGlobal.SplitAndGetRest(address, "t.me/");
        }

        public static void Log(Exception exception)
        {
            try
            {
                /*using (var db=ContextFactory.GetContext(null))
                {
                     db.Logs.Add(new Log
                    {
                        Exception = MyGlobal.RecursiveExecptionMsg(exception)
                    });
                    db.SaveChanges();
                }*/
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public static bool IsUnitTestEnvirement = false;
        public static bool IsReactWebTesting = true;

        public static T Clone<T>(T feed)
        {
            var json = JsonConvert.SerializeObject(feed,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T2 CloneTo<T, T2>(T feed)
        {
            var json = JsonConvert.SerializeObject(feed,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return JsonConvert.DeserializeObject<T2>(json);
        }

        public static string ShowThreeDotMoney(string price)
        {
            var str = price;

            List<string> splited = new List<string>();
            var c = 0;
            string threeNum = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (c == 3)
                {
                    splited.Add(string.Join("", threeNum.Reverse().ToArray()));
                    c = 0;
                    threeNum = "";
                }

                c++;
                threeNum += str[i];
            }

            if (c > 0)
            {
                splited.Add(string.Join("", threeNum.Reverse().ToArray()));
            }

            splited.Reverse();


            var answer = string.Join(",", splited.ToArray());

            return answer;
        }

        public static List<long> GetChannelIds(string DeliveredChannelIds)
        {
            if (string.IsNullOrEmpty(DeliveredChannelIds))
            {
                throw new Exception("این پست به هیچ کانال ارسال نشده است");
            }

            var strings = DeliveredChannelIds.Split(',');

            var list = strings.Select(s =>
            {
                if (s.Contains("_"))
                {
                    var tmp = s.Split('_')[1];
                    return long.Parse(tmp);
                }
                else
                {
                    return long.Parse(s);
                }
            }).ToList();
            return list;
        }


        /*public static RegisterViewModel MakeFakeUser()
        {
            List<string> names = new List<string>
            {
                "بهادر", "علی", "اصغر", "سجاد", "محمد", "میلاد", "مسعود", "نرگس", "نفیسه", "مراد", "علی", "عباس"
            };
            List<string> emailNames = new List<string>
            {
                "bahador", "ali", "asgar", "sajad", "mohammad", "milad", "masud", "narges", "nafise", "morad", "aliaba",
                "abbas"
            };

            string password = GetRandom(emailNames) + "@sdfsf";
            return new RegisterViewModel
            {
                Email = GetRandom(emailNames) + "@admin.com",
                Password = password,
                Name = GetRandom(emailNames),
                LastName = GetRandom(emailNames) + "زاده",
                ConfirmPassword = password
            };
        }*/

        public static T GetRandom<T>(List<T> arr)
        {
            Random random = new Random();
            int start2 = random.Next(0, arr.Count);

            return arr[start2];
        }

        public static string GenerateRandomString()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            return guidString;
        }

        public static string GetSummary(string body)
        {
            string res = "";
            if (string.IsNullOrEmpty(body))
                return "";
            if (body.Length > 50)
            {
                res = body.Substring(0, 50);

                return res + "...";
            }

            return body;
        }


        public static async Task<MyDataTableResponse<T>> Paging<T>(IQueryable<T> queryable,
            IQueryCollection requestParams)
            where T : Entity
        {
            int page = 0;
            if (int.TryParse(requestParams["page"].ToString() ?? "", out page))
            {
            }
            else
            {
                page = 0;
            }


            return await Paging<T>(queryable, MyGlobal.TakeConst, page);
        }

        public static ThisWeekRangeViewModel GetThisWeekRange()
        {
            var traverseDate = DateTime.Now;
            while (traverseDate.DayOfWeek != DayOfWeek.Saturday)
            {
                traverseDate = traverseDate.AddDays(-1);
            }

            return new ThisWeekRangeViewModel
            {
                StartOfWeek = traverseDate,
                EndOfWeek = traverseDate.AddDays(6)
            };
        }

        public static string SplitArr(string data)
        {
            var arr = Enumerable.Range(0, data.Length / 30 + (data.Length % 30 > 0 ? 1 : 0))
                .Select(i => data.Substring(i * 30, data.Length > i * 30 + 30 ? 30 : data.Length - i * 30)).ToList();
            return string.Join("<br/>", arr);
        }

        public static bool IsUnitTestEnvirementNoSeed = false;

        public static string Version = "0.0.1." + (VersionPublishDateTime.HasValue
            ? MyGlobal.ToIranianDateWidthTime(VersionPublishDateTime.Value)
            : "");

        public static DateTime? VersionPublishDateTime = null;
        public static string B_IS_TEST = "B_IS_TEST";
        public static string B_API_KEY = "B_API_KEY";
        public static string TestWIF = "cUrKwMQVB2pwXxUeVztHgpygpMXDHY4YvxtRKhf1nFpknWMwnLbT";

        public static List<DateTime> GetThisYearMonthsArrayInGaregorian()
        {
            PersianCalendar pc = new PersianCalendar();

            var today = DateTime.Now;

            List<DateTime> monthOfYear = new List<DateTime>();

            for (int i = 1; i <= 12; i++)
            {
                var monthFirstDay = new PersianDateTime(pc.GetYear(today), i, 1).ToDateTime();

                monthOfYear.Add(monthFirstDay);
            }


            return monthOfYear;
        }

        public static List<DateTime> GetLast5YearInJalaliToGeorgian()
        {
            PersianCalendar pc = new PersianCalendar();

            var today = DateTime.Now.AddYears(1);

            List<DateTime> years = new List<DateTime>();

            for (int i = 0; i < 5; i++)
            {
                var monthFirstDay = new PersianDateTime(pc.GetYear(today), 1, 1);

                var iYear = monthFirstDay.AddYears(-i).ToDateTime();

                years.Add(iYear);
            }


            return years.OrderByDescending(o => o.Year).ToList();
        }

        /*hh:mm*/
        public static DateTime? TryParseTime(string @from)
        {
            if (string.IsNullOrEmpty(@from))
            {
                return null;
            }

            try
            {
                var hour = int.Parse(@from.Split(':')[0]);
                var minute = int.Parse(@from.Split(':')[1]);

                return new DateTime(2000, 1, 1, hour, minute, 0);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 11/21/2020 - 11/28/2020
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static ParsedRangeDateTime TryParseRangeOrOneDate(string range)
        {
            if (string.IsNullOrEmpty(range))
            {
                return null;
            }

            ParsedRangeDateTime model = new ParsedRangeDateTime();

            try
            {
                range = range.Trim();
                if (range.Contains("-"))
                {
                    model.From = TryParseSingleDate(range.Split('-')[0]);
                    model.To = TryParseSingleDate(range.Split('-')[1]);
                }
                else
                {
                    model.From = TryParseSingleDate(range);
                }


                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 2020/11/21
        /// yy/mm/dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static DateTime? TryParseSingleDate(string datePart)
        {
            try
            {
                var year = datePart.Split('/')[0];
                var mon = datePart.Split('/')[1];
                var day = datePart.Split('/')[2];

                return new DateTime(int.Parse(year), int.Parse(mon), int.Parse(day));
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static T FromJson<T>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }

        public static string ToJson<T>(T obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }

        public static (List<T> removed, List<T> shared, List<T> added) ListUpdate<T>(List<T> before, List<T> add,
            Func<T, T, bool> compare)
        {
            var removed = before.Where(b => !add.Any(a => compare(b, a))).ToList();

            var shared = add.Where(b => before.Any(a => compare(b, a))).ToList();

            add = add.Where(a => !shared.Any(s => compare(a, s))).ToList();


            return (removed.ToList(), shared, add.ToList());
        }

        public static IFileSupport SetFiles(IFileSupport model)
        {
            if (!string.IsNullOrEmpty(model.FilesBind))
            {
                model.Files = model.FilesBind.Split(',')
                    .Select(s => int.Parse(s)).ToArray();
            }

            return model;
        }

        public static string ReplaceMultipleSpacesWithSingleSpace(string packed)
        {
            packed = Regex.Replace(packed, @"\s+", " ");
            return packed;
        }

        public static List<DoubleItem<T>> ListToDoubleList<T>(List<T> itemProductList)
        {
            if (itemProductList == null)
                return new List<DoubleItem<T>>();
            var templist = itemProductList.ToList();

            if (templist.Count % 2 > 0)
            {
                templist.Add(default(T));
            }

            var half = templist.Take(templist.Count / 2).ToList();
            var half2 = templist.Skip(templist.Count / 2).Take(templist.Count - templist.Count / 2)
                .ToList();


            List<DoubleItem<T>> res = new List<DoubleItem<T>>();
            for (int i = 0; i < half.Count(); i++)
            {
                res.Add(new DoubleItem<T>
                {
                    First = half[i],
                    Second = half2.ElementAtOrDefault(i)
                });
            }

            return res;
        }
    }


    public class DoubleItem<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
    }

    [Serializable]
    internal class NotBreakException : Exception
    {
        public NotBreakException()
        {
        }

        public NotBreakException(string message) : base(message)
        {
        }

        public NotBreakException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotBreakException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class DateFromToDateViewModel
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }


    public static class MyExtentions
    {
        public static bool Implements<I>(this Type type, I @interface) where I : class
        {
            if (((@interface as Type) == null) || !(@interface as Type).IsInterface)
                throw new ArgumentException("Only interfaces can be 'implemented'.");

            return (@interface as Type).IsAssignableFrom(type);
        }

        public static string ToTrimmedString(this decimal target)
        {
            string strValue = target.ToString(CultureInfo.InvariantCulture); //Get the stock string

            //If there is a decimal point present
            if (strValue.Contains("."))
            {
                //Remove all trailing zeros
                strValue = strValue.TrimEnd('0');

                //If all we are left with is a decimal point
                if (strValue.EndsWith(".")) //then remove it
                    strValue = strValue.TrimEnd('.');
            }

            return strValue;
        }

        public static string GetBaseUrl(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.Request.Host + accessor.HttpContext.Request.Path +
                   accessor.HttpContext.Request.QueryString;
        }

        public static bool IsHasAttribute<T>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.CustomAttributes.Any(s => s.AttributeType == typeof(T));
        }

        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T) converter.ConvertFromString(input);
                }

                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
    }


    public class ThisWeekRangeViewModel
    {
        public DateTime StartOfWeek { get; set; }
        public DateTime EndOfWeek { get; set; }
    }

    public class ParsedRangeDateTime
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}