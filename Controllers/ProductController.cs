using Microsoft.AspNetCore.Mvc;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {


            _context = context;


        }
        //cette action crée un nouveau produit
        public IActionResult Create()
        {
            return View();
        }
        //cette action vérifie si le produit existe déja avant de le créer 
        //cette action vérifie si le produit existe déja avant de le créer 
        [HttpPost]
        public IActionResult Create(Product product)

        {
            if (_context.Products.Any(d => d.Id.Equals(product.Id)))
            {
                ViewBag.Erreur = "ce produit existe déja";
                return View(product);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        //cette action affiche la liste des produits de le BD
        public IActionResult Index()
        {

            List<Product> diplomes = _context.Products.OrderBy(d => d.PriceHt).ThenBy(d => d.Name).ToList();
            return View(diplomes);

        }
        //Recupère le produit a modifié
        public IActionResult Edit(string id)
        {
            Product product = _context.Products.FirstOrDefault(d => d.Name.Equals(id));
            if (product == null)

                return NotFound();

            return View(product);

        }
        // modifie le produit
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            Product ProductExistant = _context.Products.FirstOrDefault(d => d.Name.Equals(product.Name));
            if (ProductExistant == null)

            {
                ViewBag.Erreur = "ce produit existe déja";
                return View(product);
            }

            ProductExistant.Name = product.Name;
            ProductExistant.PriceHt = product.PriceHt;


            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        // Action pour supprimer un produit
        public IActionResult Delete(int id)
        {
            // Recherche le produit à supprimer dans la base de données
            var productToDelete = _context.Products.FirstOrDefault(p => p.Id == id);

            // Vérifie si le produit existe
            if (productToDelete == null)
            {
                return NotFound(); // Retourne une réponse NotFound si le produit n'est pas trouvé
            }

            // Supprime le produit de la base de données
            _context.Products.Remove(productToDelete);
            _context.SaveChanges(); // Enregistre les modifications dans la base de données

            return RedirectToAction("Index"); // Redirige vers la liste des produits après la suppression
        }

    }
}
