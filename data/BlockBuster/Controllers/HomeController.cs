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
        private filmm Getfilm(film film) // data.films.Where(or => or.id == id).FirstOrDefault();
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
        // Tat ca the loai cua moi phim
        public ActionResult Category_film(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList()); }
        // 2 the loai cua moi phim - chi lay 2 de hien thi tai partialview phim moi
        public ActionResult Category_film_2(int id) { return PartialView(data.film_categories.Where(or => or.film_id == id).OrderByDescending(a => a.id).Take(2).ToList()); }
        // Partial view menu
        public ActionResult Menu_film() { return PartialView(data.forms.OrderBy(a => a.id).ToList()); }
        // Lay danh sach the loai
        List<category> Get_cate_list()
        {
            List<category> cate_list = data.categories.ToList();
            return (cate_list);
        }
        // Lay bang chu cai
        public class letter
        {
            public int id;
            public String value;
        }
        List<letter> Get_alphabet()
        {
            List<letter> alphabet = new List<letter>();
            for (int i = 65; i <= 90; i++)
            {
                letter letter = new letter();
                letter.id = i;
                letter.value = ((char)i).ToString();
                alphabet.Add(letter);
            }
            return (alphabet);
        }
        // Lay danh sach quoc gia
        List<country> Get_country_list()
        {
            List<country> coun_list = data.countries.ToList();
            return (coun_list);
        }
        // Tao danh sach nam tu be den lon
        List<String> Get_year_min()
        {
            List<String> year_min = new List<String>();
            for (int i = 1920; i <= 2020; i += 10)
            {
                year_min.Add(i.ToString());
            }
            return (year_min);
        }
        // Tao danh sach nam tu lon den be
        List<String> Get_year_max()
        {
            List<String> year_max = new List<String>();
            for (int i = 2020; i >= 1920; i -= 10)
            {
                year_max.Add(i.ToString());
            }
            return (year_max);
        }
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
        public ActionResult Film_list(int? form_id, int? sort, int? cate_id, int? coun_id, int? rate, string key, FormCollection collection, int? view_style, int? page_size,  int? page)
        {
            // phan trang
            int pageSize = 5;
            if(page_size != null)
            {
                pageSize = int.Parse(page_size.ToString());
            }
            int pageNum = (page ?? 1);

            int form_idd = 0;
            int sortt = 0;
            int cate_idd = 0;
            int coun_idd = 0;
            int ratee = 0;
            int view_stylee = 1;

            if (form_id != null) { form_idd = int.Parse(form_id.ToString()); } else {; }
            if (sort != null) { sortt = int.Parse(sort.ToString()); } else {; }
            if (cate_id != null) { cate_idd = int.Parse(cate_id.ToString()); } else {; }
            if (collection["cate_id"] != null) { cate_id = int.Parse(collection["cate_id"]); } else {; }
            if (coun_id != null) { coun_idd = int.Parse(coun_idd.ToString()); } else {; }
            if (collection["coun_id"] != null) { coun_idd = int.Parse(collection["coun_id"]); } else {; }
            if (rate != null) { ratee = int.Parse(rate.ToString()); } else {; }
            if (collection["rate"] != null) { ratee = int.Parse(collection["rate"]); } else {; }
            if (view_style != null) { view_stylee = int.Parse(view_style.ToString()); } else {; }

            ViewBag.form_id = form_idd;
            ViewBag.sort = sortt;
            ViewBag.cate_id = cate_idd;
            ViewBag.coun_id = coun_idd;
            ViewBag.view_style = view_stylee;
            ViewBag.page_size = pageSize;
            ViewBag.rate = ratee;
            ViewBag.key = key;
            ViewBag.country = Get_country_list();
            ViewBag.category = Get_cate_list();
            List<film> list_film = new List<film>();
            // tim theo tu khoa
            if (key != "none")
            {
                if (key == "")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // chon cach sap xep phim
                    switch (sortt)
                    {
                        case 0:
                            var film = from fil in data.films
                                       where fil.name.ToUpper().Contains(key.ToUpper()) && fil.form_id == form_idd
                                       orderby fil.view_count descending
                                       select fil;
                            if(film.Count()>0)
                            {
                                foreach (var item in film)
                                {
                                    list_film.Add(item);
                                }
                            }
                            break;
                        case 1:
                            var film_ = from fil in data.films
                                        where fil.name.ToUpper().Contains(key.ToUpper()) && fil.form_id == form_idd
                                        orderby fil.rate descending
                                        select fil;
                            if (film_.Count() > 0)
                            {
                                foreach (var item in film_)
                                {
                                    list_film.Add(item);
                                }
                            }
                            break;
                        case 2:
                            var film__ = from fil in data.films
                                         where fil.name.ToUpper().Contains(key.ToUpper()) && fil.form_id == form_idd
                                         orderby fil.release descending
                                         select fil;
                            if (film__.Count() > 0)
                            {
                                foreach (var item in film__)
                                {
                                    list_film.Add(item);
                                }
                            }
                            break;
                        case 3:
                            var film___ = from fil in data.films
                                          where fil.name.ToUpper().Contains(key.ToUpper()) && fil.form_id == form_idd
                                          orderby fil.release ascending
                                          select fil;
                            if (film___.Count() > 0)
                            {
                                foreach (var item in film___)
                                {
                                    list_film.Add(item);
                                }
                            }
                            break;
                    }
                }
            }
            else
            {
                // chon cach sap xep phim
                switch (sortt)
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
            }
            List<film> list_film_ = Get_list_film(list_film, cate_idd, coun_idd, ratee);// loc danh sach phim theo the loai, quoc gia va dien danh gia
            List<filmm> list_film_convert = Get_list_film_convert(list_film_);// convert lai danh sach phim
            int count = list_film_convert.Count;
            if(count == 0) {
                ViewBag.count = 0;
                return View();
            }
            else
            {
                ViewBag.count = list_film_convert.Count;
                Session["listfilm"] = list_film_convert;
                return View(list_film_convert.ToPagedList(pageNum, pageSize));
            }
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
            List<film_celebrity> list_celebrity = data.film_celebrities.Where(or => or.celeb_id == id).ToList();
            List<film> list_film = new List<film>();
            foreach (var item in list_celebrity)
            {
                list_film.Add(item.film);
            }
            return (list_film);
        }
        // Lay danh sach phim theo diem danh gia
        List<film> Get_film_rate(int id)
        {
            List<film> list_film = data.films.Where(or => or.rate > id).ToList();
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
        public ActionResult Celebrity_list(int? coun_id, int? sort, String key, int? letter, int? min, int? max, FormCollection collection, int? view_style, int? page_size, int? page)
        {
            // phan trang
            int pageSize = 6;
            if (page_size != null)
            {
                pageSize = int.Parse(page_size.ToString());
            }
            int pageNum = (page ?? 1);

            int coun_idd = -1;
            int sortt = 0;
            int minn = 0;
            int maxx = 2021;
            int letterr = -1;
            String keyy = "none";
            int view_stylee = 1;

            if (key != "none" && key != null) { keyy = key; } else {; }
            if (collection["key"] != null) { keyy = collection["key"]; } else {; }
            if (letter != null) { letterr = int.Parse(letter.ToString()); } else {; }
            if (collection["letter"] != null) { letterr = int.Parse(collection["letter"]); } else {; }
            if (min != null) { minn = int.Parse(min.ToString()); } else {; }
            if (collection["min"] != null) { minn = int.Parse(collection["min"]); } else {; }
            if (max != null) { maxx = int.Parse(max.ToString()); } else {; }
            if (collection["max"] != null) { maxx = int.Parse(collection["max"]); } else {; }
            if (view_style != null) { view_stylee = int.Parse(view_style.ToString()); } else {; }

            if (sort != null) { sortt = int.Parse(sort.ToString()); } else {; }
            if (coun_id != null) { coun_idd = int.Parse(coun_id.ToString()); } else {; }

            ViewBag.coun_id = coun_idd;
            ViewBag.sort = sortt;
            ViewBag.key = keyy;
            ViewBag.min = minn;
            ViewBag.max = maxx;
            ViewBag.letter = letterr;
            ViewBag.key = key;
            ViewBag.view_style = view_stylee;
            ViewBag.page_size = pageSize;
            ViewBag.country = Get_country_list();
            ViewBag.alphabet = Get_alphabet();
            ViewBag.year_min = Get_year_min();
            ViewBag.year_max = Get_year_max();

            List<celebrity> list_celeb = new List<celebrity>();
            // tim theo tu khoa
            if (keyy != "none" && keyy != "")
            {
                // chon cach sap xep co tim kiem
                switch (sortt)
                {
                    case 0:
                        var celeb = from cele in data.celebrities
                                    where cele.name.ToUpper().Contains(keyy.ToUpper())
                                    orderby cele.name
                                    select cele;
                        if (celeb.Count() > 0)
                        {
                            foreach (var item in celeb)
                            {
                                list_celeb.Add(item);
                            }
                        }
                        else
                        {
                            ViewBag.count = "0";
                            return View();
                        }
                        break;
                    case 1:
                        var celebb = from cele in data.celebrities
                                     where cele.name.ToUpper().Contains(keyy.ToUpper())
                                     orderby cele.name descending
                                     select cele;
                        if (celebb.Count() > 0)
                        {
                            foreach (var item in celebb)
                            {
                                list_celeb.Add(item);
                            }
                        }
                        else
                        {
                            ViewBag.count = "0";
                            return View();
                        }
                        break;
                    case 2:
                        var celeb__ = from cele in data.celebrities
                                      where cele.name.ToUpper().Contains(keyy.ToUpper())
                                      orderby cele.birthday
                                      select cele;
                        if (celeb__.Count() > 0)
                        {
                            foreach (var item in celeb__)
                            {
                                list_celeb.Add(item);
                            }
                        }
                        else
                        {
                            ViewBag.count = "0";
                            return View();
                        }
                        break;
                    case 3:
                        var celeb___ = from cele in data.celebrities
                                       where cele.name.ToUpper().Contains(keyy.ToUpper())
                                       orderby cele.birthday descending
                                       select cele;
                        if (celeb___.Count() > 0)
                        {
                            foreach (var item in celeb___)
                            {
                                list_celeb.Add(item);
                            }
                        }
                        else
                        {
                            ViewBag.count = "0";
                            return View();
                        }
                        break;
                }
            }
            else
            {
                // chon cach sap xep khong co tim kiem
                switch (sortt)
                {
                    case 0:
                        list_celeb = data.celebrities.OrderBy(a => a.name).ToList();
                        break;
                    case 1:
                        list_celeb = data.celebrities.OrderByDescending(a => a.name).ToList();
                        break;
                    case 2:
                        list_celeb = data.celebrities.OrderBy(a => a.birthday).ToList();
                        break;
                    case 3:
                        list_celeb = data.celebrities.OrderByDescending(a => a.birthday).ToList();
                        break;
                }
            }
            List<celebrity> list_celeb_ = Get_list_celeb(list_celeb, letterr, coun_idd, minn, maxx);// loc danh sach
            int count = list_celeb_.Count;
            if (count == 0)
            {
                ViewBag.count = 0;
                return View();
            }
            else
            {
                ViewBag.count = list_celeb_.Count;
                Session["listfilm"] = list_celeb_;
                return View(list_celeb_.ToPagedList(pageNum, pageSize));
            }
        }
        // Lay danh sach celeb theo tu dau tien trong ten
        List<celebrity> Get_celeb_letter(int letter)
        {
            String letterr = ((char)letter).ToString();
            List<celebrity> list_celeb = data.celebrities.Where(or => or.name.Substring(0, 1).ToUpper() == letterr.ToUpper()).ToList();
            List<celebrity> list_celeb_ = new List<celebrity>();
            foreach (var item in list_celeb)
            {
                list_celeb_.Add(item);
            }
            return (list_celeb_);
        }
        // Lay danh sach celeb theo quoc tich
        List<celebrity> Get_celeb_country(int id)
        {
            List<celebrity> list_celeb = data.celebrities.Where(or => or.country_id == id).ToList();
            List<celebrity> list_celeb_ = new List<celebrity>();
            foreach (var item in list_celeb)
            {
                list_celeb_.Add(item);
            }
            return (list_celeb_);
        }
        // Lay danh sach celeb theo nam sinh
        List<celebrity> Get_celeb_year(int min, int max)
        {
            List<celebrity> list_celeb = data.celebrities.ToList();
            List<celebrity> list_celeb_ = new List<celebrity>();
            foreach (var item in list_celeb)
            {
                DateTime birthday = DateTime.Parse((item.birthday).ToString());
                int year = birthday.Year;
                if (year > min && year < max)
                {
                    list_celeb_.Add(item);
                }
            }
            return (list_celeb_);
        }
        // Lay danh sach celeb theo dieu kien
        List<celebrity> Get_list_celeb(List<celebrity> list_celeb, int letter, int coun_id, int year_min, int year_max)
        {
            List<int> list_celeb_remove = new List<int>();
            if (letter > 64 && letter < 91)
            {
                List<celebrity> list_celeb_letter = Get_celeb_letter(letter);
                foreach (var item in list_celeb)
                {
                    if (!list_celeb_letter.Contains(item))
                    {
                        list_celeb_remove.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            if (coun_id > -1)
            {
                List<celebrity> list_celeb_country = Get_celeb_country(coun_id);
                foreach (var item in list_celeb)
                {
                    if (!list_celeb_country.Contains(item))
                    {
                        list_celeb_remove.Add(item.id);
                    }
                    else {; }
                }
            }
            else {; }
            List<celebrity> list_celeb_year = Get_celeb_year(year_min, year_max);
            foreach (var item in list_celeb)
            {
                if (!list_celeb_year.Contains(item))
                {
                    list_celeb_remove.Add(item.id);
                }
                else {; }
            }
            if (list_celeb_remove.Count > 0)
            {
                foreach (int item in list_celeb_remove)
                {
                    list_celeb.RemoveAll(r => r.id == item);
                }
            }
            else {; }
            return (list_celeb);
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
            if (film.Count() <= 0)
            {
                return HttpNotFound();
            }
            else
            {
                Update_view_count(id);
                return View(Getfilm(film.Single()));
            }
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
                userr users = (userr)Session["UserAccount"];
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
                userr users = (userr)Session["UserAccount"];
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
            userr users = (userr)Session["UserAccount"];
            if (Session["UserAccount"] != null)
            {
                ViewBag.film_id = id;
                ViewBag.rate = rate;
                userr use = data.userrs.SingleOrDefault(n => n.id == users.id);
                ViewBag.first_name = use.first_name;
                ViewBag.last_name = use.last_name;
                ViewBag.email = use.email;
            }
            else
            {
                return RedirectToAction("Login_to", "User", new { film_id = id });
            }
            return View(data.films.Where(or => or.id == id).FirstOrDefault());
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
                    userr users = (userr)Session["UserAccount"];
                    int film_id = int.Parse(collection["film"]);
                    revie.created = DateTime.Now;
                    revie.user_id = users.id;
                    revie.film_id = film_id;
                    revie.comment = collection["comment"];
                    revie.title = collection["title"];
                    revie.point = int.Parse(collection["point"]);
                    data.reviews.InsertOnSubmit(revie);
                    data.SubmitChanges();
                    // cap nhat diem cua phim
                    var review = data.reviews.Where(or => or.film_id == film_id).ToList();
                    if (review.Count() > 0)
                    {
                        int sum = 0;
                        foreach (var item in review)
                        {
                            sum += int.Parse((item.point).ToString());
                        }
                        float point = sum / (review.Count());
                        film fil = data.films.Where(or => or.id == film_id).FirstOrDefault();
                        fil.rate = int.Parse((Math.Ceiling(point)).ToString());
                        UpdateModel(fil);
                        data.SubmitChanges();
                    }
                    else {; }
                    return RedirectToAction("Film_single", "Home", new { id = film_id });
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Partial_favorite(int id)
        {
            userr users = (userr)Session["UserAccount"];
            if (users == null)
            {
                return PartialView(-1);
            }
            else
            {
                var fav = from f in data.favorites
                          where f.film_id == id && f.user_id == users.id
                          select f;
                if (fav.Count() > 0)
                {
                    ViewBag.check = 1;
                    return PartialView(id);
                }
                ViewBag.check = 0;
                return PartialView(id);
            }
        }
        public ActionResult Add_favorite(int id)
        {
            if (Session["UserAccount"] != null)
            {
                userr users = (userr)Session["UserAccount"];
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
            userr users = (userr)Session["UserAccount"];
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
        // Trailer cua tung phim hien thi trong trang film_single
        public ActionResult Trailer(int id)
        {
            trailer trailer = data.trailers.Where(or => or.film_id == id).OrderByDescending(a => a.id).FirstOrDefault();
            if (trailer == null )
            {
                return PartialView();
            }
            return PartialView(trailer);
        }
        // Partial view danh sach trailer moi nhat
        public ActionResult Trailer_new() { return PartialView(data.trailers.OrderByDescending(a => a.id).Take(2).ToList()); }
        // Danh sach trailer
        public ActionResult Trailer_list(int? film_id, int? page)
        {
            // phan trang
            int pageSize = 5;
            int pageNum = (page ?? 1);

            List<trailer> trailer_list = new List<trailer>();
            if(film_id != null)
            {
                trailer_list = data.trailers.Where(or => or.film_id == film_id).OrderByDescending(a => a.id).ToList();
            }
            else
            {
                trailer_list = data.trailers.OrderByDescending(a => a.id).ToList();
            }
            if (trailer_list.Count() == 0)
            {
                return RedirectToAction("Trailer_none", "Home");
            }
            else
            {
                return View(trailer_list.ToPagedList(pageNum, pageSize));
            }
        }
        //search
        public ActionResult Search()
        {
            return PartialView();
        }
        public ActionResult Update_view_count(int id)
        {
            film fil = data.films.SingleOrDefault(n => n.id == id);
            if (fil != null)
            {
                fil.view_count += 1;
                UpdateModel(fil);
                data.SubmitChanges();
                return null;
            }
            return HttpNotFound();
        }
        // Danh sach trailer
        public ActionResult Trailer_none()
        {
            return View();
        }
    }
}