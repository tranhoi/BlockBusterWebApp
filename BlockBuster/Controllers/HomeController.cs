using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlockBuster.Controllers
{
    public class HomeController : Controller
    {
        dbBBusterDataContext data = new dbBBusterDataContext(); // tao bien ket noi dat
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // Lay danh sach phim moi nhat
        private List<film> Getnewfilm(int count)
        {
            return data.films.OrderByDescending(a => a.created).Take(count).ToList();
        }
        // Partial view danh sach phim moi nhat
        public ActionResult Newfilm()
        {
            var film = Getnewfilm(8);
            return PartialView(film);
        }
        // Lay danh sach phim le duoc xem nhieu nhat
        private List<film> Getpopularmovie(int count)
        {
            return data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.view_count).Take(count).ToList();
        }
        // Partial view danh sach phim le duoc xem nhieu nhat
        public ActionResult Popular_movie()
        {
            var film = Getpopularmovie(7);
            return PartialView(film);
        }
        // Lay danh sach phim bo duoc xem nhieu nhat
        private List<film> Getpopulardrama(int count)
        {
            return data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.view_count).Take(count).ToList();
        }
        // Partial view danh sach phim bo duoc xem nhieu nhat
        public ActionResult Popular_drama()
        {
            var film = Getpopulardrama(7);
            return PartialView(film);
        }
        // Lay danh sach phim le duoc danh gia cao nhat
        private List<film> Gettopratemovie(int count)
        {
            return data.films.Where(or => or.form_id == 1).OrderByDescending(a => a.rate).Take(count).ToList();
        }
        // Partial view danh sach phim le duoc danh gia cao nhat
        public ActionResult Toprate_movie()
        {
            var film = Gettopratemovie(7);
            return PartialView(film);
        }
        // Lay danh sach phim bo duoc xem nhieu nhat
        private List<film> Gettopratedrama(int count)
        {
            return data.films.Where(or => or.form_id == 2).OrderByDescending(a => a.rate).Take(count).ToList();
        }
        // Partial view danh sach phim bo duoc xem nhieu nhat
        public ActionResult Toprate_drama()
        {
            var film = Gettopratedrama(7);
            return PartialView(film);
        }
        // Lay danh sach ngau nhien 5 nguoi noi tieng
        private List<celebrity> Getcelebrities(int count)
        {
            return data.celebrities.OrderByDescending(a => a.id).Take(count).ToList();
        }
        // Partial view danh sach ngau nhien 5 nguoi noi tieng
        public ActionResult Celebrities()
        {
            var celeb = Getcelebrities(5);
            return PartialView(celeb);
        }
        // Lay danh sach 6 trailer moi nhat
        private List<trailer> Getnewtrailer(int count)
        {
            return data.trailers.OrderByDescending(a => a.id).Take(count).ToList();
        }
        // Partial view danh sach 6 trailer moi nhat
        public ActionResult Newtrailer()
        {
            var trailer = Getnewtrailer(5);
            return PartialView(trailer);
        }
        // The loai cua moi phim
        public ActionResult Category_film(int id)
        {
            var cate = from cat in data.film_categories
                       where cat.film_id == id
                       select cat;
            return PartialView(cate);
        }
        // Nghe nghiep cua tung nguoi noi tieng
        public ActionResult Celeb_job(int id)
        {
            var job = from jo in data.celeb_jobs
                       where jo.celeb_id == id
                       select jo;
            return PartialView(job);
        }
        // Lay so luot nhan xet cua tung phim
        public ActionResult Review_count(int id)
        {
            int? review_count = data.reviews.Count(or => or.film_id == id);
            return PartialView(review_count);
        }
        public ActionResult Film_detail(int id)
        {
            var film = from f in data.films
                       where f.id == id
                       select f;
            return View(film.Single());
        }
    }
}