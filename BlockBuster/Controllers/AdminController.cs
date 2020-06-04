using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace BlockBuster.Controllers
{
    public class AdminController : Controller
    {
        dbBBusterDataContext data = new dbBBusterDataContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var pass = collection["pass"];
            admin adm = data.admins.SingleOrDefault(n => n.username == username && n.password == pass);
            if (adm != null)
            {
                Session["AdminAccount"] = adm;
                return RedirectToAction("Home", "Admin");
            }
            else
                ViewBag.Notification = "error";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("AdminAccount");
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult Home()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return PartialView();
            }
        }
        public PartialViewResult Account()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] != null)
            {
                ViewBag.User_name = adm.name;
                ViewBag.User_position = adm.position.name;
            }
            else
            {
                ViewBag.User_name = null;
            }
            return PartialView();
        }
        public PartialViewResult Function()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] != null)
            {
                ViewBag.position = adm.position.name;
            }
            return PartialView();
        }
        public ActionResult List_movies(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                // phan trang
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                // seach
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.films.ToList().OrderBy(n => n.created).Where(or => or.form_id == 1).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var film = from fil in data.films where fil.form_id == 1 && fil.name.ToUpper().Contains(key.ToUpper()) select fil;
                    if (film.Count() == 0)
                    {
                        ViewBag.Notification = "empty";
                        return View(data.films.ToList().Where(or => or.form_id == 1).OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View(film.Where(or => or.form_id == 1).OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                    }
                }
            }
        }
        public ActionResult List_dramas(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                // phan trang
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                // seach
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.films.ToList().OrderBy(n => n.created).Where(or => or.form_id == 2).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var film = from fil in data.films where fil.form_id == 2 && fil.name.ToUpper().Contains(key.ToUpper()) select fil;
                    if (film.Count() == 0)
                    {
                        ViewBag.Notification = "empty";
                        return View(data.films.ToList().Where(or => or.form_id == 2).OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View(film.Where(or => or.form_id == 1).OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                    }
                }
            }
        }
        public ActionResult List_admins(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.admins.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var admins = from admin in data.admins where admin.name.ToUpper().Contains(key.ToUpper()) || admin.username.ToUpper().Contains(key.ToUpper()) select admin;

                if (admins.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.admins.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                return View(admins.OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult List_celebrities(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                // phan trang
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                // seach
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.celebrities.ToList().OrderBy(n => n.name).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var cele = from cel in data.celebrities where cel.name.ToUpper().Contains(key.ToUpper()) select cel;
                    if (cele.Count() == 0)
                    {
                        ViewBag.Notification = "empty";
                        return View(data.films.ToList().OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View(cele.OrderByDescending(n => n.name).ToPagedList(pageNumber, pageSize));
                    }
                }
            }
        }
        public ActionResult List_trailers(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                // phan trang
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                // seach
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.trailers.ToList().OrderBy(n => n.name).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var trai = from tra in data.trailers where tra.name.ToUpper().Contains(key.ToUpper()) select tra;
                    if (trai.Count() == 0)
                    {
                        ViewBag.Notification = "empty";
                        return View(data.trailers.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        return View(trai.OrderByDescending(n => n.name).ToPagedList(pageNumber, pageSize));
                    }
                }
            }
        }
        public ActionResult List_users(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.users.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var user = from use in data.users where use.first_name.ToUpper().Contains(key.ToUpper()) || use.last_name.ToUpper().Contains(key.ToUpper()) || use.email.ToUpper().Contains(key.ToUpper()) select use;

                if (user.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.users.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                return View(user.OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult List_categories()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.categories.ToList().OrderBy(n => n.id));
            }
        }
        public ActionResult List_countries()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.countries.ToList().OrderBy(n => n.id));
            }
        }
        public ActionResult Get_film_celebrity(int id)
        {
            return PartialView(data.film_celebrities.ToList().Where(or => or.film_id == id).OrderByDescending(n => n.id));
        }
        public ActionResult Banner()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.categories.ToList().OrderByDescending(n => n.id));
            }
        }
        public ActionResult Catalog()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.countries.ToList().OrderBy(n => n.id));
            }
        }
        [HttpGet]
        public ActionResult Created_admin()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
                return View();
            }
        }
        [HttpPost]
        public ActionResult Created_admin(admin adm)
        {
            if (ModelState.IsValid)
            {
                data.admins.InsertOnSubmit(adm);
                data.SubmitChanges();
            }
            return RedirectToAction("Admins");
        }
        [HttpGet]
        public ActionResult Create_Items()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.Brand_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.Catalog_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.Ranked_id = new SelectList(data.celebrities.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.TimeNow = DateTime.Now;
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Items(film item, FormCollection collection, HttpPostedFileBase fileUpload)
        {
            ViewBag.Brand_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.celebrities.ToList().OrderBy(n => n.name), "id", "name");

            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var dedescription = collection["description"];
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images_product"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    item.image_link = fileName;
                    item.description = dedescription;
                    item.created = DateTime.Today;
                    data.films.InsertOnSubmit(item);
                    data.SubmitChanges();
                }
                return RedirectToAction("Items");
            }
        }
        public ActionResult Details_product(int id)
        {
            film ite = data.films.SingleOrDefault(n => n.id == id);
            ViewBag.id_items = ite.id;
            if (ite == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ite);
        }
        [HttpGet]
        public ActionResult Delete_product(int id)
        {
            film item = data.films.SingleOrDefault(n => n.id == id);
            ViewBag.Items_id = item.id;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete_product")]
        public ActionResult Confirm_deletion(int id)
        {
            film item = data.films.SingleOrDefault(n => n.id == id);
            ViewBag.Items_id = item.id;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.films.DeleteOnSubmit(item);
            data.SubmitChanges();
            return RedirectToAction("Items");
        }
        [HttpGet]
        public ActionResult Edit_product(int id)
        {
            film ite = data.films.SingleOrDefault(n => n.id == id);
            if (ite == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Brand_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.celebrities.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Created = ite.created;
            ViewBag.Items_id = ite.id;
            return View(ite);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_product(film items, FormCollection collection)
        {
            ViewBag.Brand_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.celebrities.ToList().OrderBy(n => n.name), "id", "name");
            film ite = data.films.First(n => n.id == items.id);
            if (ModelState.IsValid)
            {
                var dedescription = collection["description"];
                ite.created = DateTime.Now;
                ite.description = dedescription;
                UpdateModel(ite);
                data.SubmitChanges();
                return RedirectToAction("Items");
            }
            return this.Edit_product(ite.id);
        }
        [HttpGet]
        public ActionResult Edit_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.User_id = use.id;
            return View(use);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_user(user users)
        {
            user use = data.users.First(n => n.id == users.id);
            if (ModelState.IsValid)
            {
                UpdateModel(use);
                data.SubmitChanges();
                return RedirectToAction("Users");
            }
            return this.Edit_user(use.id);
        }
        [HttpGet]
        public ActionResult Edit_admin(int id)
        {
            ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Admin_id = adm.id;
            return View(adm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_admin(admin admins)
        {
            ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
            admin adm = data.admins.First(n => n.id == admins.id);
            if (ModelState.IsValid)
            {
                UpdateModel(adm);
                data.SubmitChanges();
                return RedirectToAction("Admins");
            }
            return this.Edit_admin(adm.id);
        }
        //[HttpGet]
        //public ActionResult Inset_banner()
        //{
        //    admin adm = (admin)Session["AdminAccount"];
        //    if (Session["AdminAccount"] == null)
        //    {
        //        return RedirectToAction("Login", "Admin");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult Inset_banner( bann, HttpPostedFileBase bannerUpload)
        //{
        //    if (bannerUpload == null)
        //    {
        //        ViewBag.Notification = "Please select the banner";
        //        return View();
        //    }
        //    else
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var fileName = Path.GetFileName(bannerUpload.FileName);
        //            var path = Path.Combine(Server.MapPath("~/images_banner"), fileName);
        //            if (System.IO.File.Exists(path))
        //                ViewBag.Notification = "banner already exists";
        //            else
        //            {
        //                bannerUpload.SaveAs(path);
        //            }
        //            bann.banner_link = fileName;
        //            data.banners.InsertOnSubmit(bann);
        //            data.SubmitChanges();
        //        }
        //        return RedirectToAction("Banner");
        //    }
        //}
        //public ActionResult Delete_banner(int id)
        //{
        //    banner bann = data.banners.SingleOrDefault(n => n.id == id);
        //    if (bann == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    data.banners.DeleteOnSubmit(bann);
        //    data.SubmitChanges();
        //    return RedirectToAction("Banner");
        //}
        public ActionResult Delete_brand(int id)
        {
            category bra = data.categories.SingleOrDefault(n => n.id == id);
            if (bra == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.categories.DeleteOnSubmit(bra);
            data.SubmitChanges();
            return RedirectToAction("Brand");
        }
        public ActionResult Delete_catalog(int id)
        {
            country cata = data.countries.SingleOrDefault(n => n.id == id);
            if (cata == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.countries.DeleteOnSubmit(cata);
            data.SubmitChanges();
            return RedirectToAction("Catalog");
        }
        [HttpGet]
        public ActionResult Inset_brand()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Inset_brand(category bra)
        {
            if (ModelState.IsValid)
            {
                data.categories.InsertOnSubmit(bra);
                data.SubmitChanges();
            }
            return RedirectToAction("Brand");
        }
        [HttpGet]
        public ActionResult Inset_catalog()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Inset_catalog(country cata)
        {
            if (ModelState.IsValid)
            {
                data.countries.InsertOnSubmit(cata);
                data.SubmitChanges();
            }
            return RedirectToAction("Catalog");
        }
        [HttpGet]
        public ActionResult Delete_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            ViewBag.Users_id = use.id;
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(use);
        }

        [HttpPost, ActionName("Delete_user")]
        public ActionResult Confirm_deletion_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            ViewBag.Users_id = use.id;
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.users.DeleteOnSubmit(use);
            data.SubmitChanges();
            return RedirectToAction("Users");
        }
        [HttpGet]
        public ActionResult Delete_admin(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            ViewBag.Admins_id = adm.id;
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(adm);
        }

        [HttpPost, ActionName("Delete_admin")]
        public ActionResult Confirm_deletion_admin(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            ViewBag.Admins_id = adm.id;
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.admins.DeleteOnSubmit(adm);
            data.SubmitChanges();
            return RedirectToAction("Admins");
        }
        //public ActionResult Messenger()
        //{
        //    var mess = from messe in data.messeages select messe;
        //    return PartialView(mess);
        //}
        //public ActionResult Total_price(int id)
        //{
        //    int? TotalPrice = data.det_orders.Where(or => or.order_id == id).Sum(od => (od.quantity * od.amount));
        //    ViewBag.TotalPrice = TotalPrice;
        //    return PartialView();
        //}
        //public ActionResult Orders(FormCollection collection, int? page)
        //{
        //    admin adm = (admin)Session["AdminAccount"];
        //    if (Session["AdminAccount"] == null)
        //    {
        //        return RedirectToAction("Login", "Admin");
        //    }
        //    else
        //    {
        //        int pageNumber = (page ?? 1);
        //        int pageSize = 8;
        //        string key = collection["txtKey"];
        //        ViewBag.key = key;
        //        if (key == null || key == "")
        //        {
        //            return View(data.orders.OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
        //        }
        //        var order = from ord in data.orders where ord.user.name.ToUpper().Contains(key.ToUpper()) select ord;
        //        if (order.Count() == 0)
        //        {
        //            ViewBag.Notification = "empty";
        //            return View(data.orders.ToList().OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
        //        }
        //        return View(order.OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
        //    }
        //}
        //[HttpGet]
        //public ActionResult Change_processed(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ord);
        //}
        //[HttpPost, ActionName("Change_processed")]
        //public ActionResult Confirm_change_processed(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    ord.status_id = 1;
        //    ord.delivery_date = null;
        //    UpdateModel(ord);
        //    data.SubmitChanges();
        //    return RedirectToAction("Orders");
        //}
        //[HttpGet]
        //public ActionResult Change_shipped(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ord);
        //}
        //[HttpPost, ActionName("Change_shipped")]
        //public ActionResult Confirm_change_shipped(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    ord.status_id = 2;
        //    ord.delivery_date = null;
        //    UpdateModel(ord);
        //    data.SubmitChanges();
        //    return RedirectToAction("Orders");
        //}
        //[HttpGet]
        //public ActionResult Change_delivered(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ord);
        //}
        //[HttpPost, ActionName("Change_delivered")]
        //public ActionResult Confirm_change_delivered(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    ord.status_id = 3;
        //    ord.delivery_date = DateTime.Today;
        //    UpdateModel(ord);
        //    data.SubmitChanges();
        //    return RedirectToAction("Orders");
        //}
        //[HttpGet]
        //public ActionResult Delete_order(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    ViewBag.order_id = ord.id;
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(ord);
        //}
        //[HttpPost, ActionName("Delete_order")]
        //public ActionResult Confirm_deletion_order(int id)
        //{
        //    order ord = data.orders.SingleOrDefault(n => n.id == id);
        //    if (ord == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    det_order detor = data.det_orders.FirstOrDefault(n => n.order_id == id);
        //    if (detor != null)
        //    {
        //        ViewBag.Notification = "You must delete all order details before deleting the order";
        //        return this.Delete_order(ord.id);
        //    }
        //    data.orders.DeleteOnSubmit(ord);
        //    data.SubmitChanges();
        //    return RedirectToAction("Orders");
        //}
        //public ActionResult Details_Order(int id)
        //{
        //    var detord = from det_orders in data.det_orders
        //                 where det_orders.order_id == id
        //                 select det_orders;
        //    if (detord.Count() == 0)
        //    {
        //        ViewBag.order_id = id;
        //        ViewBag.Notification = "none";
        //        return View();
        //    }
        //    ViewBag.order_id = id;
        //    return View(detord);
        //}
        //public ActionResult Update_det_order(int id, FormCollection collection)
        //{
        //    det_order detor = data.det_orders.SingleOrDefault(n => n.id == id);
        //    if (detor != null)
        //    {
        //        detor.quantity = int.Parse(collection["txtQuantity"].ToString());
        //        UpdateModel(detor);
        //        data.SubmitChanges();
        //    }
        //    return RedirectToAction("Details_Order", new { id = detor.order_id });
        //}
        //[HttpGet]
        //public ActionResult Delete_detorder(int id)
        //{
        //    det_order detor = data.det_orders.SingleOrDefault(n => n.id == id);
        //    if (detor == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    ViewBag.detor_id = detor.id;
        //    return View(detor);
        //}

        //[HttpPost, ActionName("Delete_detorder")]
        //public ActionResult Confirm_deletion_detorder(int id)
        //{
        //    det_order detor = data.det_orders.SingleOrDefault(n => n.id == id);
        //    if (detor == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    data.det_orders.DeleteOnSubmit(detor);
        //    data.SubmitChanges();
        //    return RedirectToAction("Details_Order", new { id = detor.order_id });
        //}
    }
}