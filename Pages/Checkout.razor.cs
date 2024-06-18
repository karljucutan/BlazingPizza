using BlazingPizza.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingPizza.Pages
{
    public partial class Checkout
    {
        private Order Order => OrderState.Order; // private access modifier by default if not explicitly indicated.
        private bool isSubmitting;

        async Task PlaceOrder() // private access modifier by default if not explicitly indicated.
        {
            isSubmitting = true;
            var response = await HttpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}orders", OrderState.Order);
            var newOrderId = await response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo("/myorders");
        }
    }
}