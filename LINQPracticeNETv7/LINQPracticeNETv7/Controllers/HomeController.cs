using LINQPracticeNETv7.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LINQPracticeNETv7.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            //make sure the cards are seeded
            Seeding.SeedAllCards.SeedCards(_context);


            //select * equivalent
            var query = from c in _context.Cards
                        select c;

            //limit the results (AND search)

            //show only one suit
            //=> lambda expression; field and then criteria

            //show values greater than or equal to 10

            //show any card with a rank containing "e"

            //get the face cards and the aces (|| are OR)

            //execute the query
            List<Card> selectedCards = query.ToList();

            //code for the counts
            ViewBag.SelectedCardCount = selectedCards.Count;
            ViewBag.TotalCardCount = _context.Cards.Count();

            //display the selected cards on the view
            //ORDER BY in ANY OTHER PLACE doesn't work
            return View(selectedCards.OrderBy(c => c.Value));
        }
    }
}
