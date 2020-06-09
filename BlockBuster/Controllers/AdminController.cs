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
        // ham kiem tra mat khau
        private bool CheckPassword(string pass)
        {
            //min 8 ky tu, max 16 ky tu
            if (pass.Length < 8 || pass.Length > 16)
                return false;

            //khong chua khoan trang
            if (pass.Contains(" "))
                return false;

            //gom it nhat mot chu in hoa
            if (!pass.Any(char.IsUpper))
                return false;

            //gom it nhat mot chu thuong
            if (!pass.Any(char.IsLower))
                return false;
            //gom it nhat mot ky tu dat biet
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                    return true;
            }
            return false;
        }
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
                    return View(data.films.ToList().OrderByDescending(n => n.created).Where(or => or.form_id == 1).ToPagedList(pageNumber, pageSize));
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
                    return View(data.films.ToList().OrderByDescending(n => n.created).Where(or => or.form_id == 2).ToPagedList(pageNumber, pageSize));
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
                    return View(data.admins.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var admins = from admin in data.admins where admin.name.ToUpper().Contains(key.ToUpper()) || admin.username.ToUpper().Contains(key.ToUpper()) select admin;

                if (admins.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.admins.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                    return View(data.celebrities.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var cele = from cel in data.celebrities where cel.name.ToUpper().Contains(key.ToUpper()) select cel;
                    if (cele.Count() == 0)
                    {
                        ViewBag.Notification = "empty";
                        return View(data.celebrities.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                    return View(data.trailers.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                        return View(trai.OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                    return View(data.users.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var user = from use in data.users where use.first_name.ToUpper().Contains(key.ToUpper()) || use.last_name.ToUpper().Contains(key.ToUpper()) || use.email.ToUpper().Contains(key.ToUpper()) select use;

                if (user.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.users.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                return View(data.categories.ToList().OrderByDescending(n => n.id));
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
        public ActionResult Delete_movie(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(fil); }
        }
        public ActionResult Delete_movie_confirm(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_cel = data.film_celebrities.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cel)
                {
                    data.film_celebrities.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_cat = data.film_categories.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cat)
                {
                    data.film_categories.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_cou = data.film_countries.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cou)
                {
                    data.film_countries.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_rev = data.reviews.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_rev)
                {
                    data.reviews.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_tra = data.film_trailers.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_tra)
                {
                    data.film_trailers.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                string directoryimg = Server.MapPath("/images/films/" + fil.image_link);
                System.IO.File.Delete(directoryimg);
                data.films.DeleteOnSubmit(fil);
                data.SubmitChanges();
                return RedirectToAction("List_movies");
            }
        }
        public ActionResult Delete_drama(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(fil); }
        }
        public ActionResult Delete_drama_confirm(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_cel = data.film_celebrities.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cel)
                {
                    data.film_celebrities.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_cat = data.film_categories.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cat)
                {
                    data.film_categories.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_cou = data.film_countries.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_cou)
                {
                    data.film_countries.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_rev = data.reviews.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_rev)
                {
                    data.reviews.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_tra = data.film_trailers.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_tra)
                {
                    data.film_trailers.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                string directoryimg = Server.MapPath("/images/films/" + fil.image_link);
                System.IO.File.Delete(directoryimg);
                data.films.DeleteOnSubmit(fil);
                data.SubmitChanges();
                return RedirectToAction("List_dramas");
            }
        }
        public ActionResult Delete_celebrity(int id)
        {
            celebrity cel = data.celebrities.SingleOrDefault(n => n.id == id);
            if (cel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(cel); }
        }
        public ActionResult Delete_celebrity_confirm(int id)
        {
            celebrity cel = data.celebrities.SingleOrDefault(n => n.id == id);
            if (cel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_cel = data.film_celebrities.Where(or => or.celeb_id == id).ToList();
                foreach (var item in fil_cel)
                {
                    data.film_celebrities.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var cel_job = data.celeb_jobs.Where(or => or.celeb_id == id).ToList();
                foreach (var item in cel_job)
                {
                    data.celeb_jobs.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                string directoryimg = Server.MapPath("/images/celeb/" + cel.avatar);
                System.IO.File.Delete(directoryimg);
                data.celebrities.DeleteOnSubmit(cel);
                data.SubmitChanges();
                return RedirectToAction("List_celebrities");
            }
        }
        public ActionResult Delete_trailer(int id)
        {
            trailer tra = data.trailers.SingleOrDefault(n => n.id == id);
            if (tra == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(tra); }
        }
        public ActionResult Delete_trailer_confirm(int id)
        {
            trailer tra = data.trailers.SingleOrDefault(n => n.id == id);
            if (tra == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_tra = data.film_trailers.Where(or => or.trailer_id == id).ToList();
                foreach (var item in fil_tra)
                {
                    data.film_trailers.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                string directoryimg = Server.MapPath("/images/trailer/"+tra.image_link);
                System.IO.File.Delete(directoryimg);
                data.trailers.DeleteOnSubmit(tra);
                data.SubmitChanges();
                return RedirectToAction("List_trailers");
            }
        }
        public ActionResult Delete_admin(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(adm); }
        }
        public ActionResult Delete_admin_confirm(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                data.admins.DeleteOnSubmit(adm);
                data.SubmitChanges();
                return RedirectToAction("List_admins");
            }
        }
        public ActionResult Delete_category(int id)
        {
            category cat = data.categories.SingleOrDefault(n => n.id == id);
            if (cat == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(cat); }
        }
        public ActionResult Delete_category_confirm(int id)
        {
            category cat = data.categories.SingleOrDefault(n => n.id == id);
            if (cat == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_cat = data.film_categories.Where(or => or.category_id == id).ToList();
                foreach (var item in fil_cat)
                {
                    data.film_categories.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                data.categories.DeleteOnSubmit(cat);
                data.SubmitChanges();
                return RedirectToAction("List_categories");
            }
        }
        public ActionResult Delete_country(int id)
        {
            var cou = data.countries.SingleOrDefault(n => n.id == id);
            if (cou == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(cou); }
        }
        public ActionResult Delete_country_confirm(int id)
        {
            var cou = data.countries.SingleOrDefault(n => n.id == id);
            if (cou == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_cou = data.film_countries.Where(or => or.country_id == id).ToList();
                foreach (var item in fil_cou)
                {
                    data.film_countries.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var celeb_cou = data.celebrities.Where(or => or.country_id == id).ToList();
                foreach (var item in fil_cou)
                {
                    item.country_id = null;
                    UpdateModel(item);
                    data.SubmitChanges();
                }
                data.countries.DeleteOnSubmit(cou);
                data.SubmitChanges();
                return RedirectToAction("List_countries");
            }
        }
        public ActionResult Delete_user(int id)
        {
            var user = data.users.SingleOrDefault(n => n.id == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(user); }
        }
        public ActionResult Delete_user_confirm(int id)
        {
            var user = data.users.SingleOrDefault(n => n.id == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var fil_rev = data.reviews.Where(or => or.user_id == id).ToList();
                foreach (var item in fil_rev)
                {
                    data.reviews.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                var fil_fav = data.favorites.Where(or => or.user_id == id).ToList();
                foreach (var item in fil_fav)
                {
                    data.favorites.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
                data.users.DeleteOnSubmit(user);
                data.SubmitChanges();
                return RedirectToAction("List_users");
            }
        }
        public ActionResult Delete_film_category(int id)
        {
            film_category fil_cat = data.film_categories.SingleOrDefault(n => n.id == id);
            if (fil_cat == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                data.film_categories.DeleteOnSubmit(fil_cat);
                data.SubmitChanges();
                return RedirectToAction("Create_film_category", "Admin", new { id = id});
            }
        }
        [HttpGet]
        public ActionResult Create_movie()
        {
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
        [ValidateInput(false)]
        public ActionResult Create_movie(film movie, FormCollection collection, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View(movie);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/films"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    var description = collection["description"];
                    movie.image_link = fileName;
                    movie.description = description;
                    movie.created = DateTime.Now;
                    movie.view_count = 0;
                    movie.rate = 0;
                    movie.form_id = 1;
                    data.films.InsertOnSubmit(movie);
                    data.SubmitChanges();
                }
                else {; }
                //return RedirectToAction("Create_film_category", new { id = movie.id});
                return RedirectToAction("List_movies");
            }
        }
        public ActionResult List_film_category(int id)
        {
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var cat_list = data.film_categories.ToList().Where(or => or.film_id == id).ToList();
                return PartialView(cat_list);
            }
        }
        [HttpGet]
        public ActionResult Create_film_category(int id)
        {
            ViewBag.id = id;
            ViewBag.category_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
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
        [ValidateInput(false)]
        public ActionResult Create_film_category(film_category fil_cat)
        {
            ViewBag.id = fil_cat.film_id;
            ViewBag.category_id = new SelectList(data.categories.ToList().OrderBy(n => n.name), "id", "name");
            if (ModelState.IsValid)
            {
                data.film_categories.InsertOnSubmit(fil_cat);
                data.SubmitChanges();
                return RedirectToAction("Create_film_category");
            }
            else { return HttpNotFound(); }
        }
        [HttpGet]
        public ActionResult Create_drama()
        {
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
        [ValidateInput(false)]
        public ActionResult Create_drama(film drama, FormCollection collection, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View(drama);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/films"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    var description = collection["description"];
                    drama.image_link = fileName;
                    drama.description = description;
                    drama.created = DateTime.Now;
                    drama.view_count = 0;
                    drama.rate = 0;
                    drama.form_id = 2;
                    data.films.InsertOnSubmit(drama);
                    data.SubmitChanges();
                }
                else { return HttpNotFound(); }
                return RedirectToAction("List_dramas");
            }
        }
        [HttpGet]
        public ActionResult Create_celebrity()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.country_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_celebrity(celebrity celeb, FormCollection collection, HttpPostedFileBase fileUpload)
        {
            ViewBag.country_id = new SelectList(data.countries.ToList().OrderBy(n => n.name), "id", "name");
            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/celeb"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    celeb.avatar = fileName;
                    data.celebrities.InsertOnSubmit(celeb);
                    data.SubmitChanges();
                }
                else { return HttpNotFound(); }
                return RedirectToAction("List_celebrities");
            }
        }
        [HttpGet]
        public ActionResult Create_admin()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_admin(admin admin)
        {
            ViewBag.position = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
            if (ModelState.IsValid)
            {
                data.admins.InsertOnSubmit(admin);
                data.SubmitChanges();
            }
            else { return HttpNotFound(); }
            return RedirectToAction("List_admins");
        }
        [HttpGet]
        public ActionResult Create_user()
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
        [ValidateInput(false)]
        public ActionResult Create_user(user user, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string password = collection["password"];
                if (!CheckPassword(password))
                {
                    ViewBag.Notification = "Password incorrect format";
                    return View(user);
                }
                else
                {
                    user.created = DateTime.Now;
                    data.users.InsertOnSubmit(user);
                    data.SubmitChanges();
                }
            }
            else { return HttpNotFound(); }
            return RedirectToAction("List_users");
        }
        [HttpGet]
        public ActionResult Create_trailer()
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
        [ValidateInput(false)]
        public ActionResult Create_trailer(trailer tra, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/trailer"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    tra.image_link = fileName;
                    data.trailers.InsertOnSubmit(tra);
                    data.SubmitChanges();
                }
                else { return HttpNotFound(); }
                return RedirectToAction("List_trailers");
            }
        }
        [HttpGet]
        public ActionResult Create_category()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.color_id = new SelectList(data.colors.ToList().OrderBy(n => n.id), "id", "color_name");
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_category(category cat)
        {
            ViewBag.color_id = new SelectList(data.colors.ToList().OrderBy(n => n.id), "id", "color_name");
            if (ModelState.IsValid)
            {
                data.categories.InsertOnSubmit(cat);
                data.SubmitChanges();
            }
            else { return HttpNotFound(); }
            return RedirectToAction("List_categories");
        }
        [HttpGet]
        public ActionResult Create_country()
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
        [ValidateInput(false)]
        public ActionResult Create_country(country cou)
        {
            if (ModelState.IsValid)
            {
                data.countries.InsertOnSubmit(cou);
                data.SubmitChanges();
            }
            else { return HttpNotFound(); }
            return RedirectToAction("List_countries");
        }
        public ActionResult Detail_film(int id)
        {
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                film fil = data.films.Where(or => or.id == id).FirstOrDefault();
                return View(fil);
            }
        }
        [HttpGet]
        public ActionResult Edit_film(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(fil);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_film(film fil)
        {
            if (ModelState.IsValid)
            {
                UpdateModel(fil);
                data.SubmitChanges();
                return RedirectToAction("Detail_film", new { id = fil.id});
            }
            return this.Edit_film(fil.id);
        }
    }
}