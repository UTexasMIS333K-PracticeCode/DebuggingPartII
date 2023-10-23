using LINQPracticeNETv7.DAL;
using LINQPracticeNETv7.Models;
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
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
        public IActionResult AllCards()
        {

            //select * equivalent
            var query = from c in _context.Cards
                        select c;

            //execute the query
            List<Card> selectedCards = query.ToList();

            //code for the counts
            ViewBag.TotalCardCount = _context.Cards.Count();

            //display the selected cards on the view
            //ORDER BY in ANY OTHER PLACE doesn't work
            return View(selectedCards.OrderBy(c => c.Value));
        }

        public IActionResult SearchResults(SearchViewModel svm)
        {
            //make sure the cards are seeded
            Seeding.SeedAllCards.SeedCards(_context);

            //select * equivalent
            var query = from c in _context.Cards
                        select c;
                
            //see if user searched by suit
            if (svm.SelectedSuit !=null)
            {
                query = query.Where(c => c.Suit == svm.SelectedSuit);
            }

            //see if the user searched by value
            if (svm.SearchValue != null)
            {
                //update query if user selected greater than
                if (svm.SearchType == SearchType.GreaterThan)
                {
                    query = query.Where(c => c.Value >= svm.SearchValue);
                }
                //update query if user selected less than
                if (svm.SearchType == SearchType.LessThan)
                {
                    query = query.Where(c => c.Value <= svm.SearchValue);
                }
            }

            //execute the query
            List<Card> selectedCards = query.ToList();

            //code for the counts
            ViewBag.SelectedCardCount = selectedCards.Count;
            ViewBag.TotalCardCount = _context.Cards.Count();

            //display the selected cards on the view
            //ORDER BY in ANY OTHER PLACE doesn't work
            return View(selectedCards.OrderBy(c => c.Value));
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //make sure validation rules are followed
            TryValidateModel(order);


            //if any of the validation has failed, Model state 
            //will not be valid.  Send user back to try again.
            if (ModelState.IsValid == false)
            {
                ViewBag.Error = "Please make sure you have entered valid data!";
                return View("CheckoutStandard", order);
            }

            //if no items are ordered, CalcTotals throws an error
            try
            {
                //calc the totals
                order.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(order);
            }

            //display the results
            return View("Receipt", order);
        }
    }
}
