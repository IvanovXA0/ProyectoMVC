using ProyectoMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.Controllers.Juegos
{
    public class JuegosController : Controller
    {
        // GET: Juegos
        public ActionResult Index()
        {
            //creamos una lista de juegos
            List<Models.Juegos> lista_juegos = new List<Models.Juegos>();
            //llenamos nuestra lista con elementos existentes en nuestro contexto utilizndo EF y LinQ
            using (CatalogoVideojuegosMVCEntities context = new CatalogoVideojuegosMVCEntities())
            //inicializar nuesto contexto
            {
                //LinQ
                //Recorremos cada elemnto existente en el context de la BD y llenamos la lista
                lista_juegos = (from j in context.Juegos select j).ToList();
            }

            //ViewBag
            //sirve para pasar información desde el controlador hacia la vista
            ViewBag.Titulo = "Lista de Juegos";
            ViewBag.Subtitulo = "Utilizando ASP.NET MVC";

            //ViewData["Titulo"] = "Otra cosa";

            //TempData.Add("x", "x");

            //paso el modelo a la vista
            return View(lista_juegos);
        }

        // GET: Juegos/Create
        public ActionResult Create()
        {
            ViewBag.Titulo = "Nuevo Juego";
            //cargarDDL();
            return View();
        }

        // POST: Juegos/Create
        [HttpPost]
        public ActionResult Create(JuegosDTO model, HttpPostedFileBase imagen)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TransportesEntities context = new TransportesEntities())
                    {
                        var camion = new Models.camiones(); //creamos un objeto basado en el contexto de la BD
                        //asignamos los valores de los modelos de entrada, al objeto que se insertará
                        camion.ID_Camion = model.ID_Camion;
                        camion.matricula = model.matricula;
                        camion.capacidad = model.capacidad;
                        camion.kilometraje = model.kilometraje;
                        camion.marca = model.marca;
                        camion.modelo = model.modelo;
                        camion.disponibilidad = model.disponibilidad;
                        camion.tipo_Camion = model.tipo_Camion;

                        //validamos si existe una IMG y la guardo
                        if (imagen != null && imagen.ContentLength > 0)
                        {
                            string filename = Path.GetFileName(imagen.FileName);
                            string pathdir = Server.MapPath("~/Imagenes/camiones/");
                            if (!Directory.Exists(pathdir))
                            {
                                Directory.CreateDirectory(pathdir);
                            }
                            imagen.SaveAs(pathdir + filename);
                            camion.urlFoto = "/Imagenes/camiones/" + filename;
                        }

                        context.camiones.Add(camion); //agrego mi nuevo camión al contexto
                        context.SaveChanges(); //guardo e impacto en la BD

                        //Sweet Alert
                        SweetAlert("Correcto", "Se ha creado correctamente", NotificationType.success);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    //Sweet Alert
                    SweetAlert("Ops...", "Algo no está bien, por favor revisa los datos", NotificationType.info);
                    cargarDDL();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                SweetAlert("Error", ex.Message, NotificationType.error);
                cargarDDL();
                return View(model);
            }
        }

        // GET: Juegos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Juegos/Edit/5
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

        // GET: Juegos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Juegos/Delete/5
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
