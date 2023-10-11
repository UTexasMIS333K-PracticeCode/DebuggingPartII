using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LINQPracticeNETv7.Models
{
    public enum SearchType { GreaterThan, LessThan }
    public class SearchViewModel
    {

        [Display(Name = "Search by Suit")]
        public Suit? SelectedSuit { get; set; }

        [Display(Name = "Search Type:")]
        public SearchType SearchType { get; set; }

        [Display(Name = "Search by Value:")]
        public Int32? SearchValue { get; set; }
    }
}