using System;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AbstractLibrary.Controller
{
    //[AbstractLibrary.Installation.AnyRequestFilter]          
                                                                     public abstract class GenericController<T,TContext> : Microsoft.AspNetCore.Mvc.Controller where T : class, IEntity, new()
    {
        protected IRepository<T,TContext> Service;

        // GET: Admin/Generic
        public virtual ActionResult Index(int? take, int? skip, int? dependId)
        {
            take = take ?? 20;
            skip = skip == 0 ? null : skip;
            MyDataTableResponse<T> response = Service.GetAsPaging(take.Value, skip);
            return View(response);
        }


        public virtual ActionResult Detail(int id)
        {
            if (id == 0)
            {
                return View(new MyEntityResponse<T>
                {
                    Single = new T()
                });
            }

            T response = Service.GetById(id);

            return View(response);
        }

 
        
        
        [HttpPost]
        public virtual ActionResult Save(T model)
        {
            try
            {
                var response = Service.Save(model);
                // ReSharper disable once Mvc.ActionNotResolved
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
            //    SignalRMVCChat.Service.LogService<>.Log(e);
                ModelState.AddModelError("", e.Message);
                return View("Detail", new MyEntityResponse<T>
                {
                    Single = model
                });
            }
        }


        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            Service.Delete(id);
            // ReSharper disable once Mvc.ActionNotResolved
            return RedirectToAction("Index");
        }
    }
}