using BlazorDDD.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorDDD.Client.Pages
{
    public partial class Index
    {
        [Inject] HttpClient Http { get; set; }
        private List<Product> products { get; set; } = new List<Product>();
        private Product Product = new Product();
        protected override async Task OnInitializedAsync() {
            await GetAll();
        }
        private async Task GetAll() {
            try
            {
                products = await Http.GetFromJsonAsync<List<Product>>("api/Products/GetAll");
            }
            catch (Exception ex) { }
        }

        private async Task Saved() {
            var response = await Http.PostAsJsonAsync<Product>("api/Products/SaveProduct", Product);
            if (response.IsSuccessStatusCode) {
                await GetAll();
            }
        }
    }
}
