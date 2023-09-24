using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;

namespace DaNangShop_NGUYEN_QUOC_BAO_AN.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            var prducts = GetStudentsList();
            return View(prducts);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = GetProductById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                InsertNewStudent(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = GetProductById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HomeController home = new HomeController();
                    home.UpdateProducts(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = GetProductById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public static IEnumerable<Product> GetStudentsList()
        {
            using var context = new CodeFirstDbContext();
            var listStudent = context.Product.ToList();
            return listStudent;
        }
        public static void InsertNewStudent(Product productInsert)
        {
            try
            {
                using var context = new CodeFirstDbContext();
                context.Product.Add(productInsert);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Product GetProductById(int id)
        {
            Product student;
            try
            {
                var context = new CodeFirstDbContext();
                student = context.Product.SingleOrDefault(x => x.ProductId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return student;
        }
        public void UpdateProducts(Product product)
        {
            try
            {
                Product student = GetProductById(product.ProductId);
                if (student != null)
                {
                    using var context = new CodeFirstDbContext();
                    context.Product.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Student does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteStudent(int idStudentDelete)
        {
            try
            {
                Product student = GetProductById(idStudentDelete);
                if (student != null)
                {
                    using var context = new CodeFirstDbContext();
                    context.Product.Remove(student);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Student does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
