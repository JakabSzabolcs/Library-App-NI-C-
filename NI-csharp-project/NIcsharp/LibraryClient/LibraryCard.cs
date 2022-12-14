using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace LibraryClient.Pages
{
    public partial class LibraryCard
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        
        public Book[] Books { get; set; }

        public string SearchName = "";

        public IEnumerable<Book> FilteredBooks =>
            Books.Where(b => b.NameOfBorrower == SearchName && b.IsBorrowed).OrderBy(b => b.DateOfReturn);

        protected override async Task OnInitializedAsync()
        {
            Books = await HttpClient.GetFromJsonAsync<Book[]>("book");
            await base.OnInitializedAsync();
        }
    }
}
