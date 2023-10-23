using System.ComponentModel.DataAnnotations;

namespace LINQPracticeNETv7.Models
{
    public class Order
    {
        //constant for sales tax rate
        private const Decimal SALES_TAX_RATE = 0.0875m;

        //properties for direct orders
        [Display(Name = "Customer Name:")]
        public String CustomerName { get; set; }

        [Display(Name = "Sales Tax:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; private set; }

        //Constants for the book prices
        public const Decimal ADULT_PRICE = 11m;
        public const Decimal CHILD_PRICE = 6m;

        //properties shared by both order types
        [Display(Name = "Number of adult tickets:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessage = "Number of adult tickets is required!")]
        [Range(0, 45, ErrorMessage = "The number of adult tickets must be at least zero!")]
        public Int32 NumberOfAdultTickets { get; set; }

        [Display(Name = "Number of child tickets:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessage = "Number of child tickets is required!")]
        [Range(0, 55, ErrorMessage = "The number of child tickets must be at least zero!")]
        public Int32 NumberOfChildTickets { get; set; }

        [Display(Name = "Total Number of Tickets:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Int32 TotalItems { get; set; }


        [Display(Name = "Adult Tickets Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal AdultSubtotal { get; set; }

        [Display(Name = "Child Tickets Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal ChildSubtotal { get;  set; }


        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get;  set; }


        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get;  set; }

        //create method for calculating subtotals
        protected void CalcSubtotals()
        { 
          //calculate the rest of the subtotals
            AdultSubtotal = NumberOfAdultTickets * ADULT_PRICE;
            ChildSubtotal = NumberOfChildTickets * CHILD_PRICE;

            Subtotal = AdultSubtotal + ChildSubtotal;
        }

        public void CalcTotals()
        {
            CalcSubtotals();
            //calculate total items
            TotalItems = NumberOfAdultTickets + NumberOfChildTickets;

            if (TotalItems == 0)
            {
                throw new Exception("You must buy at least one ticket!");
            }

            //calculate sales tax
            SalesTax = Subtotal * SALES_TAX_RATE;

            //calculate total
            Total = Subtotal + SalesTax;
        }

    }
}
