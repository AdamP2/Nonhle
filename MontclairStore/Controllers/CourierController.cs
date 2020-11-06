//using MontclairStore.Logic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace MontclairStore.Controllers
//{
//    public class CourierController : Controller
//    {
//        // GET: Courier
//        [ActionName("index")]
//        public async Task<ActionResult> IndexAsync()
//        {
//            var courier = await DocumentDBRepository<Courier>.GetCouriesAsync(d => !d.isActive);
//            return View(courier);
//        }
//        public async Task<ActionResult> SearchAsync([Bind(Include = "CourierId,CourierName,CourierEmail,Contact,isActive")]Courier courier)
//        {
//            if (ModelState.IsValid)
//            {
//                await DocumentDBRepository<Courier>.CreateCouriersAsync(courier);
//                return RedirectToAction("Index");
//            }
//            return View(courier);
//        }
//        [ActionName("Create")]
//        public async Task<ActionResult> CreateAsync()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ActionName("Create")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> CreateAsync([Bind(Include = "CourierId,CourierName,CourierEmail,Contact,isActive")]Courier courier)
//        {

//            if (ModelState.IsValid)
//            {
//                await DocumentDBRepository<Courier>.CreateCouriersAsync(courier);
//                return RedirectToAction("Index");
//            }
//            return View(courier);
//        }
//        [HttpPost]
//        [ActionName("Edit")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> EditAsync([Bind(Include = "CourierId,CourierName,CourierEmail,Contact,isActive")]Courier courier)
//        {
//            if (ModelState.IsValid)
//            {
//                await DocumentDBRepository<Courier>.UpdateCouriersAsync(courier.CourierId, courier);
//                return RedirectToAction("Index");
//            }
//            return View(courier);
//        }
//        [ActionName("Edit")]
//        public async Task<ActionResult> EditAsync(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Courier courier = await DocumentDBRepository<Courier>.GetCouriersAsync(id);
//            if (courier == null)
//            {
//                return HttpNotFound();
//            }

//            return View(courier);
//        }

//        [ActionName("Delete")]
//        public async Task<ActionResult> DeleteAsync(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            Courier courier = await DocumentDBRepository<Courier>.GetCouriersAsync(id);
//            if (courier == null)
//            {
//                return HttpNotFound();
//            }

//            return View(courier);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "CourierId")] string id)
//        {
//            await DocumentDBRepository<Courier>.DeleteCouriersAsync(id);
//            return RedirectToAction("Index");
//        }
//        [ActionName("Details")]
//        public async Task<ActionResult> DetailsAsync(string id)
//        {
//            Courier courier = await DocumentDBRepository<Courier>.GetCouriersAsync(id);

//            return View(courier);
//        }
//    }
//}