using System.Collections.Generic;
using NewsApp.Entities;

namespace NewsApp.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<NewsDoc> Messages { get; set; }
        public string CurrentGreeting { get; set; }
    }
}