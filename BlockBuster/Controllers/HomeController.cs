using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            filmm.Name = film.name;
            filmm.Image_link = film.image_link;
            filmm.Source = film.source;
            filmm.View_count = double.Parse((film.view_count).ToString());
            filmm.Description = film.description;
            filmm.Created = DateTime.Parse((film.created).ToString());
            filmm.Form_id = int.Parse((film.form_id).ToString());
            filmm.Rate = int.Parse((film.rate).ToString());
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
        // Nghe nghiep cua tung nguoi noi tieng
        public ActionResult Celeb_job(int id) { return PartialView(data.celeb_jobs.Where(or => or.celeb_id == id).OrderByDescending(a => a.id).ToList()); }
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
        // Binh luan moi nhat cua moi phim
        public ActionResult Film_review(int id)
        {
            var rev = data.reviews.Where(or => or.film_id == id).OrderByDescending(a => a.id).FirstOrDefault();
            if (rev == null)
            {
                ViewBag.check = false;
                return PartialView();
            }
            else { return PartialView(rev); }
        }
        // Tat ca binh luan moi nhat cua moi phim
        public ActionResult Film_allreview(int id)
        {
            var rev = data.reviews.Where(or => or.film_id == id).OrderByDescending(a => a.id).ToList();
            if (rev.Count() == 0)
            {
                ViewBag.check = false;
                return PartialView();
            }
            else { return PartialView(rev); }
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
        public ActionResult Celebrity_film(int id)
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
            return PartialView(celeb_film_list_convert);
        }
    }
}