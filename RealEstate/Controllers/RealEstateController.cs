using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class RealEstateController : Controller
    {
        int flag = 1;
        DataContext db = new DataContext();
        // GET: RealEstate
        public ActionResult Index()
        {
            RealEstateEntities1 Entities = new RealEstateEntities1();
            return View(Entities.PropertySearches.ToList());
            
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult List(string address, string propertytype, string pricerange)
        {

            List<PropertySearch> propertylist = new List<PropertySearch>();
            RealEstateEntities1 Entities = new RealEstateEntities1();
            foreach (var item in Entities.PropertySearches.ToList())
            {
                
              if ((item.location == address) && (item.pricerange == pricerange))
                {
                  if(item.type == propertytype)
                  {
                    propertylist.Add(item);
                    flag = 0;
                    continue;
                  }
                  else if(propertytype == "All")
                  {
                    propertylist.Add(item);
                    flag = 0;
                    continue;
                  }

                }
                if ((address == ""))
                {
                    if (item.pricerange == pricerange)
                    {
                        if (item.type == propertytype)
                        {
                            propertylist.Add(item);
                            flag = 0;

                            continue;
                        }
                        else if (propertytype == "All")
                        {
                            propertylist.Add(item);
                            flag = 0;
                            continue;
                        }
                    }
                }                
              
            }
            if (flag == 1)
            {
                Response.Write("<script>alert('No Results found .')</script>");
                return RedirectToAction("Index");
            }
            else
                return View(propertylist);
        }

        public ActionResult Description(int? id)
        {
            RealEstateEntities1 Entities = new RealEstateEntities1();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertySearch record = Entities.PropertySearches.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }
        public ActionResult Enquiry()
        {
            return View();
        }
        public ActionResult Save(EnquiryModel obj)
        {
            if (ModelState.IsValid)
            {
                db.enquiry.Add(obj);
                db.SaveChanges();
                Response.Write("<script>alert('Your query has been successfully submitted.Thank you for your interest in M&N Groups')</script>");
                return RedirectToAction("Index");
            }
            else
                return View("Enquiry", obj);
        }

    }
}