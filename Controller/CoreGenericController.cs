using System;
using System.Linq;
using System.Threading.Tasks;
using AbstractLibrary.Model.File;
using BigPardakht.Model;
using BigPardakht.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbstractLibrary.Controller
{
    ////[AbstractLibrary.Installation.AnyRequestFilter]          
    public abstract class CoreGenericController<T, TContext> : Microsoft.AspNetCore.Mvc.Controller
        where T : class, IEntity, new()
        where TContext : DbContext
    {
        protected readonly TContext _db;
        protected DbSet<T> _entities;

        protected CoreGenericController(TContext context)
        {
            _db = context;
            this._entities = _db.Set<T>();
        }

        public virtual async Task<IQueryable<T>> Query(IQueryable<T> query)
        {
            return query;
        }

        // GET: Admin/Generic
        public virtual async Task<ActionResult> Index(int? page = null)
        {
            page = page <= 0 ? 1 : page;


            var query = await Query(_entities.AsQueryable());
            MyDataTableResponse<T> response =
                await MyGlobal.Paging(query, MyGlobal.TakeConst, page);
            return View(response);
        }


        public virtual ActionResult Detail(long id)
        {
            T response = _entities.Find(id);

            if (response == null)
            {
                throw new NotFindException();
            }

            return View(response);
        }


        public virtual ActionResult Save(long? id = null)
        {
            if (id.HasValue == false || id == 0)
            {
                return View(new T());
            }

            T response = _entities.Find(id);

            if (response == null)
            {
                throw new NotFindException();
            }

            return View(response);
        }


        [HttpPost]
        public virtual ActionResult Save(T model)
        {
            try
            {
                if (model is IFileSupport)
                {
                    MyGlobal.SetFiles(model as IFileSupport);
                }

                if (model.Id == 0)
                {
                    _entities.Add(model);
                }
                else
                {
                    var inDb = _entities.Find(model.Id);
                    _db.Entry(inDb).CurrentValues.SetValues(model);
                    _db.Entry(inDb).State = EntityState.Modified;
                }


                _db.SaveChanges();
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
        public virtual ActionResult Delete(long id)
        {
            try
            {
                var record = _entities.Find(id);

                if (record == null)
                {
                    throw new NotFindException();
                }

                _db.Entry(record).State = EntityState.Deleted;
                _db.SaveChanges();

                // ReSharper disable once Mvc.ActionNotResolved
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //    SignalRMVCChat.Service.LogService<>.Log(e);
                ModelState.AddModelError("", e.Message);
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
    }
}