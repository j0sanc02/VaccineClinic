using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.Models;
using UniversityofLouisvilleVaccine.DataContexts;
using System.IO;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class GrantsController : Controller
    {
        private GrantsDBContext db = new GrantsDBContext();

        // GET: /Grants/
        public ActionResult Index()
        {
            return View(db.Grant.ToList());
        }

        // GET: /Grants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);
            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // GET: /Grants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Grants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,docType,fileName")]Grants grants, HttpPostedFileBase upload)
        {
                                            
            if (ModelState.IsValid)
            {
                //var filename = Path.GetFileName(grants.fileType.FileName);
                //string documentpath = "~/FileUploads/" + filename;
                //var path = Path.Combine(Server.MapPath("~/FileUploads/"), filename);
                //grants.fileType.SaveAs(path);  

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload != null && upload.ContentLength > 0)
                    {

                        var document = new FilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };

                        grants.FilePaths = new List<FilePath>();
                        grants.FilePaths.Add(document);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Documents"), document.FileName));
                    }



                    //var document = new UniversityofLouisvilleVaccine.Models.File
                    //{
                    //      FileName = System.IO.Path.GetFileName(upload.FileName),
                    //      FileType = FileType.Document,
                    //      ContentType = upload.ContentType
                    //};

                    //using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    //{
                    //    document.Content = reader.ReadBytes(upload.ContentLength);
                    //}

                    //grants.Files = new List<UniversityofLouisvilleVaccine.Models.File> { document };

                }
                
                               
                db.Grant.Add(grants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grants);
        }

        // GET: /Grants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);
            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // POST: /Grants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,docType,fileName")] Grants grants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grants);
        }

        // GET: /Grants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);
            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // POST: /Grants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grants grants = db.Grant.Find(id);
            db.Grant.Remove(grants);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public FileResult Download(string fileNameWithExtention)
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + "FileUploads/";
        //    string fileName = fileNameWithExtention;
        //    return File(path + fileName, "text/plain", "test.txt");

        //}

    }
}
