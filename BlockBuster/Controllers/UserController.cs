using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace BlockBuster.Controllers
{
    public class UserController : Controller
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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user use, FormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];
            string repassword = collection["repassword"];
            use.created = DateTime.Now;
            //kiem tra ton tai tai khoan trung email
            user Use_email = data.users.SingleOrDefault(n => n.email == email);

            if (CheckPassword(password) == false)
            {
                ViewBag.Notification = "Password must include a capital letter, a lowercase letter, a character, a number, minimum 8 characters, maximum 16 characters and do not include spaces.";
                return View(use);
            }
            else
            {
                // kiem tra mat khau trung nhau
                if (password != repassword)
                {
                    {
                        ViewBag.Notification = "The password is not the same";
                        return View(use);
                    }
                }
                else
                {
                    //kiem tra ton tai tai khoan trung email
                    if (Use_email != null)
                    { ViewBag.Notification = "Email already exists !!!"; }
                    else
                    {
                        // kiem tra du lieu nhap vao != rong
                        if (ModelState.IsValid)
                        {
                            data.users.InsertOnSubmit(use);
                            data.SubmitChanges();
                            return RedirectToAction("Register_Success", "User");
                        }
                        else {; }
                    }
                }
            }
            return View(use);
        }
        public ActionResult Register_Success()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var email = collection["email"];
            var password = collection["password"];
            user use = data.users.SingleOrDefault(n => n.email == email && n.password == password);
            // kiem tra ton tai tai khoan
            if (use == null)
            { ViewBag.Notification = "Email or password is incorrect !!!"; }
            else
            {
                // set session account
                //Session["UserAccount"] = use;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // partial view tai khoan hien thi tren trang chu sau khi dang nhap thanh cong
        public PartialViewResult Account()
        {
            user users = (user)Session["UserAccount"];
            if (Session["UserAccount"] != null)
            {
                user use = data.users.SingleOrDefault(n => n.id == users.id);
                ViewBag.User_name = use.first_name;
            }
            else
            {
                ViewBag.User_name = null;
            }
            return PartialView();
        }
        // view chi tiet tai khoan nguoi dung
        public ActionResult MyAccount()
        {
            user users = (user)Session["UserAccount"];
            user use = data.users.SingleOrDefault(n => n.id == users.id);
            return View(use);
        }
        // Thay doi thong tin tai khoan khach hang
        [HttpGet]
        public ActionResult Edit_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            if (use == null)
            {
                // bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(use);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_user(user users, FormCollection collection)
        {
            user use = data.users.First(n => n.id == users.id);
            if (ModelState.IsValid)
            {
                use.first_name = collection["name"];
                UpdateModel(use);
                data.SubmitChanges();
                ViewBag.Notification = "Updated your information";
                return RedirectToAction("MyAccount");
            }
            return this.Edit_user(use.id);
        }
        [HttpGet]
        public ActionResult Change_pass()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Change_pass(FormCollection collection)
        {
            if (Session["UserAccount"] == null)
            {
                return RedirectToAction("Login");
            }
            user users = (user)Session["UserAccount"];
            user use = data.users.SingleOrDefault(n => n.id == users.id);
            var pass1 = use.password;
            var pass2 = collection["old_password"];
            var pass3 = collection["new_password"];
            if (Equals(pass1, pass2) == true)
            {
                use.password = pass3;
                UpdateModel(use);
                data.SubmitChanges();
                ViewBag.Notification = 1;
                Session.Remove("UserAccount");
                return this.Change_pass();
            }
            ViewBag.Notification = 0;
            return this.Change_pass();
        }
        [HttpGet]
        public ActionResult Forgot_pass()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Forgot_pass(FormCollection collection)
        {
            var email = collection["email"];
            user use = data.users.SingleOrDefault(n => n.email == email);
            if (use == null)
            {
                ViewBag.Notification = 0;
                return this.Forgot_pass();
            }
            use.password = collection["password"];
            UpdateModel(use);
            data.SubmitChanges();
            ViewBag.Notification = 1;
            Session.Remove("UserAccount");
            return this.Forgot_pass();
        }
        public ActionResult Logout()
        {
            Session.Remove("UserAccount");
            return RedirectToAction("Index", "Bean");
        }
    }
}