using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlumnosMVC.Models;
using System.Data.Entity;

namespace AlumnosMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private InsTichEntit _DBContext = new InsTichEntit();
        private List<Alumnos> _lisAlumnos;
        private Alumnos _Alumno;
        private Estados _Estado;
        private EstatusAlumnos _Estatu;

        // GET: Alumno
        public ActionResult Index()
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            //_lisAlumnos = _DBContext.Alumnos.Include(alumno => alumno.idEstadoOrigen).ToList();
            _lisAlumnos = _DBContext.Alumnos.Include(alumno => alumno.Estados).ToList();
            _DBContext.Configuration.LazyLoadingEnabled = true;
            _lisAlumnos = _DBContext.Alumnos.ToList();
            return View(_lisAlumnos);
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {

            //_DBContext.Configuration.LazyLoadingEnabled=false;
            //_Alumno = _DBContext.Alumnos.Include(x => x.idEstadoOrigen).Where(x => x.id == id).FirstOrDefault();
            //_Estado = _DBContext.Estados.Find(_Alumno.idEstadoOrigen);

            //_DBContext.Configuration.LazyLoadingEnabled = true;
            //_Alumno = _DBContext.Alumnos.Find(1);
            _Alumno = _DBContext.Alumnos.Find(id);

            return View(_Alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            ViewBag.Estados = _DBContext.Estados.ToList();
            ViewBag.Estatus = _DBContext.EstatusAlumnos.ToList();
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            ViewBag.Estados = _DBContext.Estados.ToList();
            ViewBag.Estatus = _DBContext.EstatusAlumnos.ToList();
            _Alumno = _DBContext.Alumnos.Find(id);
            return View(_Alumno);
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
