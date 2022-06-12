using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BigPardakht.Repository;
using SignalRMVCChat.Models;

namespace SignalRMVCChat.Service
{
    public class LogService<TContext>:AbstractRepository<Log,TContext>
    {

        private List<Log> CurrentSessionLogs = new List<Log>();
        
       
        public  void Save( )
        {
            this.SaveAsync(CurrentSessionLogs).GetAwaiter().GetResult();
            
        }

       
        public  void LogFunc( string msg,  [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,[CallerFilePath] string file=null)
        {
            var log = new Log(CurrentSessionLogs.Count+1, msg,lineNumber,file+"->"+caller);

            if (CurrentSessionLogs.Count==0)
            {
                SessionDateTime = DateTime.Now;
                log.SessionDateTime = DateTime.Now;
            }
            else
            {
                log.SessionDateTime = SessionDateTime;


            }
            
            
            CurrentSessionLogs.Add(log);
        }

        public DateTime SessionDateTime { get; set; } = DateTime.Now;

        public static void Log(Exception e, string data=null)
        {
            var log = new Log(e,data);
            /*using (var db = ContextFactory.GetContext(null) as GapChatContext)
            {
                if (db == null)
                {
                    throw new Exception("db is null ::::::");
                }

                db.Logs.Add(log);


                var queryForDelete = db.Logs
                    .Where(c => EntityFunctions.DiffDays(c.CreationDateTime, DateTime.Today) > 0);

                db.Logs.RemoveRange(queryForDelete);
                db.SaveChanges();
            }*/
        }

        public LogService(TContext dbContext) : base(dbContext)
        {
        }
    }
}