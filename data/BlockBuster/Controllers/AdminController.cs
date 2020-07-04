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
                if(adm.position_id == 1)
                {
                    return RedirectToAction("List_movies", "Admin");
                }
                else
                {
                    return RedirectToAction("List_admins", "Admin");
                }
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
                    return View(data.userrs.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var user = from use in data.userrs where use.first_name.ToUpper().Contains(key.ToUpper()) || use.last_name.ToUpper().Contains(key.ToUpper()) || use.email.ToUpper().Contains(key.ToUpper()) select use;

                if (user.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.userrs.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
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
                var fil_tra = data.trailers.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_tra)
                {
                    data.trailers.DeleteOnSubmit(item);
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
                var fil_tra = data.trailers.Where(or => or.film_id == id).ToList();
                foreach (var item in fil_tra)
                {
                    data.trailers.DeleteOnSubmit(item);
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
            var user = data.userrs.SingleOrDefault(n => n.id == id);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else { return View(user); }
        }
        public ActionResult Delete_user_confirm(int id)
        {
            var user = data.userrs.SingleOrDefault(n => n.id == id);
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
                data.userrs.DeleteOnSubmit(user);
                data.SubmitChanges();
                return RedirectToAction("List_users");
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
        public ActionResult Create_user(userr user, FormCollection collection)
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
                    data.userrs.InsertOnSubmit(user);
                    data.SubmitChanges();
                }
            }
            else { return HttpNotFound(); }
            return RedirectToAction("List_users");
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
        // Partial view phim - quoc gia
        public ActionResult Film_country(int id) { return PartialView(data.film_countries.Where(or => or.film_id == id).OrderBy(a => a.id).ToList()); }
        // Partial view phim - nguoi noi tieng
        public ActionResult Film_celebrity(int id) { return PartialView(data.film_celebrities.Where(or => or.film_id == id).OrderBy(a => a.id).ToList()); }
        // Partial view phim - the loai
        public ActionResult Film_category(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderBy(a => a.id).ToList()); }
        // Partial view phim - traiiler
        public ActionResult Film_trailer(int id) { return PartialView(data.trailers.Where(or => or.film_id == id).OrderBy(a => a.id).ToList()); }
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
        public ActionResult Edit_film(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (fil.release != null)
            {
                DateTime release = DateTime.Parse(fil.release.ToString());
                String year = release.Year.ToString();
                String month, day;
                if (release.Month < 10)
                {
                    month = "0" + release.Month.ToString();
                }
                else
                {
                    month = release.Month.ToString();
                }
                if (release.Day < 10)
                {
                    day = "0" + release.Day.ToString();
                }
                else
                {
                    day = release.Day.ToString();
                }
                ViewBag.release = year + "-" + month + "-" + day;
            }
            if (fil.created != null)
            {
                DateTime created = DateTime.Parse(fil.created.ToString());
                String year_ = created.Year.ToString();
                String month_, day_;
                if (created.Month < 10)
                {
                    month_ = "0" + created.Month.ToString();
                }
                else
                {
                    month_ = created.Month.ToString();
                }
                if (created.Day < 10)
                {
                    day_ = "0" + created.Day.ToString();
                }
                else
                {
                    day_ = created.Day.ToString();
                }
                ViewBag.created = year_ + "-" + month_ + "-" + day_;
            }
            ViewBag.form = Get_list_form();
            return View(fil);
        }
        public ActionResult Do_edit_film(FormCollection collection, HttpPostedFileBase fileUpload)
        {
            int id = id = int.Parse(collection["id"]);
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                if (collection["name"] != null && collection["name"] != "")
                {
                    fil.name = collection["name"];
                }
                else {; }
                if (collection["release"] != null && collection["release"] != "")
                {
                    fil.release = DateTime.Parse(collection["release"]);
                }
                else {; }
                if (collection["view_count"] != null && collection["view_count"] != "")
                {
                    fil.view_count = int.Parse(collection["view_count"]);
                }
                else {; }
                if (collection["description"] != null && collection["description"] != "")
                {
                    fil.description = collection["description"];
                }
                else {; }
                if (collection["form_id"] != null && collection["form_id"] != "")
                {
                    fil.form_id = int.Parse(collection["form_id"]);
                }
                else {; }
                if (collection["rate"] != null && collection["rate"] != "")
                {
                    fil.rate = int.Parse(collection["rate"]);
                }
                else {; }
                if (fileUpload != null)
                {
                    // Xoa anh cu
                    string directoryimg = Server.MapPath("/images/films/" + fil.image_link);
                    System.IO.File.Delete(directoryimg);
                    // Them anh moi
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/trailer"), fileName);
                    // Kiem tra anh trung
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    fil.image_link = fileName;
                }
                else {; }
                data.SubmitChanges();
                return RedirectToAction("Detail_film", "Admin", new { id = id });
            }
        }
        public List<country> Get_list_country()
        {
            List<country> list_country = data.countries.ToList();
            return (list_country);
        }
        public List<form> Get_list_form() { return (data.forms.ToList()); }
        public List<country> Get_list_all_country() { return (data.countries.ToList()); }
        public List<category> Get_list_all_category() { return (data.categories.ToList()); }
        public List<celebrity> Get_list_all_celebrity() { return (data.celebrities.ToList()); }
        // Quan ly danh sach quoc gia cua mot phim
        public ActionResult Manager_film_country(int id)
        {
            ViewBag.film_id = id;
            ViewBag.country = Get_list_all_country();
            return View(data.film_countries.Where(or => or.film_id == id).OrderBy(a => a.id).ToList());
        }
        public ActionResult Add_country_film(FormCollection collection)
        {
            int id = int.Parse(collection["film_id"]);
            ViewBag.film_id = id;
            ViewBag.country = Get_list_all_country();
            if (ModelState.IsValid)
            {
                film_country fil_coun = new film_country();
                fil_coun.film_id = id;
                fil_coun.country_id = int.Parse(collection["country_id"]);
                var a = from filc in data.film_countries
                        where filc.film_id == fil_coun.film_id && filc.country_id == fil_coun.country_id
                        select filc;
                if(a.Count() == 0)
                {
                    data.film_countries.InsertOnSubmit(fil_coun);
                    data.SubmitChanges();
                    return RedirectToAction("Manager_film_country", new { id = id });
                }
                return RedirectToAction("Manager_film_country", new { id = id });
            }
            else { return HttpNotFound(); }
        }
        public ActionResult Delete_film_country(int id)
        {
            film_country f_c = data.film_countries.SingleOrDefault(n => n.id == id);
            if (f_c == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                int film_id = int.Parse(f_c.film_id.ToString());
                data.film_countries.DeleteOnSubmit(f_c);
                data.SubmitChanges();
                return RedirectToAction("Manager_film_country", new { id = film_id });
            }
        }
        // Quan ly danh sach the loai cua mot phim
        public ActionResult Manager_film_category(int id)
        {
            ViewBag.film_id = id;
            ViewBag.category = Get_list_all_category();
            return View(data.film_categories.Where(or => or.film_id == id).OrderBy(a => a.id).ToList());
        }
        public ActionResult Add_category_film(FormCollection collection)
        {
            int id = int.Parse(collection["film_id"]);
            ViewBag.film_id = id;
            ViewBag.category = Get_list_all_category();
            if (ModelState.IsValid)
            {
                film_category fil_cate = new film_category();
                fil_cate.film_id = id;
                fil_cate.category_id = int.Parse(collection["category_id"]);
                var a = from filc in data.film_categories
                        where filc.film_id == fil_cate.film_id && filc.category_id == fil_cate.category_id
                        select filc;
                if (a.Count() == 0)
                {
                    data.film_categories.InsertOnSubmit(fil_cate);
                    data.SubmitChanges();
                    return RedirectToAction("Manager_film_category", new { id = id });
                }
                return RedirectToAction("Manager_film_category", new { id = id });
            }
            else { return HttpNotFound(); }
        }
        public ActionResult Delete_film_category(int id)
        {
            film_category f_c = data.film_categories.SingleOrDefault(n => n.id == id);
            if (f_c == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                int film_id = int.Parse(f_c.film_id.ToString());
                data.film_categories.DeleteOnSubmit(f_c);
                data.SubmitChanges();
                return RedirectToAction("Manager_film_category", new { id = film_id });
            }
        }
        // Quan ly danh sach nguoi noi tieng tham gia mot phim
        public ActionResult Manager_film_celebrity(int id)
        {
            ViewBag.film_id = id;
            ViewBag.celebrity = Get_list_all_celebrity();
            return View(data.film_celebrities.Where(or => or.film_id == id).OrderBy(a => a.id).ToList());
        }
        // Quan ly danh sach trailer cua mot phim
        public ActionResult Manager_film_trailer(int id)
        {
            ViewBag.film_id = id;
            return View(data.trailers.Where(or => or.film_id == id).OrderBy(a => a.id).ToList());
        }
        public ActionResult Create_trailer(int id)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(id);
            }
        }
        public ActionResult Config_create_trailer(trailer tra, HttpPostedFileBase fileUpload)
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
                return RedirectToAction("Manager_film_trailer", new { id = tra.film_id });
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
                string directoryimg = Server.MapPath("/images/trailer/" + tra.image_link);
                System.IO.File.Delete(directoryimg);
                data.trailers.DeleteOnSubmit(tra);
                data.SubmitChanges();
                return RedirectToAction("Manager_film_trailer", new { id = tra.film_id });
            }
        }
    }
}