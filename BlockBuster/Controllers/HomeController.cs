using Antlr.Runtime.Misc;
using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace BlockBuster.Controllers
{
    public class HomeController : Controller
    {
        dbBBusterDataContext data = new dbBBusterDataContext(); // tao bien ket noi data
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // Get phim
        private filmm Getfilm(film film) //data.films.Where(or => or.id == id).FirstOrDefault();
        {
            filmm filmm = new filmm(); // khoi tao doi tuong phim
            filmm.Id = film.id;
            filmm.Name = film.name.Trim();
            filmm.Image_link = film.image_link.Trim();
            filmm.View_count = double.Parse((film.view_count).ToString());
            filmm.Description = film.description.Trim();
            filmm.Created = DateTime.Parse((film.created).ToString());
            filmm.Form_id = int.Parse((film.form_id).ToString());
            filmm.Rate = int.Parse((film.rate).ToString());
            // convert lai ngay ra mat phim de de hien thi 
            DateTime release = DateTime.Parse((film.release).ToString()); // get ngay ra mat phim
            filmm.Year = release.Year;
            switch (release.Month)
            {
                case 1:
                    filmm.Month = "January";
                    break;
                case 2:
                    filmm.Month = "February";
                    break;
                case 3:
                    filmm.Month = "March";
                    break;
                case 4:
                    filmm.Month = "April";
                    break;
                case 5:
                    filmm.Month = "May";
                    break;
                case 6:
                    filmm.Month = "June";
                    break;
                case 7:
                    filmm.Month = "July";
                    break;
                case 8:
                    filmm.Month = "August";
                    break;
                case 9:
                    filmm.Month = "September";
                    break;
                case 10:
                    filmm.Month = "October";
                    break;
                case 11:
                    filmm.Month = "November";
                    break;
                case 12:
                    filmm.Month = "December";
                    break;
            }
            filmm.Day = release.Day;
            filmm.Hour = release.Hour;
            filmm.Minute = release.Minute;
            return (filmm);
        }
        // Get list film da convert
        private List<filmm> Get_list_film_convert(List<film> list_film)
        {
            List<filmm> list_film_convert = new List<filmm>();
            if (list_film.Count > 0)
            {
                foreach (var item in list_film)
                {
                    filmm film = Getfilm(item);
                    if (!list_film_convert.Contains(film))
                    {
                        list_film_convert.Add(film);
                    }
                }
            }
            else {; }
            return (list_film_convert);
        }
        // Partial view danh sach phim moi nhat
        public ActionResult Newfilm() { return PartialView(data.films.OrderByDescending(a => a.created).Take(8).ToList()); }
        // Partial view danh sach phim le duoc xem nhieu nhat
        public ActionResult Popular_movie() { return PartialView(data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.view_count).Take(7).ToList()); }
        // Partial view danh sach phim bo duoc xem nhieu nhat
        public ActionResult Popular_drama() { return PartialView(data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.view_count).Take(7).ToList()); }
        // Partial view danh sach phim le duoc danh gia cao nhat
        public ActionResult Toprate_movie() { return PartialView(data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.rate).Take(7).ToList()); }
        // Partial view danh sach phim bo duoc xem nhieu nhat
        public ActionResult Toprate_drama() { return PartialView(data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.rate).Take(7).ToList()); }
        // Partial view danh sach ngau nhien 5 nguoi noi tieng
        public ActionResult Celebrities() { return PartialView(data.celebrities.OrderByDescending(a => a.id).Take(5).ToList()); }
        // Partial view danh sach 6 trailer moi nhat
        public ActionResult Newtrailer() { return PartialView(data.trailers.OrderByDescending(a => a.id).Take(6).ToList()); }
        // Tat ca the loai cua moi phim
        public ActionResult Category_film(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList()); }
        // 2 the loai cua moi phim - chi lay 2 de hien thi tai partialview phim moi
        public ActionResult Category_film_2(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).Take(2).ToList()); }
        // Partial view menu
        public ActionResult Menu_film() { return PartialView(data.forms.OrderBy(a => a.id).ToList()); }
        // Partial view menu the loai
        public ActionResult Menu_category(int id)
        {
            ViewBag.form_id = id;
            return PartialView(data.categories.OrderBy(a => a.name).ToList());
        }
        // Partial view menu quoc gia
        public ActionResult Menu_country(int id)
        {
            ViewBag.form_id = id;
            return PartialView(data.countries.OrderBy(a => a.name).ToList());
        }
        // Partial view menu nguoi noi tieng theo quoc gia
        public ActionResult Menu_celebrity_county() { return PartialView(data.countries.OrderBy(a => a.id).ToList()); }
        // View danh sach phim
        public ActionResult Film_list(int form_id, int sort, int cate_id, int coun_id, int rate, int? page)
        {
            // phan trang
            int pageSize = 5;
            int pageNum = (page ?? 1);

            ViewBag.form_id = form_id;
            ViewBag.sort = sort;
            ViewBag.cate_id = cate_id;
            ViewBag.coun_id = coun_id;
            ViewBag.rate = rate;
            List<film> list_film = new List<film>();
            // chon cach sap xep phim
            switch (sort)
            {
                case 0:
                    list_film = data.films.Where(or => or.form_id == form_id).OrderByDescending(a => a.view_count).ToList();
                    break;
                case 1:
                    list_film = data.films.Where(or => or.form_id == form_id).OrderByDescending(a => a.rate).ToList();
                    break;
                case 2:
                    list_film = data.films.Where(or => or.form_id == form_id).OrderByDescending(a => a.release).ToList();
                    break;
                case 3:
                    list_film = data.films.Where(or => or.form_id == form_id).OrderBy(a => a.release).ToList();
                    break;
            }
            List<film> list_film_ = Get_list_film(list_film, cate_id, coun_id, rate);// loc danh sach phim theo the loai, quoc gia va dien danh gia
            List<filmm> list_film_convert = Get_list_film_convert(list_film_);// convert lai danh sach phim
            ViewBag.count = list_film_convert.Count;
            return View(list_film_convert.ToPagedList(pageNum, pageSize));
        }
        // Lay danh sach phim theo the loai
        List<film> Get_film_cate(int id)
        {
            List<film_category> list_cate = data.film_categories.Where(or => or.category_id == id).ToList();
            List<film> list_film = new List<film>();
            foreach (var item in list_cate)
            {
                list_film.Add(item.film);
            }
            return (list_film);
        }
        // Lay danh sach phim theo quoc gia
        List<film> Get_film_country(int id)
        {
            List<film_country> list_country = data.film_countries.Where(or => or.country_id == id).ToList();
            List<film> list_film = new List<film>();
            foreach (var item in list_country)
            {
                list_film.Add(item.film);
            }
            return (list_film);
        }
        // Lay danh sach phim theo nguoi noi tieng tham gia
        List<film> Get_film_celebrity(int id)
        {
            List<film_celebrity> list_selebrity = data.film_celebrities.Where(or => or.celeb_id == id).ToList();
            List<film> list_film = new List<film>();
            foreach (var item in list_selebrity)
            {
                list_film.Add(item.film);
            }
            return (list_film);
        }
        // Lay danh sach phim theo diem danh gia
        List<film> Get_film_rate(int id)
        {
            List<film> list_film = data.films.Where(or => or.rate >= id).ToList();
            return (list_film);
        }
        // Lay danh sach phim theo dieu kien
        List<film> Get_list_film(List<film> list_film, int cate_id, int coun_id, int rate)
        {
            List<int> list_film_remove = new List<int>();
            if (cate_id > 0)
            {
                List<film> list_film_cate = Get_film_cate(cate_id);
                foreach (var item in list_film)
                {
                    if (!list_film_cate.Contains(item))
                    {
                        list_film_remove.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            if (coun_id > 0)
            {
                List<film> list_film_country = Get_film_country(coun_id);
                foreach (var item in list_film)
                {
                    if (!list_film_country.Contains(item))
                    {
                        list_film_remove.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            if (rate > 0)
            {
                List<film> list_film_rate = Get_film_rate(rate);
                foreach (var item in list_film)
                {
                    if (!list_film_rate.Contains(item))
                    {
                        list_film_remove.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            if (list_film_remove.Count > 0)
            {
                foreach (int item in list_film_remove)
                {
                    list_film.RemoveAll(r => r.id == item);
                }
            }
            else {; }
            return (list_film);
        }
        // Nghe nghiep cua tung nguoi noi tieng
        public ActionResult Celeb_job(int id) { return PartialView(data.celeb_jobs.Where(or => or.celeb_id == id).OrderByDescending(a => a.id).ToList()); }
        // danh sach nguoi noi tieng
        public ActionResult Celebrity_list(int coun_id, int sort, int? page)
        {
            // phan trang
            int pageSize = 10;
            int pageNum = (page ?? 1);
            ViewBag.coun_id = coun_id;
            ViewBag.sort = coun_id;
            List<celebrity> celeb_list = new List<celebrity>();
            List<int> celeb_remove_list = new List<int>();
            // chon cach sap xep phim
            switch (sort)
            {
                case 0:
                    celeb_list = data.celebrities.OrderBy(a => a.name).ToList();
                    break;
                case 1:
                    celeb_list = data.celebrities.OrderByDescending(a => a.name).ToList();
                    break;
                case 2:
                    celeb_list = data.celebrities.OrderBy(a => a.birthday).ToList();
                    break;
                case 3:
                    celeb_list = data.celebrities.OrderByDescending(a => a.birthday).ToList();
                    break;
            }
            if (coun_id > 0)
            {
                List<celebrity> list_celeb_counrty = (data.celebrities.Where(or => or.country_id == coun_id).ToList());
                foreach (var item in celeb_list)
                {
                    if (!list_celeb_counrty.Contains(item))
                    {
                        celeb_remove_list.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            if (celeb_remove_list.Count > 0)
            {
                foreach (int item in celeb_remove_list)
                {
                    celeb_list.RemoveAll(r => r.id == item);
                }
            }
            else {; }
            ViewBag.count = celeb_list.Count;
            return View(celeb_list.ToPagedList(pageNum, pageSize));
        }
        // Lay so luot nhan xet cua tung phim
        public ActionResult Review_count(int id)
        {
            int? review_count = data.reviews.Count(or => or.film_id == id);
            return PartialView(review_count);
        }
        // chi tiet moi phim
        public ActionResult Film_single(int id)
        {
            var film = from f in data.films
                       where f.id == id
                       select f;
            return View(Getfilm(film.Single()));
        }
        // nguoi tham gia cua moi phim
        public ActionResult Film_role(int id)
        {
            ViewBag.film_id = id;
            var rol = from ro in data.roles
                      where ro.display == true
                      select ro;
            return PartialView(rol);
        }
        // Danh sach nguoi noi tieng cua tung phim
        public ActionResult Film_celebrity(int id, int role_id)
        {
            var celeb = from de in data.film_celebrities
                        where de.film_id == id && de.role_id == role_id
                        select de;
            if (celeb.Count() == 0)
            {
                ViewBag.check = false;
                return PartialView();
            }
            else { return PartialView(celeb); }
        }
        // Binh luan noi bat - neu chua dang nhap hoac da dang nhap nhung chua danh gia phim nay thi lay binh luan moi nhat,
        //neu da danh gia thi lay binh luan cua tai khoan dang dang nhap
        public ActionResult Film_review(int id)
        {
            if (Session["UserAccount"] != null)
            {
                user users = (user)Session["UserAccount"];
                var review = from re in data.reviews
                             where re.user_id == users.id && re.film_id == id
                             select re;
                if (review.Count() > 0)
                {
                    ViewBag.check = true;
                    return PartialView(review.Single());
                }
                else
                {
                    var rev = data.reviews.Where(or => or.film_id == id).OrderByDescending(a => a.id).FirstOrDefault();
                    if (rev != null)
                    {
                        return PartialView(rev);
                    }
                    else
                    {
                        ViewBag.check = false;
                        return PartialView();
                    }
                }
            }
            else
            {
                var rev = data.reviews.Where(or => or.film_id == id).OrderByDescending(a => a.id).FirstOrDefault();
                if (rev != null)
                {
                    return PartialView(rev);
                }
                else
                {
                    ViewBag.check = false;
                    return PartialView();
                }
            }
        }
        // Tat ca binh luan moi nhat cua moi phim
        public ActionResult Film_allreview(int id, int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var rev = data.reviews.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList();
            if (rev.Count() == 0)
            {
                ViewBag.check = false;
                return PartialView();
            }
            else { ViewBag.id = id; return PartialView(rev.ToPagedList(pageNum, pageSize)); }
        }
        // 5 phim lien quan - xet theo the loai phim
        public ActionResult Film_related(int id)
        {
            List<film_category> fil = data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList(); //danh sach the loai cua phim
            var film_related = new List<film>(); //khoi tao danh sach phim lien quan
            foreach (var item in fil)
            {
                if (film_related.Count() < 5) //kiem tra xem da du 5 phim hay chua
                {
                    List<film_category> film_ca = data.film_categories.Where(or => or.category_id == item.category_id).OrderByDescending(a => a.id).Take(5).ToList(); //danh sach tam cac phim cung the loai
                    foreach (var item_ca in film_ca)
                    {
                        if (item_ca.film.id != id) // kiem tra khac phim goc
                        {
                            if (!film_related.Contains(item_ca.film)) // kiem tra ton tai trong mang
                            {
                                film_related.Add(item_ca.film); //them phim vao danh sach phim len quan
                            }
                            else {; }
                        }
                        else {; }
                    }
                }
                else
                {
                    film_related.RemoveAt(4); // lay dung 5 phim
                    return PartialView(film_related); // xuat danh sach 5 phim lien quan
                }
            }
            return PartialView(film_related); // xuat danh sach phim lien quan (ko du 5 phim)
        }
        // Xem phim
        public ActionResult Watch_now(int id) { return View(data.films.Where(or => or.id == id).FirstOrDefault()); }
        // thong tin nguoi noi tieng
        public ActionResult Celebrity_single(int id)
        {
            celebrity celebrity = data.celebrities.Where(or => or.id == id).FirstOrDefault();
            DateTime birthday = DateTime.Parse((celebrity.birthday).ToString());
            string month = "month";
            int year, day;
            year = birthday.Year;
            switch (birthday.Month)
            {
                case 1: month = "January"; break;
                case 2: month = "February"; break;
                case 3: month = "March"; break;
                case 4: month = "April"; break;
                case 5: month = "May"; break;
                case 6: month = "June"; break;
                case 7: month = "July"; break;
                case 8: month = "August"; break;
                case 9: month = "September"; break;
                case 10: month = "October"; break;
                case 11: month = "November"; break;
                case 12: month = "December"; break;
            }
            day = birthday.Day;
            ViewBag.birthday = month + " " + day + ", " + year;
            return View(celebrity);
        }
        //danh sach phim moi nguoi noi tieng tung tham gia
        public ActionResult Celebrity_film(int id, int take)
        {
            List<film_celebrity> celeb_tempfilm = data.film_celebrities.Where(or => or.celeb_id == id).OrderByDescending(a => a.id).ToList(); //danh sach tam cac phim da tham gia
            List<film> celeb_film_list = new List<film>(); //khoi tao danh sach phim da tham gia
            foreach (var item in celeb_tempfilm)
            {
                if (!celeb_film_list.Contains(item.film)) // kiem tra ton tai trong mang
                {
                    celeb_film_list.Add(item.film); //them phim vao danh sach phim da tham gia
                }
                else {; }
            }
            // convert lai danh sach phim da tham gia de hien thi
            List<filmm> celeb_film_list_convert = new List<filmm>();
            foreach (var item in celeb_film_list)
            {
                celeb_film_list_convert.Add(Getfilm(item));
            }
            if (take > 0 && celeb_film_list_convert.Count > take)
            {
                ViewBag.take = true;
                celeb_film_list_convert.RemoveAt(take);
                return PartialView(celeb_film_list_convert);
            }
            else { return PartialView(celeb_film_list_convert); }
        }
        // Kiem tra danh gia
        public ActionResult Check_rate(int id)
        {
            ViewBag.id = id;
            if (Session["UserAccount"] != null)
            {
                user users = (user)Session["UserAccount"];
                var review = from re in data.reviews
                             where re.film_id == id && re.user_id == users.id
                             select re;
                if (review.Count() != 0)
                {
                    return PartialView(review.Single());
                }
                else { return PartialView(); }
            }
            else
            {
                return PartialView();
            }
        }
        // View viet danh gia phim
        [HttpGet]
        public ActionResult Write_review(int id, int rate)
        {
            ViewBag.film_id = id;
            ViewBag.rate = rate;
            user users = (user)Session["UserAccount"];
            if (Session["UserAccount"] != null)
            {
                user use = data.users.SingleOrDefault(n => n.id == users.id);
                ViewBag.first_name = use.first_name;
                ViewBag.last_name = use.last_name;
                ViewBag.email = use.email;
            }
            else
            {
                return RedirectToAction("Login", "User", new { noti = "You must be login to continue", film_id = id });
            }
            return PartialView(data.films.Where(or => or.id == id).FirstOrDefault());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_review(FormCollection collection)
        {

            if (ModelState.IsValid)
            {
                review revie = new review();
                if (Session["UserAccount"] == null)
                {
                    return new HttpNotFoundResult(); // 404
                }
                else
                {
                    user users = (user)Session["UserAccount"];
                    int film_id = int.Parse(collection["film"]);
                    revie.created = DateTime.Now;
                    revie.user_id = users.id;
                    revie.film_id = film_id;
                    revie.comment = collection["comment"];
                    revie.title = collection["title"];
                    revie.point = int.Parse(collection["point"]);
                    data.reviews.InsertOnSubmit(revie);
                    data.SubmitChanges();
                    return RedirectToAction("Film_single", "Home", new { id = film_id });
                }
            }
            //// tinh diem cua phim
            //List<review> reviewslist = data.reviews.Where(or => or.film_id == film.id).OrderByDescending(a => a.id).ToList(); //danh sach cac review cua phim
            //if (reviewslist.Count > 0)
            //{
            //    int point_sum = 0; // tong diem
            //    foreach (var item in reviewslist)
            //    {
            //        point_sum += int.Parse((item.point).ToString());
            //    }
            //    filmm.Rate = int.Parse((Math.Round(double.Parse((point_sum / reviewslist.Count).ToString()))).ToString()); //tinh trung binh cong va lam tron
            //}
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Partial_favorite(int id)
        {
            user users = (user)Session["UserAccount"];
            var fav = from f in data.favorites
                      where f.film_id == id && f.user_id == users.id
                      select f;
            if (users != null)
            {
                if (fav.Count() > 0)
                {
                    ViewBag.check = 1;
                    return PartialView(id);
                }
                return PartialView(id);
            }
            else
            {
                return PartialView(-1);
            }
        }
        public ActionResult Add_favorite(int id)
        {
            if (Session["UserAccount"] != null)
            {
                user users = (user)Session["UserAccount"];
                favorite fav = new favorite();
                fav.user_id = users.id;
                fav.film_id = id;
                fav.created = DateTime.Now;
                data.favorites.InsertOnSubmit(fav);
                data.SubmitChanges();
                return RedirectToAction("Film_single", "Home", new { id = id });
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Remove_favorite(int id)
        {
            user users = (user)Session["UserAccount"];
            var fav = from f in data.favorites
                      where f.film_id == id && f.user_id == users.id
                      select f;
            if (users != null)
            {
                if (fav.Count() > 0)
                {
                    data.favorites.DeleteOnSubmit(fav.Single());
                    data.SubmitChanges();
                    return RedirectToAction("Film_single", "Home", new { id = id });
                }
                else { return HttpNotFound(); }
            }
            else
            { return HttpNotFound(); }
        }
    }
}