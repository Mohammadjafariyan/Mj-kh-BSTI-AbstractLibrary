using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TelegramBotsWebApplication;

namespace DownloadManagerSite.Areas.sysadmin.Controllers
{
    public class GenericApiController<T>:Controller where T:class,IEntity,new()
    {

        protected AbstractRepository<T> CurrentService { get; set; }

        public GenericApiController(GenericService<T> service)
        {
            CurrentService = service;
        }
        
        public virtual MyDataTableResponse<T> GetAll()
        {
            var res = CurrentService.GetAll();
            return new MyDataTableResponse<T>
            {
                Status = MyResponseStatus.Success,
                EntityList = res.EntityList ,
                Total =  res.EntityList.Count,
            };
        }
        
        public virtual MyEntityResponse<T> GetById(int id)
        {
            var single = CurrentService.GetById(id);
            return new MyEntityResponse<T>
            {
                Status = MyResponseStatus.Success,
                Single = single.Single ,
            };
        }
        
        public virtual MyEntityResponse<int> Save(T entity)
        {
            var single = CurrentService.Save(entity);
            return new MyEntityResponse<int>
            {
                Status = MyResponseStatus.Success,
                Single = single.Single ,
            };
        }
        
        public virtual MyEntityResponse<int> DeleteById(int id)
        {
            var single = CurrentService.DeleteById(id);
            return new MyEntityResponse<int>
            {
                Status = MyResponseStatus.Success,
            };
        }
       
    }
    
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            /*if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }*/
            

            //Log the error!!
            // _Logger.Error(filterContext.Exception);
            string msg= MyGlobal.RecursiveExecptionMsg(context.Exception);
            // OR 
            //context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            context.Response= context.Request.CreateResponse(HttpStatusCode.OK,new MyEntityResponse<string>
            {
                Message = msg,
                Status = MyResponseStatus.Fail
            } );

        }
    }
}