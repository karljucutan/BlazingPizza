using BlazingPizza.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingPizza.Pages
{
    public partial class Checkout
    {
        private Order Order => OrderState.Order;
        private bool isSubmitting;

        private async Task PlaceOrder()
        {
            isSubmitting = true;
            var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "orders", OrderState.Order);
            var newOrderId = await response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo("/");
        }
    }
}