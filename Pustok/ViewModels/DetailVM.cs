using Pustok.Models;

namespace Pustok.ViewModels
{
    public class DetailVM
    {
        public Book Book { get; set; }

        public List<Book> RelatedBooks { get; set; }
    }
}
