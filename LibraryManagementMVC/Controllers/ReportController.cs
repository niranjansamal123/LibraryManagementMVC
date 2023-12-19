using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementMVC.Models;
using System.Data.Entity;

namespace LibraryManagementMVC.Controllers
{
    public class ReportController : Controller
    {
        LibraryDbContext dc = new LibraryDbContext();
        public ViewResult DisplayReports()
        {
            var reports = dc.Reports.Include(r => r.Student).Include(r => r.Book).ToList();
            return View(reports);
        }
        public ViewResult DisplayReport(int Id)
        {
            Report report = dc.Reports.Include(R => R.Student).Include(R => R.Book).Where(R => R.Rid == Id).Single();
            return View(report);
        }
        [HttpGet]
        public ViewResult AddReport()
        {
            ViewBag.Sid = new SelectList(dc.Students, "Sid", "Sname");
            ViewBag.Bid = new SelectList(dc.Books, "Bid", "Bname");
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddReport(Report report)
        {
            dc.Reports.Add(report);
            dc.SaveChanges();
            return RedirectToAction("DisplayReports");
        }
        public ViewResult EditReport(int  Id)
        {
            Report report = dc.Reports.Find(Id);
            ViewBag.Sid = new SelectList(dc.Students, "Sid", "Sname", report.Sid);
            ViewBag.Bid = new SelectList(dc.Books, "Bid", "Bname", report.Bid);
            return View(report);
        }
        public RedirectToRouteResult UpdateReport(Report report)
        {
            dc.Entry(report).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayReports");
        }
        public RedirectToRouteResult DeleteReport(int Id)
        {
            Report report = dc.Reports.Find(Id);
            dc.Reports.Remove(report);
            dc.SaveChanges();
            return RedirectToAction("DisplayReports");
        }

    }
}