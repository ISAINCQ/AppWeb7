using AppWeb7.Models;
using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace AppWeb7.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            var obj = new MedicamentoNegocio();
            var mentos = obj.getMedicamentos();
            var lstMentos = new List<MedicamentoModel>();

            foreach(var item in mentos)
            {
                var mendto = new MedicamentoModel();
                mendto.IdMedicamento = item.IdMedicamento;
                mendto.Nombre = item.Nombre;
                mendto.Stock = item.Stock;
                mendto.FechaCaducidad = item.FechaCaducidad;
                mendto.FechaIngreso = item.FechaIngreso;

                lstMentos.Add(mendto);
            }

            return View(lstMentos);
        }
        public IActionResult DeleteMedicamento(int IdMedicamento)
        {
            var obj = new MedicamentoNegocio();
            var est = obj.DeleteMedicamento(IdMedicamento);

            ViewData["estado"] = est;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateMedicamento(int IdMedicamento)
        {
            var obj = new MedicamentoNegocio();
            var est = obj.getMedicamentoById(IdMedicamento);
            var entity = new MedicamentoModel();

            entity.IdMedicamento = est.IdMedicamento;
            entity.Nombre = est.Nombre;
            entity.Stock = est.Stock;
            entity.FechaCaducidad = est.FechaCaducidad;
            entity.FechaIngreso = est.FechaIngreso;

            return View(entity);
        }
        [HttpPost]
        public IActionResult UpdateMedicamento(MedicamentoModel mendto)
        {
            var obj = new MedicamentoNegocio();
            var entity = new MedicamentoEntity();

            entity.IdMedicamento = mendto.IdMedicamento;
            entity.Nombre = mendto.Nombre;
            entity.Stock = mendto.Stock;
            entity.FechaCaducidad = mendto.FechaCaducidad;
            entity.FechaIngreso = mendto.FechaIngreso;

            var est = obj.UpdateMedicamento(entity);
            ViewData["estado"] = est;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddMedicamento()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMedicamento(MedicamentoModel newMendto)
        {
            var obj = new MedicamentoNegocio();
            var entity = new MedicamentoEntity();

            entity.IdMedicamento = newMendto.IdMedicamento;
            entity.Nombre = newMendto.Nombre;
            entity.Stock = newMendto.Stock;
            entity.FechaCaducidad = newMendto.FechaCaducidad;
            entity.FechaIngreso = newMendto.FechaIngreso;

            var est = obj.AddMedicamento(entity);
            ViewData["estado"] = est;

            return RedirectToAction("Index");
        }
    }
}
