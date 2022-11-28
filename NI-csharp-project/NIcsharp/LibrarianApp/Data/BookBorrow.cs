using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace LibrarianApp.Data
{
    public partial class BookBorrow : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Book Book { get; set; }


        [Parameter]
        public string BookID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await HttpClient.GetFromJsonAsync<Book>($"book/{BookID}");
            Book.NameOfBorrower = String.Empty;
            Book.DateOfReturn = DateTime.Now;
            await base.OnInitializedAsync();
        }

        private async Task SubmitForm()
        {
            Book.IsBorrowed = true;
            Book.DateOfBorrowing = DateTime.Now;
            await HttpClient.PutAsJsonAsync($"book/{BookID}", Book);
            NavigationManager.NavigateTo($"books/{BookID}");
        }
    }
}
