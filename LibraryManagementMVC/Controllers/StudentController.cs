using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementMVC.Models;
using System.Data.Entity;

namespace LibraryManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        LibraryDbContext dc = new LibraryDbContext();
        public ViewResult DisplayStudents()
        {
            var students = dc.Students;
            return View(students);
        }
        public ViewResult DisplayStudent(int Id)
        {
            Student student = dc.Students.Where(S=>S.Sid == Id).FirstOrDefault();
            return View(student);
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student, HttpPostedFileBase selectedImageFile, HttpPostedFileBase selectedVideoFile)
        {
            if(selectedImageFile != null)
            {
                string imagePath = Server.MapPath("~/Uploads/Images/");
                if(!Directory.Exists(imagePath)) 
                {
                    Directory.CreateDirectory(imagePath);
                }
                selectedImageFile.SaveAs(Path.Combine(imagePath + selectedImageFile.FileName));
                BinaryReader br = new BinaryReader(selectedImageFile.InputStream);
                student.Photo = br.ReadBytes(selectedImageFile.ContentLength);
                student.PhotoName = selectedImageFile.FileName;
            }
            if(selectedVideoFile != null)
            {
                string videoPath = Server.MapPath("~/Uploads/Videos/");
                if(!Directory.Exists(videoPath))
                {
                    Directory.CreateDirectory(videoPath);
                }
                selectedVideoFile.SaveAs(Path.Combine(videoPath + selectedVideoFile.FileName)); 
                BinaryReader br = new BinaryReader(selectedVideoFile.InputStream);
                student.Video = br.ReadBytes(selectedVideoFile.ContentLength);
                student.VideoName = selectedVideoFile.FileName;
            }
            dc.Students.Add(student);
            dc.SaveChanges();
            return RedirectToAction("DisplayStudents");
        }

        public ViewResult EditStudent(int Id)
        {
            Student student = dc.Students.Find(Id);
            TempData["Photo"] = student.Photo;
            TempData["PhotoName"] = student.PhotoName;
            TempData["Video"] = student.Video;
            TempData["VideoName"] = student.VideoName;
            return View(student);
        }
        public RedirectToRouteResult UpdateStudent(Student student, HttpPostedFileBase selectedImageFile, HttpPostedFileBase selectedVideoFile)
        {
            if(selectedImageFile != null)
            {
                string imagePath = Server.MapPath("~/Uploads/Images/");
                if(!Directory.Exists (imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                selectedImageFile.SaveAs(Path.Combine(imagePath + selectedImageFile.FileName));
                BinaryReader br = new BinaryReader (selectedImageFile.InputStream);
                student.Photo = br.ReadBytes(selectedImageFile.ContentLength);
                student.PhotoName = selectedImageFile.FileName;
            }
            else if (TempData["Photo"] != null && TempData["PhotoName"] != null)
            {
                student.Photo = (byte[])TempData["Photo"];
                student.PhotoName = (string)TempData["PhotoName"];
            }
            if(selectedVideoFile != null)
            {
                string videoPath = Server.MapPath("~/Uploads/Videos/");
                if(!Directory.Exists (videoPath))
                {
                    Directory.CreateDirectory (videoPath);
                }
                selectedVideoFile.SaveAs(Path.Combine(videoPath + selectedVideoFile.FileName));
                BinaryReader br = new BinaryReader(selectedVideoFile.InputStream);
                student.Video = br.ReadBytes(selectedVideoFile.ContentLength);
                student.VideoName = selectedVideoFile.FileName;

            }
            else if (TempData["Video"] != null && TempData["VideoName"] != null)
            {
                student.Video = (byte[])TempData["Video"];
                student.VideoName = (string)TempData["VideoName"];
            }
            dc.Entry(student).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayStudents");
        }

        public RedirectToRouteResult DeleteStudent(int Id)
        {
            Student student = dc.Students.Find(Id);
            dc.Students.Remove(student);
            dc.SaveChanges();
            return RedirectToAction("DisplayStudents");
        }
    }
}