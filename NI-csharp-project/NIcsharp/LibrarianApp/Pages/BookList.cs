using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace LibrarianApp.Pages
{
    public partial class BookList : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Book[] Books { get; set; }

        public string SearchText = "";

        public IEnumerable<Book> FilteredBooks =>
            Books.Where(b => b.Title.ToLower().Contains(SearchText.ToLower()) || b.Author.ToLower().Contains(SearchText.ToLower()));

        protected override async Task OnInitializedAsync()
        {
            Books = await HttpClient.GetFromJsonAsync<Book[]>("book");
            await base.OnInitializedAsync();
        }

        private async Task UpdateRentalStatus(long BookID, Book Book)
        {
            Book.IsBorrowed = false;
            await HttpClient.PutAsJsonAsync($"book/{BookID}", Book);
        }
    }
}
