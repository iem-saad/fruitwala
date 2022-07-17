using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using fruitwala.Models;
using fruitwala.Data;

namespace fruitwala.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("cart") == null || HttpContext.Session.GetString("cart")=="")
            {
                ViewBag.available = false;
                return View();
            }
            string[] arr = HttpContext.Session.GetString("cart").Split(',');
            List<Foods> foods = new List<Foods>();

            if (arr.Length > 0 )
            {
                foreach (string item in arr)
                {
                    foods.Add(_context.Foods.Single(b => b.Id == Int32.Parse(item)));
                }
            }
            ViewBag.available = true;
            ViewBag.foods = foods;
            return View();

        }

        public IActionResult GetDetails()
        {
            return View();
        }
        public IActionResult AddCard()
        {
            return View();
        }

        public ActionResult Buy(string id)
        {
            Foods productModel = new Foods();
            if (HttpContext.Session.GetString("cart") == null || HttpContext.Session.GetString("cart") == "")
            {
                HttpContext.Session.SetString("cart", id);
            }
            else
            {
                string str = HttpContext.Session.GetString("cart");
                str = str + "," + id;
                HttpContext.Session.SetString("cart", str);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            string[] arr = HttpContext.Session.GetString("cart").Split(',');
            string str = "";
            if (arr.Length > 0)
            {
                arr = arr.Where(val => val != id).ToArray();
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i==arr.Length-1)
                {
                    str = str + arr[i];

                }
                else
                    str = str + arr[i] + ",";
            }
            if (str=="")
            {
                HttpContext.Session.SetString("cart", "");
            }
            else
                HttpContext.Session.SetString("cart", str);
            return RedirectToAction("Index");
        }

        //private int isExist(string id)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];
        //    for (int i = 0; i < cart.Count; i++)
        //        if (cart[i].Product.Id.Equals(id))
        //            return i;
        //    return -1;
        //}
    }
}
